namespace CarRentalSystem.Admin.Models.Dealers
{
    public class DealersDetailsOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public int TotalCarAds { get; private set; }
    }
}
