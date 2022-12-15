using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Jones.EntityFrameworkCore.Extensions;

public static class QueryableExtensions
{
    public static async Task<Paging<T>> ToPagingAsync<T>(this IQueryable<T> source,
        int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var totalCount = await source.CountAsync(cancellationToken).ConfigureAwait(false);
        var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToArrayAsync(cancellationToken).ConfigureAwait(false);
        return new Paging<T>(items, page, pageSize, totalCount);
    }
}