class Program
{
    static void Main()
    {
        int splitCount = 0;
        string[] tree = File.ReadAllLines("input.txt");
        List<bool> beams = new List<bool>(141);
        for (int i = 0; i < 141; i++)
        {
            beams.Add(false);
        }
        beams[70] = true; // Set S - initial starting beam
        foreach (var line in tree)
        {
            int lineCount = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '^' && beams[i] == true)
                {
                    beams[i] = false;
                    beams[i - 1] = true;
                    beams[i + 1] = true;
                    splitCount++;
                    lineCount++;
                }
            }
            Console.WriteLine($"Line Count: {lineCount}");
        }
        Console.WriteLine(splitCount);
    }
}
