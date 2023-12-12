

using project.models.inventory;

namespace project.models.heroes;

public class BlackWizard : Hero
{
    public BlackWizard(string name, int level, int healthPoints, int magicPoints, string heroType, Weapon weapon, HealthPotion healthPotion) : base(name, level, healthPoints, magicPoints, heroType, weapon, healthPotion)
    {
    }

    public virtual string Attack()
    {
        return $"{this.Name} usou sua magia";
    }
}
