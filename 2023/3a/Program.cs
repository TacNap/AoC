using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection.Metadata;
using System.Diagnostics.CodeAnalysis;

Regex rx = new Regex(@"\d+");

var lines = File.ReadLines("../../../input.txt", Encoding.UTF8);
var linesList = new List<string>(lines);
char[] symbols = {
    '#',
    '%',
    '/',
    '*',
    '$',
    '=',
    '+',
    '-',
    '@',
    '&'
};
var sum = 0;

string dots = "..............................................................................................................................................";
linesList.Insert(0, dots);
linesList.Insert(linesList.Count, dots);



var LIMIT = linesList.Count-1;
for(int i = 0; i < LIMIT; i++) 
{
    linesList[i+1] = linesList[i+1].Insert(0, ".");
    linesList[i+1] = linesList[i+1].Insert(linesList[i+1].Length, ".");
    MatchCollection matches = rx.Matches(linesList[i]);
    foreach(Match match in matches) {
        var start = match.Index-1;
        var length = match.Length + 2;
        for(int j = -1; j <= 1; j++){
            if(linesList[i+j].Substring(start, length).IndexOfAny(symbols) > -1)
            {
                sum += int.Parse(match.Value);
            }
        }
    }
}

Console.WriteLine("Total Sum = {0}", sum);

