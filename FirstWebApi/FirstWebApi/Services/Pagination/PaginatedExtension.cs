using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Services.Pagination
{
    public static class PaginatedExtension
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination : class
       => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);

    }
}
