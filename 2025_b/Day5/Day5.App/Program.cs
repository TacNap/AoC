// Start by reading in the input. There is a space between ID ranges and individual IDs.
// The main file will need to be split in two first.
// You'll need to be using Long instead of Int.
// Start by creating a set.
// Iterate over the ranges and add these to the set.
// Then, iterate over the individual IDs' and check if they arleady exist in the set.
//

class Program
{
    static void Main()
    {
        List<string> ranges = ReadRanges();
        List<string> IDs = ReadIDs();
        int fresh_count = CollectRanges(ranges, IDs);
        Console.WriteLine(fresh_count);
    }

    static List<string> ReadRanges()
    {
        List<string> ranges = new List<string>();
        try
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != "" && line != null)
                {
                    ranges.Add(line);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ran into a problem: {e.Message}");
        }
        return ranges;
    }

    static List<string> ReadIDs()
    {
        List<string> IDs = new List<string>();
        try
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != "" && line != null)
                {
                    // Do nothing
                }
                while ((line = sr.ReadLine()) != null)
                {
                    IDs.Add(line);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ran into a problem: {e.Message}");
        }
        return IDs;
    }

    static int CollectRanges(List<string> ranges, List<string> IDs)
    {
        HashSet<long> set = new HashSet<long>();
        foreach (string range in ranges)
        {
            string[] temp = range.Split('-');
            long llim = long.Parse(temp[0]);
            long ulim = long.Parse(temp[1]);
            // DEBUG
            Console.WriteLine($"llim: {llim}");
            Console.WriteLine($"ulim: {ulim}");
            foreach (string id in IDs)
            {
                long num = long.Parse(id);
                Console.WriteLine($"num: {num}");
                if (num >= llim && num <= ulim)
                {
                    set.Add(num);
                }
            }
        }

        return set.Count();
    }
}
