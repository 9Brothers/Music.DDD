using Music.Domain.Interfaces;
using Music.Infra.Data.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Infra.Data.Repositories
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        protected string procedureName;
        protected SqlParameter[] parameters;
        protected Func<SqlDataReader, dynamic> function;

        public virtual int Add(TEntity obj)
        {
            return MusicSql<int>.Run(procedureName, parameters, SetData());
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return MusicSql<IEnumerable<TEntity>>.Run(procedureName, parameters, function);
        }

        public virtual TEntity Get(TEntity obj)
        {
            return MusicSql<TEntity>.Run(procedureName, parameters, function);
        }

        public virtual int Remove(int id)
        {
            return MusicSql<int>.Run(procedureName, parameters, SetData());
        }

        public virtual int Update(TEntity obj)
        {
            return MusicSql<int>.Run(procedureName, parameters, SetData());
        }

        public virtual Func<SqlDataReader, IEnumerable<TEntity>> GetData()
        {
            return (SqlDataReader reader) =>
            {
                var results = new List<TEntity>();

                return results;
            };
        }

        public Func<SqlDataReader, dynamic> SetData()
        {
            return (SqlDataReader reader) =>
            {
                return reader.RecordsAffected;
            };
        }
    }
}
