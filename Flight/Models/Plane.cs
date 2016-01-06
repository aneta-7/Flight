using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Planes.Models
{
    public class Plane
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID {get; set; }

        [Display(Name = "Nazwa")]
        [MaxLength(60)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Typ")]
        [MaxLength(80)]
        [Required]
        public string Type { get; set; }

    }


}