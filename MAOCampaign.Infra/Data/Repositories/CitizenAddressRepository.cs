using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEOCampaign.Core.Entities;
using MEOCampaign.Core.Interfaces.Repositories;
using MEOCampaign.Infra.Data.Context;

namespace MEOCampaign.Infra.Data.Repositories
{
    public class CitizenAddressRepository : RepositoryBase<CitizenAddress>, ICitizenAddressRepository
    {
        public CitizenAddressRepository(AppDbContext context) : base(context)
        {

        }
    }
}
