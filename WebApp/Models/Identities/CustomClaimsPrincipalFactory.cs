using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using WebApp.Helpers.Repositories.IdentityRepos;

namespace WebApp.Models.Identities
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser>
    {
        private readonly ProfileIdentityRepository _profileIdentityRepository;

        public CustomClaimsPrincipalFactory(UserManager<IdentityUser> userManager, IOptions<IdentityOptions> optionsAccessor, ProfileIdentityRepository profileIdentityRepository) : base(userManager, optionsAccessor)
        {
            _profileIdentityRepository = profileIdentityRepository;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);

            var userProfileEntity = await _profileIdentityRepository.GetAsync(x => x.UserId == user.Id);

            claimsIdentity.AddClaim(new Claim("DisplayName", $"{userProfileEntity.FirstName} {userProfileEntity.LastName}"));

            var roles = await UserManager.GetRolesAsync(user);
            claimsIdentity.AddClaims(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            return claimsIdentity;
        }
    }
}
