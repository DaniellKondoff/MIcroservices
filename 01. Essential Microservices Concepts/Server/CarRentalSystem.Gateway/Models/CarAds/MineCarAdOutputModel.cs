using CarRentalSystem.Common.Models;

namespace CarRentalSystem.Gateway.Models.CarAds
{
    public class MineCarAdOutputModel : CarAdOutputModel, IMapFrom<CarAdOutputModel>
    {
        public int TotalViews { get; set; }
    }
}
