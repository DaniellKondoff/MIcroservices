using CarRentalSystem.Common.Models;

namespace CarRentalSystem.Admin.Models.Dealers
{
    public class DealerInputModel : IMapFrom<EditDealerFormModel>
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
