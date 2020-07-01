using CarRentalSystem.Admin.Models.Dealers;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalSystem.Admin.Services.Dealers
{
    public interface IDealersService
    {
        [Get("/dealers")]
        Task<IEnumerable<DealersDetailsOutputModel>> All();

        [Get("/dealers/{id}")]
        Task<DealersDetailsOutputModel> Details(int id);

        [Put("dealers/{id}")]
        Task Edit(int id, DealerInputModel model);
    }
}
