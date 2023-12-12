using project.models.heroes;

namespace project.models.inventory;

public class HealthPotion : Item
{
    public HealthPotion(int healingAmount) 
    {
        this.HealingAmount = healingAmount;

    }
            public int HealingAmount { get; set; }
    public HealthPotion(string name, string description, int quantity, int healingAmount)
    {
        Name = name;
        Description = description;
        Quantity = quantity;
        HealingAmount = healingAmount;
    }

    public void Use(Hero target)
    {
        if (Quantity > 0)
        {
            target.HealthPoints += HealingAmount;

            Quantity--;

            Console.WriteLine($"{target.Name} usou {Name} e recuperou {HealingAmount} pontos de vida.");
        }
        else
        {
            Console.WriteLine($"Não há {Name} disponível no inventário.");
        }
    }
}
