using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEOCampaign.Core.Entities;

namespace MEOCampaign.Core.Interfaces.Repositories
{
    public interface ICitizenRepository : IRepositoryBase<Citizen>
    {
        Citizen EagerLoadingCitizen(int id);
    }
}
