using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pizzatorium.Models
{
    public class IngredientShow 
    {
        public virtual int ID { get; set; }

        public virtual string dIngredient { get; set; }
    }
}