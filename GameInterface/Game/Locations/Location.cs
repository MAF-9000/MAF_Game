using GameInterface.Game;
using GameInterface.Game.Characters;
using LordOfTheRings.Characters;
using LordOfTheRings.Items;

namespace LordOfTheRings.Locations
{
    internal class Location
    {
        public IRace Player;

        private bool victory = false;
        private int _gold = 0;
        public string Name
        { get; private set; }
        public Creature Enemy
        { get; private set; }
        public IItem[] Loot
        { get; private set; }
        public int Gold
        {
            get
            {
                return _gold;
            }
            private set
            {
            
                if(value < 0)
                {
                    _gold = 0;
                }
                else
                {
                    _gold = value;
                }
            }
        }

        public Location(string name, Creature enemy)
        {
            Name = name;
            Enemy = enemy;
            Random random = new Random();
            var lootcount = random.Next(1, 3);
            var goldcount = random.Next(-25, 25);
            Gold = goldcount;
            Loot = new IItem[lootcount];
            Cnsl.WriteLine($"Обнаружена локация - {Name}");
            for (int i = 0; i < lootcount; i++)
            {
                Loot[i] = ItemFabric.CreateRandomItem();
            }
        }

        public async Task GoToLocation(IRace player)
        {
            Player = player;
            Cnsl.WriteLine($"Игрок {Player.Name} перешел на локацию {Name}");
            Cnsl.WriteLine("");
            if (Enemy.IsAlive)
            {
                Cnsl.WriteLine($"Локацию охраняет существо {Enemy.Name}");
                Enemy.CharacterState();
            }
            else
            {
                Cnsl.WriteLine($"{Enemy.Name} мёртв. Локацию никто не охраняет.");
            }
            if (Loot.Length > 0)
            {
                Cnsl.WriteLine("");
                Cnsl.WriteLine($"В локации есть сокровища: ");
                Cnsl.WriteLine($"Золото - {Gold}");
                for (int i = 0; i < Loot.Length; i++)
                {
                    Loot[i].ItemState();
                }

            }
            else
            {
                Cnsl.WriteLine($"В локации нет сокровищ. ");
            }
            Cnsl.WriteLine("");
            await LocationMenu();
        }

        public async Task LocationMenu()
        {
            string comand = string.Empty;
            do
            {
                Cnsl.WriteLine("");
                Cnsl.WriteAction($"1 - Сразиться с {Enemy.Name} ");
                Cnsl.WriteAction("2 - Посмотреть инвентарь");
                Cnsl.WriteAction("3 - Забрать лут");
                Cnsl.WriteAction($"4 - Посмотреть характеристики {Player.Name} ");
                Cnsl.WriteAction("5 - Уйти с локации");

                comand = await Cnsl.ReadLine();
                switch (comand)
                {
                    case "1":
                        {
                            victory = Player.Battle(Enemy);
                        }
                        break;
                    case "2":
                        {
                            Player.Inventary.InventaryMenu(Player);
                        }
                        break;
                    case "3":
                        {
                            if (victory)
                            {
                                foreach (IItem item in Loot)
                                {
                                    Player.Inventary.AddItem(item);
                                    Cnsl.WriteLine($"{Player.Name} взял {item.Name}");

                                }
                                Loot = new IItem[0];
                            }
                        }
                        break;
                    case "4":
                        {
                            Player.CharacterState();
                        }
                        break;
                }
            }
            while (comand != "5" && Player.IsAlive);
        }
    }
}
