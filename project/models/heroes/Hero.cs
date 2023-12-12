
using project.models.enemies;
using project.models.inventory;

namespace project.models.heroes;

public abstract class Hero
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int HealthPoints { get; set; }
    public int MagicPoints { get; set; }
    public string HeroType { get; set; }
    public Weapon Weapon { get; set; }
    public HealthPotion HealthPotion { get; set; }

    public Hero(string name, int level, int healthPoints, int magicPoints, string heroType, Weapon weapon, HealthPotion healthPotion)
    {
        this.Name = name;
        this.Level = level;
        this.HealthPoints = healthPoints;
        this.MagicPoints = magicPoints;
        this.HeroType = heroType;
        this.Weapon = weapon;
        this.HealthPotion = healthPotion;
    }

    public override string ToString()
    {
        return $"Name: {this.Name} \n" +
        $"Level: {this.Level} \n" +
        $"HealthPoints: {this.HealthPoints} \n" +
        $"MagicPoints: {this.MagicPoints} \n" +
        $"HeroType: {this.HeroType}";

    }

    public string Attack()
    {
        return $"{this.Name} atacou com sua ///";
    }

    public string Attack(Enemy inimigo)
    {
        return $"{this.Name} atacou {inimigo.Name}";
    }
}