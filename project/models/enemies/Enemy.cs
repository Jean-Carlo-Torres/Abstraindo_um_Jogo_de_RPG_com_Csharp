
namespace project.models.enemies;

public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Level { get; set; }
    public string Elementaldamage {get; set;}

    public Enemy(string name, int health, int damage, int level, string elementaldamage){
        this.Name = name;
        this.Health = health;
        this.Damage = damage;
        this.Level = level;
        this.Elementaldamage = elementaldamage;
    }

   public string Attack()
    {
        return $"{this.Name} atacou e inflingiu {this.Damage} de dano";
    }
}