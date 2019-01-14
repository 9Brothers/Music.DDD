using Music.Domain.Entities;
using Music.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Infra.Data.Repositories
{
    public class StyleRepository : Repository<Style>, IStyleRepository
    {
        public override int Add(Style obj)
        {
            procedureName = "StyleInclude";
            SqlParameter[] param = {
                new SqlParameter("@Name", obj.Name),
            };
            parameters = param;

            return base.Add(obj);
        }

        public override IEnumerable<Style> GetAll()
        {
            procedureName = "StyleList";
            SqlParameter[] param = {
                new SqlParameter("@StyleId", DBNull.Value),
                new SqlParameter("@StyleName", DBNull.Value),
            };
            parameters = param;

            function = GetData();

            return base.GetAll();
        }

        public override Style Get(Style obj)
        {
            procedureName = "StyleList";
            SqlParameter[] param = {
                new SqlParameter("@StyleId", obj.IdStyle),
                new SqlParameter("@StyleName", obj.Name),
            };
            parameters = param;

            function = GetData();

            return base.GetAll().FirstOrDefault();
        }

        public override int Update(Style obj)
        {
            procedureName = "StyleUpdate";
            SqlParameter[] param = {
                new SqlParameter("@StyleId", obj.IdStyle),
                new SqlParameter("@StyleName", obj.Name),
            };
            parameters = param;

            return base.Update(obj);
        }

        public override int Remove(int id)
        {
            procedureName = "StyleRemove";
            SqlParameter[] param = {
                new SqlParameter("@StyleId", id),                
            };
            parameters = param;

            return base.Remove(id);
        }

        public override Func<SqlDataReader, IEnumerable<Style>> GetData()
        {
            return (SqlDataReader reader) =>
            {
                var results = new List<Style>();

                while (reader.Read())
                {
                    results.Add(new Style
                    {
                        IdStyle = (int)reader["IdStyle"],
                        Name = (string)reader["Name"]
                    });
                }

                return results;
            };
        }
    }
}
