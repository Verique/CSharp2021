namespace GenericCollectionsLibrary
{
    public interface IMyIterator<out T>
    {
        bool MoveNext();
        T Current { get; }
    }
}