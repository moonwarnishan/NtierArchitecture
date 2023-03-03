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
    public class LanguageServices : ILanguageServices
    {
        private readonly IRepository<Language> _languageRepo;
        public LanguageServices(IRepository<Language> languageRepo)
        {
            _languageRepo = languageRepo;
        }

        public void Delete(Language language)
        {
            _languageRepo.Delete(language);
        }

        public IEnumerable<Language> GetAll()
        {
            return _languageRepo.GetAll();
        }

        public Language GetById(int id)
        {
            return _languageRepo.GetById(id);
        }

        public void Insert(Language language)
        {
            _languageRepo.Insert(language);
        }

        public void Update(Language language)
        {
            _languageRepo.Update(language);
        }
    }
}
