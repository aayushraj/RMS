using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RMSWeb.Models
{
    public class LoginModel //: PageModel
    {
       //public IList<AuthenticationScheme> ExternalLogins { get; set; }

        //public string ReturnUrl { get; set; }

        [TempData]
       // public string ErrorMessage { get; set; }

       
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        


    }





}
