using System;
using System.Globalization;
using System.IO;

class Task2
{
    static void Main(string[] args)
    {
        // Проверка аргументов
        if (args.Length != 2)
        {
            Console.WriteLine("Ошибка: необходимо передать 2 аргумента — путь к файлам.");
            return;
        }

        string circleFile = args[0];
        string pointsFile = args[1];

        try
        {
            // Чтение центра и радиуса
            string[] circleLines = File.ReadAllLines(circleFile);
            string[] centerParts = circleLines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double x0 = double.Parse(centerParts[0], CultureInfo.InvariantCulture);
            double y0 = double.Parse(centerParts[1], CultureInfo.InvariantCulture);
            double r = double.Parse(circleLines[1], CultureInfo.InvariantCulture);

            double rSquared = r * r;

            // Чтение точек
            string[] points = File.ReadAllLines(pointsFile);

            foreach (string line in points)
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                double x = double.Parse(parts[0], CultureInfo.InvariantCulture);
                double y = double.Parse(parts[1], CultureInfo.InvariantCulture);

                double dx = x - x0;
                double dy = y - y0;
                double distSquared = dx * dx + dy * dy;

                if (Math.Abs(distSquared - rSquared) < 1e-9)
                    Console.WriteLine(0); // на окружности
                else if (distSquared < rSquared)
                    Console.WriteLine(1); // внутри
                else
                    Console.WriteLine(2); // снаружи
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при обработке файлов: " + ex.Message);
        }
    }
}
