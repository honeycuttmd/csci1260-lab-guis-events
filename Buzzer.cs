namespace GuiEventsLab;

/// <summary>
/// Records drink notifications and allows them to be enabled or disabled.
/// </summary>
public class Buzzer
{
    private readonly List<string> messages = new List<string>();

    /// <summary>
    /// Returns a copy of the buzzer messages.
    /// </summary>
    /// <returns>A list of drink notifications.</returns>
    public List<string> Messages()
    {
        return new List<string>(messages);
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
    /// Unsubscribes from the coffee bar's OrderReady event.
    /// </summary>
    /// <param name="bar">The coffee bar to stop listening to.</param>
    public void Disconnect(CoffeeBar bar)
    {
        bar.OrderReady -= OnOrderReady;
    }

    /// <summary>
    /// Adds a buzzer message when an order is ready.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The order information associated with the event.</param>
    private void OnOrderReady(object? sender, OrderEventArgs e)
    {
        messages.Add($"Buzz: {e.Order.Customer}, your {e.Order.Drink} is ready.");
    }
}
