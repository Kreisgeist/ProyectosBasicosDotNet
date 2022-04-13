using System;

namespace HackerRank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            bool reExecute = true;

            do
            {
                Console.Clear();
                Console.WriteLine("************************ HACKER RANK EXCERCISES ********************************");
                Console.WriteLine("Code by: Kreis");
                Console.WriteLine("Select the program you want to run:");
                Console.WriteLine("1.- Plus Minus");
                Console.WriteLine("2.- Sparse Array(Pending)");
                Console.WriteLine("100.- Exit");

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:

                        WeekOne.plusMinus();

                        break;
                    case 100:

                        Environment.Exit(0);

                        break;
                    default:

                        Console.WriteLine("Please select a valid option");

                        break;
                }

                Console.WriteLine("Would you like to execute another program?(y/n): ");
                reExecute = Console.ReadLine() == "y" ? reExecute = true: reExecute = false;

            } while (reExecute);
        }
    }
}
