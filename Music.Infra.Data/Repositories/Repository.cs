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
            function = (SqlDataReader reader) => {
                return reader.RecordsAffected;
            };

            return MusicSql<int>.Run(procedureName, parameters, function);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return MusicSql<IEnumerable<TEntity>>.Run(procedureName, parameters, function);
        }

        public virtual TEntity GetById(int id)
        {
            return MusicSql<TEntity>.Run(procedureName, parameters, function);
        }

        public void Remove(int id)
        {
            MusicSql<TEntity>.Run(procedureName, parameters, function);
        }

        public void Update(TEntity obj)
        {
            MusicSql<TEntity>.Run(procedureName, parameters, function);
        }
    }
}
