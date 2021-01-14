using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models.Cars
{
    public class Automobile
    {
        [Key]
        public int id { get; set; }
        public string Grad { get; set; }
        public int? Avaible { get; set; }
        public DateTime? Updated { get; set; }
    }
}
