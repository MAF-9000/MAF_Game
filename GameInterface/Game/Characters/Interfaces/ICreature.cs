namespace GameInterface.Game.Characters.Interfaces
{
    public interface ICreature
    {
        public string Name { get; }
        public int Level { get; }
        public  int Attack { get; }
        public  int Protection { get; }
        public int Health { get; }
        public bool IsAlive { get; }
        public  void GetDamage(int damage);
        public void GetExperience(int randomExperience);
        public void LevelUp();
        public bool Battle(ICreature enemy);
        public void CharacterState();
    }
}
