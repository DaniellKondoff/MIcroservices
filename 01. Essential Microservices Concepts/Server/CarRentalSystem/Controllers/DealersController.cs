﻿namespace CarRentalSystem.Dealers.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarRentalSystem.Common.Controllers;
    using CarRentalSystem.Common.Infrastructure;
    using CarRentalSystem.Common.Services;
    using CarRentalSystem.Common.Services.Identity;
    using CarRentalSystem.Dealers.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Dealers;
    using Services.Dealers;

    public class DealersController : ApiController
    {
        private readonly IDealerService dealers;
        private readonly ICurrentUserService currentUser;

        public DealersController(
            IDealerService dealers, 
            ICurrentUserService currentUser)
        {
            this.dealers = dealers;
            this.currentUser = currentUser;
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<DealerDetailsOutputModel>> Details(int id)
            => await this.dealers.GetDetails(id);

        [HttpGet]
        [Authorize]
        [Route("Id")]
        public async Task<ActionResult<int>> GetDealerId()
        {
            var userId = this.currentUser.UserId;

            var userIsDealer = await this.dealers.IsDealer(userId);
            if (!userIsDealer)
            {
                return BadRequest("This user is not a dealer.");
            }

            return await this.dealers.GetIdByUser(userId);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(CreateDealerInputModel input)
        {
            var dealer = new Dealer
            {
                Name = input.Name,
                PhoneNumber = input.PhoneNumber,
                UserId = this.currentUser.UserId
            };

            await this.dealers.Save(dealer);

            return Ok();
        }

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(int id, EditDealerInputModel input)
        {
            var dealer = this.currentUser.IsAdministrator
                ? await this.dealers.FindById(id)
                : await this.dealers.FindByUser(this.currentUser.UserId);

            if (id != dealer.Id)
            {
                return BadRequest(Result.Failure("You cannot edit this dealer."));
            }

            dealer.Name = input.Name;
            dealer.PhoneNumber = input.PhoneNumber;

            await this.dealers.Save(dealer);

            return Ok();
        }

        [HttpGet]
        [AuthorizeAdministrator]
        public async Task<IEnumerable<DealerDetailsOutputModel>> GetAll()
        {
            return await this.dealers.GetAll();
        }
    }
}
