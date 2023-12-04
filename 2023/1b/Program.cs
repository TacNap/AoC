using System.Text;
using System.Text.RegularExpressions;

var lines = File.ReadLines("../../../input.txt", Encoding.UTF8);

var dict  = new Dictionary<string, string>()
{
    { "zero", "0" },
    { "one", "1" },
    { "two", "2" },
    { "three", "3" },
    { "four", "4" },
    { "five", "5" },
    { "six", "6" },
    { "seven", "7" },
    { "eight", "8" },
    { "nine", "9" },
};

var sum = 0;
var regex = new Regex(@"\d|one|two|three|four|five|six|seven|eight|nine");

foreach (var line in lines)
{
    var nums = new List<string>() { };

    var matchObj = regex.Match(line);
    while (matchObj.Success)
    {
        nums.Add(matchObj.Value);
        matchObj = regex.Match(line, matchObj.Index + 1);
    }

    var convertedNums = nums.Select(n => dict.GetValueOrDefault(n) ?? n).ToList();

    var num = $"{convertedNums.First()}{convertedNums.Last()}";
    sum += int.Parse(num);
};

Console.WriteLine(sum);