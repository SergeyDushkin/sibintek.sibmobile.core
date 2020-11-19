namespace sibintek.sibmobile.Domain
{
    public interface IHierarchy<T> : IWithOuterKey<T>
    {
        T ParentKey { get; set; }
        bool HasChild { get; set; }
    }
}
