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
        int[] arr = { 1, 2, 3, 4 };
        /*Console.WriteLine($"Gia tri trung binh cua mang: {dtb(arr)}");
        Console.WriteLine($"Ket qua kiem tra: {ktra(arr,3)}");
        Console.WriteLine($"Index (2) nam o vi tri thu {index(arr,2)}");
        remove(arr, 4);
        Console.WriteLine($"Gia tri nho nhat va lon nhat: {minmax(arr)}");*/
        latmang(arr);
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
        int i = 0;
        int j = arr.Length - 1;
        while (i < j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            i++;
            j--;
        }
        Console.WriteLine("Mang sau khi lat: ");
        foreach (int a in arr)
            Console.Write($"{a} ");

    }

}
