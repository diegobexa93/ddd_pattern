namespace ddd_pattern.Domain
{
    public class Address
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }
        public string Country { get; }

        public Address(string street, string city, string state, string zipCode, string country)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street cannot be empty.", nameof(street));
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City cannot be empty.", nameof(city));
            if (string.IsNullOrWhiteSpace(state))
                throw new ArgumentException("State cannot be empty.", nameof(state));
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentException("Zip code cannot be empty.", nameof(zipCode));
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country cannot be empty.", nameof(country));

            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }

        public override bool Equals(object obj)
        {
            if (obj is Address other)
            {
                return Street == other.Street &&
                       City == other.City &&
                       State == other.State &&
                       ZipCode == other.ZipCode &&
                       Country == other.Country;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, City, State, ZipCode, Country);
        }

        public override string ToString()
        {
            return $"{Street}, {City}, {State}, {ZipCode}, {Country}";
        }
    }
}
