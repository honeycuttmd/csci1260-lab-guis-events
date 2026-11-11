// Order: one drink for one customer. The coffee bar numbers each order.
// A blank name or a blank drink is refused with an ArgumentException,
// which is the "throw close to the problem" rule from the exceptions lecture.
namespace GuiEventsLab;

public class Order
{
    public int Number { get; }
    public string Customer { get; }
    public string Drink { get; }

    public Order(int number, string customer, string drink)
    {
        if (string.IsNullOrWhiteSpace(customer))
        {
            throw new ArgumentException("Customer name is required.");
        }
        if (string.IsNullOrWhiteSpace(drink))
        {
            throw new ArgumentException("Drink is required.");
        }
        Number = number;
        Customer = customer.Trim();
        Drink = drink.Trim();
    }

    public override string ToString()
    {
        return $"#{Number} {Customer}, {Drink}";
    }
}
