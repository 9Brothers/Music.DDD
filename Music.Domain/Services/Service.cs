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

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
    }
}
