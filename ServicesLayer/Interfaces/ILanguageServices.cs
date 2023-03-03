using DomainLayer.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Interfaces
{
    public interface ILanguageServices
    {
        IEnumerable<Language> GetAll();
        Language GetById(int id);
        void Insert(Language language);
        void Update(Language language);
        void Delete(Language language);
    }
}
