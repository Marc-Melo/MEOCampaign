using AutoMapper;
using MEOCampaign.Core.Entities;
using MEOCampaign.Web.ViewModels;

namespace MEOCampaign.Web.AutoMapper
{
    /// <summary>
    /// Auto Mapper Configuration
    /// </summary>
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            // Source -> Target
            CreateMap<Citizen, CitizenReadViewModel>();
            CreateMap<CitizenViewModel, Citizen>();
            CreateMap<CitizenAddressViewModel, CitizenAddress>();
        }
    }
}
