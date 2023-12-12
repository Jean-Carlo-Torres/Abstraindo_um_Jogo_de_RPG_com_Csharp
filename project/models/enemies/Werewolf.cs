
namespace project.models.enemies;

public class Werewolf : Enemy
{

    public Werewolf(string name, int health, int damage, int level, string elementaldamage) : base(name, health, damage, level, elementaldamage)
    {
    }

    public virtual string Attack()
    {
        return $"{this.Name} atacou e inflingiu {this.Damage} de dano, causando status de {this.Elementaldamage}";
    }


}

