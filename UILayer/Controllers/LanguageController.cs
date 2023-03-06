using AutoMapper;
using DomainLayer.Domains;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Interfaces;
using UILayer.Models;

namespace UILayer.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageServices _languageServices;
        private readonly IMapper _mapper;
        public LanguageController(ILanguageServices languageServices, IMapper mapper)
        {
            _languageServices = languageServices;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            /*var languages =_languageServices.GetAll();
            _mapper.Map<List<LanguageModel>>(languages);*/
            var languageModels = new List<LanguageModel>();

            
            return View(languageModels);
        }

        public JsonResult GetAll()
        {
            var languages = _languageServices.GetAll();
            var languageModels = _mapper.Map<List<LanguageModel>>(languages);

            return new JsonResult(languageModels);
        }

        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Id,Name")] LanguageModel language)
        {
            if(ModelState.IsValid)
            {
                _languageServices.Insert( _mapper.Map<Language>(language));
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }
        public IActionResult Edit(int id)
        {
            var language = _languageServices.GetById(id);
            var languageModel = _mapper.Map<LanguageModel>(language);
            return View(languageModel);
        }
        [HttpPost]
        public IActionResult EditConfirm([Bind("Id,Name")] LanguageModel language)
        {
            if (ModelState.IsValid)
            {
                _languageServices.Update(_mapper.Map<Language>(language));
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }

        public IActionResult Delete(int id)
        {
            var language = _languageServices.GetById(id);
            var languageModel = _mapper.Map<LanguageModel>(language);
            return View(languageModel);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var language = _languageServices.GetById(id);
            _languageServices.Delete(language);
            return RedirectToAction(nameof(Index));
        }


    }
}
