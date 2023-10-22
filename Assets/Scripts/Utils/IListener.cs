
using System.Collections;

/// <summary>
/// The listener subscribes to a list of listeners, and he is notified when an event happens.
/// </summary>
public interface IListener
{
    void Subscribe(ICollection listeners);

    void Unsubscribe(ICollection listeners);
}
