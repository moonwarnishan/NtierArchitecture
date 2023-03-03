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
    public class PersonServices : IPersonServices
    {
        private readonly IRepository<Person> _personRepo;
        public PersonServices(IRepository<Person> personRepo)
        {
            _personRepo = personRepo;
        }

        public void Delete(Person person)
        {
            _personRepo.Delete(person);
        }
        
        public IEnumerable<Person> GetAll()
        {
            return _personRepo.GetAll();
        }

        public Person GetById(int id)
        {
            return _personRepo.GetById(id);
        }

        public void Insert(Person person)
        {
            _personRepo.Insert(person);
        }

        public void Update(Person person)
        {
            _personRepo.Update(person);
        }
    }
}
