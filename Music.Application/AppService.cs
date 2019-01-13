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

        public TEntity Get(TEntity obj)
        {
            return service.Get(obj);
        }

        public int Remove(int id)
        {
            return service.Remove(id);
        }

        public int Update(TEntity obj)
        {
            return service.Update(obj);
        }

        
    }
}
