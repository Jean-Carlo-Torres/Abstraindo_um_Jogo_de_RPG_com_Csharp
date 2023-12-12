using project.models.enemies;

namespace project.models.inventory
{
    public class Weapon : Item
    {
        public int Damage { get; set; }

        public Weapon(string name, string description, int damage)
        {
            Name = name;
            Description = description;
            Damage = damage;
        }

        public void Attack(Enemy enemy)
        {
            enemy.Health -= Damage;

            Console.WriteLine($"Atacou {enemy.Name} com {Name} e causou {Damage} de dano.");
        }
    }
}
