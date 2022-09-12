using System.ComponentModel.DataAnnotations;

namespace MEOCampaign.Web.ViewModels
{
    public class CitizenAddressViewModel
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int PostalCode { get; set; }
    }
}
