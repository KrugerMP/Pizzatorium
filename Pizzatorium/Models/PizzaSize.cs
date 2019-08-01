using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Pizzatorium.Models
{
    public class PizzaSize
    {
        public int ID { get; set; }
        public string PizzaSizes { get; set; }
    }
    
}