﻿namespace CarRentalSystem.Dealers.Models.Dealers
{
    using System.ComponentModel.DataAnnotations;
    using static Common.Data.DataConstants.Common;
    using static Data.DataConstants.Dealer;
    public class CreateDealerInputModel
    {
        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(MinPhoneNumberLength)]
        [MaxLength(MaxPhoneNumberLength)]
        [RegularExpression(PhoneNumberRegularExpression)]
        public string PhoneNumber { get; set; }
    }
}
