using System.Collections.Generic;

namespace sibintek.sibmobile.core
{   
    public interface IPagedCollection<T>: IPaged
    {
        IEnumerable<T> Items { get; }
        bool IsEmpty { get; }
        bool IsNotEmpty { get; }
    }
}
