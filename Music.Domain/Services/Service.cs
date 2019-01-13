using Music.Domain.Interfaces;
using Music.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Domain.Services
{
    public class Service<TEntity> : IDisposable, IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }


        public int Add(TEntity obj)
        {
            return _repository.Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity Get(TEntity obj)
        {
            return _repository.Get(obj);
        }

        public int Remove(int id)
        {
            return _repository.Remove(id);
        }

        public int Update(TEntity obj)
        {
            return _repository.Update(obj);
        }
    }
}
