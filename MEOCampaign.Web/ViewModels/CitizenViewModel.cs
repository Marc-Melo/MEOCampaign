using System.ComponentModel.DataAnnotations;
using MEOCampaign.Core.Entities;

namespace MEOCampaign.Web.ViewModels
{
    public class CitizenViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Phone]
        [StringLength(11)]
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Mobile Phone", Prompt = "999 999 999")]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{3}$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Email", Prompt = "example@example.pt")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email { get; set; }
    }
}
