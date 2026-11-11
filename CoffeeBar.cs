namespace GuiEventsLab;

/// <summary>
/// Manages customer orders and announces changes through events.
/// </summary>
public class CoffeeBar
{
    private readonly Queue<Order> waiting = new Queue<Order>();
    private int nextNumber = 1;
    public event EventHandler<OrderEventArgs>? OrderPlaced;
    public event EventHandler<OrderEventArgs>? OrderReady;
    public event EventHandler? AllCaughtUp;

    public int WaitingCount
    {
        get { return waiting.Count; }
    }

    /// <summary>
    /// Returns a copy of the waiting orders in the order they were placed.
    /// </summary>
    /// <returns>A list of orders currently waiting.</returns>
    public List<Order> Waiting()
    {
        return new List<Order>(waiting);
    }

    /// <summary>
    /// Creates a new order, adds it to the queue, and announces that it was placed.
    /// </summary>
    /// <param name="customer">The name of the customer placing the order.</param>
    /// <param name="drink">The drink being ordered.</param>
    /// <returns>The newly placed order.</returns>
    public Order Place(string customer, string drink)
    {
        Order order = new Order(nextNumber, customer, drink);
        nextNumber++;

        waiting.Enqueue(order);
        OrderPlaced?.Invoke(this, new OrderEventArgs(order));

        return order;
    }

    /// <summary>
    /// Finishes the oldest order and announces when the queue becomes empty.
    /// </summary>
    /// <returns>The order that was completed.</returns>
    public Order FinishNext()
    {
        if (waiting.Count == 0)
        {
            throw new InvalidOperationException("No orders are waiting.");
        }

        Order order = waiting.Dequeue();
        OrderReady?.Invoke(this, new OrderEventArgs(order));

        if (waiting.Count == 0)
        {
            AllCaughtUp?.Invoke(this, EventArgs.Empty);
        }

        return order;
    }
}
