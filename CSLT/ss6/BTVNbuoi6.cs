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
        Console.Write("Nhap so nguyen thu 1: ");
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
            Console.WriteLine("True! {f} la so nguyen to");
        else Console.WriteLine("False! {f} khong la so nguyen to");
        Console.Write("Nhap so nguyen muon viet day fibonacci: ");
        int g = int.Parse(Console.ReadLine());
        fibo(g);
        Console.Write("Nhap chuoi: ");
        string s = Console.ReadLine();
        Console.WriteLine($"So nguyen am trong cau la: {vowel(s)}");
        Console.Write("Nhap he so thu 1 de tinh luy thua: ");
        double h = double.Parse(Console.ReadLine());
        Console.Write("Nhap he so thu  2 de tinh luy thua: ");
        int i = int.Parse(Console.ReadLine());
        Console.WriteLine($"{h} mũ {i} = {luythua(h,i)}");
        Console.Write("Nhap so phan tu cua mang: ");
        int j = int.Parse(Console.ReadLine());
        int[] arr = new int[j];
        for (int o = 0; i < arr.Length; o++)
        {
            Console.Write($"Nhap gia tri cho vi tri thu {o+1}: ");
            arr[o] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine($"Gia tri trung binh cua {j} so= {dtb(arr)}");
        Console.WriteLine($"{doixung(s)}");
        Console.Write("Nhap nhiet do (celsius): ");
        int cel = int.Parse(Console.ReadLine());
        Console.WriteLine($"Nhiet do (fahrenheit): {celtofah(cel):N2}");
        Console.WriteLine($"Phan tu nho nhat trong mang la: {mininarr(arr)}");
        Console.Write("Nhap 1 so nguyen de tinh tong cac chu so thanh phan: ");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine($"Tong cac chu so co trong so: {tongchuso(k)}");
        sapxepmang(arr);
        Console.WriteLine($"Ket qua: {xoatrung(s)}");
        Console.Write("Nhap so nguyen thu 1: ");
        int l = int.Parse(Console.ReadLine());
        Console.Write("Nhap so nguyen thu 2: ");
        int m = int.Parse(Console.ReadLine());
        Console.WriteLine($"Uoc chung lon nhat cua {l} va {m} la {ucln(l,m)}");
        Console.Write("Nhap 1 so thap phan: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine($"Chuoi nhi phan: {decimaltobinarynhanh(n)}");
        Console.Write("Nhap 1 nam ban muon kiem tra co phai nhuan hay khong: ");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine($"{ktnam(year)}");
        Console.Write("Nhap 1 cau de dem so tu: ");
        string sentence = Console.ReadLine();
        Console.WriteLine($"So tu co trong cau: {demsotu(sentence)}");
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
    static double luythua ( double h, int i)
    {
        double kq = 1;
        for (int j = 1; j <= i; j++)
            kq = kq * h;
        return kq;
    }
    static double dtb(int[] arr)
    {
        double kq = 0;
        for (int i = 0; i < arr.Length; i++)
            kq += arr[i];
        kq = kq / (arr.Length);
        return kq;

    }
    static bool doixung(string s)
    {
        string latchuoi = daochuoi(s);

        if (s == latchuoi)
            return true;
        else
            return false;
    }
    static double celtofah( double cel)
    {
        double fah = cel * 1.8 + 32;
        return fah;
    }
    static int mininarr(int[] arr)
    {
        int min = arr[0];
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] < min)
                min = arr[i];
        return min;
    }
    static int tongchuso(int k)
    {
        k = Math.Abs(k);
        int sum = 0;
        while (k>0)
        {
            int socuoi = k % 10;
            sum += socuoi;
            k = k / 10;
        }
        return sum;
    }
    static void sapxepmang(int[] arr)
    {
        for (int i = 0; i<arr.Length-1;i++)
        {
            for (int j = 0; i < arr.Length; j++)
                if (arr[i] > arr[j])
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }    
        }
        foreach (int so in arr)
        {
            Console.Write($"{so} ");
        }
        Console.WriteLine();
    }
    static string xoatrung (string s)
    {
        string ketQua = ""; 
        foreach (char c in s) 
            if (!ketQua.Contains(c.ToString()))
                ketQua += c; 
        return ketQua;
    }
    static int ucln(int l, int m)
    {
        l = Math.Abs(l);
        m = Math.Abs(m);
        while (m != 0)
        {
            int phanDu = l % m; // Tìm phần dư của a chia cho b
            l = m;              // Đẩy b lên làm số bị chia mới
            m = phanDu;         // Đẩy phần dư lên làm số chia mới
        }
        // Khi b = 0, vòng lặp dừng lại. Số a lúc này chính là ƯCLN.
        return l;
    }
    static string decimaltobinary(int n)
    {
        if (n == 0) return "0";

        string ketQua = "";
        while (n > 0)
        {
            int phanDu = n % 2; 
            ketQua = phanDu + ketQua;
            n = n / 2; 
        }
        return ketQua;
    }
    static string decimaltobinarynhanh(int n)
    {
        return Convert.ToString(n, 2);
    }
    static bool ktnam (int year)
    {
        if (year % 4 == 0)
            return true;
        else return false;
    }
    static int demsotu (string sentence)
    {
        int dem = 1;
        foreach (char a in sentence)
            if (a == ' ')
                dem++;
        return dem;
    }
}

        

