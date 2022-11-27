using System.ComponentModel.DataAnnotations;

namespace RMSWeb.Models
{
    public class ManageUserModel
    {
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string UserName { get; set; }
        public byte ProfilePicture { get; set; }
        public string StatusMessage { get; set; }


    }
}
