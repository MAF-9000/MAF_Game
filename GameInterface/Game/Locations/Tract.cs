using GameInterface.Game;
using GameInterface.Game.Characters;
using LordOfTheRings.Characters;

namespace LordOfTheRings.Locations
{
    internal class Tract
    {
        private IRace _player;
        private Location[] locations;
        private string[] humansNames = { "Григор", "Маркон", "Арвин", "Тормунд", "Джек", "Дарден", "Ханк" };
        private string[] orcsNames = { "Лотарум", "Тарзозог", "Азог", "Углук", "Манрок", "Болдог", "Ротаркус" };
        private string[] elfsNames = { "Морниран", "Илридент", "Колориун", "", "Элихаль", "Бранэлхилл", "Гофинмон" };
        private string[] monstersNames = { "Шкилет", "Дракон", "Мертвец", "Медведь", "Троль", "Кентавр", "Джин", "Василиск", "Некромант", "Грифон", "Снежный человек", "Циклоп", "Заяц" };
        private string[] monstersAlias = { "Вонючий", "Кровавый", "Смердящий", "Одноногий", "Быстрый", "Медленный", "Смертоносный", "Пухлый", "в бурундучем помёте", "Милый", "Смертоносный", "Повелитель душ" };


        public string Name
        { get; private set; }

        public Tract()
        {
            Name = "Тракт";
            locations = new Location[3];
        }

        private async Task TractMenu()
        {
            string comand = string.Empty;
            while (_player.IsAlive && _player.Level < 10)
            {
                Cnsl.WriteAction($"1 - Пойти в локацию {locations[0].Name} ");
                Cnsl.WriteAction($"2 - Пойти в локацию {locations[1].Name} ");
                Cnsl.WriteAction($"3 - Пойти в локацию {locations[2].Name} ");
                Cnsl.WriteAction("4 - Посмотреть инвентарь");
                Cnsl.WriteAction($"5 - Посмотреть арактеристики {_player.Name} ");
                Cnsl.WriteAction("6 - Пойти дальше");
                Cnsl.WriteAction("7 - Зайти к торговцу");
                comand = await Cnsl.ReadLine();
                switch (comand)
                {
                    case "1":
                        {
                            await locations[0].GoToLocation(_player);
                        }
                        break;
                    case "2":
                        {
                            await locations[1].GoToLocation(_player);
                        }
                        break;
                    case "3":
                        {
                            await locations[2].GoToLocation(_player);
                        }
                        break;
                    case "4":
                        {
                            await _player.Inventary.InventaryMenu(_player);
                        }
                        break;
                    case "5":
                        {
                            _player.CharacterState();
                        }
                        break;
                    case "6":
                        {
                            UpdateLocation();
                        }
                        break;
                    case "7":
                        {
                            var merchant = new Merchant();
                            await merchant.MerchantMenu(_player);
                        }
                        break;

                }
            }
            if (!_player.IsAlive)
            {
                Cnsl.WriteLine($"{_player.Name} умер, достигнув уровня {_player.Level}.");
                Cnsl.WriteLine("Игра завершена.");
            }
            else
            {
                Cnsl.WriteLine("Поздравляем, Вы выиграли!");
            }


        }
        public async Task GoToTract(IRace player)
        {
            _player = player;
            Cnsl.WriteLine($"Игрок {_player.Name} перешел на локацию {Name}");
            UpdateLocation();
            await TractMenu();
        }

        private void UpdateLocation()
        {
            for (int i = 0; i < locations.Length; i++)
            {
                locations[i] = CreateRandomLocation();
            }
        }

        private Location CreateRandomLocation()
        {
            Location location = new Location(GetRandomLocationName(), CreateRandomEnemy());
            return location;
        }

        private string GetRandomLocationName()
        {
            Random r = new Random();
            string path = "LocationNames.txt";
            var text = File.ReadAllLines(path);
            string locationName, podl, wordTree;
            do
            {
                var locations = text[1].Split('|');
                var index = r.Next(0, 999) % locations.Length;
                locationName = locations[index];

                var words = text[0].Split('|');
                int index1 = r.Next(0, 999) % words.Length;
                podl = words[index1].Split('/')[GetSex(locationName)];

                words = text[2].Split('|');
                index1 = r.Next(0, 999) % words.Length;
                wordTree = words[index1];

            } while (isDuplicateName(locationName) || isDuplicateName(podl.Substring(0, podl.Length - 2)));
            return $"{podl} {locationName} {wordTree}";
        }

        private bool isDuplicateName(string name)
        {
            foreach (var loc in locations)
            {
                if (loc != null && loc.Name.Contains(name))
                    return true;
            }
            return false;
        }
        private int GetSex(string word)
        {
            if (word.EndsWith("е") || word.EndsWith("о"))
            {
                return 2;
            }
            if (word.EndsWith("а") || word.EndsWith("ь") || word.EndsWith("я"))
            {
                return 1;
            }
            return 0;
        }

        private Creature CreateRandomEnemy()
        {
            Random r = new Random();
            var i = r.Next(0, 99);
            Creature result = null;
            var index = r.Next(0, humansNames.Length - 1);
            var levelEnemy = GetEnemyLevel();
            var indexAlias = r.Next(0, monstersAlias.Length - 1);
            switch (i % 6)
            {
                case 0:
                    {
                        result = new Human($"{humansNames[index]} { monstersAlias[indexAlias] }", levelEnemy);
                    }
                    break;
                case 1:
                    {
                        result = new Elf($"{elfsNames[index]} { monstersAlias[indexAlias] }", levelEnemy);
                    }
                    break;
                case 2:
                    {
                        result = new Orc($"{orcsNames[index]} { monstersAlias[indexAlias] }", levelEnemy);
                    }
                    break;
                case 3:
                case 4:
                case 5:
                    {
                        var indexNameMon = r.Next(0, monstersNames.Length - 1);
                        result = new Monster($" {monstersNames[indexNameMon]} {monstersAlias[indexAlias]}", levelEnemy);
                    }

                    break;
            }
            return result;

        }
        private int GetEnemyLevel()
        {
            var minLevel = _player.Level == 1 ? 1 : _player.Level - 1;
            var maxLevel = _player.Level + 1;
            Random random = new Random();
            var result = random.Next(minLevel, maxLevel);
            return result;

        }

    }
}

