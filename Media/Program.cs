using System;
using System.Collections.Generic;

public class LZW
{
    // Method for LZW compression
    public static List<int> LZWCompress(string input_data)
    {
        // Initialize dictionary with ASCII characters
        var dictionary = new Dictionary<string, int>();
        for (int i = 0; i < 256; i++)
        {
            dictionary[Convert.ToChar(i).ToString()] = i;
        }

        int dict_size = 256; // Initial dictionary size
        string w = ""; // Initialize current string
        var compressed = new List<int>(); // List to store compressed data

        // Loop through input data
        foreach (char c in input_data)
        {
            string wc = w + c; // Concatenate current string with next character
            if (dictionary.ContainsKey(wc))
            {
                w = wc; // If wc is in the dictionary, update current string
            }
            else
            {
                compressed.Add(dictionary[w]); // Add index of w to compressed data
                dictionary[wc] = dict_size; // Add wc to dictionary
                dict_size++; // Increment dictionary size
                w = c.ToString(); // Set current string to the next character
            }
        }
        if (!string.IsNullOrEmpty(w))
        {
            compressed.Add(dictionary[w]); // Add index of the last string to compressed data
        }
        return compressed; // Return compressed data
    }

    // Main method to demonstrate LZW compression
    public static void Main(string[] args)
    {
        string input_data = "wabbawabba"; // Sample input data
        List<int> compressed_data = LZWCompress(input_data); // Compress the input data
        Console.WriteLine("Original: " + input_data);
        Console.WriteLine("Compressed: " + string.Join(", ", compressed_data)); // Print compressed data
    }
}
