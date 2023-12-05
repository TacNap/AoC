using System.Text;
using System.Text.RegularExpressions;

// IMPORTANT: the path here will change depending on whether 
// you build from VSCode, or from CLI
var games = File.ReadLines("input.txt", Encoding.UTF8);
var sum = 0;
var gameNoRegex = new Regex(@"\d+");
var setRegex = new Regex(@"[\s][^;:]*[;]|[\s][^;:]*$");
var redRegex = new Regex(@"\d+[\s]red");
var greenRegex = new Regex(@"\d+[\s]green");
var blueRegex = new Regex(@"\d+[\s]blue");
var countRegex = new Regex(@"\d+");

// Declare RGB Input Counts
// var redInput = 12;
// var greenInput = 13;
// var blueInput = 14;

foreach (var game in games)
{
    var gameNo = gameNoRegex.Match(game).Value; // Collect Game Number, convert to int
    MatchCollection sets = setRegex.Matches(game); // Collect Sets within a Game

    // Minimum RGB Values
    int redMin = 0;
    int greenMin = 0;
    int blueMin = 0;

    foreach (Match set in sets)
    {
        

        int redCount;
        int greenCount;
        int blueCount;

        bool redMatch = int.TryParse(((countRegex.Match((redRegex.Match(set.Value)).Value)).Value), out redCount); // Find Red
        if (redMatch && redCount > redMin)
        {
           redMin = redCount; 
        }

        bool greenMatch = int.TryParse(((countRegex.Match((greenRegex.Match(set.Value)).Value)).Value), out greenCount); // Find Green
        if (greenMatch && greenCount > greenMin)
        {
          greenMin = greenCount;
        }

        bool blueMatch = int.TryParse(((countRegex.Match((blueRegex.Match(set.Value)).Value)).Value), out blueCount); // Find Blue
        if (blueMatch && blueCount > blueMin)
        {
          blueMin = blueCount;
        }

        

    }

    // Calculate Power of Game
    sum += (redMin * greenMin * blueMin);



}

Console.WriteLine(sum);
