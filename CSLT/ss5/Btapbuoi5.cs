using System;
using System.Collections.Generic;
using System.Text;
internal class Btapbuoi5    
{
    public static void Main5()
    {
        static void bangcuuchuong()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                    Console.WriteLine($"{i}x{j}={i * j}");
            }
        }
        static void bai1()
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
        static void bai2()
        {
            double sum = 0;
            for (int i=1; i<=10; i++)
            {
                Console.Write($"Nhap he so thu {i}: ");
                double a = double.Parse(Console.ReadLine());
                sum = sum + a;
            }
            Console.WriteLine($"Tong cua 10 he so la: {sum}");
            Console.WriteLine($"Trung binh cong cua 10 he so la: {sum/10}");
        }
        static void bai3()
        {
            Console.Write($"Nhap he so ban muon lam bang cuu chuong: ");
            int a = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 10; i++) 
                Console.WriteLine($"{a}x{i}={a*i}");   
        }
        static void bai4()
        {
            Console.Write($"Nhap chieu cao cua hinh tam giac: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write($"Nhap mau hinh tam giac ban muon (1-3): ");
            int b = int.Parse(Console.ReadLine());
            if (b == 1)
            {
                for (int i = 1; i <= a; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write(j);
                    }
                    Console.WriteLine();
                }
            }
            else if(b == 2)
            {
                int counter = 1; 
                for (int i = 1; i <= a; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write(counter + " ");
                        counter++; 
                    }
                    Console.WriteLine();
                }
            }
            else if (b==3)
            {
                int count= 1;
                for (int i = 1; i <= a; i++)
                {
                    for (int space = 1; space <= a - i; space++)
                    {
                        Console.Write(" ");
                    }

                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write(count + " ");
                        count++;
                    }
                    Console.WriteLine();
                }
            }    
        }
        static void bai5()
        {
            Console.Write($"Nhap he so n: ");
            int n = int.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += 1 / i;
                Console.Write($"1/{i}");
                if(i<n)
                    Console.Write(" + ");
            }
            Console.WriteLine($" = {sum}");
        }
        static void bai6()
        {
            Console.Write("Nhap gioi han duoi: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Nhap gioi han tren: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write($"Cac so hoan hao trong khoang tu {a} den {b} la: ");
            for (int i = a; i <= b; i++)
            {
                int sum = 0;
                for (int j = 1; j <= i / 2; j++)
                    if (i % j == 0)
                        sum += j;
                if (sum == i && i > 0)
                    Console.Write($"{i}  ");
            }
            Console.WriteLine();
        }
        static void bai7()
        {
            Console.Write("Nhap mot so nguyen: ");
            int a = int.Parse(Console.ReadLine());
            bool kt = true;
            if (a < 2)
            {
                kt = false; 
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(a); i++)
                {
                    if (a % i == 0)
                    {
                        kt = false; 
                        break; 
                    }
                }
            }

            if (kt)
                Console.WriteLine($"Ket qua: {a} la so nguyen to.");
            else
                Console.WriteLine($"Ket qua: {a} khong phai la so nguyen to.");
        }
        bai7();
    }
}
