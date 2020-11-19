using System.Linq;

namespace sibintek.sibmobile.core
{   
    public static class PaginationExtension
    {
        public static IPagedCollection<T> AsPagination<T>(this IQueryable<T> data, int page = 1, int pageSize = 100)
        {
            page = page.Normalize(1);
            pageSize = pageSize.Normalize(1, 1000);

            var totalCount = data.LongCount();
            var totalPages = (int)(totalCount / pageSize);

            data = data.Skip((page - 1) * pageSize).Take(pageSize);

            return PagedCollection<T>.Create(data, page, pageSize, totalPages, totalCount);
        }

        public static int Normalize(this int value, int min, int max = int.MaxValue)
        {
            value = (value < min) ? min : value;
            value = (value > max) ? max : value;

            return value;
        }
    }
}
