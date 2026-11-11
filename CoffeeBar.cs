namespace GuiEventsLab;

// CoffeeBar: the publisher. It takes orders, makes them in the order they
// arrived, and announces what happened. It never knows who is listening.
//
// Part A. Write Place and FinishNext along with the Session 1 demo.
// Raising AllCaughtUp inside FinishNext is Exercise 1.
public class CoffeeBar
{
    private readonly Queue<Order> waiting = new Queue<Order>();
    private int nextNumber = 1;

    // Given. Raised after an order joins the line.
    public event EventHandler<OrderEventArgs>? OrderPlaced;

    // Given. Raised after an order leaves the line, ready for pickup.
    public event EventHandler<OrderEventArgs>? OrderReady;

    // Given. Raised after the last waiting order is finished. Exercise 1.
    public event EventHandler? AllCaughtUp;

    // Given.
    public int WaitingCount
    {
        get { return waiting.Count; }
    }

    // Given. A copy of the line, oldest first, so callers can show it
    // but not change it.
    public List<Order> Waiting()
    {
        return new List<Order>(waiting);
    }

    // Build the order, put it in line, then announce it. Return the order.
    public Order Place(string customer, string drink)
    {
        // TODO: Part A, demo
        throw new NotImplementedException();
    }

    // Take the oldest order out of line, then announce it. Return the order.
    // Refuse with an InvalidOperationException when nothing is waiting.
    public Order FinishNext()
    {
        // TODO: Part A, demo. Then Exercise 1: announce AllCaughtUp when
        // the order you just finished was the last one in line.
        throw new NotImplementedException();
    }
}
