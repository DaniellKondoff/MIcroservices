using CarRentalSystem.Gateway.Models.CarAdViews;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalSystem.Gateway.Services.CarAdViews
{
    public interface ICarAdViewService
    {
        [Get("/CarAdViews")]
        Task<IEnumerable<CarAdViewOutputModel>> TotalViews([Query(CollectionFormat.Multi)] IEnumerable<int> ids);
    }
}
