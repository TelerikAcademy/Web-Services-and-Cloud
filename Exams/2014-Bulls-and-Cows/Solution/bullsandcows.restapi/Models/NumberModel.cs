using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BullsAndCows.RestApi.Models
{
    public class NumberModel
    {
        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string Number { get; set; }
    }
}