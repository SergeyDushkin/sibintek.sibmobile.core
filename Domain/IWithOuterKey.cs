namespace sibintek.sibmobile.Domain
{
    public interface IWithOuterKey<T>
    {
        T OuterKey { get; set; }
    }
}
