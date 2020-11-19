namespace sibintek.sibmobile.core
{   
    public interface IPaged
    {
        int CurrentPage { get; }
        int ResultsPerPage { get; }
        int TotalPages { get; }
        long TotalResults { get; }
    }
}
