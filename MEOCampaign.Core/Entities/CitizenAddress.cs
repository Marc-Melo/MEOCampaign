using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEOCampaign.Core.Entities
{
    /// <summary>
    /// Citizen's Address
    /// </summary>
    public class CitizenAddress 
    {
        /// <summary>
        /// Citizen's Address Id - PK and FK
        /// </summary>
        [ForeignKey("Citizen")]
        public int CitizenAddressId { get; set; }

        /// <summary>
        /// Citizens's Street Address
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Citizen's City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Citizen's Postal Code Address
        /// </summary>
        public int PostalCode { get; set; }

        
        /// <summary>
        /// Citizen's database relationship
        /// </summary>
        public virtual Citizen Citizen { get; set; }

    }
}
