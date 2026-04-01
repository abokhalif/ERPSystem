using System;
using System.Text;

class Program
{
    static string RunLengthEncode(string input, int runLength)
    {
        StringBuilder encodedString = new StringBuilder();

        int count = 1;
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == input[i - 1])
            {
                count++;
                if (count > runLength)
                {
                    encodedString.Append(runLength);
                    encodedString.Append(input[i - 1]);
                    count = 1;
                }
            }
            else
            {
                encodedString.Append(count);
                encodedString.Append(input[i - 1]);
                count = 1;
            }
        }

        encodedString.Append(count);
        encodedString.Append(input[input.Length - 1]);

        return encodedString.ToString();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter the string to encode:");
        string input = Console.ReadLine();

        Console.WriteLine("Enter the run length:");
        int runLength = int.Parse(Console.ReadLine());

        string encodedString = RunLengthEncode(input, runLength);
        Console.WriteLine("Original string: " + input);
        Console.WriteLine("Encoded string: " + encodedString);
    }
}
