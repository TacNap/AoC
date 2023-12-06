using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection.Metadata;
using System.Diagnostics.CodeAnalysis;

Regex rx = new Regex(@"\d+"); // Finds any length of consecutive digits

// Read file, line by line, into a List of strings
var lines = File.ReadLines("../../../input.txt", Encoding.UTF8);
var linesList = new List<string>(lines);

// The list of symbols present in the input file.
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

// Artifically pad the input file with dots, to prevent index out-of-range exceptions
// pads first and last line
// worth noting that because of additional padding, the length of the last line will actually be +2 of any other line. makes no difference so far.
string dots = "..............................................................................................................................................";
linesList.Insert(0, dots);
linesList.Insert(linesList.Count, dots);



var LIMIT = linesList.Count-1;
for(int i = 0; i < LIMIT; i++) // 0th line is just padding
{
    // Pad each line with dots on far left and far right
    linesList[i+1] = linesList[i+1].Insert(0, ".");
    linesList[i+1] = linesList[i+1].Insert(linesList[i+1].Length, ".");

    // Find digits with regex
    MatchCollection matches = rx.Matches(linesList[i]);
    foreach(Match match in matches) {
        // Generate the X-axis indices of the rectangle that searches for symbols
        var start = match.Index-1;
        var length = match.Length + 2;
        for(int j = -1; j <= 1; j++) // Check lines on previous, current and next Y-axes 
        {
            // If there exists a symbol in any of the substrings, >IndexOfAny< will return a value > 1 
            if(linesList[i+j].Substring(start, length).IndexOfAny(symbols) > -1) 
            {
                sum += int.Parse(match.Value);
                // Note, it works fine here, but this would probably add the same value multiple times
                // if it's adjacent to multiple symbols across 2-3 lines
            }
        }
    }
}

Console.WriteLine("Total Sum = {0}", sum);

