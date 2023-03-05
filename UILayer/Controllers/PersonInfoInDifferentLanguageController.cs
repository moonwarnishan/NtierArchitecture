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
            if (HttpContext.Session.GetString("languageId") == null)
            {
                return View("~/Views/LanguageSelect/Index.cshtml");
            }
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
            person = PreparePerson(person);
            _personInfoIndifferentLanguagesServices.Insert(person);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            return View(_personDifferentLanguagesFactory.PrepModelForPersonInDiffLangUpdate(id));
        }
        [HttpPost]
        public IActionResult Edit(PersonInfoInDifferentLanguagesModel personInfoInDifferentLanguagesModel)
        {
            var model = _personDifferentLanguagesFactory.PrepModelForPersonInDiffLangUpdate(Convert.ToInt32(personInfoInDifferentLanguagesModel.Id));
            model.Name = personInfoInDifferentLanguagesModel.Name;
            var personinfo = _mapper.Map<PersonInfosInDifferentLanguages>(model);
            personinfo.Person = _personServices.GetById(personinfo.PersonId);
            _personInfoIndifferentLanguagesServices.Update(personinfo);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            return DeleteConfirmed(id);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var person = _personInfoIndifferentLanguagesServices.GetById(id);
            _personInfoIndifferentLanguagesServices.Delete(person);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var personInfoModel = _personInfoIndifferentLanguagesServices.GetById(id);
            personInfoModel.Person = _personServices.GetById(personInfoModel.PersonId);
            personInfoModel.Language = _languageServices.GetById(personInfoModel.LanguageId);
            return View(_mapper.Map<PersonInfoInDifferentLanguagesModel>(personInfoModel));
        }


        private PersonInfosInDifferentLanguages PreparePerson(PersonInfosInDifferentLanguages model)
        {
            var person = new PersonInfosInDifferentLanguages();
            person.LanguageId = int.Parse(HttpContext.Session.GetString("languageId"));
            person.Language = _languageServices.GetById(person.LanguageId);
            person.Person = _personServices.GetById(model.PersonId);
            person.Name = model.Name;
            person.DateOfBirth = person.Person.DateOfBirth;
            person.Gender = person.Person.Gender;
            person.MaritalStatus = person.Person.MaritalStatus;
            person.PersonId = model.PersonId;
            return person;
        }


    }
}
