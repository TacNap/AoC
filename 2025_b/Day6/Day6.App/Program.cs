class Program
{
    static void Main()
    {
        List<string[]> problems = ReadInput();
        Solutions(problems);
    }

    static List<string[]> ReadInput()
    {
        List<string[]> problems = new List<string[]>();
        try
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != "" && line != null)
                {
                    problems.Add(line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Something went wrong: {e.Message}");
        }

        return problems;
    }

    static void Solutions(List<string[]> problems)
    {
        long sum = 0;
        for (int col = 0; col < problems[0].Length; col++)
        {
            bool prod = problems[problems.Count - 1][col] == "*" ? true : false;
            long solution = prod ? 1 : 0;
            // Everything here is one problem
            for (int row = problems.Count - 2; row >= 0; row--)
            {
                Console.WriteLine(problems[row][col]);
                int num = int.Parse(problems[row][col]);
                if (prod)
                {
                    solution *= num;
                }
                else
                {
                    solution += num;
                }
            }
            sum += solution;
        }
        Console.WriteLine(sum);
    }
}
