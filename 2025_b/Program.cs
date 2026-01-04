// At the moment, `undo` will undo and entire written section???
// Also doesn't space opening brackets underneath the method signature
namespace _2025b;

internal static class Program {
  private static void Main(string[] args) {
    // Init variables
    long count = 0;
    string input = ReadInput();
    string[] ranges = input.Split(',');


    // ID ranges get fed into factory here
    foreach (var item in ranges) {
      Console.WriteLine($"Iterating over range: {item}");
      count += FindInvalidIDs(item);
    }


    // Print the final answer
    Console.WriteLine($"## Final Count: {count} ##");

  }

  // Read the input text file into an array
  private static string ReadInput() {
    string inputPath = Path.Combine(AppContext.BaseDirectory, "input.txt");
    string[] ranges = File.Exists(inputPath)
      ? File.ReadAllLines(inputPath)
      : File.ReadAllLines("input.txt");
    return ranges[0];
  }

  // This method takes a single range of IDs, such as:
  // '2558912-2663749'
  // Then iterates over this range to find invalid IDs.
  // It will return the sum of invalid IDs found.
  private static long FindInvalidIDs(string IDRange) {
    long subcount = 0;
    string[] limits = IDRange.Split('-');
    long llim = long.Parse(limits[0]);
    long ulim = long.Parse(limits[1]);
    for (long id = llim; id <= ulim; id++) {
      string ID = id.ToString();
      int mid = ID.Length / 2;
      string str1 = ID.Substring(0, mid);
      string str2 = ID.Substring(mid);
      if (str1 == str2) {
        Console.WriteLine($"Invalid ID: {id}");
        subcount += id;

      }
    }

    return subcount;
  }
}
