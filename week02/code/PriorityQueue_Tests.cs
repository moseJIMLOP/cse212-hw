using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities to the queue ("Low" with priority 1, "High" with priority 5).
    // Expected Result: Dequeue shouldreturn the item with the highest priority ("High"), regardless of insertion order.
    // Defect(s) Found: The loop condition in Dequeue is 'index < _queue.Count - 1', which causes the loop to skip the last element in the queue. Also, Dequeue fails to remove the returned item from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue(); 
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("high", result);


    }

    [TestMethod]
    // Scenario: Add two items with the same highest priority to the queue ("A" with priority 5, then "B" with priority 5).
    // Expected Result: Dequeue should return "A" first, as it was enqueued first (FIFO tie-breaker rule).
    // Defect(s) Found: The comparison operator in Dequeue uses '>=' instead of '>', which causes it to select the last item added instead of maintaining FIFO order when priorities are equal.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result);
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: try to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown with the message "Queue is empty".
    // Defect(s) Found: The Dequeue method does not check if the queue is empty before searching for elements, failing to throw the required InvalidOperationException.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        var exception = Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();    
        });

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}