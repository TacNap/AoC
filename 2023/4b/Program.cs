using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Day4a 
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../input.txt";
            var linesList = ReadCards(path);
            List<string> winning = new List<string>();
            List<string> revealed = new List<string>();
            SplitNumbers(linesList, winning, revealed);
            List<List<int>> winningNumbers = ConvertToList(winning);
            List<List<int>> revealedNumbers = ConvertToList(revealed);
            
            var sum = 0; 
            for(int i = 0; i < winningNumbers.Count; i++)
            {
                sum += CalculateCardWorth(winningNumbers[i], revealedNumbers[i]);
            }
            Console.WriteLine("Sum of cards = {0}", sum);



        }

        static List<string> ReadCards(string path)
        {
            var lines = File.ReadLines(path, Encoding.UTF8);
            var linesList = new List<string>(lines);
            return linesList;
        }

        static void SplitNumbers(List<string> inputLines, List<string> outputWinning, List<string> outputRevealed)
        {
            Regex winRX = new Regex(@"[:].*[|]");
            Regex revRX= new Regex(@"[|].*");

            foreach(string line in inputLines)
            {
                Match winMatch = winRX.Match(line);
                Match revMatch = revRX.Match(line);
                outputWinning.Add(winMatch.Value);
                outputRevealed.Add(revMatch.Value);
            }

        }

        static List<List<int>> ConvertToList(List<string> column)
        {
            List<List<int>> outputList = new List<List<int>>();
            Regex digitRX = new Regex(@"\d+");
            foreach(string line in column)
            {
                var tempList = new List<int>();
                MatchCollection digitMatches = digitRX.Matches(line);
                foreach(Match match in digitMatches)
                {
                    tempList.Add(int.Parse(match.Value));
                }
                outputList.Add(tempList);
            }

            return outputList;
        }

        static int CalculateCardWorth(List<int> winning, List<int> revealed)
        {
            int sum = 0;
            foreach(int winX in winning)
            {
                if (revealed.Contains(winX))
                {
                    sum++;
                }
            }

            return (int)Math.Pow(2, (sum-1));
        }



    }
}