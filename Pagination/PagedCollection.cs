using System.Collections.Generic;
using System.Linq;

namespace sibintek.sibmobile.core
{
    public class PagedCollection<T> : PagedResult, IPagedCollection<T>
    {
        public IEnumerable<T> Items { get; }

        public bool IsEmpty => Items == null || !Items.Any();
        public bool IsNotEmpty => !IsEmpty;

        protected PagedCollection()
        {
            Items = Enumerable.Empty<T>();
        }

        protected PagedCollection(IEnumerable<T> items,
            int currentPage, int resultsPerPage,
            int totalPages, long totalResults) :
                base(currentPage, resultsPerPage, totalPages, totalResults)
        {
            Items = items;
        }

        public static PagedCollection<T> Create(IEnumerable<T> items,
            int currentPage, int resultsPerPage,
            int totalPages, long totalResults)
            => new PagedCollection<T>(items, currentPage, resultsPerPage, totalPages, totalResults);

        public static PagedCollection<T> From(PagedResult result, IEnumerable<T> items)
            => new PagedCollection<T>(items, result.CurrentPage, result.ResultsPerPage,
                result.TotalPages, result.TotalResults);

        public static PagedCollection<T> Empty => new PagedCollection<T>();
    }
}
