using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planes.Models
{
    public class Flight
    {

        public int ID { get; set; }

        [Display(Name = "Kod lotu")]
        [Required]
        public string Code { get; set; }

        [Display(Name = "Miejsce staru")]
        [MaxLength(40)]
        [Required]
        public string Start { get; set; }

        [Display(Name = "Data startu" )]
        [Required]
        public DateTime Date1 { get; set; }

        [Display(Name = "Godzina startu")]
        [Required]
        public string Time1 { get; set; }

        [Display(Name = "Miejsce lądowania")]
        [Required]
        public string Meta { get; set; }

        [Display(Name = "Data lądowania")]
        [Required]
        public DateTime Date2 { get; set; }

        [Display(Name = "Godzina lądowania")]
        [Required]
        public string Time2 { get; set; }

        [Display(Name = "Samolot")]
        public virtual Plane Plane { get; set; }

    }


}