using CarRentalSystem.Common.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Admin.Models.Dealers
{
    public class EditDealerFormModel : IMapFrom<DealersDetailsOutputModel>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
