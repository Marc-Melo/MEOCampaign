using AutoMapper;
using MEOCampaign.Core.Entities;
using MEOCampaign.Core.Interfaces.Services;
using MEOCampaign.Core.Services;
using MEOCampaign.Web.Controllers;
using Moq;

namespace MEOCampaign.Tests.Mocking
{
    [TestFixture]
    public class CitizenControllerTests
    {
        private Mock<ICitizenService> _citizenService;
        private Mock<ICitizenAddressService> _citizenAddressService;
        private Mock<IMapper> _mapper;
        private CitizenController _controller;
        private Citizen _citizen;

        [SetUp]
        public void SetUp()
        {
            _citizen = new Citizen
            {
                CitizenId = 1,
                DateOfBirth = DateTime.Now,
                Name = "Richard",
                PhoneNumber = "933 885 415",
                Email = "richard@test.com",
                CitizenAddress = new CitizenAddress 
                {
                    CitizenAddressId = 1,
                    Street = "Street Example",
                    City = "City Example",
                    PostalCode = 123456
                }
            };

            _citizenService = new Mock<ICitizenService>();
            _citizenAddressService = new Mock<ICitizenAddressService>();
            _mapper = new Mock<IMapper>();

            _citizenService.Setup(s => s.GetAll()).Returns(new List<Citizen> { _citizen }.AsEnumerable());

            _citizenService.Setup(s => s.Get(1)).Returns(_citizen);
                        
            _controller = new CitizenController(_citizenService.Object, _citizenAddressService.Object, _mapper.Object);
        }

        [Test]
        public void GetAllCitizens_WhenCalled_ReturnAllCitizens()
        {
            _controller.GetAllCitizens();

            _citizenService.Verify(s => s.GetAll());
        }

        [Test]
        public void GetCitizenById_WhenCalled_ReturnExistingCitizen()
        {
            _controller.GetCitizenById(1);

            _citizenService.Verify(s => s.Get(1));
        }
    }
}
