using System;
using System.Collections.Generic;
using System.Text;
internal class BTVNbuoi7
{
    static void Main()
    {
        Console.Write("Nhap vao mot chuoi bat ky: ");
        string str = Console.ReadLine();
        Console.WriteLine($"-> Chuoi ban vua nhap la: {str}");
        int length = TinhDoDai(str);
        Console.WriteLine($"Do dai cua chuoi la: {length} ky tu");
        Console.Write("Tach tung ky tu: ");
        for (int i = 0; i < length; i++) 
            Console.Write(str[i] + " ");
        Console.WriteLine();
        Console.Write("Tung ky tu sau khi dao nguoc chuoi: ");
        for (int i = length - 1; i >= 0; i--) 
            Console.Write(str[i] + " ");
        Console.WriteLine();
        Console.WriteLine($"Tong so tu trong chuoi: {DemSoTu(str)} tu");
        Console.Write("Nhap chuoi thu 2 de so sanh voi chuoi 1: ");
        string str2 = Console.ReadLine();
        bool giongNhau = SoSanhChuoi(str, str2);
        Console.WriteLine($"-> Hai chuoi tren co giong nhau khong? {giongNhau}");
        DemLoaiKyTu(str);
        DemNguyenAmPhuAm(str);
        Console.Write("Nhap chuoi con: ");
        string substr = Console.ReadLine();
        int viTri = TimViTriChuoiCon(str, substr);
        if (viTri != -1)
            Console.WriteLine($"-> Chuoi con ton tai! Nam o vi tri index: {viTri}");
        else
            Console.WriteLine("-> Khong ton tai chuoi con nay trong chuoi goc!");
        Console.Write("Nhap 1 ky tu de kiem tra: ");
        char c = Console.ReadKey().KeyChar;
        Console.WriteLine();
        KiemTraHoaThuong(c);
        Console.WriteLine();
        Console.Write("Nhap chuoi con can dem so lan xuat hien: ");
        string substrcount = Console.ReadLine();
        Console.WriteLine($"-> So lan xuat hien: {DemSoLanXuatHien(str, substrcount)} lan");

        // 13. Chèn một chuỗi vào trước một chuỗi con khác
        Console.Write("13. Nhap chuoi ma ban muon chen: ");
        string chuoichen = Console.ReadLine();
        Console.Write("Nhap chuoi dich (Chuoi cua ban se nam ngay truoc chuoi nay): ");
        string chuoidich = Console.ReadLine();
        Console.WriteLine($"-> Ket qua: {ChenChuoi(str, chuoichen, chuoidich)}");
        Console.ReadLine(); 
    }

    // ========================================================
    // TẤT CẢ CÁC HÀM XỬ LÝ (TỰ VIẾT BẰNG LOGIC CƠ BẢN)
    // ========================================================

    // 2. Hàm tính độ dài không dùng .Length
    static int TinhDoDai(string s)
    {
        int dem = 0;
        foreach (char c in s) dem++;
        return dem;
    }

    // 5. Hàm đếm số từ (Dựa vào khoảng trắng)
    static int DemSoTu(string s)
    {
        int soTu = 0;
        bool dangLaTu = false;
        int len = TinhDoDai(s);
        for (int i = 0; i < len; i++)
        {
            if (s[i] == ' ' || s[i] == '\n' || s[i] == '\t')
            {
                dangLaTu = false; // Gặp khoảng trắng thì ngắt từ
            }
            else if (dangLaTu == false)
            {
                dangLaTu = true; // Bắt đầu một từ mới
                soTu++;
            }
        }
        return soTu;
    }

    // 6. Hàm so sánh chuỗi thủ công
    static bool SoSanhChuoi(string s1, string s2)
    {
        int len1 = TinhDoDai(s1);
        int len2 = TinhDoDai(s2);
        if (len1 != len2) return false; // Độ dài khác nhau thì chắc chắn khác nhau

        for (int i = 0; i < len1; i++)
        {
            if (s1[i] != s2[i]) return false; // Chỉ cần 1 ký tự lệch là sai
        }
        return true;
    }

