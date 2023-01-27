using System.Data;
using Jones.Utils;

namespace Jones.Extensions;

public static class DataReaderExtensions
{
    public static IEnumerable<T> To<T>(this IDataReader dataReader)
    {
        var mapper = new DataReaderMapper<T>(dataReader);
        while (dataReader.Read())
        {
            yield return mapper.MapFrom(dataReader);
        }
    }
}