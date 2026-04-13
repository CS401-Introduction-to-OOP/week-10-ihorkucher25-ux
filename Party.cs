using System.Collections;
using System.Collections.Generic;
public class Party : IEnumerable<Character>
{
    private readonly List<Character> _characters = new List<Character>();
    public void AddCharacter(Character character)
    {
        _characters.Add(character);
    }
    public IEnumerator<Character> GetEnumerator()
    {
        foreach (var character in _characters)
        {
            yield return character; 
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}