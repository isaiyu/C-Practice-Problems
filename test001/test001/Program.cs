using System; //this is like import in Java and #include in C/C++
using System.Text;

namespace test001
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(base_converter(5, 2));
            for (int i = 15; i < 34; ++i)
            {
                Console.WriteLine(base_converter(i,16));
            }
        }

        private static string base_converter(int num, int b)
        {
            if (num < b)
            {
                return int_to_char(num);
            }
            string zeroes = "";
            int numberOfZeroes = times_divisible(num, b) - times_divisible(remainder(num, b, times_divisible(num, b)),b);
            for (int i = 0; i < numberOfZeroes - 1; ++i)
            {                
                zeroes = String.Concat(zeroes, "0");
            }

            return String.Concat(String.Concat(int_to_char(digit_value(num, b,times_divisible(num,b))),zeroes),
                base_converter(remainder(num, b, times_divisible(num, b)), b));
        }

        
        private static int times_divisible(int dividend, int divisor)
        {
            int count = 0;
            while (dividend/divisor > 0)
            {
                dividend = dividend / divisor;
                ++count;
            }
            return count;
        }


        //assume positive integer exponent for now
        private static int pow(int b, int exp)
        {
            int total = b;
            if (exp == 0)
            {
                return 1;
            }
            while (exp > 1)
            {
                total = total * b;
                --exp;
            }
            return total;
        }


        private static int digit_value(int dividend, int b, int timesDivisible)
        {
            return dividend / pow(b, timesDivisible);
        }

        private static int remainder(int dividend, int b, int timesDivisible)
        {
            return dividend - pow(b, timesDivisible) * (dividend / pow(b, timesDivisible));
        }

        private static string int_to_char(int i)
        {
            if (i > -1 && i < 10)
            {
                return i.ToString();
            }
            else
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                return ((char)(i + 87)).ToString();
            }
        }

    }
}
