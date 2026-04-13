// using System.Collections;
// using System.Collections.Generic;
// public class Party : IEnumerable<Character>
// {
//     private readonly List<Character> _characters = new List<Character>();
//     public void AddCharacter(Character character)
//     {
//         _characters.Add(character);
//     }
//     public IEnumerator<Character> GetEnumerator()
//     {
//         foreach (var character in _characters)
//         {
//             yield return character; 
//         }
//     }

//     IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


//     public IEnumerable<Character> GetActiveCharacters()
//     {
//         foreach (var character in _characters)
//         {
//             if (character.State == CharacterState.Active)
//             {
//                 yield return character;
//             }
//         }
//     }

//     public IEnumerable<Character> GetCharactersWithLowHP(int threshold)
//     {
//         foreach (var character in _characters)
//         {
//             if (character.HP < threshold && character.State != CharacterState.Dead)
//             {
//                 yield return character;
//             }
//         }
//     }
// }

// public class EventLog : IEnumerable<Event>
// {
//     private readonly List<Event> _events = new List<Event>();

//     public void AddEvent(Event ev)
//     {
//         _events.Add(ev);
//     }

//     public IEnumerator<Event> GetEnumerator()
//     {
//         foreach (var ev in _events)
//         {
//             yield return ev;
//         }
//     }

//     IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

//     public IEnumerable<Event> GetEventsByType(EventType type)
//     {
//         foreach (var ev in _events)
//         {
//             if (ev.Type == type)
//             {
//                 yield return ev;
//             }
//         }
//     }

//     public IEnumerable<Event> GetLastNEvents(int n)
//     {
//         int startIndex = Math.Max(0, _events.Count - n);
//         for (int i = startIndex; i < _events.Count; i++)
//         {
//             yield return _events[i];
//         }
//     }
// }