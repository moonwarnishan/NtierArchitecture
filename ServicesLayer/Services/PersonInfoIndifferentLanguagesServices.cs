using DomainLayer.Domains;
using RepositoryLayer.Interfaces;
using ServicesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services
{
    public class PersonInfoIndifferentLanguagesServices : IPersonInfoIndifferentLanguagesServices
    {
        private readonly IRepository<PersonInfosInDifferentLanguages> _personInfoIndifferentLanguagesRepo;
        public PersonInfoIndifferentLanguagesServices(IRepository<PersonInfosInDifferentLanguages> personInfoIndifferentLanguagesRepo)
        {
            _personInfoIndifferentLanguagesRepo = personInfoIndifferentLanguagesRepo;
        }

        public void Delete(PersonInfosInDifferentLanguages personInfo)
        {
            _personInfoIndifferentLanguagesRepo.Delete(personInfo);
        }

        public IEnumerable<PersonInfosInDifferentLanguages> GetAll()
        {
            return _personInfoIndifferentLanguagesRepo.GetAll();
        }

        public PersonInfosInDifferentLanguages GetById(int id)
        {
            return _personInfoIndifferentLanguagesRepo.GetById(id);
        }

        public void Insert(PersonInfosInDifferentLanguages personInfo)
        {
            _personInfoIndifferentLanguagesRepo.Insert(personInfo);
        }

        public void Update(PersonInfosInDifferentLanguages personInfo)
        {
            _personInfoIndifferentLanguagesRepo.Update(personInfo);
        }
    }
}
