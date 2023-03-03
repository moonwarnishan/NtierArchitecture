using AutoMapper;
using DomainLayer.Domains;
using UILayer.Models;

namespace UILayer.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LanguageModel, Language>();
            CreateMap<PersonInfoInDifferentLanguagesModel, PersonInfosInDifferentLanguages>();
            CreateMap<PersonModel, Person>();
            CreateMap<Language, LanguageModel>();
            CreateMap<PersonInfosInDifferentLanguages, PersonInfoInDifferentLanguagesModel>();
            CreateMap<Person, PersonModel>();
        }
    }
}
