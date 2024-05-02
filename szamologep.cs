using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int choice;
            do
            {
                Console.WriteLine("1. Összeadás");
                Console.WriteLine("2. Kivonás");
                Console.WriteLine("3. Szorzás");
                Console.WriteLine("4. Osztás");
                Console.WriteLine("5. Kiíratás a fájlból");
                Console.WriteLine("6. Kilépés");
                Console.Write("Válassz egy menüpontot: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        numbers.Clear();
                        Console.Write("Hány számmal akarsz dolgozni? ");
                        int n = int.Parse(Console.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write("Add meg a(z) {0}. számot: ", i + 1);
                            numbers.Add(int.Parse(Console.ReadLine()));
                        }
                        int sum = 0;
                        StringBuilder operation = new StringBuilder();
                        foreach (int number in numbers)
                        {
                            sum += number;
                            operation.Append(number + " + ");
                        }
                        operation.Length -= 3; // Remove the last " + "
                        operation.Append(" = " + sum);
                        Console.WriteLine("Az összeg: {0}", sum);
                        StreamWriter sw = new StreamWriter("output.txt", true);
                        sw.WriteLine(operation.ToString());
                        sw.WriteLine("---------------");
                        sw.Close();
                        break;
                    case 2:
                        numbers.Clear();
                        Console.Write("Hány számmal akarsz dolgozni? ");
                        n = int.Parse(Console.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write("Add meg a(z) {0}. számot: ", i + 1);
                            numbers.Add(int.Parse(Console.ReadLine()));
                        }
                        int difference = numbers[0];
                        operation = new StringBuilder(numbers[0].ToString());
                        for (int i = 1; i < numbers.Count; i++)
                        {
                            difference -= numbers[i];
                            operation.Append(" - " + numbers[i]);
                        }
                        operation.Append(" = " + difference);
                        Console.WriteLine("A különbség: {0}", difference);
                        sw = new StreamWriter("output.txt", true);
                        sw.WriteLine(operation.ToString());
                        sw.WriteLine("---------------");
                        sw.Close();
                        break;
                    case 3:
                        numbers.Clear();
                        Console.Write("Hány számmal akarsz dolgozni? ");
                        n = int.Parse(Console.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write("Add meg a(z) {0}. számot: ", i + 1);
                            numbers.Add(int.Parse(Console.ReadLine()));
                        }
                        int product = 1;
                        operation = new StringBuilder();
                        foreach (int number in numbers)
                        {
                            product *= number;
                            operation.Append(number + " * ");
                        }
                        operation.Length -= 3; // Remove the last " * "
                        operation.Append(" = " + product);
                        Console.WriteLine("A szorzat: {0}", product);
                        sw = new StreamWriter("output.txt", true);
                        sw.WriteLine(operation.ToString());
                        sw.WriteLine("---------------");
                        sw.Close();
                        break;
                    case 4:
                        Console.Write("Add meg az első számot: ");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Add meg a második számot: ");
                        int b = Convert.ToInt32(Console.ReadLine());
                        if (b == 0)
                        {
                            Console.WriteLine("Nullával nem lehet osztani!");
                        }
                        else
                        {
                            double result = (double)a / b;
                            operation = new StringBuilder(a + " / " + b + " = " + result);
                            Console.WriteLine("Az osztás eredménye: {0}",result);
                            sw = new StreamWriter("output.txt", true);
                            sw.WriteLine(operation.ToString());
                            sw.WriteLine("---------------");
                            sw.Close();
                        }
                        break;
                    case 5:
                        StreamReader sr = new StreamReader("output.txt");
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                        sr.Close();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Nem létező menüpont!");
                        break;
                }
            } while (choice != 6);
        }
    }
}