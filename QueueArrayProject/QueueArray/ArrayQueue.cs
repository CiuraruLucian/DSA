using System;

public class ArrayQueue : IQueue
{
    private const int initialSize = 100;
    private int[] arrayQueue = new int[initialSize];
    int top = 0;

    public void Enqueue(int value)
    {
        if (top < arrayQueue.Length)
        {
            arrayQueue[top] = value;
            top++;
        }
        else
        {
            int[] newArray = new int[initialSize * 2];
            Array.Copy(arrayQueue, newArray, initialSize);
            arrayQueue = newArray;
            arrayQueue[top] = value;
            top++;
        }
    }

    public int Dequeue()
    {
        if (!isEmpty())
        {
            top--;
            return arrayQueue[top];
        }
        else
        {
            Console.WriteLine("The array is empty!");
            return -1;
        }
    }

    public int Peek()
    {
        if (!isEmpty())
        {
            return arrayQueue[top - 1];
        }
        else
        {
            Console.WriteLine("The array is empty!");
            return -1;
        }
    }

    public bool isEmpty()
    {
        return top == 0;
    }
}