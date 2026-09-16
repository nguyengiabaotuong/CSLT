using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;
internal class BTVNbuoi6
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        /*Console.Write("Nhap so nguyen thu 1: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Nhap so nguyen thu 2: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine($"Tong 2 so nguyen  = {sum(a,b)}");
        Console.Write("Nhap 1 so nguyen de kiem tra chan le: ");
        int d = int.Parse(Console.ReadLine());
        Console.WriteLine($"Ket qua: {chanle(d)}");
        Console.Write("Nhap so nguyen thu 3: ");
        int c = int.Parse(Console.ReadLine());
        Console.WriteLine($"So nguyen lon nhat trong 3 so nguyen la: {max(a, b, c)}");
        Console.Write("Nhap so nguyen de tinh giai thua: ");
        int e = int.Parse(Console.ReadLine());
        Console.WriteLine($"Giai thua cua {e}= {gt(e)}");
        Console.Write("Nhap chuoi ban muon dao nguoc: ");
        string chuoi = Console.ReadLine();
        Console.WriteLine($"Ket qua: {daochuoi(chuoi)}");
        Console.Write("Nhap so nguyen de xet so nguyen to: ");
        int f = int.Parse(Console.ReadLine());
        if (snt(f))
            Console.WriteLine("True");
        else Console.WriteLine("False");
        Console.Write("Nhap so nguyen muon viet day fibonacci: ");
        int g = int.Parse(Console.ReadLine());
        fibo(g);
        Console.Write("Nhap chuoi ban muon dem so ky tu nguyen am: ");
        string s = Console.ReadLine();
        Console.WriteLine($"{vowel(s)}");*/
    }
    static int sum(int a, int b)
    { return a + b; }
    static string chanle(int d)
    {
        bool le = true;
        string kt = "";
        if (d % 2 == 0)
            le = false;
        if (le)
            kt = $"{d}%2 ≠ 0 -> {d} la so le ";
        else kt = $"{d}%2 = 0 -> {d} la so chan ";
        return kt;
    }
    static int max(int a,int b,int c)
    {
        return Math.Max(Math.Max(a, b), c);
    }
    static long gt(int e)
    {
        long kq = 1;
        for (int i = 1; i <= e; i++)
            kq *= i;
        return kq;
    }
    static string daochuoi(string chuoi)
    {
        char[] charArray = chuoi.ToCharArray();
        Array.Reverse(charArray);
        string kq = new string(charArray);
        return kq;
    }
    static bool snt(int f)
    {
        bool snt = true;
        for (int i = 2; i < f/2; i++)
            if (f % i == 0)
            {
                snt = false;
                break;
            }
        return snt;
    }
    static void fibo (int g)
    {
        if (g <= 0) return;
        if (g == 1)
        {
            Console.WriteLine("0");
            return;
        }
        int a = 0;
        int b = 1;
        Console.Write($"{a} {b} ");
        for (int i=3; i<=g;i++)
        {
            int c = a + b;
            Console.Write($"{c} ");
            a = b;
            b = c;
        }
        Console.WriteLine();
    }
    static int vowel (string s)
    {
        int dem = 0;
        foreach (char b in s)
        {
            char c = Char.ToLower(b);
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                dem ++;
        }
        return dem;
    }
    static double luythua ( double x, int y)
    {

    }

}
        

