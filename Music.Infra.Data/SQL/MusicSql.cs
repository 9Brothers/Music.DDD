using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Infra.Data.SQL
{
    public class MusicSql<T>
    {
        public static T Run(string procedureName, SqlParameter[] parameters, Func<SqlDataReader, dynamic> funcao)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBMUSIC"].ConnectionString))
            {
                foreach (var parameter in parameters)
                {
                    if (parameter.Value == null)
                    {
                        parameter.Value = DBNull.Value;
                    }
                }

                var command = new SqlCommand(procedureName, connection);
                command.Parameters.AddRange(parameters);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    var result = funcao(reader);

                    connection.Close();
                    connection.Dispose();

                    return result;
                }
            }
        }
    }
}
