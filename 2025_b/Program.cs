// At the moment, `undo` will undo and entire written section???
namespace _2025b;

internal static class Program {
  private static void Main(string[] args) {
    int count = 0;
    string input = ReadInput();
    Console.WriteLine("Initial Input:");
    Console.WriteLine(input);
    string[] ranges = input.Split(',');
    Console.WriteLine("Split into Ranges:");
    Console.WriteLine(ranges[0]);
    Console.WriteLine(ranges[1]);

    // read each line into ranges[];
    // for each line in ranges
    // int llim = ;
    // int ulim = ;
    // for (int i = llim; i < ulim; i++) {
    //    if (i contains some invalid pattern) {
    //      count += i;
    //    }
    // }
    //
    // Console.WriteLine(count);


  }

  // Read the input text file into an array
  // Doesn't need to separate by lines - needs to separate by something else
  private static string ReadInput() {
    string inputPath = Path.Combine(AppContext.BaseDirectory, "input.txt");
    string[] ranges = File.Exists(inputPath)
      ? File.ReadAllLines(inputPath)
      : File.ReadAllLines("input.txt");
    return ranges[0];
  }
}
