using System;
using System.ComponentModel.DataAnnotations;

namespace webapp.Models
{
    public class Temperature
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public decimal Temp { get; set; }

        // public string Genre { get; set; }
        // public decimal Price { get; set; }
    }
}