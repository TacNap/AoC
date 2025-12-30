namespace _2025;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(SpinDial(ReadInput()));
    }

    private static string[] ReadInput()
    {
        string inputPath = Path.Combine(AppContext.BaseDirectory, "input.txt");
        string[] lines = File.Exists(inputPath)
            ? File.ReadAllLines(inputPath)
            : File.ReadAllLines("input.txt");
        return lines;
    }

    private static int SpinDial(string[] lines)
    {
        int n = 50;
        int counter = 0;
        foreach (string line in lines)
        {
            int value = int.Parse(line[1..]);
            if (line[0] == 'L')
            {
                n = n - value;
            } else if (line[0] == 'R')
            {
                n = n + value;
            } else
            {
                Console.WriteLine("ERROR: Direction wasn't read correctly");
                return 0;
            }

            if (n % 100 == 0) {
                counter++;
            }
        }
        return counter;
    }
}
