using System.Collections.Generic;

namespace CarRentalSystem.Schedule.Data.Models
{
    public class Driver
    {
        public int Id { get; set; }

        public string Licence { get; set; }

        public int YearsOfExperience { get; set; }

        public string UserId { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
