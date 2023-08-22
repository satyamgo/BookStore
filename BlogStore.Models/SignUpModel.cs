using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please Enter Unused-Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please Enter ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        
    }
}
