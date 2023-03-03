using DomainLayer.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Interfaces
{
    public interface IPersonServices
    {
        IEnumerable<Person> GetAll();
        Person GetById(int id);
        void Insert(Person person);
        void Update(Person person);
        void Delete(Person person);
    }
}
