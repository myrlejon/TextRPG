using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace TextRPG
{
    class Program
    {
        static Player User = new Player("", 1, 100, 0, 0, 5, 0);
        static Minion Worm = new Minion("Giant worm", 1, 100, 5, 0);

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
            Console.WriteLine("\n1. Go adventuring\n2. Show details about your character\n3. Exit game\n");
            string menyInput = Console.ReadLine();

            if (menyInput == "1")
            {
                Adventure();
            }
            if (menyInput == "2")
            {
                Stats();
            }

            void Stats()
            {
                Console.WriteLine($"*************************\n*\tName: {User.Name}\t*\n*\tLevel: {User.Level}\t*\n*\tHp: {User.Health}/200\t*\n*\tExp: {User.Experience}/100\t*\n*\tGold: {User.Gold} \t*\n*\tStrength: {User.Strength}\t*\n*\tToughness: {User.Toughness}\t*\n*************************");
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
        }

        //static void Stats()
        //{
        //    Console.WriteLine($"************************\n*Name:{}");
        //}
    }
}
