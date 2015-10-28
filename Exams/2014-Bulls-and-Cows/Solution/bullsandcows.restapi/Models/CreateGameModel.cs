using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BullsAndCows.RestApi.Models
{
    public class CreateGameModel
    {
        [Required]
        [StringLength(40, MinimumLength=6)]
        public string Name { get; set; }

        [Required]
        [StringLength(4, MinimumLength=4)]
        public string Number { get; set; }
    }
}