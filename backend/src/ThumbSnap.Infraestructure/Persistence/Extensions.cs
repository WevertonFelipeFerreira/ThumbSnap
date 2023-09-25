using Microsoft.EntityFrameworkCore;
using ThumbSnap.Domain.Entities.Common;
using ThumbSnap.Domain.Models;

namespace ThumbSnap.Infraestructure.Persistence
{
    //TODO: Create utils project and extract the methods bellow to your respective types
    public static class Extensions
    {
        public static async Task<PaginationResult<T>> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PaginationResult<T>();

            result.Page = page;
            result.PageSize = pageSize;
            result.ItemsCount = await query.CountAsync();

            var pageCount = (double)result.ItemsCount / pageSize;
            result.TotalPages = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;

            result.Data = await query
                                .Skip(skip)
                                .Take(pageSize)
                                .ToListAsync();

            return result;
        }

        public static IQueryable<T> SetWithIncludes<T>(this IQueryable<T> query, string? navigationPropertiesPath) where T : EntityBase
        {
            List<string> includes;

            if (navigationPropertiesPath is not null)
            {
                includes = navigationPropertiesPath.Split(";").ToList();
                if (includes.Any())
                {
                    foreach (var property in includes)
                    {
                        query = query.Include(property);
                    }
                }
            }

            return query;
        }
    }
}
