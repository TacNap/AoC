using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection.Metadata;
using System.Diagnostics.CodeAnalysis;

Regex rx = new Regex(@"[*]"); // Finds '*'
Regex rxDigits = new Regex(@"[\d]+"); // Finds consecutive digits

// Read file, line by line, into a List of strings
var lines = File.ReadLines("../../../input.txt", );
var linesList = new List<string>(lines);
var product = 0;

// Artifically pad the input file with dots, to prevent index out-of-range exceptions
// pads first and last line
// worth noting that because of additional padding, the length of the last line will actually be +2 of any other line. makes no difference so far.
string dots = "..............................................................................................................................................";
linesList.Insert(0, dots);
linesList.Insert(linesList.Count, dots);



var LIMIT = linesList.Count-1;
for(int i = 0; i < LIMIT; i++) 
{
    // Pad each line with dots on far left and far right
    linesList[i+1] = linesList[i+1].Insert(0, ".");
    linesList[i+1] = linesList[i+1].Insert(linesList[i+1].Length, ".");

    // Find instances of '*' with regex
    MatchCollection matches = rx.Matches(linesList[i]);
    foreach(Match match in matches) {
        var n = match.Index;
        var borderNumbers = new List<int>();
        for (int j = -1; j <= 1; j++) // Check lines on previous, current and next Y-axes 
        {

            MatchCollection numberMatches = rxDigits.Matches(linesList[i + j]);
            foreach(Match partNumber in numberMatches)
            {
                
               
                if (n - partNumber.Index <= 1 && n - partNumber.Index >= -1) // If first digit is within border
                {
                    borderNumbers.Add(int.Parse(partNumber.Value));
                } else if (n - ((partNumber.Index + partNumber.Length) - 1) <= 1 && n - (partNumber.Index + partNumber.Length) >= -1) // If last digit is within border
                {
                    borderNumbers.Add(int.Parse(partNumber.Value));
                }
            }

            
        }
        if (borderNumbers.Count == 2) // If the star is adjacent to exactly 2 part numbers
        {
            product += (borderNumbers[0] * borderNumbers[1]);
        }

    }
}

Console.WriteLine("Total Product = {0}", product);

