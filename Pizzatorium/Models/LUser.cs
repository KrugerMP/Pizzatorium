using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pizzatorium.Models
{
    public class LUser
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Username not valid")]
        public virtual string dUserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Password not valid")]
        public virtual string dPassword { get; set; }
    }
}