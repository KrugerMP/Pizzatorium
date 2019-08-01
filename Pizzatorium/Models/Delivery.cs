using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pizzatorium.Models
{
    public class Delivery
    {
        public virtual int DeliveryId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Name is too long")]
        public virtual string dName { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Area name is too longS")]
        public virtual string dArea { get; set; }

        [Required(ErrorMessage = "Photo must be provided")]
        public virtual string dPhoto { get; set; }
    }
}