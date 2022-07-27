using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Models
{
    public class BandViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Band Name")]
        [RegularExpression("^[A-Za-z0-9 _]*[A-Za-z0-9][A-Za-z0-9 _]*$")]
        [Remote(action: "VerifyBandName", controller: "Band")]
        public string BandName { get; set; }
    }
}
