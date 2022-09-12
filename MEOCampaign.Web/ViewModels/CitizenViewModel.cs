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

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
