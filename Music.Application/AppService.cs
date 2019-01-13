using Music.Application.Interface;
using Music.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Application
{
    public class AppService<TEntity> : IDisposable, IAppService<TEntity> where TEntity : class
    {
        private readonly IService<TEntity> service;

        public AppService(IService<TEntity> service)
        {
            this.service = service;
        }

        public int Add(TEntity obj)
        {
            return service.Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return service.GetAll();
        }

        public TEntity GetById(int id)
        {
            return service.GetById(id);
        }

        public void Remove(int id)
        {
            service.Remove(id);
        }

        public void Update(TEntity obj)
        {
            service.Update(obj);
        }
    }
}
