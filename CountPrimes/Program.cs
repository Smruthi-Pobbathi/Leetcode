/* Leetcode (204) - Count Primes:
    Given an integer n, return the number of prime numbers that are strictly less than n.
*/
using System;
using System.Linq;

public class PrimeCount
{
    public int CountPrimes(int n)
    {
        if (n == 0 || n == 1)
            return 0;

        bool[] b = new bool[n];
        b[0] = true;
        b[1] = true;
        for (int i = 2; i < n; i++)
        {
            if (b[i]) continue;

            for (int j = i * 2; j < n; j += i)
                b[j] = true;
        }

        return b.Where(x => !x).Count();
    }
}

public class TestPrimeCount
{
    public static void Main(string[] args)
    {
        PrimeCount primeCounter = new PrimeCount();

        // Test case 1: Input 10
        Console.WriteLine("Test Case 1: Input = 10, Expected Output = 4, Actual Output = " + primeCounter.CountPrimes(10));

        // Test case 2: Input 0
        Console.WriteLine("Test Case 2: Input = 0, Expected Output = 0, Actual Output = " + primeCounter.CountPrimes(0));

        // Test case 3: Input 1
        Console.WriteLine("Test Case 3: Input = 1, Expected Output = 0, Actual Output = " + primeCounter.CountPrimes(1));

        // Test case 4: Input 100
        Console.WriteLine("Test Case 4: Input = 100, Expected Output = 25, Actual Output = " + primeCounter.CountPrimes(100));

        // Test case 5: Input 2
        Console.WriteLine("Test Case 5: Input = 2, Expected Output = 0, Actual Output = " + primeCounter.CountPrimes(2));
    }
}




