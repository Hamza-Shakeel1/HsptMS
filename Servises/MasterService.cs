using HsptMS.Abstraction;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HsptMS.Servises
{
    public class MasterService : IMasterService
    {
        private readonly IDoctorServise _doctorService;

        public MasterService(IDoctorServise doctorService)
        {
            _doctorService = doctorService;
        }
        public List<SelectListItem> GetDoctors()
        {
            return _doctorService.GetAllDoctorss()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();
            
        }
       
    }
}
