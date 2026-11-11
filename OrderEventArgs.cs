namespace GuiEventsLab;

/// <summary>
/// Stores the order information passed to event handlers.
/// </summary>
public class OrderEventArgs : EventArgs
{
    public Order Order { get; }

    /// <summary>
    /// Initializes the event arguments with the specified order.
    /// </summary>
    /// <param name="order">The order associated with the event.</param>
    public OrderEventArgs(Order order)
    {
        Order = order;
    }
}
