using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models.Flights
{
    public class SagaFlightReservation
    {
        [Key]
        public Guid Guid { get; set; }
        public Guid UserId { get; set; }
        public string Grad { get; set; }
        public double Cena { get; set; }
    }
}
