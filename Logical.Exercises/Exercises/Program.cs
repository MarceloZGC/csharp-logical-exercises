using Exercises.Extension;
using Exercises.Model;
using Exercises.Services;
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        bool continueExecution = true;
        while (continueExecution)
        {
            ShowMenu();
            int option = ReadOption();
            ExecuteOption(option);
            continueExecution = AskToContinue();
            if (continueExecution)
            {
                Console.Clear();
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("################### MENU ###################\n");
        Console.WriteLine("1. Find the largest number in an array");
        Console.WriteLine("2. Check if a string is a palindrome");
        Console.WriteLine("3. Calculate the factorial of a number");
        Console.WriteLine("4. Check if a number is prime");
        Console.WriteLine("5. Count the number of occurrences of an element in an array");
        Console.WriteLine("6. Get all files in subfolders");
        Console.WriteLine("0. Exit");
    }

    static int ReadOption()
    {
        int option;
        while (true)
        {
            Console.Write("\n\nSelect an option: ");
            if (int.TryParse(Console.ReadLine(), out option))
            {
                if (option >= 0 && option <= 6)
                {
                    break;
                }
            }
            Console.WriteLine("\nInvalid option. Please try again.\n");
        }
        return option;
    }

    static void ExecuteOption(int option)
    {
        switch (option)
        {
            case 1:
                Console.WriteLine($"\n\nExecuting Option {option} logic...\n");

                // Generate Random Array
                RandomArrayResult arrayResultLargest = ReusableFuctions.GenerateRandomArray(10, 1, 100);
                Console.WriteLine($"\nArray with random positions: [{arrayResultLargest.ArrayAsString}] \n");

                int largest = LogicalFunctions.FindLargestNumber(arrayResultLargest.Array);
                Console.WriteLine($"The largest number in the array is: {largest}");

                break;
            
            case 2:
                Console.WriteLine($"\n\nExecuting Option {option} logic...\n");

                // Inform an element string to check if it is a Palindrome
                string word = ReusableFuctions.ReadStringFromConsole();

                bool isPalindrome = LogicalFunctions.IsPalindrome(word);
                Console.WriteLine($"Is the word '{word}' a palindrome? {isPalindrome}");
                
                break;
            
            case 3:
                Console.WriteLine($"\n\nExecuting Option {option} logic...\n");

                // Inform an element number to know its factorial
                int factorialNumber = ReusableFuctions.ReadNumberFromConsole();
                int factorial = LogicalFunctions.CalculateFactorial(factorialNumber);
                Console.WriteLine($"The factorial of the number '{factorialNumber}' is: {factorial}");

                break;
            
            case 4:
                Console.WriteLine($"\n\nExecuting Option {option} logic...\n");

                // Inform an element number to check if it is Prime
                int primeNumber = ReusableFuctions.ReadNumberFromConsole();
                bool isPrime = LogicalFunctions.IsPrime(primeNumber);
                Console.WriteLine($"Is the number '{primeNumber}' a prime number? {isPrime}");

                break;
            
            case 5:
                Console.WriteLine($"\n\nExecuting Option {option} logic...\n");

                // Generate Random Array
                RandomArrayResult arrayResult = ReusableFuctions.GenerateRandomArray(50, 1, 100);
                Console.WriteLine($"\nArray with random positions: [{arrayResult.ArrayAsString}] \n");

                // Inform an element number to find the occurrences number
                int element = ReusableFuctions.ReadNumberFromConsole();

                int countOccurrences = LogicalFunctions.CountOccurrences(arrayResult.Array, element);
                Console.WriteLine($"The occurrences number of the value '{element}' is: {countOccurrences}");

                break;

            case 6:
                Console.WriteLine($"\n\nExecuting Option {option} logic...\n");

                LogicalFunctions.FilesName();

                break;

            case 0:
                Console.WriteLine("\n\nExiting program...\n");
                Environment.Exit(0);
                break;
        }
    }

    static bool AskToContinue()
    {
        Console.WriteLine("\n\nDo you want to perform another operation? (y/n)");
        string response = Console.ReadLine().Trim().ToLower();
        return response == "y";
    }   
}