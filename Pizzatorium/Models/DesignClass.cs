using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizzatorium.Models
{
    public class DesignClass
    {
        [Required (ErrorMessage = "Please select a pizza size")]
        [Display(Name = "Select your Pizza Size")]
        public int[] form { get; set; }

        [Required (ErrorMessage = "Please select an ingredient")]
        [Display(Name = "Select Ingredient")]
        public int[] IngredientSelect { get; set; }

    }
}