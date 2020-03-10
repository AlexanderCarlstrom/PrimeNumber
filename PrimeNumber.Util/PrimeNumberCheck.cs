using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNumber.Util
{
    public class PrimeNumberCheck
    {

        /**
         * I use a sorted set because it can't store duplicates and it is sorted by default
         * this will make the program run faster because I don't have to add that functionality on my own.
         * However, in the AddNext() function, it will be slower since I have to go through all values before
         * getting to the last one
         */
        private SortedSet<int> _primes;

        public PrimeNumberCheck()
        {
            _primes = new SortedSet<int>();
        }

        /**
         * Main function
         * Validate input
         * Check if it's a prime number
         * If it's a prime number - add it to the sorted set
         */
        public bool CheckPrime(string input)
        {
            var number = CheckInput(input);

            if (IsPrime(number))
            {
                AddPrime(number);
                return true;
            }

            return false;
        }

        // validate input - checks if input is anything other than int
        public int CheckInput(string input)
        {
            var check = int.TryParse(input, out var number);
            if (!check)
            {
                throw new ArgumentException("Wrong Type of Input");
            }

            return number;
        }

        /**
         * Add a number to the sorted set
         */
        public void AddPrime(int num) => _primes.Add(num);

        /**
         * Loop through the sorted set and returns a string of it's content
         * If the sorted set is empty throw an invalid operations exception
         */
        public string GetPrimeNumbers()
        {
            var numbers = "";
            var count = _primes.Count;
            foreach (var num in _primes)
            {
                count--;
                numbers += num;
                if (count != 0) numbers += ", ";
            }
            if (numbers == "") throw new InvalidOperationException("No Numbers In List");
            return numbers;
        }

        /**
         * Get the last value in the sorted set, find the next prime number and adds it to the set
         */
        public void AddNext()
        {
            if (_primes.Count == 0)
            {
                _primes.Add(2);
                return;
            }

            // this will be slower for a sorted set
            var current = _primes.Last();

            while (true)
            {
                current++;
                if (IsPrime(current))
                {
                    break;
                }
            }
            AddPrime(current);
        }

        /**
         * Check if a number is prime
         */
        public bool IsPrime(int num)
        {
            var limit = num / 2;

            for (var i = 2; i <= limit; i++)
            {
                if (num  % i == 0) return false;
            }

            return true;
        }



    }
}