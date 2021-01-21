using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TextRPG
{
    class Program
    {
        static Player User = new Player("", 1, 150, 0, 0, 5, 0, 5, 150, 100);
        static Minion Worm = new Minion("Giant worm", 1, 50, 40, 10, 3, 0, 5, 50);
        static Minion Rat = new Minion("Angry rat", 3, 80, 50, 20, 5, 1, 5, 80);
        static Minion Boar = new Minion("Wild boar", 5, 120, 70, 30, 8, 2, 10, 120);
        static Minion Dragon = new Minion("Fiery Dragon", 8, 250, 120, 100, 15, 5, 15, 250);
        static Shop Potion = new Shop("Health potion", "A potion that heals the user for 50 health. Press P during combat to use it.", 0, 50);
        static Shop Amulet_Turtle = new Shop("Amulet of the Turtle", "An Amulet that grants the user 5 toughness, which reduces damage to the user.", 0, 80);
        static Shop Amulet_Bear = new Shop("Amulet of the Bear", "An Amulet that grants the user 5 strength, which results in more damage to the opponent.", 0, 95);
        static Shop Lucky_Charm = new Shop("Lucky charm", "An Ancient coin that grants the user 5 luck, which increases the odds of critical strikes.", 0, 120);
        static Shop Dragon_Slayer = new Shop("Dragon Slayer", "A very heavy sword that grants the user 20 strength, which results in more damage to the opponent.", 0, 200);

        static List<Minion> monsterList = new List<Minion>() {Worm, Rat, Boar, Dragon};
        static List<Shop> shopList = new List<Shop>() {Potion, Amulet_Turtle, Amulet_Bear, Lucky_Charm, Dragon_Slayer};

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
            if (nameInput == "Nils" || nameInput == "Robin")
            {
                GodMode();
            }
            Menu();
        }

        static void GodMode()
        {
            User.Strength += 50;
            User.Toughness += 50;
            User.Luck += 50;
        }

        static void Menu()
        {
            bool loop = true;
            while (true)
            {
                Console.WriteLine("\n1. Go adventuring\n2. Show details about your character\n3. Buy items from the shop\n4. Exit game\n");
                string menyInput = Console.ReadLine();

                if (menyInput == "1")
                { Fight(); }
                else if (menyInput == "2")
                { Stats(); }
                else if (menyInput == "3")
                { Shop(); }
                else if (menyInput == "4")
                { System.Environment.Exit(0); }
            }

            void Stats()
            {
                Console.WriteLine($"*************************\n*\tName: {User.Name}\t*\n*\tLevel: {User.Level}\t*\n*\tHp: {User.Health}/{User.Healthmax}\t*\n*\tExp: {User.Experience}/{User.Experiencecap}\t*\n*\tGold: {User.Gold} \t*\n*\tStrength: {User.Strength}\t*\n*\tToughness: {User.Toughness}\t*\n*************************\n");
                Console.WriteLine($"*************************\n {Potion.Name}: {Potion.Total}\n {Amulet_Turtle.Name}: {Amulet_Turtle.Total}\n {Amulet_Bear.Name}: {Amulet_Bear.Total}\n {Lucky_Charm.Name}: {Lucky_Charm.Total}\n {Dragon_Slayer.Name}: {Dragon_Slayer.Total}\n*************************\n\nPress any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        static void Buy(int i)
        {
            Console.WriteLine($"{shopList[i].Description}\nAre you sure you want to buy this item? (Y/N)");
            string decisionInput = Console.ReadLine();

            if (shopList[i].Total == 1)
            {
                Console.WriteLine("You already have this item!");
            }
            else if (decisionInput == "Y" || decisionInput == "y")
            {
                User.Gold = User.Gold - shopList[i].Price;
                shopList[i].Total++;
                Console.WriteLine($"You bought a {shopList[i].Name}!\nYou have {User.Gold} gold left.");
                if (i == 1)
                { User.Toughness +=5; }
                else if (i == 2)
                { User.Strength +=5; }
                else if (i == 3)
                { User.Luck += 5; }
                else if (i == 4)
                { User.Strength += 20; }
            }
        }

        static void Shop()
        {
            int i = 0;
            bool loop = true;
            while (loop)
            {
                Console.WriteLine($"***************************************************************************\n\n\tWelcome to the shop traveler, what would you like to buy today?\n\n1. {Potion.Name} [{Potion.Price}g]\n\n2. {Amulet_Turtle.Name} [{Amulet_Turtle.Price}g]\n\n3. {Amulet_Bear.Name} [{Amulet_Bear.Price}g]\n\n4. {Lucky_Charm.Name} [{Lucky_Charm.Price}]\n\n5. {Dragon_Slayer.Name}: [{Dragon_Slayer.Price}]\n\n6. Exit the shop.\t\t\t\tGold: {User.Gold}\n\n***************************************************************************");
                string shopInput = Console.ReadLine();
                if (shopInput == "1" & User.Gold >= Potion.Price)
                { Buy(0); }
                else if (shopInput == "2" & User.Gold >= Amulet_Turtle.Price)
                { Buy(1); }
                else if (shopInput == "3" & User.Gold >= Amulet_Bear.Price)
                { Buy(2); }
                else if (shopInput == "4" & User.Gold >= Lucky_Charm.Price)
                { Buy(3); }
                else if (shopInput == "5" & User.Gold >= Dragon_Slayer.Price)
                { Buy(4); }
                else if (shopInput == "6")
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine("You do not have enough gold for that item!");
                }
            }
        }

        static void LevelUp()
        {
            User.Level++;
            User.Strength++;
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

        static void Fight()
        {
            int i = 0;
            var random = new Random();
            int randomEncounter = random.Next(1, 10);
            //Här har spelaren en 10% chans att inte stöta på ett monster
            if (randomEncounter == 1)
            {
                Console.WriteLine("You see nothing but swaying grass all around you...\n[Press enter to continue]\n");
                Console.ReadKey();
                Menu();
            }
            //i är platsen i monsterList. 0 = Worm, 1 = Rat, 2 = Boar och 3 = Drake.
            else
            {
                if (randomEncounter <= 5 & User.Level >= 8)
                { i = 3; }
                else if (randomEncounter >= 5 & User.Level >= 5)
                { i = 2; }
                else if (randomEncounter <= 5 & User.Level >= 3)
                { i = 1; }
                else
                { i = 0; }
            }
            bool loop = true;
            Console.WriteLine($"A wild {monsterList[i].Name} appeared!");

            while (loop)
            {
                int playerDMG_RNG = random.Next(1, User.Luck);
                int minionDMG_RNG = random.Next(1, monsterList[i].Luck);
                int playerDMG = playerDMG_RNG + User.Strength - monsterList[i].Toughness;
                int minionDMG = minionDMG_RNG + monsterList[i].Strength - User.Toughness;
                if (playerDMG <= 0)
                { playerDMG = 0; }
                else if (minionDMG <= 0)
                { minionDMG = 0; }


                Console.WriteLine($"You hit the monster, dealing {playerDMG} damage!");
                monsterList[i].Health = monsterList[i].Health - playerDMG;
                Console.WriteLine($"The {monsterList[i].Name} hit you, dealing {minionDMG} damage!");
                User.Health = User.Health - minionDMG;
                Console.WriteLine($"{User.Name}: {User.Health}hp\n{monsterList[i].Name}: {monsterList[i].Health}hp");

                if (User.Health <= 0)
                {
                    Console.WriteLine("You were killed by the monster. Press any key to close the application.");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                    loop = false;

                }
                else if (monsterList[i].Health <= 0)
                {
                    Console.WriteLine($"You killed the monster! You gain {monsterList[i].Experience} experience and {monsterList[i].Gold} gold!");
                    User.Experience = User.Experience + monsterList[i].Experience;
                    User.Gold = User.Gold + monsterList[i].Gold;
                    if (User.Experience >= User.Experiencecap)
                    {
                        LevelUp();
                    }
                    monsterList[i].Health = monsterList[i].Healthmax;
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
            if (Potion.Total == 1 & User.Level <= 4)
            {
                Potion.Total--;
                User.Health = User.Health + 50;
                if (User.Health >= User.Healthmax)
                {
                    User.Health = User.Healthmax;
                }
                Console.WriteLine($"You used an health potion! You now have {User.Health} health.");
            }
            else if (Potion.Total == 1 & User.Level >= 5)
            {
                Potion.Total--;
                User.Health = User.Health + 100;
                if (User.Health >= User.Healthmax)
                {
                    User.Health = User.Healthmax;
                }
                Console.WriteLine($"You used an health potion! You now have {User.Health} health.");
            }
            else
            {
                Console.WriteLine("You do not have any health potions.");
            }
        }
    }
}
