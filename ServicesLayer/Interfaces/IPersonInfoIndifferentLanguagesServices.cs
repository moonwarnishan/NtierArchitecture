using DomainLayer.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Interfaces
{
    public interface IPersonInfoIndifferentLanguagesServices
    {
        IEnumerable<PersonInfosInDifferentLanguages> GetAll();
        PersonInfosInDifferentLanguages GetById(int id);
        void Insert(PersonInfosInDifferentLanguages personInfo);
        void Update(PersonInfosInDifferentLanguages personInfo);
        void Delete(PersonInfosInDifferentLanguages personInfo);
    }
}
