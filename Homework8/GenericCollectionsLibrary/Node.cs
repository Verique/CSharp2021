namespace GenericCollectionsLibrary
{
    public class Node<T>
    {
        public T Data { get; private set; }
        public Node<T> Next { get; set; }

        public Node(T data, Node<T> next)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}