namespace _2025b;

internal static class Program
{
    private static void Main(string[] args)
    {
        int voltage = 0;
        string[] banks = ReadInput();
        foreach (var bank in banks)
        {
            voltage += FindVoltage(bank);
        }
        Console.WriteLine($"Final Voltage: {voltage}");
    }

    private static string[] ReadInput()
    {
        string inputPath = Path.Combine(AppContext.BaseDirectory, "input.txt");
        string[] banks = File.Exists(inputPath)
            ? File.ReadAllLines(inputPath)
            : File.ReadAllLines("input.txt");
        return banks;
    }

    private static int FindVoltage(string bank)
    {
        int num1 = 0;
        int num2 = 0;
        int checkpoint = 0;
        Console.WriteLine(bank);
        for (int i = 0; i < bank.Length - 1; i++)
        {
            int num = bank[i] - '0'; // very strange method of converting char to int.
            if (num1 < num)
            {
                num1 = num;
                checkpoint = i; // in order to remove from bank string
            }
        }

        Console.WriteLine(bank.Substring(checkpoint + 1));
        Console.WriteLine($"(Found) {num1}");
        for (int i = checkpoint + 1; i < bank.Length; i++)
        {
            int num = bank[i] - '0';
            if (num2 < num)
            {
                num2 = num;
            }
        }
        Console.WriteLine($"(Found) {num2}");
        string str1 = num1.ToString();
        string str2 = num2.ToString();
        Console.WriteLine($"Voltage: {str1}{str2}");
        return int.Parse(str1 + str2);
    }
}
// At the moment, this version just finds the largest two digits and returns them.
// Instead, it needs to find the largest two-digit number IN ORDER.
// This will have some weird edge cases i think.
// But otherwise, just find the largest digit, then find the largest digit AFTER THAT.
// Still iterate once to find the first, largest digit
// Iterate again from that digit to find the next largest.
// Not sure how this will work when the final index is the largest number.
