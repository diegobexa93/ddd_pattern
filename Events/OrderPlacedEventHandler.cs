using ddd_pattern.Domain;

namespace ddd_pattern.Events
{
    public class OrderPlacedEventHandler
    {
        public void Handle(OrderPlacedEvent orderPlacedEvent)
        {
            //logic event

            Console.WriteLine($"Order with ID {orderPlacedEvent.OrderId} was placed at {orderPlacedEvent.OccurredOn}.");
        }
    }
}
