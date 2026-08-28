using System;
using System.Collections.Generic;
using System.Text;

internal class BTVNbuoi4
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        static void cau1()
        {
            Console.Write("Nhap he so a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Nhập he so b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Nhập he so c: ");
            double c = double.Parse(Console.ReadLine());
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                        Console.WriteLine("Ket qua: Phuong trinh co vo so nghiem.");
                    else
                        Console.WriteLine("Ket qua: Phuong trinh vo nghiem.");
                }
                else
                {
                    double x = -c / b;
                    Console.WriteLine($"Ket qua: Phuong trinh co 1 nghiem duy nhat x = {x}");
                }
            }
            else
            {
                double delta = Math.Pow(b, 2) - 4 * a * c;
                Console.WriteLine($"Delta = {delta}");
                if (delta < 0)
                    Console.WriteLine("Ket qua: Phuong trinh vo nghiem (Delta < 0).");
                else if (delta == 0)
                {
                    double x = -b / (2 * a);
                    Console.WriteLine($"Ket qua: Phuong trinh co nghiem kep x1 = x2 = {x}");
                }
                else
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    Console.WriteLine("Ket qua: Phuong trinh co 2 nghiem phan biet:");
                    Console.WriteLine($"x1 = {x1}");
                    Console.WriteLine($"x2 = {x2}");
                }
            }
        }
        static void cau2()
        {
            Console.Write("Nhap 1 so nguyen:");
            int a = int.Parse(Console.ReadLine());
            if ( a%2 ==0)
                Console.WriteLine($"Ket qua: {a} la so chan"); 
            else
                Console.WriteLine($"Ket qua: {a} la so le");
        }
        static void cau3()
        {
            Console.Write("Nhap so thu 1: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Nhap so thu 2: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Nhap so thu 3: ");
            int c = int.Parse(Console.ReadLine());

            if (a >= b && a >= c)
                Console.WriteLine($"So lon nhat la: {a}");
            else if (b >= a && b >= c)
                Console.WriteLine($"So lon nhat la: {b}");
            else
                Console.WriteLine($"So lon nhat la: {c}");
        }
        static void cau4()
        {
            Console.WriteLine("Nhap chieu dai 3 canh cua tam giac:");
            Console.Write("Canh a:");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Canh b:");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Canh c:");
            int c = int.Parse(Console.ReadLine());
            if (a == b && b == c)
                Console.WriteLine("Day la tam giac deu (Equilateral).");
            else if (a == b || b == c || a == c)
                Console.WriteLine("Day la tam giac can (Isosceles).");
            else
                Console.WriteLine("Day la tam giac thuong (Scalene).");
        }
        static void cau5()
        {
            Console.Write("Nhap toa do X: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Nhap toa do Y: ");
            int y = int.Parse(Console.ReadLine());
            if (x > 0 && y > 0)
                Console.WriteLine($"Toa do ({x},{y}) nam o goc phan tu thu 1 (1st Quadrant).");
            else if (x < 0 && y > 0)
                Console.WriteLine($"Toa do ({x},{y}) nam o goc phan tu thu 2 (2st Quadrant).");
            else if (x < 0 && y < 0)
                Console.WriteLine($"Toa do ({x},{y}) nam o goc phan tu thu 3 (3st Quadrant).");
            else if (x > 0 && y < 0)
                Console.WriteLine($"Toa do ({x},{y}) nam o goc phan tu thu 4 (4st Quadrant).");
            else if (x == 0 && y == 0)
                Console.WriteLine($"Toa do ({x},{y}) nam tai goc toa do (Origin).");
            else if (x != 0 && y == 0)
                Console.WriteLine($"Toa do ({x},{y}) nam tren truc x.");
            else 
                Console.WriteLine($"Toa do ({x},{y}) nam tren truc y.");
        }
        cau5();
    }
}

