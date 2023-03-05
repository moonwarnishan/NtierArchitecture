using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServicesLayer.Interfaces;
using UILayer.Models;

namespace UILayer.Factories
{
    public class LanguageFactory : ILanguageFactory
    {
        private readonly ILanguageServices _languageServices;
        private readonly IMapper _mapper;
        public LanguageFactory(ILanguageServices languageServices , IMapper mapper)
        {
            _languageServices = languageServices;
            _mapper = mapper;
        }

        public async Task<LanguageModel> CreateLanguageModel()
        {
            var languages = _languageServices.GetAll();
            var languageModel = new LanguageModel();
            foreach (var language in languages)
            {
                languageModel.AllLanguages.Add(new SelectListItem()
                {
                    Value = language.Id.ToString(),Text = language.Name
                });
            }

            return languageModel;
        }

    }
}
