using Microsoft.AspNetCore.Http;
using System.Security.Claims;
namespace Koton.Shared
{
    public class SharedIdentity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SharedIdentity(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Email => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
        public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Sid);
        
        public bool IsInRole(string role) => _httpContextAccessor.HttpContext?.User?.IsInRole(role) ?? false;
        
    }
}
