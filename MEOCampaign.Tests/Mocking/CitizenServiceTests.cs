using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MEOCampaign.Core.Entities;
using MEOCampaign.Core.Interfaces.Repositories;
using MEOCampaign.Core.Interfaces.Services;
using MEOCampaign.Core.Services;
using MEOCampaign.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.ContentModel;

namespace MEOCampaign.Tests.Mocking
{
    [TestFixture]
    public class CitizenServiceTests
    {
        private Mock<ICitizenRepository> _citizenRepository;
        private CitizenService _citizenService;
        private Citizen _citizen;
        private Citizen _citizenEagerLoading;

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
            };

            _citizenEagerLoading = new Citizen
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

            _citizenRepository = new Mock<ICitizenRepository>();

            _citizenRepository.Setup(s => s.GetAll()).Returns(new List<Citizen> { _citizen }.AsEnumerable());

            _citizenRepository.Setup(s => s.Get(1)).Returns(_citizen);

            _citizenRepository.Setup(s => s.Find(s => s.Email == "richard@test.com")).Returns(new List<Citizen> { _citizen });

            _citizenRepository.Setup(s => s.EagerLoadingCitizen(1)).Returns(_citizenEagerLoading);

            _citizenService = new CitizenService(_citizenRepository.Object);
        }

        [Test]
        public void GetAll_WhenCalled_ReturnAllCitizens()
        {
            var result = _citizenService.GetAll();

            Assert.That(result, Is.EqualTo(new List<Citizen> { _citizen }));
        }

        [Test]
        public void Get_WhenCalled_ReturnSpecificCitizen()
        {
            var result = _citizenService.Get(1);

            Assert.That(result, Is.EqualTo(_citizen));
        }

        [Test]
        public void Get_WhenCalled_ReturnSpecificCitizenWithoutAddress()
        {
            var result = _citizenService.Get(1);

            Assert.That(result, Is.EqualTo(_citizen));
            Assert.That(result.CitizenAddress, Is.Null);
        }

        [Test]
        public void Find_WhenCalled_ReturnSpecificCitizen()
        {
            var result = _citizenService.Find(s => s.Email == "richard@test.com");

            Assert.That(result, Is.EqualTo(new List<Citizen> { _citizen }));
            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Find_WhenCalled_NotReturnSpecificCitizen()
        {
            var result = _citizenService.Find(s => s.Email == "empty@test.com");

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void EagerLoadingCitizen_WhenCalled_ReturnCitizenWithAddress()
        {
            var result = _citizenService.EagerLoadingCitizen(1);

            Assert.That(result, Is.EqualTo(_citizenEagerLoading));
        }

    }
}