    // 7. Hàm đếm loại ký tự
    static void DemLoaiKyTu(string s)
    {
        int chuCai = 0, chuSo = 0, dacBiet = 0;
        int len = TinhDoDai(s);
        for (int i = 0; i < len; i++)
        {
            char c = s[i];
            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')) chuCai++;
            else if (c >= '0' && c <= '9') chuSo++;
            else dacBiet++;
        }
        Console.WriteLine($"7. So luong -> Chu cai: {chuCai}, Chu so: {chuSo}, Ky tu dac biet: {dacBiet}\n");
    }

    // 8. Hàm đếm nguyên âm, phụ âm
    static void DemNguyenAmPhuAm(string s)
    {
        int nguyenAm = 0, phuAm = 0;
        int len = TinhDoDai(s);
        for (int i = 0; i < len; i++)
        {
            char c = s[i];
            // Nếu nó là chữ cái
            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' ||
                    c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
                    nguyenAm++;
                else
                    phuAm++;
            }
        }
        Console.WriteLine($"8. Nguyen am (Vowels): {nguyenAm}, Phu am (Consonants): {phuAm}\n");
    }

    // 9 & 10. Hàm tìm vị trí chuỗi con bằng thuật toán quét (Sliding Window)
    static int TimViTriChuoiCon(string str, string sub)
    {
        int lenStr = TinhDoDai(str);
        int lenSub = TinhDoDai(sub);
        if (lenSub == 0 || lenSub > lenStr) return -1;

        for (int i = 0; i <= lenStr - lenSub; i++)
        {
            bool match = true;
            for (int j = 0; j < lenSub; j++)
            {
                if (str[i + j] != sub[j])
                {
                    match = false;
                    break;
                }
            }
            if (match == true) return i; // Trả về vị trí đầu tiên tìm thấy
        }
        return -1; // Không tìm thấy
    }

    // 11. Kiểm tra ký tự
    static void KiemTraHoaThuong(char c)
    {
        if (c >= 'a' && c <= 'z')
            Console.WriteLine($"-> '{c}' la chu cai in thuong (Lowercase).");
        else if (c >= 'A' && c <= 'Z')
            Console.WriteLine($"-> '{c}' la chu cai IN HOA (Uppercase).");
        else
            Console.WriteLine($"-> '{c}' KHONG phai la chu cai.");
    }

    // 12. Hàm đếm số lần xuất hiện chuỗi con
    static int DemSoLanXuatHien(string str, string sub)
    {
        int lenStr = TinhDoDai(str);
        int lenSub = TinhDoDai(sub);
        if (lenSub == 0 || lenSub > lenStr) return 0;

        int dem = 0;
        for (int i = 0; i <= lenStr - lenSub; i++)
        {
            bool match = true;
            for (int j = 0; j < lenSub; j++)
            {
                if (str[i + j] != sub[j])
                {
                    match = false;
                    break;
                }
            }
            if (match == true)
            {
                dem++;
                i += lenSub - 1; // Nhảy vọt qua chuỗi con vừa tìm được để đếm tiếp
            }
        }
        return dem;
    }

    // 13. Nối chuỗi thủ công không dùng .Insert hay .Substring
    static string ChenChuoi(string goc, string chuoiChen, string chuoiDich)
    {
        int pos = TimViTriChuoiCon(goc, chuoiDich);
        if (pos == -1) return goc; // Không tìm thấy chuỗi đích thì trả về y nguyên

        string ketQua = "";
        int lenGoc = TinhDoDai(goc);

        // 1. Nối thủ công phần từ đầu cho tới ngay trước chuỗi đích
        for (int i = 0; i < pos; i++) ketQua += goc[i];

        // 2. Nối chuỗi cần chèn vào giữa
        ketQua += chuoiChen;

        // 3. Nối thủ công phần còn lại của chuỗi gốc
        for (int i = pos; i < lenGoc; i++) ketQua += goc[i];

        return ketQua;
    }
}

