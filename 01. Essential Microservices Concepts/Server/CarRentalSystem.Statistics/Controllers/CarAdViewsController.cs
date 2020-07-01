using CarRentalSystem.Common.Controllers;
using CarRentalSystem.Statistics.Models;
using CarRentalSystem.Statistics.Services.CarAddViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalSystem.Statistics.Controllers
{
    public class CarAdViewsController : ApiController
    {
        private readonly ICarAdViewService carAdViews;

        public CarAdViewsController(ICarAdViewService carAdViews)
            => this.carAdViews = carAdViews;

        [HttpGet]
        [Route(Id)]
        public async Task<int> TotalViews(int id)
            => await this.carAdViews.GetTotalViews(id);

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<CarAdViewOutputModel>> TotalViews([FromQuery] IEnumerable<int> ids)
            => await this.carAdViews.GetTotalViews(ids);
    }
}
