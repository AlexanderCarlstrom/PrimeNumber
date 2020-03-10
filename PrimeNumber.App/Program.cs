using System;
using System.Collections.Generic;
using PrimeNumber.Util;

namespace PrimeNumber.App
{
    class Program
    {
        public static void Main(string[] args)
        {
            var prime = new PrimeNumberCheck();
            var running = true;
            while (running)
            {
                PrintMenu();
                var option = Console.ReadLine();
                
                try
                {
                    switch (option)
                    {
                        case "1":
                            Console.Write("Number: ");
                            var input = Console.ReadLine();
                            var result = prime.CheckPrime(input);

                            Console.WriteLine();
                            Console.WriteLine("Number is " + (result ? "prime" : "not prime"));
                            break;
                        case "2":
                            var str = prime.GetPrimeNumbers();
                            Console.WriteLine();
                            Console.WriteLine("Numbers: " + str);
                            break;
                        case "3":
                            prime.AddNext();
                            break;
                        case "4":
                            running = false;
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                }
                catch (ArgumentException aE)
                {
                    Console.WriteLine();
                    Console.WriteLine(aE.Message + ", requires a number please try again");
                }
                catch (InvalidOperationException iOe)
                {
                    Console.WriteLine();
                    Console.WriteLine(iOe.Message + ", please add some numbers before printing the list");
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("--- MENU ---");
            Console.WriteLine("1. Input Number - check if prime");
            Console.WriteLine("2. Output Numbers");
            Console.WriteLine("3. Add Next Prime Number");
            Console.WriteLine("4. Exit");
            Console.Write("> ");
        }
    }
}