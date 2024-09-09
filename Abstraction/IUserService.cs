using HsptMS.Data.Models;

namespace HsptMS.Abstraction
{
    public interface IUserService
    {
		void Register(User user);
		User? GetUser(string emailOrUsername, string password);
	}
}
