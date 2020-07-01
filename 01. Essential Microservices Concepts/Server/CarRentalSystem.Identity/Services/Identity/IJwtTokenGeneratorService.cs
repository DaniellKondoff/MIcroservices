namespace CarRentalSystem.Identity.Services.Identity
{
    using Data.Models;
    using System.Collections.Generic;

    public interface IJwtTokenGeneratorService
    {
        string GenerateToken(User user, IEnumerable<string> roles = null);
    }
}
