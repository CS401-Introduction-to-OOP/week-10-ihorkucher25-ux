namespace AdventureParty
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. ІНІЦІАЛІЗАЦІЯ ДАНИХ (Команда з Brawl Stars)
            var party = new Party();
            party.AddCharacter(new Character { Name = "Леон", Role = "Асасин", Level = 5, HP = 80, Gold = 150, State = CharacterState.Active });
            party.AddCharacter(new Character { Name = "Спайк", Role = "Стрілець", Level = 5, HP = 100, Gold = 200, State = CharacterState.Active });
            party.AddCharacter(new Character { Name = "Макс", Role = "Підтримка", Level = 6, HP = 30, Gold = 50, State = CharacterState.Active });
            party.AddCharacter(new Character { Name = "Честер", Role = "Асасин", Level = 4, HP = 0, Gold = 500, State = CharacterState.Dead });

            var eventLog = new EventLog();
            eventLog.AddEvent(new Event { TurnNumber = 1, Description = "Команда зайшла на арену Showdown", Type = EventType.Discovery, StatChange = "None" });
            eventLog.AddEvent(new Event { TurnNumber = 2, Description = "Макс зловила кулю, поки пила енергетик", Type = EventType.Trap, StatChange = "-20 HP" });
            eventLog.AddEvent(new Event { TurnNumber = 3, Description = "Честер дістав вибухову коробку замість лікувальної", Type = EventType.Combat, StatChange = "-100 HP, +500 Gold" });

            var methods = new AllMethods();

            // 2. ГОЛОВНИЙ ЦИКЛ ДОДАТКУ (Інтерфейс)
            while (true)
            {
                Console.Clear();
                
                Console.WriteLine("=====================================");
                Console.WriteLine(" 🏆 МЕНЕДЖЕР КОМАНДИ БРАВЛЕРІВ 🏆");
                Console.WriteLine("=====================================");
                Console.WriteLine("1. Показати всіх бійців (IEnumerable)");
                Console.WriteLine("2. Показати лише живих (yield)");
                Console.WriteLine("3. Вивести лог подій арени");
                Console.WriteLine("4. Статистика команди (LINQ Aggregation)");
                Console.WriteLine("5. Групування за класами (LINQ GroupBy)");
                Console.WriteLine("0. Вийти в головне меню (Вихід)");
                Console.WriteLine("=====================================");
                Console.Write("Оберіть дію: ");

                string choice = Console.ReadLine();
                Console.WriteLine(); 

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("=== УСІ БРАВЛЕРИ ===");
                        foreach (var c in party) Console.WriteLine(c);
                        break;

                    case "2":
                        Console.WriteLine("=== АКТИВНІ БІЙЦІ ===");
                        foreach (var c in methods.GetCharactersByState(party, CharacterState.Active)) 
                            Console.WriteLine($"{c.Name} ({c.Role}) - HP: {c.HP}");
                        break;

                    case "3":
                        Console.WriteLine("=== ЛОГ АРЕНИ ===");
                        foreach (var ev in eventLog) Console.WriteLine(ev);
                        break;

                    case "4":
                        Console.WriteLine("=== СТАТИСТИКА ===");
                        Console.WriteLine($"Найбільше золота в інвентарі: {methods.GetRichestCharacter(party)}");
                        Console.WriteLine($"Бійців з низьким HP (<50): {methods.GetDamagedCount(party)}");
                        break;

                    case "5":
                        Console.WriteLine("=== РОЗПОДІЛ ЗА КЛАСАМИ ===");
                        var stats = methods.GetRoleStatistics(party);
                        foreach (var stat in stats)
                        {
                            Console.WriteLine($" - Клас '{stat.Key}': {stat.Value} бійців");
                        }
                        break;

                    case "0":
                        Console.WriteLine("Гру завершено! До зустрічі на арені.");
                        return;

                    default:
                        Console.WriteLine("Помилка! Такої команди немає. Спробуйте ще раз.");
                        break;
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу для повернення в меню...");
                Console.ReadKey();
            }
        }
    }
}