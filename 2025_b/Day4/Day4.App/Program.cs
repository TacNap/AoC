namespace _2025b;

internal static class Program
{
    private static void Main(string[] args)
    {
        string[] data = ReadInput();
        Console.WriteLine(CountRolls(data));
    }

    private static string[] ReadInput()
    {
        string inputPath = Path.Combine(AppContext.BaseDirectory, "input.txt");
        string[] rows = File.Exists(inputPath)
            ? File.ReadAllLines(inputPath)
            : File.ReadAllLines("input.txt");
        return rows;
    }

    private static int CountRolls(string[] data)
    {
        int rollCount = 0;
        // Replace upper limit with data.Length
        for (int row = 0; row < data.Length; row++)
        {
            Console.WriteLine(data[row]);
            for (int col = 0; col < data[row].Length; col++)
            {
                if (data[row][col] == '.')
                {
                    continue;
                }
                int nCount = 0;

                // Begin counting neighbours here
                for (int dy = -1; dy <= 1; dy++)
                {
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        if (dy == 0 & dx == 0)
                            continue;

                        int ny = row + dy;
                        int nx = col + dx;

                        // Check Bounds
                        if (ny >= 0 && ny < data.Length && nx >= 0 && nx < data[ny].Length)
                        {
                            if (data[ny][nx] == '@')
                            {
                                nCount++;
                            }
                        }
                    }
                }
                if (nCount < 4)
                {
                    Console.WriteLine(nCount);
                    rollCount++;
                }
            }
        }
        return rollCount;
    }
}
