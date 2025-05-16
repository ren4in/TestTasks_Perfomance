using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Task4
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Ошибка: укажите путь к файлу с числами.");
            return;
        }

        string path = args[0];

        try
        {
            var lines = File.ReadAllLines(path);
            var nums = lines
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(int.Parse)
                .ToList();

            if (nums.Count == 0)
            {
                Console.WriteLine("Файл пуст.");
                return;
            }

            nums.Sort();
            int median = nums[nums.Count / 2]; 

            int moves = nums.Sum(x => Math.Abs(x - median));

            Console.WriteLine(moves);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
        }
    }
}
