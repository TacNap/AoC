using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection.Metadata;
using System.Diagnostics.CodeAnalysis;

Regex rx = new Regex(@"\d+");

var lines = File.ReadLines("input.txt", Encoding.UTF8);
var linesList = new List<string>(lines);
var LIMIT = linesList.Count-1;
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

// NEED TO CONSIDER EDGE CASES
// FIRST LINE
// LAST LINE
// FAR LEFT OR FAR RIGHT NUMBERS

// First line
MatchCollection matches = rx.Matches(linesList[0]);
matches = rx.Matches(linesList[0]);
    foreach(Match match in matches) {
        var start = match.Index-1;
        var length = match.Length + 2;
        // how do we quickly iterate .Contains over a list?
        for(int j = 0; j <= 1; j++){
            if(linesList[0+j].Substring(start, length).IndexOfAny(symbols) > -1)
            {
                // convert match to int
                // add to sum
                sum += int.Parse(match.Value);   
            }
        }
    }
// Last Line

for(int i = 1; i < LIMIT; i++) 
{
    matches = rx.Matches(linesList[i]);
    foreach(Match match in matches) {
        var start = match.Index-1;
        var length = match.Length + 2;
        // how do we quickly iterate .Contains over a list?
        for(int j = -1; j <= 1; j++){
            if(linesList[i+j].Substring(start, length).IndexOfAny(symbols) > -1)
            {
                // convert match to int
                // add to sum
                sum += int.Parse(match.Value);   
            }
        }
    }
}

Console.WriteLine(sum);

