using DomainLayer.Domains;
using LinqToDB;
using RepositoryLayer.Data;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinqToDB.Reflection.Methods.LinqToDB.Insert;

namespace RepositoryLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDataConnection _dataConnection;
        public Repository(ApplicationDataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }

        public void Delete(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(); ;
            }
            _dataConnection.Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dataConnection.GetTable<T>().ToList();
        }

        public T GetById(int id)
        {
            if(id == null)
            {
                throw new ArgumentNullException();
            }
            var data =  _dataConnection.GetTable<T>().Where(x => x.Id == id).FirstOrDefault();
            if(data == null)
            {
                throw new NullReferenceException();
            }
            return data;
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(); 
            }
            _dataConnection.Insert(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(); ;
            }
            _dataConnection.Update(entity);
        }

    }
}
