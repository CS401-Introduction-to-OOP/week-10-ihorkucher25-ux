public class AllMethods
{
    public IEnumerable<Character> GetActiveCharacters(IEnumerable<Character> characters)
    {
        foreach (var character in characters)
        {
            if (character.State == CharacterState.Active)
            {
                yield return character;
            }
        }
    }
public IEnumerable<Character> GetCharactersByState(IEnumerable<Character> characters, CharacterState targetState)
{
    foreach (var character in characters)
    {
        if (character.State == targetState)
        {
            yield return character;
        }
    }
}
public IEnumerable<Event> GetLastNEvents(IEnumerable<Event> events, int n)
        {
            var eventList = events.ToList(); 
            int startIndex = Math.Max(0, eventList.Count - n);
            
            for (int i = startIndex; i < eventList.Count; i++)
            {
                yield return eventList[i];
            }
        }

        public IEnumerable<Character> GetCharactersAboveLevel(IEnumerable<Character> characters, int levelThreshold)
        {
            return characters.Where(c => c.Level >= levelThreshold);
        }

        public IEnumerable<Character> SortCharactersByHP(IEnumerable<Character> characters)
        {
            return characters.OrderByDescending(c => c.HP);
        }

        public IEnumerable<string> GetCharacterNames(IEnumerable<Character> characters)
        {
            return characters.Select(c => c.Name);
        }
        public Character GetRichestCharacter(IEnumerable<Character> characters)
        {
            return characters.OrderByDescending(c => c.Gold).FirstOrDefault();
        }
        public int GetDamagedCount(IEnumerable<Character> characters, int hpThreshold = 50)
        {
            return characters.Count(c => c.HP < hpThreshold && c.State != CharacterState.Dead);
        }
        public Dictionary<string, int> GetRoleStatistics(IEnumerable<Character> characters)
        {
            return characters
                .GroupBy(ch => ch.Role)
                .ToDictionary(
                    group => group.Key,     
                    group => group.Count()  
                );
}
}
