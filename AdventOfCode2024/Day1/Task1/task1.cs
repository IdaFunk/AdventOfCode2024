using System;
using System.Collections.Generic;
using System.IO;

namespace Day1.task1
{
    public class Task1
    {
        private (List<int> array1, List<int> array2) ReadFile(string filePath)
        {
            List<int> firstArray = new List<int>();
            List<int> secondArray = new List<int>();
            string[] lines = File.ReadLines(filePath).ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(new[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 2
                && int.TryParse(parts[0], out int firstValue)
                && int.TryParse(parts[1], out int secondValue))
                {
                    firstArray.Add(firstValue);
                    secondArray.Add(secondValue);
                }
                else
                {
                    Console.WriteLine($"Ogiltig rad hittad och hoppar över: {lines[i]}");
                }
            }

            return (firstArray, secondArray);
        }

        private int SumDiff(List<int> array1, List<int> array2)
        {
            int totDiff = 0;

            array1.Sort();
            array2.Sort();

            if (array1.Count() == array2.Count())
            {
                for (int i = 0; i < array1.Count(); i++)
                {
                    int diff = array1[i] - array2[i];

                   totDiff += Math.Abs(diff);
                }
            }

            return totDiff;
        }


        public void PrintAnswer(string message)
        {
            (List<int> array1, List<int> array2) = ReadFile("Task1/input.txt");
            int diff = SumDiff(array1, array2);

            Console.WriteLine("Diff:");
            Console.WriteLine(diff);
        }

    }
}