using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2_Part_Two
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = "(one|two|three|four|five|six|seven|eight|nine|zero)";

            string[] fakeInput = { "two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen" };
            string[] inputArray = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "input.txt"));
            //string[] inputArray = fakeInput;

            int sum = 0;


            foreach (string inputLine in inputArray)
            {
                string currentTemp = inputLine.ToLower();
                string firstNum = "";
                string lastNum = "";
                bool isFirst = true;

                currentTemp = Regex.Replace(inputLine, pattern, GetMatchEvaluator);

                foreach (char c in currentTemp)
                {
                    if (char.IsDigit(c))
                    {
                        if (isFirst)
                        {
                            firstNum = c.ToString();
                            isFirst = false;
                        }
                        else
                        {
                            lastNum = c.ToString();
                        }
                    }
                }
                sum += int.Parse(firstNum + lastNum);
                Console.WriteLine(firstNum + lastNum);
            }
            Console.WriteLine(sum);
        }

        private static string GetMatchEvaluator(Match match)
        {
            return GetNumFromText(match.Value);
        }


        static string GetNumFromText(string text)
        {
            switch (text)
            {
                case "one": return "1";
                case "two": return "2";
                case "three": return "3";
                case "four": return "4";
                case "five": return "5";
                case "six": return "6";
                case "seven": return "7";
                case "eight": return "8";
                case "nine": return "9";
                case "zero": return "0";
                default: return text;
            }
        }
    }
}