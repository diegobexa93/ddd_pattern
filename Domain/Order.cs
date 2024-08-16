namespace ddd_pattern.Domain
{
    public class Order
    {
        public Guid Id { get; private set; }
        public DateTime OrderDate { get; private set; }
        public Customer Customer { get; private set; }

        private List<OrderItem> _orderItems = new List<OrderItem>();

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        //events

        private List<object> _domainEvents = new List<object>();
        public IReadOnlyCollection<object> DomainEvents => _domainEvents.AsReadOnly();

        public Order(Guid id, Customer customer, DateTime orderDate)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Order ID cannot be empty.");

            if (orderDate > DateTime.Now)
                throw new ArgumentException("Order date cannot be in the future.");

            Id = id;
            OrderDate = orderDate;
            Customer = customer;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException(nameof(orderItem));

            _orderItems.Add(orderItem);
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException(nameof(orderItem));

            _orderItems.Remove(orderItem);
        }

        public decimal GetTotalOrderValue()
        {
            return _orderItems.Sum(item => item.GetTotalPrice());
        }

        protected void AddDomainEvent(object eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
