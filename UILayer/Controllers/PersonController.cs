using AutoMapper;
using DomainLayer.Domains;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Interfaces;
using UILayer.Factories;
using UILayer.Models;

namespace UILayer.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonServices _personServices;
        private readonly IPersonFactory _personFactory;
        private readonly IMapper _mapper;
        public PersonController(IPersonServices personServices , IPersonFactory personFactory, IMapper mapper)
        {
            _personServices = personServices;
            _personFactory = personFactory;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            return View(_personFactory.PreparePersonModelList());
        }

        public IActionResult Create()
        {
            var personModel = _personFactory.PersonModelPrepareForCreate();
            return View(personModel);
        }
        [HttpPost]
        public IActionResult Create([Bind("Id,Name,DateOfBirth,Gender,MaritalStatus,Creation,CreationDate")] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                _personServices.Insert(_mapper.Map<Person>(personModel));
                return RedirectToAction("Index");
            }
            return View(personModel);
        }

        public IActionResult Edit(int id)
        {
            var personModel = _personFactory.PreparePersonModelForEdit(id);
            return View(personModel);
        }

        [HttpPost]
        public IActionResult Edit(PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                _personServices.Update(_mapper.Map<Person>(personModel));
                return RedirectToAction("Index");
            }
            return View(personModel);
        }

        public IActionResult Delete(int id)
        {
            var personModel = _personFactory.PreparePersonModelForDetailsView(id);
            return View(personModel);
        }
        [HttpPost]
        public IActionResult Delete(PersonModel personModel)
        {
            _personServices.Delete(_mapper.Map<Person>(personModel));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            _personServices.GetById(id);
            return View(_personFactory.PreparePersonModelForDetailsView(id));
        }

    }
}
