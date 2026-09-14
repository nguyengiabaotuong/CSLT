using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

internal class Btapbuoi6
{
    public static void Main6()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập số thứ 1: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Nhập số thứ 2: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Nhập số thứ 3: ");
        int c = int.Parse(Console.ReadLine());
        int max = solonnhat(a, b, c);
        Console.WriteLine($"Số lớn nhất trong 3 số là {max}");
        Console.Write("Nhập 1 số muốn tính giai thừa: ");
        int d = int.Parse(Console.ReadLine());
        int gt = giaithua(d);
        Console.WriteLine($"Giai thừa của d= {gt}");
        Console.Write("Nhập 1 số để xét số nguyên tố: ");
        int e = int.Parse(Console.ReadLine());
        if (IsPrime(e))
            Console.WriteLine($"{e} là số nguyên tố");
        else Console.WriteLine($"{e} không là số nguyên tố");
        Console.Write("Nhập 1 số để giới hạn in số nguyên tố: ");
        int limit = int.Parse(Console.ReadLine());
        Console.Write("Nhập 1 số lượng (n) số nguyên tố muốn in: ");
        int n = int.Parse(Console.ReadLine());
        Sntnhohon(limit);
        Sosnt(n);
        Console.Write("Nhập 1 số (f) để xét số hoàn hảo: ");
        int f = int.Parse(Console.ReadLine());
        if (Perfect(f))
           Console.WriteLine($"{f} là số hoàn hảo");
        else Console.WriteLine($"{f} không là số hoàn hảo");
        Console.Write("Nhập một chuỗi để xét chuỗi Pangram: ");
        string text = Console.ReadLine();
        if (IsPangram(text))
            Console.WriteLine($"{text} là chuỗi Pangram");
        else Console.WriteLine($"{text} không là chuỗi Pangram");
    }
    static int solonnhat(int a, int b, int c)
    {
        if (a > b && a > c)
            return a;
        else if (b > a && b > c)
            return b;
        else return c;
    }
    static int giaithua(int d)
    {
        int a = 1;
        for (int i=1; i<=d;  i++ )
            a *= i;
        return a;
    }
    static bool IsPrime(int e)
    {
        if (e < 2) return false;
        for (int i = 2; i <= Math.Sqrt(e); i++)
            if (e % i == 0) return false; 
        return true;
    }
    static void Sntnhohon(int limit)
    {
        Console.Write($"Các số nguyên tố nhỏ hơn {limit}: ");
        for (int i = 2; i < limit; i++)
            if (IsPrime(i)) Console.Write(i + " ");
        Console.WriteLine();
    }
    static void Sosnt(int n)
    {
        Console.Write($"{n} số nguyên tố đầu tiên: ");
        int count = 0;
        int number = 2; 
        while (count < n)
        {
            if (IsPrime(number))
            {
                Console.Write(number + " ");
                count++; 
            }
            number++;
        }
        Console.WriteLine();
    }
    static bool Perfect(int f)
    {
        if (f < 2) return false;
        int sum = 0;
        for (int i = 1; i <= f / 2; i++)
            if (f % i == 0) sum += i;
        return sum == f;
    }
    static void PerfUnder1000()
    {
        Console.Write("Số hoàn hảo < 1000: ");
        for (int i = 2; i < 1000; i++)
            if (Perfect(i)) Console.Write(i + " ");
    }
    static bool IsPangram(string text)
    {
        string lowerText = text.ToLower();
        for (char c = 'a'; c <= 'z'; c++)
            if (!lowerText.Contains(c))
                return false;
        return true; 
    }
}