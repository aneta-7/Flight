using Planes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Flights.Models
{
    public class FlightViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Kod lotu")]
        public string Code { get; set; }

        [Display(Name = "Miejsce staru")]
        [MaxLength(40)]
        public string Start { get; set; }

        [Display(Name = "Data startu")]
        public DateTime Date1 { get; set; }

        [Display(Name = "Godzina startu")]
        public string Time1 { get; set; }

        [Display(Name = "Miejsce lądowania")]
        public string Meta { get; set; }

        [Display(Name = "Data lądowania")]
        public DateTime Date2 { get; set; }

        [Display(Name = "Godzina lądowania")]
        public string Time2 { get; set; }

        [Display(Name = "Samolot")]
        public List<Plane> Planes { get; set; }

        public int SelectedPlaneID { get; set; }
    }
}