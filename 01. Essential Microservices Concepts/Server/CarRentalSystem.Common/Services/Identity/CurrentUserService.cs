namespace CarRentalSystem.Common.Services.Identity
{
    using System;
    using System.Security.Claims;
    using CarRentalSystem.Common.Infrastructure;
    using Microsoft.AspNetCore.Http;

    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            this.UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }

        public bool IsAdministrator => user.IsAdministrator();
    }
}
