using System;

public class ArrayStack : IStack
{
    private const int initialSize = 100;
    private int[] arrayStack = new int[initialSize];
    private int top = 0;

    public void Push(int value)
    {
        if (top < arrayStack.Length)
        {
            arrayStack[top] = value;
            top++;
        }
        else
        {

            int[] newArray = new int[initialSize * 2];
            Array.Copy(arrayStack, newArray, initialSize);
            arrayStack = newArray;
            arrayStack[top] = value;
            top++;
        }
    }

    public int Pop()
    {
        if (!isEmpty())
        {
            top--;
            return arrayStack[top];
        }
        else
        {
            Console.WriteLine("The array is empty!");
            return -1;
        }

    }

    public int Peek()
    {
        return arrayStack[top - 1];
    }

    public bool isEmpty()
    {
        return top == 0;
    }
}
