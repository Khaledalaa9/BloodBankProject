using BloodBankProject.BLL.ViewModels.RequestViewModels;
using BloodBankProject.DAL.Data.Models;
using BloodBankProject.DAL.Repositories.BloodStockRepository;
using BloodBankProject.DAL.Repositories.HospitalRepository;
using BloodBankProject.DAL.Repositories.PendingRequestRepository;
using BloodBankProject.DAL.Repositories.RequestRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.Managers.RequestManager
{
    public class RequestManager : IRequestManager
    {
        private readonly IRequestRepo _requestRepo;
        private readonly IBloodStockRepo _bloodStockRepo;
        private readonly IPendingRequestRepo _pendingRequest;

        public RequestManager(IRequestRepo requestRepo,IBloodStockRepo bloodStockRepo,IPendingRequestRepo pendingRequest)
        {
            _requestRepo = requestRepo;
            _bloodStockRepo = bloodStockRepo;
            _pendingRequest = pendingRequest;
           
        }

        public void Add(RequestAddVM requestAddVM)
        {
            Request request = new Request
            {
                City = requestAddVM.City,
                BloodType = requestAddVM.BloodType,
                QuantityRequested = requestAddVM.QuantityRequested,
                PatientStatus = requestAddVM.PatientStatus,
                HospitalId = requestAddVM.HospitalId,
                BloodStockId =null
                            
            };
           
            _requestRepo.Add(request);
        }

        public IEnumerable<RequestReadVM> GetAll()
        {
            var RequestModelList = _requestRepo.GetAll();

            var RequestReadVM = RequestModelList.Select(a => new RequestReadVM
            {
                BloodType = a.BloodType,
                PatientStatus = a.PatientStatus,
                City = a.City,
                QuantityRequested = a.QuantityRequested,
                hospitalReadVM = new ViewModels.HospitalViewModels.HospitalReadVM
                {
                    City = a.Hospital.City,
                    Name = a.Hospital.Name,
                }
            }).ToList();

            return RequestReadVM;
        }

        public IEnumerable<BloodStock> GetAvailableBlood(RequestAddVM requestAddVM)
        {

            var pendingRequests = _pendingRequest.GetPendingRequests().ToList();

            var newPendingRequest = new PendingRequest
            {
                BloodType = requestAddVM.BloodType,
                City = requestAddVM.City,
                PatientStatus = requestAddVM.PatientStatus,
                QuantityRequested = requestAddVM.QuantityRequested,
                HospitalId = requestAddVM.HospitalId
            };

            pendingRequests.Add(newPendingRequest);

            int totalRequestsFromAllHospitals = pendingRequests.Count;

            if (totalRequestsFromAllHospitals < 10)
            {
                Console.WriteLine("Request is pending, waiting for more requests.");
                _pendingRequest.SavePendingRequest(newPendingRequest);
                return Enumerable.Empty<BloodStock>();
            }


            var orderedRequests = pendingRequests.OrderBy(pr =>
                      pr.PatientStatus == "Immediate" ? 1 :
                      pr.PatientStatus == "Urgent" ? 2 :
                      3).ToList();

            foreach (var pendingRequest in orderedRequests)
            {
                var availableBlood = _requestRepo.GetAvailableBlood(pendingRequest.BloodType, pendingRequest.City);

                availableBlood = availableBlood.OrderBy(b => CalculateDistance(b.BloodBankCity, pendingRequest.City));

                var selectedBloodStocks = availableBlood.Take(pendingRequest.QuantityRequested).ToList();

                DeductBloodStock(selectedBloodStocks, pendingRequest.QuantityRequested, pendingRequest.BloodType, pendingRequest.City);
            }
            _requestRepo.ClearRequests();
            _pendingRequest.ClearPendingRequests();

            return Enumerable.Empty<BloodStock>();
        }
        private void DeductBloodStock(List<BloodStock> selectedBloodStocks, int quantityRequested, string requestedBloodType, string requestedCity)
        {
            int remainingQuantity = quantityRequested;
            BloodStock updatedBloodStock = null;
            foreach (var bloodStock in selectedBloodStocks)
            {
                if (bloodStock.BloodType != requestedBloodType || bloodStock.BloodBankCity != requestedCity)
                {
                    continue; 
                }

                if (bloodStock.AvailableQuantity < remainingQuantity)
                {
                    break;
                }

                bloodStock.AvailableQuantity -= remainingQuantity;
                remainingQuantity = 0; 
                updatedBloodStock = bloodStock;
                break;
            }
            if (updatedBloodStock != null)
            {
                _bloodStockRepo.Update(updatedBloodStock);
            }

        }

        //Haversine Formula
        private double CalculateDistance(string city1, string city2)
        {
            
            var cityCoordinates = new Dictionary<string, (double Latitude, double Longitude)>
            {
                  #region Location coordinates
		          { "Cairo", (30.0444, 31.2357) },       // القاهرة
                  { "Alexandria", (31.2156, 29.9553) },  // الإسكندرية
                  { "Giza", (30.0131, 31.2089) },        // الجيزة
                  { "Suez", (29.9668, 32.5498) },        // السويس
                  { "Port Said", (31.2653, 32.3019) },   // بورسعيد
                  { "Ismailia", (30.6043, 32.2723) },    // الإسماعيلية
                  { "Aswan", (24.0889, 32.8998) },       // أسوان
                  { "Luxor", (25.6872, 32.6396) },       // الأقصر
                  { "Assiut", (27.1801, 31.1837) },      // أسيوط
                  { "Fayoum", (29.3082, 30.8429) },      // الفيوم
                  { "Sharm El Sheikh", (27.9158, 34.3299) },  // شرم الشيخ
                  { "Hurghada", (27.2579, 33.8116) },    // الغردقة
                  { "Mansoura", (31.0379, 31.3815) },    // المنصورة
                  { "Zagazig", (30.5877, 31.5020) },     // الزقازيق
                  { "Tanta", (30.7865, 31.0004) },       // طنطا
                  { "Beni Suef", (29.0661, 31.0994) },   // بني سويف
                  { "Minya", (28.1099, 30.7503) },       // المنيا
                  { "Sohag", (26.5596, 31.6953) },       // سوهاج
                  { "Qena", (26.1551, 32.7160) },        // قنا
                  { "Damietta", (31.4165, 31.8133) },    // دمياط
                  { "Matrouh", (31.3523, 27.2373) },     // مرسى مطروح
                  { "Damanhour", (31.0364, 30.4682) },   // دمنهور
                  { "Kafr El Sheikh", (31.1113, 30.9396) }, // كفر الشيخ
                  { "El Arish", (31.1321, 33.8036) },    // العريش
                  { "Helwan", (29.8414, 31.3002) },      // حلوان
                  { "Al Minya", (28.1099, 30.7503) }     // المنيا 
	               #endregion
            };

            if (!cityCoordinates.ContainsKey(city1) || !cityCoordinates.ContainsKey(city2))
            {
                throw new InvalidOperationException("One or both cities are not found.");
            }

            var coord1 = cityCoordinates[city1];
            var coord2 = cityCoordinates[city2];

            double R = 6371; 
            double dLat = (coord2.Latitude - coord1.Latitude) * (Math.PI / 180);
            double dLon = (coord2.Longitude - coord1.Longitude) * (Math.PI / 180);
            double lat1 = coord1.Latitude * (Math.PI / 180);
            double lat2 = coord2.Latitude * (Math.PI / 180);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = R * c;

            return distance;
        }
    }
}
