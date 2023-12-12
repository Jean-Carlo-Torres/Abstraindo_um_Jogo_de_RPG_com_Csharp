
using project.models.inventory;

namespace project.models.heroes;

public class Knight : Hero
{
    public Knight(string name, int level, int healthPoints, int magicPoints, string heroType, Weapon weapon, HealthPotion healthPotion) : base(name, level, healthPoints, magicPoints, heroType, weapon, healthPotion)
    {
    }

    public virtual string Defense()
    {
        return $"{this.Name} defendeu com seu escudo!";
    }
}
