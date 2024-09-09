using HsptMS.Abstraction;
using HsptMS.Data.Models;
using System.Security.Claims;

namespace HsptMS.Servises
{
	public class ContextService: IContextService
	{
		private readonly IHttpContextAccessor _contextAccessor;
        public string GetUserId()
        {
			 var userId = _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId ?? string.Empty;
        }

		public string GetUserName()
		{
            var userName = _contextAccessor.HttpContext?.User?.Identity?.Name;
            return userName ?? string.Empty;
        }

		public bool IsUserLoggedIn()
		{
			return _contextAccessor?
				.HttpContext?
				.User?
				.Identity?
				.IsAuthenticated ?? true;
		}
	}
}
