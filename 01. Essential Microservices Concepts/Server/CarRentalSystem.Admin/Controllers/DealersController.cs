using AutoMapper;
using CarRentalSystem.Admin.Models.Dealers;
using CarRentalSystem.Admin.Services.Dealers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRentalSystem.Admin.Controllers
{
    public class DealersController : AdministrationController
    {
        private readonly IDealersService dealers;
        private readonly IMapper mapper;

        public DealersController(IDealersService dealers, IMapper mapper)
        {
            this.dealers = dealers;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
            => View(await this.dealers.All());

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = this.mapper.Map<EditDealerFormModel>(await this.dealers.Details(id));
            return View(model);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(int id, EditDealerFormModel model)
        {
           return await this.Handle(
                async () => await this.dealers.Edit(id, this.mapper.Map<DealerInputModel>(model)),
                success: this.RedirectToAction(nameof(Index)),
                failure: View(model));
        }
    }
}
