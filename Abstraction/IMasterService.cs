using Microsoft.AspNetCore.Mvc.Rendering;

namespace HsptMS.Abstraction
{
    public interface IMasterService
    {
        List<SelectListItem> GetDoctors();
       
    }
}
