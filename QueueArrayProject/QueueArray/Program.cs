using System;

public class Program
{
    static void Main(string[] args)
    {
        IQueue queue = new ArrayQueue();



        for (int i = 0; i < 101; i++)
        {
            queue.Enqueue(i);
        }

        for (int i = 0; i < 102; i++)
        {
            queue.Dequeue();
        }



        Console.WriteLine("The top element is: " + queue.Peek());

        Console.WriteLine("Popped: " + queue.Dequeue());
        Console.WriteLine("Popped: " + queue.Dequeue());

        Console.WriteLine("The top element is: " + queue.Peek());

        Console.WriteLine("Is empty: " + queue.isEmpty());

        queue.Dequeue();

        Console.WriteLine("Is empty after clearing: " + queue.isEmpty());
    }
}