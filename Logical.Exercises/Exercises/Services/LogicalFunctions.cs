using Exercises.Extension;
using Exercises.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Services
{
    internal class LogicalFunctions
    {
        #region 1. Option
        public static int FindLargestNumber(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("The array is empty or null.");
            }

            int largest = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > largest)
                {
                    largest = array[i];
                }
            }

            return largest;
        }
        #endregion

        #region 2. Option
        public static bool IsPalindrome(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }

            int start = 0;
            int end = word.Length - 1;

            while (start < end)
            {
                if (word[start] != word[end])
                {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }
        #endregion

        #region 3. Option
        public static int CalculateFactorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Negative numbers do not have a defined factorial.");
            }

            if (number == 0 || number == 1)
            {
                return 1;
            }

            int result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
        #endregion

        #region 4. Option
        public static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 5. Option
        public static int CountOccurrences(int[] array, int element)
        {
            int counter = 0;
            foreach (int num in array)
            {
                if (num == element)
                {
                    counter++;
                }
            }
            return counter;
        }
        #endregion

        #region 6. Option
        public static void FilesName()
        {
            string directoryPath = @"C:\Users\Marcelo\Desktop\test1";

            // Using the above directory, start getting files in subfolders
            Dictionary<string, List<string>> filesInSubfolders = GetAllFilesInSubfolders(directoryPath);

            Console.WriteLine("Files found in each subfolder:");
            foreach (var folder in filesInSubfolders)
            {
                Console.WriteLine($"Subfolder: {folder.Key}");
                foreach (var file in folder.Value)
                {
                    Console.WriteLine($"- {file}");
                }
                Console.WriteLine();
            }
        }

        private static Dictionary<string, List<string>> GetFilesInFolder(string folderPath)
        {
            Dictionary<string, List<string>> filesInSubfolders = new Dictionary<string, List<string>>();

            try
            {
                // Get files in folderPath and assign them to the array
                string[] files = Directory.GetFiles(folderPath);
                filesInSubfolders[folderPath] = new List<string>(files);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Access denied to folder: {folderPath}");
            }

            return filesInSubfolders;
        }

        private static Dictionary<string, List<string>> GetAllFilesInSubfolders(string rootFolderPath)
        {
            Dictionary<string, List<string>> filesInSubfolders = new Dictionary<string, List<string>>();

            // Get all files in folder
            filesInSubfolders[rootFolderPath] = GetFilesInFolder(rootFolderPath)[rootFolderPath];

            // Search for subfolders
            string[] subfolders = Directory.GetDirectories(rootFolderPath);

            // Find all files in each subfolders
            foreach (string subfolder in subfolders)
            {
                // Recursive function to list all files in each subfolder
                filesInSubfolders = GetAllFilesInSubfoldersRecursive(subfolder, filesInSubfolders);
            }

            return filesInSubfolders;
        }

        private static Dictionary<string, List<string>> GetAllFilesInSubfoldersRecursive(string folderPath, Dictionary<string, List<string>> filesInSubfolders)
        {
            filesInSubfolders[folderPath] = GetFilesInFolder(folderPath)[folderPath];

            string[] subfolders = Directory.GetDirectories(folderPath);
            foreach (string subfolder in subfolders)
            {
                filesInSubfolders = GetAllFilesInSubfoldersRecursive(subfolder, filesInSubfolders);
            }
            return filesInSubfolders;
        }
        #endregion
    }
}
