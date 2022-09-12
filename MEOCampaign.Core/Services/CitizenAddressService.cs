using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEOCampaign.Core.Entities;
using MEOCampaign.Core.Interfaces.Repositories;
using MEOCampaign.Core.Interfaces.Services;

namespace MEOCampaign.Core.Services
{
    public class CitizenAddressService : ServiceBase<CitizenAddress>, ICitizenAddressService
    {
        private readonly ICitizenAddressRepository _citizenAddressRepository;

        public CitizenAddressService(ICitizenAddressRepository citizenAddressRepository) : base(citizenAddressRepository)
        {
            _citizenAddressRepository = citizenAddressRepository;
        }
    }
}
