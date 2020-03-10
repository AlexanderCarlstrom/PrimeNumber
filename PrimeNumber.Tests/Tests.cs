using System;
using NUnit.Framework;
using PrimeNumber.Util;

namespace PrimeNumber.Tests
{
    public class Tests
    {
        // CheckInput(string input) - CHECK IF INPUT IS VALID
        
        // Valid input
        // Input: 11, 2, 3
        // Expects: 11, 2, 3
        [Test]
        public void CheckInput_ValidInput()
        {
            var prime = new PrimeNumberCheck();
            Assert.AreEqual(11, prime.CheckInput("11"));
            Assert.AreEqual(2, prime.CheckInput("2"));
            Assert.AreEqual(3, prime.CheckInput("3"));
        }
        
        // Valid input
        // Input: hej
        // Expects: ArgumentException - invalid input
        [Test]
        public void CheckInput_InvalidInput()
        {
            var prime = new PrimeNumberCheck();
            Assert.Throws<ArgumentException>(() => prime.CheckInput("hej"));
        }
        
        // AddPrime(int num) - ADD NUMBER TO LIST
        
        // Unique numbers
        // Input: 11, 2, 3
        // Expects: 2, 3, 11
        [Test]
        public void AddPrime_UniqueNumbers()
        {
            var prime = new PrimeNumberCheck();
            prime.AddPrime(11);
            prime.AddPrime(2);
            prime.AddPrime(3);
            Assert.AreEqual("2, 3, 11", prime.GetPrimeNumbers());
        }
        
        // Duplicate numbers
        // Input: 11, 2, 11, 3, 3, 2
        // Expects: ArgumentException - invalid input
        [Test]
        public void AddPrime_DuplicateNumbers()
        {
            var prime = new PrimeNumberCheck();
            prime.AddPrime(11);
            prime.AddPrime(2);
            prime.AddPrime(11);
            prime.AddPrime(3);
            prime.AddPrime(3);
            prime.AddPrime(2);
            Assert.AreEqual("2, 3, 11", prime.GetPrimeNumbers());
        }
        
        
        // GetPrimeNumbers() - CONVERTS LIST OF PRIME NUMBERS TO STRING
        
        // List not empty
        // Input: 11, 2, 3
        // Expects: 2, 3, 11
        [Test]
        public void GetPrimeNumbers_ListNotEmpty()
        {
            var prime = new PrimeNumberCheck();
            prime.AddPrime(11);
            prime.AddPrime(2);
            prime.AddPrime(3);
            Assert.AreEqual("2, 3, 11", prime.GetPrimeNumbers());
        }
        
        // List is empty
        // Input: 
        // Expects: invalid operation exception - list is empty
        [Test]
        public void GetPrimeNumbers_EmptyList()
        {
            var prime = new PrimeNumberCheck();
            Assert.Throws<InvalidOperationException>(() => prime.GetPrimeNumbers());
        }
        
        
        // AddNext() - ADD NEXT PRIME NUMBER TO LIST
        
        // List not empty
        // Input: 11, 2, 3
        // Expects: 2, 3, 11, 13
        [Test]
        public void AddNext_ListNotEmpty()
        {
            var prime = new PrimeNumberCheck();
            prime.AddPrime(11);
            prime.AddPrime(2);
            prime.AddPrime(3);
            prime.AddNext();
            Assert.AreEqual("2, 3, 11, 13", prime.GetPrimeNumbers());
        }
        
        // List is empty
        // Input: 
        // Expects: 2
        [Test]
        public void AddNext_EmptyList()
        {
            var prime = new PrimeNumberCheck();
            prime.AddNext();
            Assert.AreEqual("2", prime.GetPrimeNumbers());
        }
        
        // IsPrime() - CHECK IF NUMBER IS PRIME
        
        // With prime numbers
        // Input: 2, 3, 5, 7
        // Expects: true
        [Test]
        public void IsPrime_Primes()
        {
            var prime = new PrimeNumberCheck();
            Assert.True(prime.IsPrime(2));
            Assert.True(prime.IsPrime(3));
            Assert.True(prime.IsPrime(5));
            Assert.True(prime.IsPrime(7));
        }
        
        // With non-prime numbers
        // Input: 4, 6, 8, 9
        // Expects: false
        [Test]
        public void IsPrime_NonPrimes()
        {
            var prime = new PrimeNumberCheck();
            Assert.False(prime.IsPrime(4));
            Assert.False(prime.IsPrime(6));
            Assert.False(prime.IsPrime(6));
            Assert.False(prime.IsPrime(6));
        }
        
        
        // CheckPrime() - MAIN FUNCTION
        
        // Only prime numbers
        // Input: 11, 2, 3
        // Expects: 2, 3, 11
        [Test]
        public void CheckPrime_OnlyPrime()
        {
            var prime = new PrimeNumberCheck();
            prime.CheckPrime("11");
            prime.CheckPrime("2");
            prime.CheckPrime("3");
            Assert.AreEqual("2, 3, 11", prime.GetPrimeNumbers());
        }
        
        // Only none-prime numbers
        // Input: 6, 8, 12
        // Expects: invalid operation exception - empty list
        [Test]
        public void CheckPrime_OnlyNonPrime()
        {
            var prime = new PrimeNumberCheck();
            prime.CheckPrime("6");
            prime.CheckPrime("8");
            prime.CheckPrime("12");
            Assert.Throws<InvalidOperationException>(() => prime.GetPrimeNumbers());
        }
        
        // Combination
        // Input: 6, 3, 8, 5, 2, 12, 13, 9
        // Expects: 2, 3, 5, 13
        [Test]
        public void CheckPrime_Combination()
        {
            var prime = new PrimeNumberCheck();
            prime.CheckPrime("6");
            prime.CheckPrime("3");
            prime.CheckPrime("8");
            prime.CheckPrime("5");
            prime.CheckPrime("2");
            prime.CheckPrime("12");
            prime.CheckPrime("13");
            prime.CheckPrime("9");
            Assert.AreEqual("2, 3, 5, 13", prime.GetPrimeNumbers());
        }


    }
}