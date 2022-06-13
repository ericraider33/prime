using System;
using System.Collections.Generic;

namespace prime
{
    public class Block
    {
        public class Prime
        {
            public int primeNumber;
            public int peg;
            public bool isNew;
        }

        public int newPrimes;
        public int blockStart;
        public int blockEnd; 
        public List<Prime> primes;

        public void print()
        {
            Console.WriteLine();

            int run = blockEnd - blockStart;
            Console.WriteLine($"Run {run}");
            Console.WriteLine($"NewPrimes {newPrimes}");
            foreach (Prime p in primes)
            {
                if (p.peg == 0)
                    continue;
                
                double percentage = 100 * (double)p.peg / (double)run;
                Console.WriteLine($"PrimeNumber {p.primeNumber}, Peg {p.peg}, Percentage {percentage:0.0}");
            }
        }
    }
}