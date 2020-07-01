using AutoMapper;
using CarRentalSystem.Common.Controllers;
using CarRentalSystem.Gateway.Models.CarAds;
using CarRentalSystem.Gateway.Services.CarAds;
using CarRentalSystem.Gateway.Services.CarAdViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Gateway.Controllers
{
    public class CarAdsController : ApiController
    {
        private readonly ICarAdService carAds;
        private readonly ICarAdViewService carAdViews;
        private readonly IMapper mapper;

        public CarAdsController(ICarAdService carAds, ICarAdViewService carAdViews, IMapper mapper)
        {
            this.carAds = carAds;
            this.carAdViews = carAdViews;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [Route(nameof(Mine))]
        public async Task<IEnumerable<MineCarAdOutputModel>> Mine()
        {
            var mineCarAds = await this.carAds.Mine();

            var mineCarAdIds = mineCarAds.CarAds.Select(c => c.Id);

            var mineCarAdViews = await this
                .carAdViews
                .TotalViews(mineCarAdIds);

            var outputMineCarAds =
                this.mapper
                    .Map<
                        IEnumerable<CarAdOutputModel>,
                        IEnumerable<MineCarAdOutputModel>>(mineCarAds.CarAds)
                    .ToDictionary(c => c.Id);

            var mineCarAdViewsDictionary = mineCarAdViews
                .ToDictionary(v => v.CarAdId, v => v.TotalViews);

            foreach (var (carAdId, totalViews) in mineCarAdViewsDictionary)
            {
                outputMineCarAds[carAdId].TotalViews = totalViews;
            }

            return outputMineCarAds.Values;
        }
    }
}
