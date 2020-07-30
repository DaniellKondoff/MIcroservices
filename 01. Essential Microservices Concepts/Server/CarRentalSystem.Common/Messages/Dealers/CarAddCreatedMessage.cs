namespace CarRentalSystem.Common.Messages.Dealers
{
    public class CarAddCreatedMessage
    {
        public int CarAddId { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }
    }
}
