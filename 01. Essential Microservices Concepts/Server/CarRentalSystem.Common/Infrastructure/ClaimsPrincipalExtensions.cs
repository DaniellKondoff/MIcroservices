using System.Security.Claims;

namespace CarRentalSystem.Common.Infrastructure
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdministrator(this ClaimsPrincipal user)
            => user.IsInRole(Constants.AdministratorRoleName);
    }
}
