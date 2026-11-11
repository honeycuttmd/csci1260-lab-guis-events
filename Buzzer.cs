namespace GuiEventsLab;

// Buzzer: a subscriber that can also stop listening. It records the
// messages a customer's phone would show, like
// "Buzz: Ada, your latte is ready."
//
// Part B. Write Connect, Disconnect, and OnOrderReady along with the
// Session 1 demo.
public class Buzzer
{
    private readonly List<string> messages = new List<string>();

    // Given.
    public List<string> Messages()
    {
        return new List<string>(messages);
    }

    public void Connect(CoffeeBar bar)
    {
        // TODO: Part B, demo
        throw new NotImplementedException();
    }

    // Unsubscribe with the same method that subscribed.
    public void Disconnect(CoffeeBar bar)
    {
        // TODO: Part B, demo
        throw new NotImplementedException();
    }

    private void OnOrderReady(object? sender, OrderEventArgs e)
    {
        // TODO: Part B, demo
        throw new NotImplementedException();
    }
}
