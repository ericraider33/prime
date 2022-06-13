using System.Collections.Generic;

namespace prime
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<PrimeInfo> primes = new List<PrimeInfo>(100);
            List<Block> blocks = new List<Block>();
            primes.Add(new PrimeInfo(2, 3, 6));
            primes.Add(new PrimeInfo(3, 2, 6));
            primes.Add(new PrimeInfo(5));

            int currentNumber = 5;
            int blockStart = 6; 
            int maxOut = 2 * 3 * 5;
            int nextPrimeIndex = 3;
            
            while (true)
            {
                currentNumber++;

                bool isPrime = true;
                foreach (PrimeInfo p in primes)
                {
                    if (p.value != currentNumber)
                        continue;
                    
                    p.count += 1;
                    p.value += p.primeNumber;

                    if (isPrime)
                        p.peg++;

                    isPrime = false;
                }

                if (isPrime)
                    primes.Add(new PrimeInfo(currentNumber));

                if (currentNumber == maxOut)
                {
                    Block block = new Block();
                    block.blockStart = blockStart;
                    block.blockEnd = maxOut;
                    
                    block.primes = new List<Block.Prime>(primes.Count);
                    blocks.Add(block);

                    foreach (PrimeInfo p in primes)
                    {
                        Block.Prime bp = new Block.Prime();
                        bp.primeNumber = p.primeNumber;
                        bp.peg = p.peg;
                        bp.isNew = p.primeNumber >= blockStart;
                        block.primes.Add(bp);

                        if (bp.isNew)
                            block.newPrimes++;
                        
                        p.peg = 0;                          // resets count
                    }

                    block.print();
                    
                    // Sets up next block
                    blockStart = maxOut + 1;                // will always be a prime number ;)
                    int nextPrimeNumber = primes[nextPrimeIndex].primeNumber;
                    nextPrimeIndex++;
                    maxOut = maxOut * nextPrimeNumber;
                }
            }
        }
    }
}