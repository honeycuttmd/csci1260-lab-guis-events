namespace GuiEventsLab;

/// <summary>
/// Keeps a list of completed orders for the pickup screen.
/// </summary>
public class PickupScreen
{
    private readonly List<string> lines = new List<string>();

    /// <summary>
    /// Returns a copy of the pickup screen messages.
    /// </summary>
    /// <returns>A list of completed order messages.</returns>
    public List<string> Lines()
    {
        return new List<string>(lines);
    }

    /// <summary>
    /// Subscribes to the coffee bar's OrderReady event.
    /// </summary>
    /// <param name="bar">The coffee bar to listen to.</param>
    public void Connect(CoffeeBar bar)
    {
        bar.OrderReady += OnOrderReady;
    }

    /// <summary>
    /// Adds a pickup message when an order is ready.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The order information associated with the event.</param>
    private void OnOrderReady(object? sender, OrderEventArgs e)
    {
        lines.Add($"Ready: #{e.Order.Number} {e.Order.Customer}");
    }
}
