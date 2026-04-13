public enum EventType { Combat, Discovery, Trap, Rest }
public class Event
{
    public int TurnNumber { get; set; }
    public string Description { get; set; }
    public EventType Type { get; set; }
    public string StatChange { get; set; }

    public override string ToString() => 
        $"[Хід {TurnNumber}] {Type}: {Description} ({StatChange})";
}