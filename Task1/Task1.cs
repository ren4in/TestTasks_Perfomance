using System;
using System.Collections.Generic;

class Task1
{
    static void Main(string[] args)
    {
         
            if (args.Length != 2)
            {
                Console.WriteLine("Ошибка: необходимо передать два аргумента: n и m.");
                return;
            }

            if (!int.TryParse(args[0], out int n) || !int.TryParse(args[1], out int m))
            {
                Console.WriteLine("Ошибка: аргументы должны быть целыми числами.");
                return;
            }

            List<int> path = new List<int>();
            int current = 1;
            do
            {
                path.Add(current);
                current = (current + m - 1) % n;
                if (current == 0)
                    current = n;
            }
            while (current != 1);

            Console.WriteLine(string.Join("", path));
        }
    }




