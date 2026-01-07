// Unfortunately, this problem is beyond my abilities in data structures and algorithms :(
class Program
{
    static void Main()
    {
        string[] coords = File.ReadAllLines("input.txt"); // Untouched reference of all junctions
        string[] coords_checklist = File.ReadAllLines("input.txt"); // Only holds junctions that haven't yet been connected
        List<List<string>> circuits = new List<List<string>>();

        List<string> points = CalculateShortestDistance(coords, coords_checklist);
        circuits.Add(new List<string> { points[0], points[1] });

        Console.WriteLine(circuits[0][0]);
        Console.WriteLine(circuits[0][1]);
        string temp_str = "97412,2019,74375";
        Console.WriteLine(circuits[0].Contains(temp_str));

        // Ok I can effectively find the two points that are closest together.
        // Now what? Hwo the fuck do i link them together.
        //
        // Using List<List<string>>
        // check each point against each list.
        // If it exists in the list (using .Contains()), add the new point to that circuit.
    }

    static List<string> CalculateShortestDistance(string[] coords, string[] coords_checklist)
    {
        double short_distance = 100000000000;
        int indexi = 0;
        int indexj = 0;
        List<string> points = new List<string>();

        for (int i = 0; i < coords.Length - 1; i++)
        {
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
        points.Add(coords[indexi]);
        points.Add(coords[indexj]);
        return points;
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
