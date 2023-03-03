using DomainLayer.Domains;
using LinqToDB;
using LinqToDB.Data;

namespace RepositoryLayer.Data
{
    public class ApplicationDataConnection : DataConnection
    {
        public ApplicationDataConnection(DataOptions<ApplicationDataConnection> options)
        : base()
        {

        }
        public ITable<Person> Persons => this.GetTable<Person>();
        public ITable<Language> Languages => this.GetTable<Language>();
        public ITable<PersonInfosInDifferentLanguages> PersonsInfoIndifferentLanguages => this.GetTable<PersonInfosInDifferentLanguages>();
        

    }
}
