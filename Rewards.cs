namespace GuiEventsLab;

// Rewards: a subscriber that is also a publisher. It counts finished drinks
// for each customer and announces FreeDrinkEarned on every third one.
//
// Exercise 2. Write Connect and a private handler named OnOrderReady.
public class Rewards
{
    public const int DrinksPerReward = 3;

    private readonly Dictionary<string, int> drinks = new Dictionary<string, int>();

    // Given. Raise it with the same OrderEventArgs the bar sent you.
    public event EventHandler<OrderEventArgs>? FreeDrinkEarned;

    // Given.
    public int DrinksFor(string customer)
    {
        return drinks.GetValueOrDefault(customer);
    }

    // Subscribe your handler to the bar's OrderReady event.
    public void Connect(CoffeeBar bar)
    {
        // TODO: Exercise 2
        throw new NotImplementedException();
    }

    // TODO: Exercise 2. Write the handler here. Add one to the customer's
    // count, and when the count reaches a multiple of DrinksPerReward,
    // raise FreeDrinkEarned.
}
