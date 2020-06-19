using System.Collections.Generic;

namespace CarRentalSystem.Schedule.Data.Models
{
    public class RentedCar
    {
        public int Id { get; set; }

        public string DisplayInfo { get; set; }

        public int CarAdId { get; set; }

        public int Kilometers { get; set; }

        public bool HasInsurance { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
