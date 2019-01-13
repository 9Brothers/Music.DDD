using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Add(TEntity obj);
        TEntity Get(TEntity obj);
        IEnumerable<TEntity> GetAll();
        int Update(TEntity obj);
        int Remove(int id);
        void Dispose();
        Func<SqlDataReader, IEnumerable<TEntity>> GetData();
        Func<SqlDataReader, dynamic> SetData();
    }
}
