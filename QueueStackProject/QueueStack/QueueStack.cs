using System;
using System.Collections.Generic;

public class QueueStack : IQueue
{
    private const int initialSize = 100;
    private Stack<int> stack = new Stack<int>(initialSize);


    public void Enqueue(int value)
    {


        stack.Push(value);


    }

    public int Dequeue()
    {
        // daca isEmpty este adevarat printez un mesaj si returnez -1
        // daca stack ul nu este empty scot valoare de jos fara sa modific stack ul in alta parte
        //dupa returnez valoarea urmatoare
        if (isEmpty())
        {
            Console.WriteLine("The stack is empty !");
            return -1;
        }
        int[] tempArray = stack.ToArray();
        int bottomElement = tempArray[tempArray.Length - 1];
        while (stack.Count > 0)
        {
            stack.Pop();
        }
    }

    public int Peek()
    {
        if (!isEmpty())
        {
            return (int)stack.Peek();
        }
        else
        {
            Console.WriteLine("The stack is empty!");
            return -1;
        }
    }

    public bool isEmpty()
    {
        return stack.Count == 0;
    }
    public void Print()
    {
        int[] stackArray = stack.ToArray();
        for (int i = 0; i < stackArray.Length; i++)
        {
            Console.WriteLine($"Element {i}: {stackArray[i]}");
        }

    }
}
