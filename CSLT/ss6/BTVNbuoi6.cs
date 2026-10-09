using System;
using System.Collections.Generic;
using System.Text;
internal class BTVNbuoi6
    {
        static void Main()
        {
            Random rand = new Random();
            int[] arr = new int[10];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(1, 10); 
            Console.Write("Mang ban dau: ");
            InMang(arr);
            Console.WriteLine($"Trung binh: {TinhTrungBinh(arr)}");
            Console.WriteLine($"Ket qua: {KiemTraTonTai(arr, 5)}");
            Console.WriteLine($"Vi tri cua so 5: {TimViTri(arr, 5)}");
            Console.Write($"Mang sau khi xoa so 5: ");
            InMang(XoaPhanTu(arr, 5));
            TimMinMax(arr);
            Console.Write($"Mang da dao: ");
            InMang(DaoNguoc(arr));
            Console.Write($"Cac so trung lap: ");
            TimTrungLap(arr);
            Console.Write($"Mang sau khi xoa so trung lap: ");
            InMang(XoaTrungLap(arr));
            int[] arr2 = new int[10];
            Console.WriteLine("Nhap 10 so nguyen:");
            for (int i = 0;i < 10; i++)
            {
                Console.Write($"So thu {i+1}: ");
                arr2[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < arr2.Length - 1; i++)
                for (int j = i + 1; j < arr2.Length; j++)
                    if (arr2[i] > arr2[j])
                    {
                        int temp = arr2[i];
                        arr2[i] = arr2[j];
                        arr2[j] = temp;
                    }
            Console.Write("Mang sau khi Bubble Sort: ");
            InMang(arr2);
            Console.Write("\nNhap mot cau (sentence): ");
            string sentence = Console.ReadLine();
            Console.Write("Nhap tu can tim: ");
            string word = Console.ReadLine();
            string[] words = sentence.Split(' ');
            bool found = false;
            for (int i = 0; i < words.Length; i++)
                if (words[i] == word)
                {
                    found = true;
                    Console.WriteLine($"Tim thay tu '{word}' tai vi tri tu thu {i + 1}");
                    break;
                }
            if (found == false) Console.WriteLine("Khong tim thay tu nay!");
            Console.Write("Nhap so hang N: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot M: ");
            int M = int.Parse(Console.ReadLine());
            int[,] matrix = new int[N, M];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    matrix[i, j] = rand.Next(1, 100);
            Console.WriteLine("\nMa tran ngau nhien:");
            InMaTran(matrix);
            int maxMat = matrix[0, 0];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    if (matrix[i, j] > maxMat) maxMat = matrix[i, j];
            Console.WriteLine($"\nGia tri Max cua toan ma tran: {maxMat}");
            Console.Write("\nNhap chi so hang/cot (i) can xem (bat dau tu 0): ");
            int index = int.Parse(Console.ReadLine());
            InHangVaTimMin(matrix, index);
            InCotVaTimMin(matrix, index);
            Console.WriteLine("\nMa tran chuyen vi (Transpose):");
            int[,] transposed = new int[M, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    transposed[j, i] = matrix[i, j];
            InMaTran(transposed);
            if (N == M)
            {
                Console.Write("\nDuong cheo chinh: ");
                for (int i = 0; i < N; i++) 
                    Console.Write(matrix[i, i] + " ");
                Console.Write("\nDuong cheo phu: ");
                for (int i = 0; i < N; i++) 
                    Console.Write(matrix[i, N - 1 - i] + " ");
                Console.WriteLine();
            }
            else
                Console.WriteLine("\nMa tran khong vuong nen khong in duong cheo.");
            Console.ReadLine(); 
        }
        static void InMang(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++) 
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        static double TinhTrungBinh(int[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++) sum = sum + arr[i];
            return sum / arr.Length;
        }
        static bool KiemTraTonTai(int[] arr, int val)
        {
            for (int i = 0; i < arr.Length; i++) 
                if (arr[i] == val) 
                    return true;
            return false;
        }
        static int TimViTri(int[] arr, int val)
        {
            for (int i = 0; i < arr.Length; i++) 
                if (arr[i] == val) 
                    return i;
            return -1;
        }
        static int[] XoaPhanTu(int[] arr, int val)
        {
            int dem = 0;
            for (int i = 0; i < arr.Length; i++) 
                if (arr[i] != val) 
                    dem++;
            int[] newArr = new int[dem];
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] != val)
                {
                    newArr[j] = arr[i];
                    j++;
                }
            return newArr;
        }
        static void TimMinMax(int[] arr)
        {
            int min = arr[0], max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[i];
            }
            Console.WriteLine($"Min: {min}, Max: {max}");
        }
        static int[] DaoNguoc(int[] arr)
        {
            int[] newArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                newArr[i] = arr[arr.Length - 1 - i];
            return newArr;
        }
        static void TimTrungLap(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool daXet = false;
                for (int k = 0; k < i; k++) 
                    if (arr[i] == arr[k]) 
                        daXet = true;
                if (daXet == true) continue; 
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[i] == arr[j])
                    {
                        Console.Write(arr[i] + " ");
                        break;
                    }
            }
            Console.WriteLine();
        }
        static int[] XoaTrungLap(int[] arr)
        {
            int[] temp = new int[arr.Length];
            int soLuongMoi = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                bool daTonTai = false;
                for (int k = 0; k < soLuongMoi; k++)
                {
                    if (temp[k] == arr[i])
                    {
                        daTonTai = true;
                        break;
                    }
                }
                if (daTonTai == false)
                {
                    temp[soLuongMoi] = arr[i];
                    soLuongMoi++;
                }
            }
            int[] ketQua = new int[soLuongMoi];
            for (int i = 0; i < soLuongMoi; i++) ketQua[i] = temp[i];
            return ketQua;
        }
        static void InMaTran(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                    Console.Write(mat[i, j] + "\t");
                Console.WriteLine();
            }
        }
        static void InHangVaTimMin(int[,] mat, int row)
        {
            if (row < 0 || row >= mat.GetLength(0)) return;
            int min = mat[row, 0];
            Console.Write($"Hang {row}: ");
            for (int j = 0; j < mat.GetLength(1); j++)
            {
                Console.Write(mat[row, j] + " ");
                if (mat[row, j] < min) 
                    min = mat[row, j];
            }
            Console.WriteLine($" => Min cua hang {row}: {min}");
        }
        static void InCotVaTimMin(int[,] mat, int col)
        {
            if (col < 0 || col >= mat.GetLength(1)) return;
            int min = mat[0, col];
            Console.Write($"Cot {col}: ");
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                Console.Write(mat[i, col] + " ");
                if (mat[i, col] < min) 
                    min = mat[i, col];
            }
            Console.WriteLine($" => Min cua cot {col}: {min}");
        }
}