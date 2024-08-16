namespace ddd_pattern.Domain
{
    public class OrderPlacedEvent
    {
        public Guid OrderId { get; }
        public DateTime OccurredOn { get; }

        public OrderPlacedEvent(Guid orderId)
        {
            OrderId = orderId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
