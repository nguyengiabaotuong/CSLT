using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;
internal class Btapbuoi7
{
    public static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 2, 4 };
        Console.WriteLine($"Gia tri trung binh cua mang: {dtb(arr)}");
        Console.WriteLine($"Ket qua kiem tra: {ktra(arr,3)}");
        Console.WriteLine($"Index (2) nam o vi tri thu {index(arr,2)}");
        remove(arr, 4);
        Console.WriteLine($"Gia tri nho nhat va lon nhat: {minmax(arr)}");
        latmang(arr);
        trunglap(arr);
        Console.WriteLine($"Mang sau khi xoa trung lap: ");
        int[] kq = xoatrung(arr);
        foreach (int i in kq)
            Console.Write($"{i} ");
    }
    static double dtb(int[] arr)
    {
        double kq = 0;
        for (int i = 0; i < arr.Length; i++)
            kq += arr[i];
        kq = kq / (arr.Length);
        return kq;
    }
    static bool ktra(int[] arr, int a)
    {
        bool kt = false;
        foreach (int i in arr)
            if (i == a)
                kt = true;
        return kt;
    }
    static int index(int[] arr, int b)
    {
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == b)
                return i;
        return -1;
    }
    static void remove(int[] arr, int c)
    {
        int n = 0;
        foreach (int i in arr)
            if (i == c)
                n++;
        int[] newarr = new int[arr.Length - n];
        int j = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == c)
                continue;
            newarr[j] = arr[i];
            j++;

        }
        Console.WriteLine("Mang sau khi xoa:");
        foreach (int i in newarr)
            Console.Write($"{i} ");
        Console.WriteLine();
    }
    static (int, int) minmax(int[] arr)
    {
        int min = arr[0];
        int max = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < min)
                min = arr[i];
            if (arr[i] > max)
                max = arr[i];
        }
        return (min, max);
    }
    static void latmang(int[] arr)
    {
        int[] newarr = new int[arr.Length];
        int j = 0;
        for (int i = arr.Length - 1; i == 0; i--)
        {
            newarr[j] = arr[i];
            j++;
        }
        Console.WriteLine("Mang sau khi lat: ");
        foreach (int a in arr)
            Console.Write($"{a} ");
        Console.WriteLine();
    }
    static void trunglap(int[] arr)
    {
        Console.Write("Cac so trung lap la: ");
        for (int i = 0; i < arr.Length - 1; i++)
        {
            bool daxet = false;
            for (int k = 0; k < i; k++)
                if (arr[i] == arr[k])
                {
                    daxet = true;
                    break;
                }
            if (daxet) continue; 
            for (int j = i + 1; j < arr.Length; j++)
                if (arr[i] == arr[j])
                {
                    Console.Write($"{arr[i]} ");
                    break; 
                }
        }
        Console.WriteLine();
    }
    static int[] xoatrung(int[]arr)
    {
        int[] newarr = new int[arr.Length];
        int soLuongMoi = 0; 
        for (int i = 0; i < arr.Length; i++)
        {
            bool daTonTai = false;
            for (int k = 0; k < soLuongMoi; k++)
                if (newarr[k] == arr[i])
                {
                    daTonTai = true;
                    break; 
                }
            if (!daTonTai)
            {
                newarr[soLuongMoi] = arr[i];
                soLuongMoi++; 
            }
        }
        // Bước 3: Lúc này mảng temp có thể bị dư rất nhiều ô trống ở cuối. 
        // Ta tạo mảng kết quả VỪA KHÍT với số lượng thực tế.
        int[] ketQua = new int[soLuongMoi];
        for (int i = 0; i < soLuongMoi; i++)
            ketQua[i] = newarr[i];
        return ketQua;
    }
}
