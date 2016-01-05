﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planes.Models
{
    public class Plane
    {

        public int ID {get; set; }

        [Display(Name = "Nazwa")]
        [MaxLength(60)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Typ")]
        [MaxLength(80)]
        [Required]
        public string Type { get; set; }

        [Display(Name = "Przelot")]
        public virtual Flight Flight { get; set; }
    }


}