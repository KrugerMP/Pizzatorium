using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pizzatorium.Models
{
    public class Area
    {
        [Required]
        public virtual int AreaId { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Area name is too long")]
        public virtual string dArea { get; set; }
    }
}