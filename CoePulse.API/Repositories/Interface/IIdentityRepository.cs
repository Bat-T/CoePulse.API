using Microsoft.AspNetCore.Identity;

namespace CoePulse.API.Repositories.Interface
{
    public interface IIdentityRepository
    {
        public string CreateJwtToken(IdentityUser user,List<string> roles);
    }
}
