namespace sibintek.sibmobile.core
{
    // https://www.odata.org/documentation/odata-version-2-0/uri-conventions/
    public interface IODataQuery : IQuery
    {
        // 4.5. Filter System Query Option ($filter)
        // Logical Operators
        string Filter { get; }
        string Order { get; }
        int Skip { get; }
        int Limit { get; }
    }
}
