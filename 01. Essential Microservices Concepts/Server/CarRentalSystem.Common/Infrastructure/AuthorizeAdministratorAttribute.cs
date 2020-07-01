using Microsoft.AspNetCore.Authorization;

namespace CarRentalSystem.Common.Infrastructure
{
    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute()
        {
            this.Roles = Constants.AdministratorRoleName;
        }
    }
}
