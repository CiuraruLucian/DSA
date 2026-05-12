public interface IQueue
{
    void Enqueue(int value);
    int Dequeue();
    int Peek();
    bool isEmpty();
}