namespace ddd_pattern.Domain
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }

        public Customer(Guid id, string name, Address address)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Customer ID cannot be empty.", nameof(id));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Customer name cannot be empty.", nameof(name));
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            Id = id;
            Name = name;
            Address = address;
        }

        public void ChangeAddress(Address newAddress)
        {
            if (newAddress == null)
                throw new ArgumentNullException(nameof(newAddress));

            Address = newAddress;
        }
    }
}
