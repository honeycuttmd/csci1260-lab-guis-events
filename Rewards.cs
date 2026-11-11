namespace GuiEventsLab;

/// <summary>
/// Tracks completed drinks and announces when a customer earns a free drink.
/// </summary>
public class Rewards
{
    public const int DrinksPerReward = 3;
    private readonly Dictionary<string, int> drinks = new Dictionary<string, int>();
    public event EventHandler<OrderEventArgs>? FreeDrinkEarned;

    /// <summary>
    /// Returns the number of completed drinks for a customer.
    /// </summary>
    /// <param name="customer">The customer to look up.</param>
    /// <returns>The number of completed drinks for the customer.</returns>
    public int DrinksFor(string customer)
    {
        return drinks.GetValueOrDefault(customer);
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
    /// Counts completed drinks and announces every third drink for a customer.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The order information associated with the event.</param>
    private void OnOrderReady(object? sender, OrderEventArgs e)
    {
        string customer = e.Order.Customer;

        if (drinks.ContainsKey(customer))
        {
            drinks[customer]++;
        }
        else
        {
            drinks[customer] = 1;
        }

        if (drinks[customer] % DrinksPerReward == 0)
        {
            FreeDrinkEarned?.Invoke(this, e);
        }
    }
}
