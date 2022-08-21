using GameInterface.Game.Characters;

namespace GameInterface.Game.Items.Armors
{
    internal class HelmetOfMadness : Helmet
    {
        public HelmetOfMadness()
        {

        }

        public void Execute(IRace person)
        {
            person.Helmet = this;
        }

        public void ItemState()
        {
            Cnsl.WriteLine($"Шлем: {Name} с защитой - {Protection}, цена предмета - {Cost} ");
        }
        public string ItemInfo()
        {
            return $"{Name}, защита({Protection}), цена({Cost})";
        }
    }
}
