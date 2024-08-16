namespace ddd_pattern.Events
{
    public class DomainEventDispatcher
    {
        private readonly List<object> _handlers = new List<object>();

        public void RegisterHandler<TEvent>(Action<TEvent> handler)
        {
            _handlers.Add(handler);
        }

        public void Dispatch(IEnumerable<object> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                foreach (var handler in _handlers)
                {
                    if (handler is Action<object> typedHandler)
                    {
                        typedHandler(domainEvent);
                    }
                }
            }
        }
    }
}
