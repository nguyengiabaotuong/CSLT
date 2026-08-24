using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;


internal class Btapbuoi3
{
    public static void Main2()
    {
        //▸The Celsius scale is centigrade, 100 divisions separate the freezing point
        //from the boiling point of water.On the Fahrenheit scale of Anglo-Saxons,
        //these two points are 180 degrees apart. The Kelvin scale is an absolute
        //scale used in science.
        //▸Create a C# program to convert from degrees Celsius to Kelvin and
        //Fahrenheit. Request the user the number of degrees celsius to convert
        //them using the following conversion tables
        Console.Write("Enter the Celsius: ");
        float c = Convert.ToSingle(Console.ReadLine());
        float k = c + 273;
        float f = 1.8f * c + 32;
        Console.WriteLine($"{k} Kelvin");
        Console.WriteLine($"{Math.Round(f)} Fahrenheit");
        //▸Create a program in C# for calculate the surface and volume of a sphere, given its
        //surface = 4 * pi * radius squared
        //volume = 4/3 * pi * radius cubed
        Console.Write("Enter the r: ");
        float r = Convert.ToSingle(Console.ReadLine());
        double s = 4 * Math.PI * r * r;
        double v = 4 / 3 * Math.PI * r * r * r;
        Console.WriteLine($"Surface: {s}");
        Console.WriteLine($"Volume: {v}");
        //▸Write a program in C# that calculates the result of adding, subtracting,
        //multiplying and dividing two numbers entered by the user.
        //-In addition you should also calculate the rest of the division on the last line.
        Console.Write("Enter the  first number: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter the  second number: ");
        int b = int.Parse(Console.ReadLine());
        int sum = a + b;
        int minus = a - b;
        int mul = a * b;
        double div = a / b;
        double mod = a % b;
        Console.WriteLine($"Adding= {sum}");
        Console.WriteLine($"Substracting= {minus}");
        Console.WriteLine($"Multiplying= {mul}");
        Console.WriteLine($"Dividing= {div}");
        Console.WriteLine($" {a} mod {b}= {mod}");
    }
}


