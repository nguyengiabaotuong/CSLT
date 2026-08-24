using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;



internal class Btapbuoi4
{
    public static void Main()
    {
        static void bai1()
        {
            //Write a C# Sharp program that takes two numbers as input and 
            //performs an operation(+,-,*,x,/) on them and displays the result of that
            //operation.
            Console.Write("Enter the  first number: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter the  second number: ");
            double b = double.Parse(Console.ReadLine());
            double sum = a + b;
            double minus = a - b;
            double mul = a * b;
            double div = a / b;
            double mod = a % b;
            Console.WriteLine($"Adding= {sum}");
            Console.WriteLine($"Substracting= {minus}");
            Console.WriteLine($"Multiplying= {mul:F3}");
            Console.WriteLine($"Dividing= {div:F3}");
        }
        static void bai2()
        {
            //Write a C# Sharp program to display certain values of the function x = y2 
            //+ 2y + 1(using integer numbers for y, ranging from - 5 to + 5)
            int x = 0;
            Console.WriteLine("Funtion y^2 + 2y + 1 : ");
            for (int y = -5; y <= 5; y++)
            {
                x = y * y + 2 * y + 1;
                Console.WriteLine($"The value of function with y= {y} is: {x}");
            }
        }
        static void bai3()
        {
            //Write a C# Sharp program that takes distance and time (hours, minutes, 
            //seconds) as input and displays speed in kilometers per hour(km / h) and
            //miles per hour(miles/ h).
            Console.Write("Enter the distance (meters): ");
            int distance = int.Parse(Console.ReadLine());
            Console.Write("Enter the time - hours: ");
            float hours = float.Parse(Console.ReadLine());
            Console.Write("Enter the time - minutes: ");
            int minutes = int.Parse(Console.ReadLine());
            Console.Write("Enter the time - seconds: ");
            int seconds = int.Parse(Console.ReadLine());
            float totalHours = hours + (minutes / 60.0f) + (seconds / 3600.0f);
            float distanceKm = distance / 1000.0f;
            float distanceMiles = distance / 1609.344f;
            float kmPerHr = distanceKm / totalHours;
            float milesPerHr = distanceMiles / totalHours;
            Console.WriteLine($"Speed in km/h is: {kmPerHr:F5}");
            Console.WriteLine($"Speed in miles/h is: {milesPerHr:F5}");
        }
        static void bai4()
        {
            //Write a C# Sharp program that takes the radius of a sphere as input and 
            //calculates and displays the surface and volume of the sphere.V =
            //4 / 3 * π * r3
            Console.Write("Enter the r: ");
            float r = Convert.ToSingle(Console.ReadLine());
            double s = 4 * Math.PI * r * r;
            double v = 4 / 3 * Math.PI * r * r * r;
            Console.WriteLine($"Surface: {s}");
            Console.WriteLine($"Volume: {v}");
        }
        static void bai5()
            {
                Console.Write("Enter a symbol: ");
                char symbol = char.Parse(Console.ReadLine());
                char lower = char.ToLower(symbol);
                if (char.IsDigit(symbol))
                {
                    Console.WriteLine("It's a digit.");
                }
                else if (lower == 'a' || lower == 'e' || lower == 'i' || lower == 'o' || lower == 'u')
                {
                    Console.WriteLine("It's a vowel.");
                }
                else
                {
                    Console.WriteLine("It's another symbol.");
                }
            }
        bai5();
    }
}


