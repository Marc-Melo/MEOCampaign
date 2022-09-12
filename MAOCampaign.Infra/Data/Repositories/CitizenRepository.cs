using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEOCampaign.Core.Entities;
using MEOCampaign.Core.Interfaces.Repositories;
using MEOCampaign.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace MEOCampaign.Infra.Data.Repositories
{
    public class CitizenRepository : RepositoryBase<Citizen>, ICitizenRepository
    {
        public CitizenRepository(AppDbContext context) : base(context)
        {

        }

        public Citizen EagerLoadingCitizen(int id)
        {
            return _context.Set<Citizen>()
                .Include(a => a.CitizenAddress)
                .Where(b => b.CitizenId == id).FirstOrDefault();
        }
    }
}
