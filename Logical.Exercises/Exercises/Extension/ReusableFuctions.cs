using Exercises.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercises.Extension
{
    internal class ReusableFuctions
    {
        public static int ReadNumberFromConsole()
        {
            int element;
            while (true)
            {
                Console.Write("Please enter a number: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out element))
                {
                    break; // if the conversion is okay, break the loop
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            return element;
        }

        public static string ReadStringFromConsole()
        {
            Console.Write("Please enter a string: ");
            string input = Console.ReadLine();
            return input;
        }

        public static RandomArrayResult GenerateRandomArray(int length, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] array = new int[length];
            StringBuilder arrayAsStringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(minValue, maxValue + 1);
                arrayAsStringBuilder.Append(array[i]);
                if (i < length - 1)
                {
                    arrayAsStringBuilder.Append(", ");
                }
            }
            string arrayAsString = arrayAsStringBuilder.ToString();

            return new RandomArrayResult
            {
                Array = array,
                ArrayAsString = arrayAsString
            };
        }

    }
}
