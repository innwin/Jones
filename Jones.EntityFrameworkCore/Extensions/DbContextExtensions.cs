using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Jones.EntityFrameworkCore.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Jones.EntityFrameworkCore.Extensions
{
    // https://github.com/devel0/netcore-ef-util
    public static class DbContextExtensions
    {

        public static List<T> SqlQuery<T>(this DbContext context, string query, ILogger logger = null)
        {
            return SqlQuery<T>(context, query, logger, null);
        }

        public static List<T> SqlQuery<T>(this DbContext context, string query, params SqlParameter[] sqlParams)
        {
            return SqlQuery<T>(context, query, null, sqlParams);
        }

        /// <summary>
        /// execute Raw SQL queries: Non-model types
        /// https://github.com/aspnet/EntityFrameworkCore/issues/1862
        /// </summary>
        public static List<T> SqlQuery<T>(this DbContext context, string query, ILogger logger, params SqlParameter[] sqlParams)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                if (sqlParams != null) command.Parameters.AddRange(sqlParams);
                context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    var list = new List<T>();
                    var mapper = new DataReaderMapper<T>(result);

                    while (result.Read())
                    {
                        list.Add(mapper.MapFrom(result));
                    }

                    sw.Stop();
                    logger?.LogInformation($"Executed ({sw.ElapsedMilliseconds}ms)");
                    logger?.LogInformation($"{query}");

                    return list;
                }
            }
        }

    }

}
