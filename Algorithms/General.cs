using System.Numerics;

namespace DataStructuresAlgorithms
{
    public class General
    {
        public static BigInteger Factorial(BigInteger num) // O(N) time complexity
        {
            BigInteger total = 1;

            for (BigInteger i = num; i > 0; --i)
                total *= i;

            return total;
        }

        public static BigInteger FactorialRecursion(BigInteger num)
        {
            if (num == 0)
                return 1;

            return num * FactorialRecursion(num - 1);
        }

        public static void Fibonacci(BigInteger limit)
        {
            if (limit < 0)
                return;
            else if (limit == 0)
            {
                System.Console.WriteLine($"F(0) = 0");
                return;
            }
            else if (limit == 1)
            {
                System.Console.WriteLine($"F(1) = 1");
                return;
            }
            Console.WriteLine($"F(0) = 0\nF(1) = 1");
            BigInteger prior1 = 0, prior2 = 1;

            for (BigInteger i = 2; i <= limit; ++i)
            {
                BigInteger newPrior2 = prior1 + prior2;
                Console.WriteLine($"F({i}) = {newPrior2}");
                prior1 = prior2;
                prior2 = newPrior2;
            }
        }

        public static BigInteger FibonacciRecursion(BigInteger n)
        {
            Console.WriteLine($"F(n)");
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            
            return FibonacciRecursion(n - 1) + FibonacciRecursion(n - 2);
        }

        public static bool IsPrime(int num) // O(sqrt(N)) time complexity
        {
            if (num == 1)
                return false;

            int i = 2;

            // This will loop from 2 to int(sqrt(num))
            while (i * i <= num)
            {
                // Check if i divides x without leaving a remainder
                if (num % i == 0)
                    // This means that num has a factor in between 2 and sqrt(num)
                    // So it is not a isPrime number
                    return false;
                i++;
            }
            // If we did not find any factor in the above loop,
            // then n is a isPrime number
            return true;
        }

        public static int Digits(int num)
        {
            // 0 is 1 digit
            if (num == 0)
                return 1;

            int digit = 0;
            // Will negate the negative sign if the num is negative
            // so we can count the digits
            if (num < 0)
                num *= -1;

            // This will remove the last digit and increment total
            // digit count until integer division leads us to 0
            while (num > 0)
            {
                num /= 10;
                digit++;
            }

            // The amount of times we were able to remove a digit
            // will give us the total digit count
            return digit;
        }

        public static int EuclideanGCD(int a, int b)
        {
            int R; // Remainder value of a / b

            // If b = 0, then we have gotten to a point where we found the GCD
            while (b > 0)
            {
                R = a % b;
                a = b; // The next a value is the current b value
                b = R; // The next b value is the remainder of a / b
            }

            return a;
        }

        public static int KadanesMaxSumSubArray(int[] array)
        {
            int localMax = 0, globalMax = Int32.MinValue;

            for (int i = 0; i < array.Length; ++i)
            {
                localMax = Math.Max(array[i], array[i] + localMax);
                globalMax = localMax > globalMax ? localMax : globalMax;
            }

            return globalMax;
        }

        public static string TreeStringConverter(string treeString)
        {
            string raw = "";

            for (int i = 0; i < treeString.Length; ++i)
                if (char.IsLetter(treeString[i]))
                    raw += treeString[i];

            string tree = "";
            int parent = 0;

            for (int i = 0; i < raw.Length; ++i)
            {
                if (i == 0)
                    tree += raw[i];
                if (tree.Contains(raw[i]))
                    parent = tree.IndexOf(raw[i]);
                else
                    tree = $"{tree.Substring(0, parent + 1)}({raw[i]}){tree.Substring(parent + 1)}";
            }

            return tree;
        }

        public static int Ackermann(int m, int n)
        {
            if (m == 0)
                return n + 1;
            else if ((m > 0) && (n == 0))
                return Ackermann(m - 1, 1);

            return Ackermann(m - 1, Ackermann(m, n - 1));
        }

        public static Stack<int> ToBinary(int num)
        {
            Stack<int> binary = new();
            bool isPositive = num > 0;

            if (!isPositive)
                num *= -1;

            while (num >= 1)
            {
                if (num % 2 == 0)
                    binary.Pile(0);
                else
                    binary.Pile(1);

                num /= 2;
            }

            binary.Pile(isPositive ? 0 : 1);

            Node<int> curr = binary.Peek();

            while (curr != null)
            {
                Console.Write(curr.Data);
                curr = curr.Next;
            }
            Console.WriteLine();

            return binary;
        }

        public static string ToBinaryString(int num)
        {
            string binary = "";

            bool isPositive = num > 0;
            binary += isPositive ? '0' : '1';

            while (num > 0)
            {
                binary = binary.Insert(1, num % 2 == 0 ? "0" : "1");
                num /= 2;
            }

            return binary;
        }

        // public static string FloatToBinary(float num, int precision)
        // {
        //     int wholeNum = (int)num;
        //     float decimalNum = num - 10f;
        //     string binary = ToBinaryString(wholeNum) + '.';
        //     Console.WriteLine(decimalNum);

        //     for (int i = 0; i < precision; ++i)
        //     {
        //         int bit = (int)(decimalNum * 2);
        //         binary += bit == 0 ? '0' : '1';
                
        //         decimalNum = bit == 1 ? decimalNum = 1 - (decimalNum * 2) : decimalNum *= 2;
        //     }
            
        //     return binary;
        // }

        public static BigInteger ToDecimal(Stack<int> binary)
        {
            static BigInteger IntPow(int baseNum, int exponent)
            {
                if (exponent == 0)
                    return 1;

                int OGBase = 1;

                while (exponent > 0)
                {
                    OGBase *= baseNum;
                    --exponent;
                }

                return OGBase;
            }

            BigInteger Base = IntPow(2, binary.Count - 2);
            BigInteger Decimal = 0;

            Node<int> curr = binary.Peek().Next;

            while (curr != null)
            {
                if (curr.Data == 1)
                    Decimal += Base;

                Base /= 2;
                curr = curr.Next;
            }

            return binary.Peek().Data == 0 ? Decimal : Decimal * -1;
        }
    
        public static int SieveOfEratosthenes(int num)
        {
            int primes = 0;
            bool[] isPrime = new bool[num + 1];
            for (int i = 0; i <= num; ++i)
                isPrime[i] = true;
 
            for (int p = 2; p * p <= num; ++p)
                if (isPrime[p])
                    for (int i = p * p; i <= num; i += p)
                        isPrime[i] = false;

            for (int p = 2; p <= num; ++p)
            {
                if (isPrime[p])
                    Console.Write($"{p} ");
                ++primes;
            }

            return primes;
        }
    }
}