using System.Collections.Generic;

namespace CarRentalSystem.Gateway.Models.CarAds
{
    public class MineCarAdsOutputModel
    {
        public IEnumerable<CarAdOutputModel> CarAds { get; set; }
    }
}
