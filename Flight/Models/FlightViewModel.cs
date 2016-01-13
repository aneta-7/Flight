using Flights.Validations;
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
        [Required(ErrorMessage = "Kod jest wymagany")]
        public string Code { get; set; }

        [Display(Name = "Miejsce staru")]
        [MaxLength(40)]
        [Required(ErrorMessage = "Miejsce wylotu jest wymagane")]
        public string Start { get; set; }

        [Display(Name = "Data startu")]
        [Required(ErrorMessage = "Data wylotu jest wymagana")]
        //   [CustomValidation(typeof(DateTimeCheck), "dateValidation")]
        [DataType(DataType.Date)]
      //  [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "#232")]
        public Nullable<DateTime> Date1 { get; set; }

        [Display(Name = "Godzina startu")]
        [Required(ErrorMessage = "Godzina startu jest wymagana")]
        [DateTimeCheck]
        public string Time1 { get; set; }

        [Display(Name = "Miejsce lądowania")]
        [Required(ErrorMessage = "Miejsce przylotu jest wymagane")]
        public string Meta { get; set; }

        [Display(Name = "Data lądowania")]
        [Required(ErrorMessage = "Data przylotu jest wymagana")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> Date2 { get; set; }

        [Display(Name = "Godzina lądowania")]
        [Required(ErrorMessage = "Godzina przylotu jest wymagana")]
        [DateTimeCheck]
        public string Time2 { get; set; }

        [Display(Name = "Samolot")]  
        public List<Plane> Planes { get; set; }

        public int SelectedPlaneID { get; set; }


      
    }
}