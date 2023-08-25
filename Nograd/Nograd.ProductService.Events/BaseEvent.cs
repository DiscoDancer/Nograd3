namespace Nograd.ProductService.Events;

public abstract class BaseEvent
{
    protected BaseEvent(string type)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentNullException(nameof(type));
        }

        this.Type = type;
    }

    public string Type { get; }
}