public enum CharacterState { Active, Inactive, Dead }


public class Character
{
    public string Name { get; set; }
    public string Role { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public int Gold { get; set; }
    public CharacterState State { get; set; }
    public override string ToString() => 
        $"{Name} ({Role}, Рівень: {Level}) | HP: {HP} | Золото: {Gold} | Стан: {State}";
}