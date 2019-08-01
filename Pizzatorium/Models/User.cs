using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pizzatorium.Models
{
    public class User
    {

        public virtual int UserId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(30, MinimumLength = 3 , ErrorMessage = "Name is too long")]
        public virtual string dName { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 8 , ErrorMessage = "Username should be between 8 and 30 charachters long")]
        public virtual string dUserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(15, MinimumLength = 10 , ErrorMessage = "Password is not long enough")]
        public virtual string dPassword { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(50 , ErrorMessage = "This is an unknown address")]
        public virtual string dAddress { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Not a valid number")]
        public virtual string dPhone { get; set; }

        [Required]
        [Display(Name = "Favourite Pizza")]
        [StringLength(30, ErrorMessage = "This pizza name is too long")]
        public virtual string dFavPizza { get; set; }
    }
}