﻿using Music.Domain.Entities;
using Music.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Infra.Data.Repositories
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        public override int Add(Song obj)
        {
            procedureName = "SongsInclude";
            SqlParameter[] param = {
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@StyleName", obj.Style.Name),
                new SqlParameter("@ArtistName", obj.Artist.Name),
            };
            parameters = param;

            return base.Add(obj);
        }

        public override IEnumerable<Song> GetAll()
        {
            procedureName = "SongsList";
            SqlParameter[] param = {
                new SqlParameter("@SongName", DBNull.Value),
                new SqlParameter("@StyleName", DBNull.Value),
                new SqlParameter("@ArtistName", DBNull.Value),
            };
            parameters = param;

            function = GetData();

            return base.GetAll();
        }

        public override Song Get(Song obj)
        {
            procedureName = "SongsList";
            SqlParameter[] param = {
                new SqlParameter("@SongName", obj.Name),
                new SqlParameter("@StyleName", obj.Style.Name),
                new SqlParameter("@ArtistName", obj.Artist.Name),
            };
            parameters = param;

            function = GetData();

            return base.GetAll().FirstOrDefault();
        }

        public override int Update(Song obj)
        {
            procedureName = "SongsUpdate";
            SqlParameter[] param = {
                new SqlParameter("@SongId", obj.IdSong),
                new SqlParameter("@SongName", obj.Name),
                new SqlParameter("@StyleId", obj.Style.IdStyle),
                new SqlParameter("@ArtistId", obj.Artist.IdArtist),
            };
            parameters = param;

            return base.Update(obj);
        }

        public override int Remove(int id)
        {
            procedureName = "SongsRemove";
            SqlParameter[] param = {
                new SqlParameter("@SongId", id),                
            };
            parameters = param;

            return base.Remove(id);
        }

        public override Func<SqlDataReader, IEnumerable<Song>> GetData() {

            return (SqlDataReader reader) =>
            {
                var results = new List<Song>();

                while (reader.Read())
                {
                    var song = new Song
                    {
                        IdSong = (int)reader["IdSong"],
                        Artist = new Artist
                        {
                            IdArtist = (int)reader["IdArtist"],
                            Name = (string)reader["Artist"]
                        },
                        Name = (string)reader["Name"],
                        Style = new Style
                        {
                            IdStyle = (int)reader["IdStyle"],
                            Name = (string)reader["Style"]
                        }
                    };

                    results.Add(song);
                }

                return results;
            };
        }
    }
}
