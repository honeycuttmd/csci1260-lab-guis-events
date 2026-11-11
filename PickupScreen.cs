namespace GuiEventsLab;

// PickupScreen: a subscriber. It listens for OrderReady and keeps the
// lines the screen above the counter would show, like "Ready: #1 Ada".
//
// Part B. Write Connect and OnOrderReady along with the Session 1 demo.
public class PickupScreen
{
    private readonly List<string> lines = new List<string>();

    // Given.
    public List<string> Lines()
    {
        return new List<string>(lines);
    }

    // Subscribe OnOrderReady to the bar's OrderReady event.
    public void Connect(CoffeeBar bar)
    {
        // TODO: Part B, demo
        throw new NotImplementedException();
    }

    // Runs every time the bar raises OrderReady.
    private void OnOrderReady(object? sender, OrderEventArgs e)
    {
        // TODO: Part B, demo
        throw new NotImplementedException();
    }
}
