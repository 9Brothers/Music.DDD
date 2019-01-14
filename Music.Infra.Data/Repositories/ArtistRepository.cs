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
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public override int Add(Artist obj)
        {
            procedureName = "ArtistInclude";
            SqlParameter[] param = {
                new SqlParameter("@ArtistName", obj.Name),                
            };
            parameters = param;

            return base.Add(obj);
        }

        public override IEnumerable<Artist> GetAll()
        {
            procedureName = "ArtistList";
            SqlParameter[] param = {
                new SqlParameter("@ArtistId", DBNull.Value),
                new SqlParameter("@ArtistName", DBNull.Value)
            };
            parameters = param;

            function = GetData();

            return base.GetAll();
        }

        public override Artist Get(Artist obj)
        {
            procedureName = "ArtistList";
            SqlParameter[] param = {
                new SqlParameter("@ArtistId", obj.IdArtist),
                new SqlParameter("@ArtistName", obj.Name),          
            };
            parameters = param;

            function = GetData();

            return base.GetAll().FirstOrDefault();
        }

        public override int Update(Artist obj)
        {
            procedureName = "ArtistUpdate";
            SqlParameter[] param = {
                new SqlParameter("@ArtistId", obj.IdArtist),
                new SqlParameter("@ArtistName", obj.Name),
            };
            parameters = param;

            return base.Update(obj);
        }

        public override int Remove(int id)
        {
            procedureName = "ArtistRemove";
            SqlParameter[] param = {
                new SqlParameter("@ArtistId", id),                
            };
            parameters = param;

            return base.Remove(id);
        }

        public override Func<SqlDataReader, IEnumerable<Artist>> GetData()
        {
            return (SqlDataReader reader) =>
            {
                var results = new List<Artist>();

                while (reader.Read())
                {
                    results.Add(new Artist
                    {
                        IdArtist = (int) reader["IdArtist"],
                        Name = (string) reader["Name"]
                    });
                }

                return results;
            };
        }
    }
}
