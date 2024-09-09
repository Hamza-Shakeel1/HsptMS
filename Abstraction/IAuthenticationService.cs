using HsptMS.Data.Models;
using HsptMS.Data.ViewModels;
using System.Threading.Tasks;

public interface IAuthenticationService
{
    Task<bool> LoginAsync(LoginVM model);
    Task LogOutAsync();
    void Signup(User user);
}
