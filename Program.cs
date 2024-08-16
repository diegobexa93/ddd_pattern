using ddd_pattern.Domain;
using ddd_pattern.Events;
using Newtonsoft.Json;


var address1 = new Address("123 Main St", "Anytown", "CA", "12345", "USA");
var address2 = new Address("456 Maple Ave", "Othertown", "NY", "67890", "USA");

var customer = new Customer(Guid.NewGuid(), "John Doe", address1);

// Change customer's address
customer.ChangeAddress(address2);

// Verify immutability and equality
var address3 = new Address("123 Main St", "Anytown", "CA", "12345", "USA");
bool areEqual = address1.Equals(address3); // true

//new order
var order = new Order(Guid.NewGuid(), customer, DateTime.Now);
order.AddOrderItem(new OrderItem(Guid.NewGuid(), "productA", 50, 100));
order.AddOrderItem(new OrderItem(Guid.NewGuid(), "productB", 20, 100));
order.AddOrderItem(new OrderItem(Guid.NewGuid(), "productC", 30, 100));
order.AddOrderItem(new OrderItem(Guid.NewGuid(), "productD", 10, 100));
order.AddOrderItem(new OrderItem(Guid.NewGuid(), "productE", 5,  100));

string output = JsonConvert.SerializeObject(order, Formatting.Indented);


Console.WriteLine(output);

Console.WriteLine("Send Event");



// Configura o dispatcher de eventos de domínio
var dispatcher = new DomainEventDispatcher();
dispatcher.RegisterHandler<OrderPlacedEvent>(new OrderPlacedEventHandler().Handle);

// Despacha eventos de domínio associados à ordem
dispatcher.Dispatch(order.DomainEvents);

// Limpa eventos de domínio após o despacho
order.ClearDomainEvents();