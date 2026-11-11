using Avalonia.Controls;
using Avalonia.Interactivity;

namespace GuiEventsLab;

// MainWindow: the code behind the window. It shows the coffee bar and asks
// it to do things. Every decision about orders stays in CoffeeBar.
//
// Part C and Part D are written along with the Session 2 demos.
// Exercise 3 and Exercise 4 are yours.
public partial class MainWindow : Window
{
    private readonly CoffeeBar bar = new CoffeeBar();

    public MainWindow()
    {
        InitializeComponent();

        // TODO: Part C, demo. Subscribe to bar.OrderPlaced.

        // TODO: Exercise 3. Subscribe to bar.OrderReady and bar.AllCaughtUp.

        // TODO: Part D, demo. Subscribe to TextChanged on both boxes,
        // then set the buttons for an empty window.

        // TODO: Exercise 4. Connect a Rewards object to the bar and
        // subscribe to its FreeDrinkEarned event.
    }

    // Write the click handlers, the event handlers, and the helper
    // methods below this line.
}
