class Program
{
    static void Main()
    {
        string[] coords = File.ReadAllLines("input.txt");
        double short_distance = 100000000000;
        int indexi = 0;
        int indexj = 0;

        for (int i = 0; i < coords.Length - 1; i++)
        {
            Console.WriteLine($"Iterating Line: {coords[i]}");
            for (int j = i + 1; j < coords.Length; j++)
            {
                // calculate shortest distance
                double distance = CalculateDistance(coords[i], coords[j]);
                if (distance < short_distance)
                {
                    short_distance = distance;
                    indexi = i;
                    indexj = j;
                }
            }
        }
        Console.WriteLine(short_distance);
        Console.WriteLine($"i: {indexi}");
        Console.WriteLine($"j: {indexj}");
        // Ok I can effectively find the two points that are closest together.
        // Now what? Hwo the fuck do i link them together.
        //
        // Using List<List<string>>
        // check each point against each list.
        // If it exists in the list (using .Contains()), add the new point to that circuit.
    }

    static double CalculateDistance(string p1, string p2)
    {
        double distance = 0;
        string[] P1 = p1.Split(',');
        string[] P2 = p2.Split(',');
        // truly optimised
        double p1x = double.Parse(P1[0]);
        double p1y = double.Parse(P1[1]);
        double p1z = double.Parse(P1[2]);
        double p2x = double.Parse(P2[0]);
        double p2y = double.Parse(P2[1]);
        double p2z = double.Parse(P2[2]);
        double dx = p1x - p2x;
        double dy = p1y - p2y;
        double dz = p1z - p2z;

        // calculate euclidian distance
        distance = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2) + Math.Pow(dz, 2));

        return distance;
    }
}
