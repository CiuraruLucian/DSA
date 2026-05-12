using System;
using System.Collections.Generic;

public class Program
{
    static int passed = 0;
    static int failed = 0;

    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("========== ADVANCED QUEUE TESTING ==========\n");
        Console.ResetColor();

        TestBasicFIFO();
        TestPeek();
        TestEmptyQueue();
        TestRandomized();
        StressTest();

        Console.WriteLine("\n===========================================");

        if (failed == 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"ALL TESTS PASSED ({passed} tests)");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"TESTS FAILED -> Passed: {passed}, Failed: {failed}");
        }

        Console.ResetColor();
    }

    // =====================================================
    // ASSERT METHOD
    // =====================================================
    static void AssertEqual(int expected, int actual, string testName)
    {
        if (expected == actual)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[PASS] {testName}");
            passed++;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"[FAIL] {testName}");
            Console.WriteLine($"       Expected: {expected}");
            Console.WriteLine($"       Actual:   {actual}");

            failed++;
        }

        Console.ResetColor();
    }

    static void AssertTrue(bool condition, string testName)
    {
        if (condition)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[PASS] {testName}");
            passed++;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[FAIL] {testName}");
            failed++;
        }

        Console.ResetColor();
    }

    // =====================================================
    // TEST 1 - FIFO
    // =====================================================
    static void TestBasicFIFO()
    {
        Console.WriteLine("\n=== FIFO TEST ===");

        IQueue queue = new QueueStack();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        queue.Print();
        Console.WriteLine("Test");
        AssertEqual(10, queue.Dequeue(), "FIFO #1");
        AssertEqual(20, queue.Dequeue(), "FIFO #2");
        AssertEqual(30, queue.Dequeue(), "FIFO #3");

    }

    // =====================================================
    // TEST 2 - PEEK
    // =====================================================
    static void TestPeek()
    {
        Console.WriteLine("\n=== PEEK TEST ===");

        IQueue queue = new QueueStack();

        queue.Enqueue(99);

        AssertEqual(99, queue.Peek(), "Peek returns first element");
        AssertEqual(99, queue.Dequeue(), "Peek does not remove element");
    }

    // =====================================================
    // TEST 3 - EMPTY QUEUE
    // =====================================================
    static void TestEmptyQueue()
    {
        Console.WriteLine("\n=== EMPTY QUEUE TEST ===");

        IQueue queue = new QueueStack();

        AssertTrue(queue.isEmpty(), "Queue starts empty");

        queue.Enqueue(1);

        AssertTrue(!queue.isEmpty(), "Queue not empty after enqueue");

        queue.Dequeue();

        AssertTrue(queue.isEmpty(), "Queue empty after dequeue");

        try
        {
            queue.Dequeue();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[FAIL] Dequeue on empty queue should throw exception");
            Console.ResetColor();

            failed++;
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[PASS] Exception thrown on empty dequeue");
            Console.ResetColor();

            passed++;
        }
    }

    // =====================================================
    // TEST 4 - RANDOMIZED TEST
    // =====================================================
    static void TestRandomized()
    {
        Console.WriteLine("\n=== RANDOMIZED TEST ===");

        IQueue customQueue = new QueueStack();
        Queue<int> realQueue = new Queue<int>();

        Random rnd = new Random();

        for (int i = 0; i < 100000; i++)
        {
            int action = rnd.Next(2);

            if (action == 0)
            {
                int value = rnd.Next(100000);

                customQueue.Enqueue(value);
                realQueue.Enqueue(value);
            }
            else
            {
                if (realQueue.Count == 0)
                    continue;

                int expected = realQueue.Dequeue();
                int actual = customQueue.Dequeue();

                if (expected != actual)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine($"\n[FAIL] RANDOMIZED TEST FAILED");
                    Console.WriteLine($"Operation: {i}");
                    Console.WriteLine($"Expected: {expected}");
                    Console.WriteLine($"Actual:   {actual}");

                    Console.ResetColor();

                    failed++;
                    return;
                }
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[PASS] Randomized test");
        Console.ResetColor();

        passed++;
    }

    // =====================================================
    // TEST 5 - STRESS TEST
    // =====================================================
    static void StressTest()
    {
        Console.WriteLine("\n=== STRESS TEST ===");

        IQueue queue = new QueueStack();

        try
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < 1_000_000; i++)
            {
                int value = queue.Dequeue();

                if (value != i)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("[FAIL] Stress test");
                    Console.WriteLine($"Expected: {i}");
                    Console.WriteLine($"Actual:   {value}");

                    Console.ResetColor();

                    failed++;
                    return;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[PASS] Stress test");
            Console.ResetColor();

            passed++;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("[FAIL] Stress test exception");
            Console.WriteLine(ex.Message);

            Console.ResetColor();

            failed++;
        }
    }
}