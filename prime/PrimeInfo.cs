namespace prime
{
    public class PrimeInfo
    {
        public int primeNumber;
        
        public int count;
        public int value;

        public int peg;             // counts the number wholes filled

        public PrimeInfo(int primeNumber)
        {
            this.primeNumber = primeNumber;

            count = 2;
            value = primeNumber * 2;
        }

        public PrimeInfo(int primeNumber, int count, int value)
        {
            this.primeNumber = primeNumber;
            this.count = count;
            this.value = value;
        }
    }
}