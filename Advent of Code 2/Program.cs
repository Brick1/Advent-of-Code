using System.Runtime.ExceptionServices;

namespace Advent_of_Code_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputArray = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "input.txt"));
            int sum = 0;

            foreach (string input in inputArray)
            {
                bool isFirst = true;
                char last = '0';
                char first = '0';
                foreach (char c in input)
                {
                    if (char.IsDigit(c))
                    {
                        if (isFirst)
                        {
                            first = c;
                            isFirst = false;
                        }
                        last = c;
                    }
                }
                sum += int.Parse(new char[] { first, last });
            }

            Console.WriteLine("Sum is: " + sum);
        }
    }
}