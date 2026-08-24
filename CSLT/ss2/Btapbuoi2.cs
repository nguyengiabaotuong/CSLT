using System;

internal class Btapbuoi2
{
    public static void Main1()
    {
        //1.to Add / Sum Two Numbers.
        Console.Write("Enter first integer number: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second integer number: ");
        int b = Convert.ToInt32(Console.ReadLine());
        int sum = a + b;
        Console.WriteLine($"Sum = {sum}");
        //2.to Swap Values of Two Variables.
        int c = a;
        a = b;
        b = c;
        Console.WriteLine($"-> After swap a = {a}, b = {b}");
        //3.to Multiply two Floating Point Numbers
        Console.Write("Enter first float number: ");
        float d = Convert.ToSingle(Console.ReadLine());
        Console.Write("Enter second float number: ");
        float e = Convert.ToSingle(Console.ReadLine());
        Console.WriteLine($"-> Multiple = {d * e}");
        //4.to convert feet to meter
        Console.Write("Enter length (feet): ");
        float feet = Convert.ToSingle(Console.ReadLine());
        float meters = feet * 0.3048f;
        Console.WriteLine($"-> {feet} feet = {meters} meters");
        //5.to convert Celsius to Fahrenheit and vice versa
        Console.Write("Nhap nhiet do (Celsius): ");
        float t = Convert.ToSingle(Console.ReadLine());
        float f = (c * 1.8f) + 32;
        Console.WriteLine($"-> {c} C = {f} F");
        //6.to find the Size of data types
        Console.WriteLine($"-> Size of int: {sizeof(int)} bytes");
        Console.WriteLine($"-> Size of float: {sizeof(float)} bytes");
        Console.WriteLine($"-> Size of double: {sizeof(double)} bytes");
        Console.WriteLine($"-> Size of char: {sizeof(char)} bytes");
        Console.WriteLine($"-> Size of long: {sizeof(long)} bytes");
        //7.to Print ASCII Value(tip: read character, print number of this char)
        Console.Write("Enter a char: ");
        char ch = Convert.ToChar(Console.ReadLine());
        Console.WriteLine($"-> Gia tri ASCII cua '{ch}' la: {(int)ch}");
        //8.to Calculate Area of Circle
        Console.Write("Enter radius: ");
        double radius = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"-> Area of circle = {Math.PI * radius * radius}");
        //9.to Calculate Area of Square
        Console.Write("Enter side: ");
        double side = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"-> Area of square = {side * side}");
        //10.to convert days to years, weeks and days
        Console.Write("Enter number of day: ");
        int totalDays = Convert.ToInt32(Console.ReadLine());
        int years = totalDays / 365;
        int weeks = (totalDays % 365) / 7;
        int days = (totalDays % 365) % 7;
        Console.WriteLine($"-> {totalDays} days = {years} years, {weeks} weeks and {days} days");



    }
}
