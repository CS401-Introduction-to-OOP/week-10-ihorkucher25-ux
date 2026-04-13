using System.Collections;
using System.Collections.Generic;
public class EventLog : IEnumerable<Event>
{
    private readonly List<Event> _events = new List<Event>();

    public void AddEvent(Event ev)
    {
        _events.Add(ev);
    }

    public IEnumerator<Event> GetEnumerator()
    {
        foreach (var ev in _events)
        {
            yield return ev;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}