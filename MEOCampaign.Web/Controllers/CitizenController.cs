using AutoMapper;
using MEOCampaign.Core.Entities;
using MEOCampaign.Core.Interfaces.Services;
using MEOCampaign.Core.Services;
using MEOCampaign.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace MEOCampaign.Web.Controllers
{
    /// <summary>
    /// Citizen Controller 
    /// </summary>
    public class CitizenController : Controller
    {
        private readonly ICitizenService _citizenService;
        private readonly ICitizenAddressService _citizenAddressService;
        private readonly IMapper _mapper;

        public CitizenController(ICitizenService citizenService, ICitizenAddressService citizenAddressService,  IMapper mapper)
        {
            _citizenService = citizenService;
            _citizenAddressService = citizenAddressService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("CreateCitizen");
        }

        /// <summary>
        /// Method to Create the Citizen information and his address
        /// </summary>
        /// <param name="citizenBaseViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<CitizenReadViewModel> Create(CitizenBaseViewModel citizenBaseViewModel)
        {
            if (ModelState.IsValid)
            {
                //Missing Transaction

                var citizenModel = _mapper.Map<Citizen>(citizenBaseViewModel.CitizenViewModel);
                _citizenService.Add(citizenModel);

                var citizenAddressModel = _mapper.Map<CitizenAddress>(citizenBaseViewModel.CitizenAddressViewModel);
                citizenAddressModel.CitizenAddressId = citizenModel.CitizenId;
                _citizenAddressService.Add(citizenAddressModel);

                var citizenReadViewModel = _mapper.Map<CitizenReadViewModel>(citizenModel);

                return View("ViewCitizen", citizenReadViewModel);
            }

            return View("GetAllCitizens");
        }

        /// <summary>
        /// Get all Citizens' data stored
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<CitizenReadViewModel>> GetAllCitizens()
        {
            var citizens = _citizenService.GetAll();

            return View(_mapper.Map<IEnumerable<CitizenReadViewModel>>(citizens));
        }

        /// <summary>
        /// Get the Citizen' data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<CitizenReadViewModel> GetCitizenById(int id)
        {
            var citizen = _citizenService.Get(id);
            if(citizen != null)
                return View("ViewCitizen", _mapper.Map<CitizenReadViewModel>(citizen));

            return View();
        }

    }
}
