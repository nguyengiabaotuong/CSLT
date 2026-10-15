using System;
using System.Collections.Generic;
using System.Text;
internal class BTVNbuoi8
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine(" CÁC THAO TÁC FILE CƠ BẢN ");
        ThaoTacFileCoBan();
        Console.WriteLine(" IN CẤU TRÚC THƯ MỤC ");
        // In cấu trúc của thư mục hiện tại (dấu "." đại diện cho thư mục code đang chạy)
        InCauTrucThuMuc(".",0);
        Console.WriteLine(" THỐNG KÊ KÝ TỰ VÀ SỐ ");
        ThongKeKyTuVaViTri();
        Console.ReadLine();
    }
    static void ThaoTacFileCoBan()
    {
        string file1 = "blank.txt";
        string file2 = "textfile.txt";
        string file3 = "arrayfile.txt";
        string file4 = "copyfile.txt";
        string file5 = "movefile.txt";
        // 1. Tạo một file trống trên ổ đĩa
        File.Create(file1).Close(); // Phải gọi Close() để nhả file ra, không bị lỗi khi xóa
        Console.WriteLine("1. Đã tạo file trống: " + file1);
        // 2. Xóa một file khỏi ổ đĩa
        if (File.Exists(file1))
        {
            File.Delete(file1);
            Console.WriteLine("2. Đã xóa file: " + file1);
        }
        // 3. Tạo một file và thêm một đoạn văn bản
        File.WriteAllText(file2, "Hello word!");
        Console.WriteLine("3. Đã tạo và ghi nội dung vào: " + file2);
        // 4. Đọc file văn bản vừa tạo
        string noidung = File.ReadAllText(file2);
        Console.WriteLine($"4. Nội dung file {file2}: {noidung}"); 
        // 5. Tạo file và ghi một mảng chuỗi (Array of strings) vào file
        string[] mangchuoi = { "Dong 1: Mot", "Dong 2: Hai", "Dong 3: Ba", "Dong 4: Bon" };
        File.WriteAllLines(file3, mangchuoi);
        Console.WriteLine("5. Đã ghi mảng chuỗi vào: " + file3);
        // 6. Ghi nối (append) thêm văn bản vào file có sẵn
        File.AppendAllText(file3, "Dong 5: Ghi noi them vao cuoi file.");
        Console.WriteLine("6. Đã nối thêm chữ vào cuối file: " + file3);
        // 7. Copy file sang tên khác và hiển thị nội dung
        File.Copy(file3, file4, true); 
        Console.WriteLine($"7. Đã copy sang {file4} Nội dung: ");
        Console.WriteLine(File.ReadAllText(file4));
        // 8. Di chuyển (Move) file vào cùng thư mục nhưng đổi tên
        File.Move(file4, file5);
        Console.WriteLine($"8. Đã Move (đổi tên) {file4} thành {file5}");
        string[] lines = File.ReadAllLines(file5);
        // 9. Đọc dòng đầu tiên của file
        Console.WriteLine($"9. Dòng đầu tiên: {lines[0]}");
        // 10. Đọc dòng cuối cùng của file
        Console.WriteLine($"10. Dòng cuối cùng: {lines[lines.Length - 1]}");
        // 11. Đọc n dòng cuối cùng của file
        int n = 2;
        Console.WriteLine($"11. Đọc {n} dòng cuối cùng:");
        for (int i = lines.Length - n; i < lines.Length; i++)
            Console.WriteLine($"    - {lines[i]}");
        // 12. Đọc một dòng cụ thể 
        int d = 3;
        Console.WriteLine($"12. Dòng thứ {d} là: {lines[d - 1]}");
        // 13. Đếm tổng số dòng trong file
        Console.WriteLine($"13. Tổng số dòng trong file: {lines.Length}");
    }
    // 14. In cấu trúc thư mục 
    static void InCauTrucThuMuc(string path, int khoangCach)
    {
        // Tạo chuỗi thụt lề để nhìn giống hình cây thư mục
        string thutlui = new string(' ', khoangCach * 4);
        // In các File trong thư mục hiện tại
        string[] files = Directory.GetFiles(path);
        foreach (string file in files)
        {
            // Path.GetFileName giúp chỉ lấy tên file, bỏ đi phần đường dẫn dài dằng dặc
            Console.WriteLine($"{thutlui}|-- [File] {Path.GetFileName(file)}");
        }
        // In các Thư mục con và dùng Đệ quy (gọi lại chính hàm này) để quét tiếp vào trong
        string[] thuMucs = Directory.GetDirectories(path);
        foreach (string tm in thuMucs)
        {
            Console.WriteLine($"{thutlui}|-- [Thư mục] {Path.GetFileName(tm)}");
            InCauTrucThuMuc(tm, khoangCach + 1); // Tăng khoảng cách thụt lề cho cấp con
        }
    }
    // 15. Đọc file, thống kê ký tự/số bằng Mảng chữ nhật (Rectangular) và Jagged Array
    static void ThongKeKyTuVaViTri()
    {
        string fileName = "thongke.txt";
        File.WriteAllText(fileName, "AABB12\nB1"); // Tạo file mẫu để thống kê
        string[] lines = File.ReadAllLines(fileName);
        // HINT 1: Dùng Mảng chữ nhật (Rectangular Array) [256, 2] để đếm
        // Cột 0: Lưu mã ASCII của ký tự | Cột 1: Lưu số lần xuất hiện
        int[,] thongKe = new int[256, 2];
        for (int i = 0; i < 256; i++) thongKe[i, 0] = i;
        // HINT 2: Dùng Jagged Array đếm vị trí (Dòng, Cột)
        // Jagged Array là "Mảng của các mảng". Vì mỗi ký tự xuất hiện số lần khác nhau
        // nên ta dùng mảng Jagged để chứa mảng vị trí cho từng ký tự.
        string[][] viTriJagged = new string[256][];
        // Bước 1: Quét file để ĐẾM số lượng trước
        for (int r = 0; r < lines.Length; r++)
        {
            for (int c = 0; c < lines[r].Length; c++)
            {
                char kyTu = lines[r][c];
                thongKe[(int)kyTu, 1]++; // Tăng số lượng đếm ở cột 1
            }
        }
        // Bước 2: Khởi tạo kích thước cho các mảng con bên trong Jagged Array
        for (int i = 0; i < 256; i++)
        {
            if (thongKe[i, 1] > 0)
            {
                // Nếu ký tự này có xuất hiện, cấp phát mảng con bằng đúng số lần xuất hiện
                viTriJagged[i] = new string[thongKe[i, 1]];
            }
        }
        // Mảng phụ để nhớ xem ký tự đó đã được điền vào index thứ mấy của mảng con
        int[] indexTam = new int[256];
        // Bước 3: Quét file lại lần nữa để GHI VỊ TRÍ vào Jagged Array
        for (int r = 0; r < lines.Length; r++)
        {
            for (int c = 0; c < lines[r].Length; c++)
            {
                char kyTu = lines[r][c];
                int ascii = (int)kyTu;

                // Ghi tọa độ vào mảng con
                viTriJagged[ascii][indexTam[ascii]] = $"(Dòng {r + 1}, Cột {c + 1})";
                indexTam[ascii]++; // Tăng con trỏ của ký tự đó lên
            }
        }
        // Bước 4: IN KẾT QUẢ
        Console.WriteLine($"Đọc file {fileName} thành công. Bắt đầu thống kê:\n");
        for (int i = 0; i < 256; i++)
        {
            if (thongKe[i, 1] > 0) // Chỉ in những ký tự xuất hiện ít nhất 1 lần
            {
                char kyTu = (char)thongKe[i, 0];
                string phanLoai = (kyTu >= '0' && kyTu <= '9') ? "Số" : "Chữ/Ký tự";

                Console.WriteLine($"[{phanLoai}] '{kyTu}' xuất hiện {thongKe[i, 1]} lần.");

                // Lôi mảng con từ Jagged Array ra để in vị trí
                Console.Write("   -> Các vị trí: ");
                for (int j = 0; j < viTriJagged[i].Length; j++)
                    Console.Write(viTriJagged[i][j] + " ");
                Console.WriteLine();
            }
        }
    }
}

