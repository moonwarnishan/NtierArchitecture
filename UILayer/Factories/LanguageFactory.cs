using AutoMapper;
using ServicesLayer.Interfaces;
using UILayer.Models;

namespace UILayer.Factories
{
    public class LanguageFactory
    {
        private readonly ILanguageServices _languageServices;
        private readonly IMapper _mapper;
        public LanguageFactory(ILanguageServices languageServices , IMapper mapper)
        {
            _languageServices = languageServices;
            _mapper = mapper;
        }

    }
}
