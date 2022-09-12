using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEOCampaign.Core.Entities
{
    /// <summary>
    /// Citizen
    /// </summary>
    public class Citizen 
    {
        /// <summary>
        /// Citizen's Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CitizenId { get; set; }

        /// <summary>
        /// Citizen's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Citizen's DateOfBirth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Citizen's PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Citizen's Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Citizen's Address database relationship 
        /// </summary>
        public virtual CitizenAddress CitizenAddress { get; set; }

    }
}
