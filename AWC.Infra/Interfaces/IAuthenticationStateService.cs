using AWC.Infra.Entities;
using AWC.Infra.Models;

namespace AWC.Infra.Interfaces
{
    public interface IAuthenticationStateService
    {
        bool IsAuthenticated { get; }
        Guid? SessionId { get; }
        public UserEntity? User { get; set; }
        Task<CookieModel> CreateJwtSessionToken(string username, string password, bool remember);
    }
}
