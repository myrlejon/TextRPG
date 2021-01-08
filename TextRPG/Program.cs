using System;

namespace TextRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Welcome();
        }

        static void Welcome()
        {
            Console.WriteLine("************************\n* Welcome to the game! *\n************************");
            Console.Write("Enter your name: ");
            string nameInput = Console.ReadLine();
            Console.WriteLine("\n1. Go adventuring\n2. Show details about your character\n3. Exit game\n");
            string menyInput = Console.ReadLine();

            if (menyInput == "1")
            {
                Adventure();
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
            Console.WriteLine(randomEncounter);
        }
    }
}
