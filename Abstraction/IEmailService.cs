using HsptMS.Data.DTO;
using System.Threading.Tasks;

namespace HsptMS.Abstract
{
    public interface IEmailService
    {
        void SendEmail(SendEmailDto emailDto);
    }
}
