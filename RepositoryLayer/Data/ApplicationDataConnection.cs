using DomainLayer.Domains;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using static LinqToDB.DataProvider.SqlServer.SqlServerProviderAdapter;
using System.Data.Common;

namespace RepositoryLayer.Data
{
    public class ApplicationDataConnection : DataConnection
    {
        public ApplicationDataConnection(DataOptions<ApplicationDataConnection> options)
        : base(
              new DataOptions()
            .UseSqlServer("Server=.;Database=PersonInfoLayeredArchitecture;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;")
            )
        {

        }
        public ITable<Person> Persons { set; get; }
        public ITable<Language> Languages { set; get; }
        public ITable<PersonInfosInDifferentLanguages> PersonsInfoIndifferentLanguages { set; get; }

    }
}
