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
    public class CitizenService : ServiceBase<Citizen>, ICitizenService
    {
        private readonly ICitizenRepository _citizenRepository;

        public CitizenService(ICitizenRepository citizenRepository) : base(citizenRepository)
        {
            _citizenRepository = citizenRepository;
        }

        public Citizen EagerLoadingCitizen(int id)
        {
            return _citizenRepository.EagerLoadingCitizen(id);
        }
    }
}
