using Flunt.Notifications;

namespace Store.Domain.Entities;

public class Base : Notifiable
{
    public Base()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
}
