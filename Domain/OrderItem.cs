namespace ddd_pattern.Domain
{
    public class OrderItem
    {
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }

        public OrderItem(Guid productId, string productName, decimal unitPrice, int quantity)
        {
            if (productId == Guid.Empty)
                throw new ArgumentException("Product ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("Product name cannot be empty.");

            if (unitPrice <= 0)
                throw new ArgumentException("Unit price must be greater than zero.");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public decimal GetTotalPrice()
        {
            return UnitPrice * Quantity;
        }
    }
}
