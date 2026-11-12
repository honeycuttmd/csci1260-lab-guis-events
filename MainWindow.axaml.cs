using Avalonia.Controls;
using Avalonia.Interactivity;

namespace GuiEventsLab;

/// <summary>
/// Displays the coffee bar and handles order placement and pickup events.
/// </summary>
public partial class MainWindow : Window
{
    private readonly CoffeeBar bar = new CoffeeBar();
    private readonly Rewards rewards = new Rewards();

    /// <summary>
    /// Initializes the window and subscribes to coffee bar events.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();

        bar.OrderPlaced += OnOrderPlaced;
        bar.OrderReady += OnOrderReady;
        bar.AllCaughtUp += OnAllCaughtUp;

        CustomerBox.TextChanged += Boxes_TextChanged;
        DrinkBox.TextChanged += Boxes_TextChanged;

        rewards.Connect(bar);
        rewards.FreeDrinkEarned += OnFreeDrinkEarned;

        UpdateButtons();
    }

    /// <summary>
    /// Places an order using the customer and drink entered in the text boxes.
    /// </summary>
    /// <param name="sender">The button that raised the event.</param>
    /// <param name="e">The button click event arguments.</param>
    private void PlaceButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            bar.Place(CustomerBox.Text ?? "", DrinkBox.Text ?? "");

            CustomerBox.Text = "";
            DrinkBox.Text = "";
            StatusText.Text = "";
        }
        catch (ArgumentException ex)
        {
            StatusText.Text = ex.Message;
        }
    }

    /// <summary>
    /// Finishes the next waiting order.
    /// </summary>
    /// <param name="sender">The button that raised the event.</param>
    /// <param name="e">The button click event arguments.</param>
    private void ReadyButton_Click(object? sender, RoutedEventArgs e)
    {
        bar.FinishNext();
    }

    /// <summary>
    /// Updates the waiting list when a new order is placed.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The order information associated with the event.</param>
    private void OnOrderPlaced(object? sender, OrderEventArgs e)
    {
        ShowWaiting();
        UpdateButtons();
    }

    /// <summary>
    /// Adds a completed order to the pickup list and refreshes the waiting list.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The order information associated with the event.</param>
    private void OnOrderReady(object? sender, OrderEventArgs e)
    {
        PickupList.Items.Add($"#{e.Order.Number} {e.Order.Customer}");

        ShowWaiting();
        UpdateButtons();
    }

    /// <summary>
    /// Displays a message when all waiting orders have been completed.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The event arguments.</param>
    private void OnAllCaughtUp(object? sender, EventArgs e)
    {
        StatusText.Text = "All caught up.";
    }

    /// <summary>
    /// Refreshes the waiting list to show all orders currently in the queue.
    /// </summary>
    private void ShowWaiting()
    {
        WaitingList.Items.Clear();

        foreach (Order order in bar.Waiting())
        {
            WaitingList.Items.Add(order.ToString());
        }
    }

    /// <summary>
    /// Updates the Place and Ready buttons based on the current input and waiting orders.
    /// </summary>
    private void UpdateButtons()
    {
        PlaceButton.IsEnabled =
            !string.IsNullOrWhiteSpace(CustomerBox.Text) &&
            !string.IsNullOrWhiteSpace(DrinkBox.Text);

        ReadyButton.IsEnabled = bar.WaitingCount > 0;
    }

    /// <summary>
    /// Updates button states when a customer or drink changes.
    /// </summary>
    /// <param name="sender">The text box that raised the event.</param>
    /// <param name="e">The text changed event arguments.</param>
    private void Boxes_TextChanged(object? sender, TextChangedEventArgs e)
    {
        UpdateButtons();
    }

    /// <summary>
    /// Displays a notification when a customer earns a free drink.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The order information associated with the event.</param>
    private void OnFreeDrinkEarned(object? sender, OrderEventArgs e)
    {
        RewardText.Text = $"Free drink earned: {e.Order.Customer}";
    }
}