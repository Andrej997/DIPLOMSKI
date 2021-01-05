using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models.Payments
{
    public class Payment
    {
        [Key]
        public int id { get; set; }

        public Guid UserId { get; set; }

        public double? Avaible { get; set; }

        public DateTime? Updated { get; set; }
    }
}
