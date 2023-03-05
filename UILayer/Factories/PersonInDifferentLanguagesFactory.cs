using AutoMapper;
using DomainLayer.Domains;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServicesLayer.Interfaces;
using System;
using UILayer.Models;

namespace UILayer.Factories
{
    public class PersonInDifferentLanguagesFactory : IPersonInDifferentLanguagesFactory
    {
        private readonly IPersonInfoIndifferentLanguagesServices _personInfoIndifferentLanguagesServices;
        private readonly IMapper _mapper;
        private readonly ILanguageServices _languageServices;
        private readonly IPersonServices _personServices;

        public PersonInDifferentLanguagesFactory(
            IPersonInfoIndifferentLanguagesServices personInfoIndifferentLanguagesServices,
            IMapper mapper,
            ILanguageServices languageServices,
            IPersonServices personServices
            )
        {
            _personServices = personServices;
            _languageServices = languageServices;
            _personInfoIndifferentLanguagesServices = personInfoIndifferentLanguagesServices;
            _mapper = mapper;
        }
        
        

        
        public List<PersonInfoInDifferentLanguagesModel> GetPersonsOnSelectedLanguage(int id)
        {
            var personInfoIndifferentLanguages = _personInfoIndifferentLanguagesServices.GetAll().Where(x=> x.LanguageId == id).ToList();
            var models = _mapper.Map<List<PersonInfoInDifferentLanguagesModel>>(personInfoIndifferentLanguages);
            foreach (var m in models)
            {
                m.GenderInfo = Enum.GetName(typeof(AllGenders), m.Gender);
                m.MaritalStatusInfo = Enum.GetName(typeof(AllMaritalStatuses), m.MaritalStatus);
                m.Person = _personServices.GetById(Convert.ToInt32(m.PersonId));
                m.Language = _languageServices.GetById(Convert.ToInt32(m.LanguageId));
            }
            return models;
        }

        public PersonInfoInDifferentLanguagesModel PrepModelForPersonInDiffLangCreate()
        {
            var model = new PersonInfoInDifferentLanguagesModel();
            _personServices.GetAll().ToList().ForEach(x=>model.AllPersons?.Add(
                new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }
                ));
            _languageServices.GetAll().ToList().ForEach(x => model.AllLanguages?.Add(
                new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }
            ));
            return model;
        }

        public PersonInfoInDifferentLanguagesModel PrepModelForPersonInDiffLangUpdate(int id)
        {
            var personsInfo = _personInfoIndifferentLanguagesServices.GetById(id);
            var model = _mapper.Map<PersonInfoInDifferentLanguagesModel>(personsInfo);
            _personServices.GetAll().ToList().ForEach(x => model.AllPersons?.Add(
                new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }
            ));
            Enum.GetValues(typeof(AllGenders)).Cast<AllGenders>()
                .Select(g => new SelectListItem
                {
                    Value = ((int)g).ToString(),
                    Text = g.ToString()
                }).ToList().ForEach(x => model.AllGenders.Add(x));

            Enum.GetValues(typeof(AllMaritalStatuses)).Cast<AllMaritalStatuses>()
                .Select(g => new SelectListItem
                {
                    Value = ((int)g).ToString(),
                    Text = g.ToString()
                }).ToList().ForEach(x => model.AllMaterialStatus.Add(x));
            model.Person = _personServices.GetById(Convert.ToInt32(model.PersonId));
            return model;
        }
    }
}
