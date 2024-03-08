using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    internal class Program
    {

        static Random rng = new Random();
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            string response;
            do
            {
                Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
                response = Console.ReadLine();
                Console.Clear();
            }
            while (response.ToLower() != "yes" && response.ToLower() != "no");

            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine($"Your Name is:{userName}\n");
            Console.Write("What is your age? ");
            int userAge = 0;
            userAge = int.Parse(Console.ReadLine());
            Console.WriteLine($"Your Age is:{userAge}\n");

            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            
            bool seeList = (Console.ReadLine().ToLower() == "sure") ? true : false;

            if (seeList) 
            {
                foreach (string activity in activities)
                {
                    Console.Write($" {activity}");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("\nWould you like to add any activities before we generate one? yes/no: ");
               

                Console.WriteLine();
                bool addToList = (Console.ReadLine() == "yes") ? true : false;
                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($" {activity}");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("\nWould you like to add more? yes/no: ");
                    addToList = (Console.ReadLine() == "yes");
                }

            }
            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.WriteLine("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                if (userAge > 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                cont = (Console.ReadLine().ToLower() == "redo") ? true : false; 

            }

        }
    }
}
