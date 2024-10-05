using System;
using System.Text;

class PasswordCracker
{
    private static DateTime dtStart = DateTime.Now;
    private static DateTime dtEnd;

    // Target password to crack
    private static string targetPassword = "abc123DE";

    // All possible characters (you can extend this)
    private static char[] characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

    // Max length of password (can be adjusted)
    private static int maxLength = 8;

    public static void Main(string[] args)
    {
        // Start with an empty solution and try to brute-force the password
        StringBuilder currentGuess = new StringBuilder();
        bool success = CrackPassword(currentGuess, 0);

        if (success)
        {
            Console.WriteLine("Password found: " + currentGuess.ToString());
        }
        else
        {
            Console.WriteLine("Password not found.");
        }
        dtEnd = DateTime.Now;
        Console.WriteLine("Time " + (dtEnd - dtStart));
    }

    // Recursive backtracking function to try all combinations
    private static bool CrackPassword(StringBuilder currentGuess, int position)
    {
        // Base case: If the length of the current guess matches the target, check if it's correct
        if (currentGuess.Length == targetPassword.Length)
        {
            if (currentGuess.ToString() == targetPassword)
            {
                return true; // Password cracked
            }
            return false; // Backtrack
        }

        // Try each character at the current position
        for (int i = 0; i < characters.Length; i++)
        {
            // Append a character to the current guess
            currentGuess.Append(characters[i]);

            // Recursively try to extend the guess
            if (CrackPassword(currentGuess, position + 1))
            {
                return true; // Password found
            }

            // If not successful, backtrack by removing the last character
            currentGuess.Length--; // Backtrack
        }

        // If no solution found, return false
        return false;
    }
}
