using AutoMapper;
using DomainLayer.Domains;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Interfaces;
using UILayer.Factories;
using UILayer.Models;

namespace UILayer.Controllers
{
    public class PersonInfoInDifferentLanguageController : Controller
    {
        private readonly IPersonInfoIndifferentLanguagesServices _personInfoIndifferentLanguagesServices;
        private readonly IPersonInDifferentLanguagesFactory _personDifferentLanguagesFactory;
        private readonly IMapper _mapper;
        private readonly ILanguageServices _languageServices;
        private readonly IPersonServices _personServices;
        public PersonInfoInDifferentLanguageController(
            IPersonInfoIndifferentLanguagesServices personInfoIndifferentLanguagesServices,
            IPersonInDifferentLanguagesFactory personInDifferentLanguagesFactory,
            IMapper mapper,
            ILanguageServices languageServices,
            IPersonServices personServices)
        {
            _personInfoIndifferentLanguagesServices = personInfoIndifferentLanguagesServices;
            _personDifferentLanguagesFactory = personInDifferentLanguagesFactory;
            _mapper = mapper;
            _languageServices = languageServices;
            _personServices = personServices;
        }

        public IActionResult Index()
        {
            var persons = _personDifferentLanguagesFactory.GetPersonsOnSelectedLanguage(int.Parse(HttpContext.Session.GetString("languageId")));
            return View(persons);
        }

        public IActionResult Create()
        {
            return View(_personDifferentLanguagesFactory.PrepModelForPersonInDiffLangCreate());
        }
        [HttpPost]
        public IActionResult Create(PersonInfoInDifferentLanguagesModel personInfoInDifferentLanguagesModel)
        {
            var person = _mapper.Map<PersonInfosInDifferentLanguages>(personInfoInDifferentLanguagesModel);
            if (HttpContext.Session.GetString("languageId") == null)
            {
                return View("~/Views/LanguageSelect/Index.cshtml");
            }
            person.LanguageId = int.Parse(HttpContext.Session.GetString("languageId"));
            person.Language = _languageServices.GetById(person.LanguageId);
            person.Person = _personServices.GetById(person.PersonId);
            if (ModelState.IsValid)
            {
                _personInfoIndifferentLanguagesServices.Insert(person);
                return RedirectToAction(nameof(Index));
            }
            return View(personInfoInDifferentLanguagesModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_personDifferentLanguagesFactory.PrepModelForPersonInDiffLangUpdate(id));
        }
        [HttpPost]
        public IActionResult Edit(PersonInfoInDifferentLanguagesModel personInfoInDifferentLanguagesModel)
        {
            var person = _mapper.Map<PersonInfosInDifferentLanguages>(personInfoInDifferentLanguagesModel);
            if (ModelState.IsValid)
            {
                _personInfoIndifferentLanguagesServices.Update(person);
                return RedirectToAction(nameof(Index));
            }
            return View(personInfoInDifferentLanguagesModel);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_personDifferentLanguagesFactory.PrepModelForPersonInDiffLangUpdate(id));
        }
        [HttpPost]
        public IActionResult Delete(PersonInfoInDifferentLanguagesModel model)
        {
            var person = _mapper.Map<PersonInfosInDifferentLanguages>(model);
            _personInfoIndifferentLanguagesServices.Delete(person);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var personInfoModel = _personInfoIndifferentLanguagesServices.GetById(id);
            return View(_mapper.Map<PersonInfoInDifferentLanguagesModel>(personInfoModel));
        }
        
    }
}
