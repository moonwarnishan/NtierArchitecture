using AutoMapper;
using DomainLayer.Domains;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServicesLayer.Interfaces;
using System;
using UILayer.Models;

namespace UILayer.Factories
{
    public class PersonFactory : IPersonFactory
    {
        private readonly IPersonServices _personServices;
        private readonly IMapper _mapper;
        public PersonFactory(IPersonServices personServices, IMapper mapper)
        {
            _personServices = personServices;
            _mapper = mapper;
        }
        
        public List<PersonModel> PreparePersonModelList()
        {
            var personModels = _mapper.Map<List<PersonModel>>(_personServices.GetAll());
            foreach(var person in personModels)
            {
                person.GenderInfo = Enum.GetName(typeof(AllGenders), person.Gender);
                person.MaritalStatusInfo = Enum.GetName(typeof(AllMaritalStatuses), person.MaritalStatus);
            }
            return personModels;
        }

        
        public PersonModel PersonModelPrepareForCreate()
        {
            var personModel = new PersonModel();
            personModel = AddEnumValues(personModel);
            return personModel;
        }

        public PersonModel PreparePersonModelForEdit(int id)
        {
            var person = _personServices.GetById(id);
            var personModel = _mapper.Map<PersonModel>(person);
            personModel = AddEnumValues(personModel);
            return personModel;
        }

        public PersonModel PreparePersonModelForDetailsView(int Id)
        {
            var person = _personServices.GetById(Id);
            var personModel = _mapper.Map<PersonModel>(person);
            personModel.GenderInfo = Enum.GetName(typeof(AllGenders), person.Gender);
            personModel.MaritalStatusInfo = Enum.GetName(typeof(AllMaritalStatuses), person.MaritalStatus);
            return personModel;
        }

        
        private PersonModel AddEnumValues(PersonModel personModel)
        {
            Enum.GetValues(typeof(AllGenders)).Cast<AllGenders>()
                           .Select(g => new SelectListItem
                           {
                               Value = ((int)g).ToString(),
                               Text = g.ToString()
                           }).ToList().ForEach(x => personModel.Genders.Add(x));

            Enum.GetValues(typeof(AllMaritalStatuses)).Cast<AllMaritalStatuses>()
                           .Select(g => new SelectListItem
                           {
                               Value = ((int)g).ToString(),
                               Text = g.ToString()
                           }).ToList().ForEach(x => personModel.MaritalStatuses.Add(x));
            return personModel;
        }
    }
}
