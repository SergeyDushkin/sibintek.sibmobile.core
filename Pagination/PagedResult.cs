namespace sibintek.sibmobile.core
{
    public class PagedResult : IPaged
    {
        public int CurrentPage { get; }
        public int ResultsPerPage { get; }
        public int TotalPages { get; }
        public long TotalResults { get; }

        protected PagedResult()
        {
            
        }

        protected PagedResult(int currentPage, int resultsPerPage,
            int totalPages, long totalResults)
        {
            CurrentPage = currentPage > totalPages ? totalPages : currentPage;
            ResultsPerPage = resultsPerPage;
            TotalPages = totalPages;
            TotalResults = totalResults;
        }
    }
}
