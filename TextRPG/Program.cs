using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TextRPG
{
    class Program
    {
        static Player User = new Player("", 1, 150, 0, 0, 5, 0, 150, 100);
        static Minion Worm = new Minion("Giant worm", 1, 50, 35, 10, 3, 0, 50);
        static Minion Boar = new Minion("Wild boar", 5, 120, 70, 25, 8, 2, 120);
        static Minion Dragon = new Minion("Fiery Dragon", 8, 250, 120, 50, 15, 5, 250);
        static Shop Potion = new Shop("Health potion", "A potion that heals the user for 50 health. Press P during combat to use it.", 0, 50);
        static Shop Amulet_Turtle = new Shop("Amulet of the Turtle", "An Amulet that grants the user 5 toughness", 0, 80);
        static Shop Amulet_Bear = new Shop("Amulet of the Bear", "An Amulet that grants the user 5 strength", 0, 95);

        static void Main(string[] args)
        {
            Welcome();
        }

        static void Welcome()
        {
            Console.WriteLine("************************\n* Welcome to the game! *\n************************");
            Console.Write("Enter your name: ");
            string nameInput = Console.ReadLine();
            User.Name = nameInput;
            bool loop = true;
            while (loop = true)
            {
                Console.WriteLine("\n1. Go adventuring\n2. Show details about your character\n3. Buy items from the shop\n4. Exit game\n");
                string menyInput = Console.ReadLine();

                if (menyInput == "1")
                {
                    Adventure();
                }
                else if (menyInput == "2")
                {
                    Stats();
                }
                else if (menyInput == "3")
                {
                    Shop();
                }
            }

            void Stats()
            {
                Console.WriteLine($"*************************\n*\tName: {User.Name}\t*\n*\tLevel: {User.Level}\t*\n*\tHp: {User.Health}/{User.Healthmax}\t*\n*\tExp: {User.Experience}/{User.Experiencecap}\t*\n*\tGold: {User.Gold} \t*\n*\tStrength: {User.Strength}\t*\n*\tToughness: {User.Toughness}\t*\n*************************\n\nPress any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        static void Shop()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine($"***************************************************************************\n\n\tWelcome to the shop traveler, what would you like to buy today?\n\n1. {Potion.Name} [{Potion.Price}g]\n\n2. {Amulet_Turtle.Name} [{Amulet_Turtle.Price}g]\n\n3. {Amulet_Bear.Name} [{Amulet_Bear.Price}g]\n\n4. Exit the shop.\n\n***************************************************************************");
                string shopInput = Console.ReadLine();
                if (shopInput == "1" & User.Gold >= Potion.Price)
                {
                    Console.WriteLine($"{Potion.Description}\nAre you sure you want to buy this item? (Y/N)");
                    string decisionInput = Console.ReadLine();
                    if (decisionInput == "Y")
                    {
                        User.Gold = User.Gold - Potion.Price;
                        Potion.Total++;
                        Console.WriteLine($"You bought a {Potion.Name}!\nYou have {User.Gold} gold left.");
                    }
                    else if (Potion.Total == 1)
                    {
                        Console.WriteLine("You already have this item!");
                    }
                }
                else if (shopInput == "2" & User.Gold >= Amulet_Turtle.Price)
                {
                    Console.WriteLine($"{Amulet_Turtle.Description}\nAre you sure you want to buy this item? (Y/N)");
                    string decisionInput = Console.ReadLine();
                    if (decisionInput == "Y" & Amulet_Turtle.Total == 0)
                    {
                        User.Gold = User.Gold - Amulet_Turtle.Price;
                        Amulet_Turtle.Total++;
                        Console.WriteLine($"You bought a {Amulet_Turtle.Name}!\nYou have {User.Gold} gold left.");
                    }
                    else if (Amulet_Turtle.Total == 1)
                    {
                        Console.WriteLine("You already have this item!");
                    }
                }


                else if (shopInput == "4")
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine("You do not have enough gold for that item!");
                }
            }
        }


        static void Adventure()
        {
            var random = new Random();
            int randomEncounter = random.Next(1, 10);
            //Här har spelaren en 10% chans att inte stöta på ett monster
            if (randomEncounter == 1)
            {
                Console.WriteLine("You see nothing but swaying grass all around you...\n[Press enter to continue]\n");
                Console.ReadKey();
            }
            else
            {
                if (randomEncounter <= 5 & User.Level >= 8)
                {
                    DragonFight();
                }
                else if (randomEncounter >= 5 & User.Level >= 5)
                {
                    BoarFight();
                }
                else
                {
                    WormFight();
                }
            }
        }

        static void LevelUp()
        {
            User.Level++;
            User.Strength++;
            User.Toughness++;
            User.Experience = User.Experience - User.Experiencecap;
            User.Experiencecap = User.Experiencecap + 50;
            int healthCap = 10 * (User.Level - 1);
            User.Health = 150 + healthCap;
            User.Healthmax = User.Health;
            Console.WriteLine($"You leveled up, and are now level {User.Level}!");
            if (User.Level == 10)
            {
                Console.WriteLine("Congratulations, You won the game!");
                System.Environment.Exit(0);
            }
        }

        static void WormFight()
        {
            var random = new Random();
            bool loop = true;
            Console.WriteLine($"A wild {Worm.Name} appeared!");

            while (loop == true)
            {
                int playerDMG_RNG = random.Next(1, 5);
                int minionDMG_RNG = random.Next(1, 5);
                int playerDMG = playerDMG_RNG + User.Strength - Worm.Toughness;
                int minionDMG = minionDMG_RNG + Worm.Strength - User.Toughness;
                Console.WriteLine($"You hit the monster, dealing {playerDMG} damage!");
                Worm.Health = Worm.Health - playerDMG;
                Console.WriteLine($"The {Worm.Name} hit you, dealing {minionDMG} damage!");
                User.Health = User.Health - minionDMG;
                Console.WriteLine($"{User.Name}: {User.Health}hp\n{Worm.Name}: {Worm.Health}hp");

                if (User.Health <= 0)
                {
                    Console.WriteLine("You were killed by the monster. Press any key to close the application.");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                    loop = false;

                }
                else if (Worm.Health <= 0)
                {
                    Console.WriteLine($"You killed the monster! You gain {Worm.Experience} experience and {Worm.Gold} gold!");
                    User.Experience = User.Experience + Worm.Experience;
                    User.Gold = User.Gold + Worm.Gold;
                    if (User.Experience >= User.Experiencecap)
                    {
                        LevelUp();
                    }
                    Worm.Health = Worm.Healthmax;
                    loop = false;
                }
                string input = Console.ReadLine();
                if (input == "P" || input == "p")
                {
                    UsePotion();
                }
            }
        }
        static void BoarFight()
        {
            var random = new Random();
            bool loop = true;
            Console.WriteLine($"A wild {Boar.Name} appeared!");

            while (loop == true)
            {
                int playerDMG_RNG = random.Next(1, 5);
                int minionDMG_RNG = random.Next(1, 5);
                int playerDMG = playerDMG_RNG + User.Strength - Boar.Toughness;
                int minionDMG = minionDMG_RNG + Boar.Strength - User.Toughness;
                Console.WriteLine($"You hit the monster, dealing {playerDMG} damage!");
                Boar.Health = Boar.Health - playerDMG;
                Console.WriteLine($"The {Boar.Name} hit you, dealing {minionDMG} damage!");
                User.Health = User.Health - minionDMG;
                Console.WriteLine($"{User.Name}: {User.Health}hp\n{Boar.Name}: {Boar.Health}hp");


                if (User.Health <= 0)
                {
                    Console.WriteLine("You were killed by the monster. Press any key to close the application.");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                    loop = false;

                }
                else if (Boar.Health <= 0)
                {
                    Console.WriteLine($"You killed the monster! You gain {Boar.Experience} experience and {Boar.Gold} gold!");
                    User.Experience = User.Experience + Boar.Experience;
                    User.Gold = User.Gold + Boar.Gold;
                    if (User.Experience >= User.Experiencecap)
                    {
                        LevelUp();
                    }
                    Boar.Health = Boar.Healthmax;
                    loop = false;
                }
                string input = Console.ReadLine();
                if (input == "P" || input == "p")
                {
                    UsePotion();
                }
            }
        }


        static void DragonFight()
        {
            var random = new Random();
            bool loop = true;
            Console.WriteLine($"A wild {Dragon.Name} appeared!");

            while (loop == true)
            {
                int playerDMG_RNG = random.Next(1, 5);
                int minionDMG_RNG = random.Next(1, 5);
                int playerDMG = playerDMG_RNG + User.Strength - Dragon.Toughness;
                int minionDMG = minionDMG_RNG + Dragon.Strength - User.Toughness;
                Console.WriteLine($"You hit the monster, dealing {playerDMG} damage!");
                Dragon.Health = Dragon.Health - playerDMG;
                Console.WriteLine($"The {Dragon.Name} hit you, dealing {minionDMG} damage!");
                User.Health = User.Health - minionDMG;
                Console.WriteLine($"{User.Name}: {User.Health}hp\n{Dragon.Name}: {Dragon.Health}hp");

                if (User.Health <= 0)
                {
                    Console.WriteLine("You were killed by the monster. Press any key to close the application.");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                    loop = false;

                }
                else if (Dragon.Health <= 0)
                {
                    Console.WriteLine($"You killed the monster! You gain {Dragon.Experience} experience and {Dragon.Gold} gold!");
                    User.Experience = User.Experience + Dragon.Experience;
                    User.Gold = User.Gold + Dragon.Gold;
                    if (User.Experience >= User.Experiencecap)
                    {
                        LevelUp();
                    }
                    Dragon.Health = Dragon.Healthmax;
                    loop = false;
                }
                string input = Console.ReadLine();
                if (input == "P" || input == "p")
                {
                    UsePotion();
                }
            }

        }

        static void UsePotion()
        {
            if (Potion.Total == 1)
            {
                Potion.Total--;
                User.Health = User.Health + 50;
                Console.WriteLine($"You used an health potion! You now have {User.Health} health.");
            }
            else
            {
                Console.WriteLine("You do not have any health potions.");
            }
        }
    }
}
