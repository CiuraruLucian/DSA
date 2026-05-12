using System;

public class Program
{
    static void Main(string[] arg)
    {
        IStack stack = new ArrayStack();



        for (int i = 0; i < 101; i++)
        {
            stack.Push(i);
        }

        for (int i = 0; i < 102; i++)
        {
            stack.Pop();
        }



        Console.WriteLine("The top element is: " + stack.Peek());

        Console.WriteLine("Popped: " + stack.Pop());
        Console.WriteLine("Popped: " + stack.Pop());

        Console.WriteLine("The top element is: " + stack.Peek());

        Console.WriteLine("Is empty: " + stack.isEmpty());

        stack.Pop();

        Console.WriteLine("Is empty after clearing: " + stack.isEmpty());
    }
}