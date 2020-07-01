using CarRentalSystem.Admin.Models.Identity;
using Refit;
using System.Threading.Tasks;

namespace CarRentalSystem.Admin.Services.Identity
{
    public interface IIdentityService
    {
        [Post("/Identity/Login")]
        Task<UserOutputModel> Login([Body] UserInputModel loginInput);
    }
}
