using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Domain.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        int Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int id);
        void Dispose();
    }
}
