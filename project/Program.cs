using project.models.enemies;
using project.models.heroes;
using project.models.inventory;

namespace project
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            Weapon arusWeapon = new Weapon("Sword", "A sharp sword for slashing", 20);
            Weapon wedgeWeapon = new Weapon("Shuriken", "A throwing star for quick attacks", 15);
            Weapon jenicaWeapon = new Weapon("Staff of Light", "A magical staff emitting light", 25);
            Weapon topapaWeapon = new Weapon("Storm Staff", "A staff that controls the power of storms", 30);

            HealthPotion arusPotion = new HealthPotion("Health Potion", "Restores health", 5, 30);
            HealthPotion wedgePotion = new HealthPotion("Health Potion", "Restores health", 3, 30);
            HealthPotion jenicaPotion = new HealthPotion("Health Potion", "Restores health", 7, 30);
            HealthPotion topapaPotion = new HealthPotion("Health Potion", "Restores health", 4, 30);

            Knight arus = new Knight("Arus", 42, 749, 72, "Knight", arusWeapon, arusPotion);
            Ninja wedge = new Ninja("Wedge", 42, 574, 89, "Ninja", wedgeWeapon, wedgePotion);
            WhiteWizard jenica = new WhiteWizard("Jenica", 42, 601, 482, "White Wizard", jenicaWeapon, jenicaPotion);
            BlackWizard topapa = new BlackWizard("Topapa", 42, 385, 641, "Black Wizard", topapaWeapon, topapaPotion);

            List<Hero> heroes = new List<Hero>
                {
                    arus,
                    wedge,
                    jenica,
                    topapa
                };

            ExibirOpcoesDoMenu();
            void ExibirOpcoesDoMenu()
            {
                Console.WriteLine("\n1 - Iniciar Batalha!");
                Console.WriteLine("2 - Status");
                Console.WriteLine("3 - Inventory");

                Console.Write("\nDigite sua opção: ");
                string opcaoEscolhida = Console.ReadLine()!;
                int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
                switch (opcaoEscolhidaNumerica)
                {
                    case 1:
                        IniciarBatalha();
                        break;
                    case 2:
                        Status();
                        break;
                    case 3:
                        Inventory();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }

            void IniciarBatalha()
            {
                Console.WriteLine("\nBatalha iniciada!");

                Enemy werewolf = new Werewolf("Werewolf", 42, 425, 425, "Werewolf");

                while (AnyHeroAlive(heroes) && werewolf.Health > 0)
                {
                    foreach (var hero in heroes)
                    {
                        if (hero.HealthPoints > 0)
                        {
                            Console.WriteLine($"{hero.Name}'s turno:");

                            if (random.Next(0, 2) == 0)
                            {
                                int damage = random.Next(1, hero.Level * 10);
                                werewolf.Health -= damage;
                                Console.WriteLine($"{hero.Name} atacou e infligiu {damage} de dano");
                            }
                            else
                            {
                                Console.WriteLine($"{hero.Name} errou o ataque!");
                            }
                            
                            if (hero.HealthPoints < hero.HealthPoints / 2)
                            {
                                Console.WriteLine($"{hero.Name} tem menos da metade dos pontos de vida. Deseja usar uma poção? (S/N)");
                                char response = char.ToUpper(Console.ReadKey().KeyChar);
                                if (response == 'S')
                                {
                                    UseHealthPotion(hero);
                                }
                            }

                            if (werewolf.Health <= 0)
                            {
                                Console.WriteLine($"{werewolf.Name} foi derrotado!");
                                PausaEDeclaraVencedor();
                                return;
                            }
                        }
                    }

                    Console.WriteLine($"{werewolf.Name}'s turno:");
                    if (random.Next(0, 2) == 0)
                    {
                        int damage = random.Next(1, werewolf.Level * 10);
                        heroes.ForEach(hero => hero.HealthPoints -= damage);
                        Console.WriteLine($"{werewolf.Name} atacou e infligiu {damage} de dano a todos os heróis");
                    }
                    else
                    {
                        Console.WriteLine($"{werewolf.Name} errou o ataque!");
                    }

                    if (!AnyHeroAlive(heroes))
                    {
                        Console.WriteLine("Todos os heróis foram derrotados!");
                        PausaEDeclaraVencedor();
                        return;
                    }
                    ExibirStatusHeroes();
                }
                PausaEDeclaraVencedor();
            }

            void UseHealthPotion(Hero hero)
            {
                if (hero.HealthPotion != null)
                {
                    int healingAmount = hero.HealthPotion.HealingAmount;
                    hero.HealthPoints += healingAmount;
                    Console.WriteLine($"{hero.Name} usou uma poção de cura e recuperou {healingAmount} pontos de vida.");
                }
                else
                {
                    Console.WriteLine($"{hero.Name} não tem poções de cura.");
                }
            }

            void ExibirStatusHeroes()
            {
                Console.WriteLine("\nStatus dos heróis:");
                foreach (var hero in heroes)
                {
                    Console.WriteLine($"{hero.Name}: Nível {hero.Level}, PV {hero.HealthPoints}/{hero.HealthPoints}, MP {hero.MagicPoints}");
                }
            }

            void PausaEDeclaraVencedor()
            {
                Console.WriteLine("\nDigite uma tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }

            bool AnyHeroAlive(List<Hero> heroes)
            {
                foreach (var hero in heroes)
                {
                    if (hero.HealthPoints > 0)
                    {
                        return true;
                    }
                }
                return false;
            }

            void Inventory()
            {
                Console.WriteLine("\nInventário:");
                foreach (var hero in heroes)
                {
                    Console.WriteLine($"{hero.Name}'s Inventário:");
                    ExibirInventario(hero);
                }

                Console.WriteLine("\nDigite uma tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }

            void ExibirInventario(Hero hero)
            {
                Console.WriteLine($"Arma: {hero.Weapon.Name} - Descrição: {hero.Weapon.Description} - Dano: {hero.Weapon.Damage}");

                if (hero.HealthPotion != null)
                {
                    Console.WriteLine($"Poção: {hero.HealthPotion.Name} - Descrição: {hero.HealthPotion.Description} - Cura: {hero.HealthPotion.HealingAmount}");
                }
                else
                {
                    Console.WriteLine("Sem poção de cura no inventário.");
                }
            }

            void Status()
            {
                Console.WriteLine("\nStatus dos personagens:");
                Console.WriteLine($"{arus.Name}: Nível {arus.Level}, PV {arus.HealthPoints}, MP {arus.MagicPoints}");
                Console.WriteLine($"{wedge.Name}: Nível {wedge.Level}, PV {wedge.HealthPoints}, MP {wedge.MagicPoints}");
                Console.WriteLine($"{jenica.Name}: Nível {jenica.Level}, PV {jenica.HealthPoints}, MP {jenica.MagicPoints}");
                Console.WriteLine($"{topapa.Name}: Nível {topapa.Level}, PV {topapa.HealthPoints}, MP {topapa.MagicPoints}");
                Console.WriteLine("\nDigite uma tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }
        }
    }
}




