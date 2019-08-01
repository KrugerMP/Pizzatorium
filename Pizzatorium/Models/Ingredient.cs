using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pizzatorium.Models
{
    public class Ingredient
    {
        public virtual int IngredientId { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Ingredient name is too long")]
        public virtual string dIngredient { get; set; }

        [Required]
        public virtual decimal dPrice { get; set; }
    }
}