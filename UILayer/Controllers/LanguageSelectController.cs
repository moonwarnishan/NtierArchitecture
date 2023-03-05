using DomainLayer.Domains;
using Microsoft.AspNetCore.Mvc;
using UILayer.Factories;

namespace UILayer.Controllers
{
    public class LanguageSelectController : Controller
    {
        private readonly ILanguageFactory _languageFactory;
        private readonly IPersonInDifferentLanguagesFactory _personInDifferentLanguagesFactory;

        public LanguageSelectController(ILanguageFactory languageFactory,
            IPersonInDifferentLanguagesFactory personInDifferentLanguagesFactory)
        {
            _languageFactory=languageFactory;
            _personInDifferentLanguagesFactory=personInDifferentLanguagesFactory;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _languageFactory.CreateLanguageModel());
        }
        [HttpPost]
        public IActionResult SelectConfirm(int id)
        {

            var personModels = _personInDifferentLanguagesFactory.GetPersonsOnSelectedLanguage(id);
            HttpContext.Session.Remove("languageId");
            HttpContext.Session.SetString("languageId", id.ToString());
            return View("~/Views/PersonInfoInDifferentLanguage/Index.cshtml", personModels);
        }

    }
}
