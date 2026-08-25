using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
enum CurrencyType
{
                USD=1,
                EUR=2,
                JPY=3,
                GBP=4
}
enum HocLuc
{
    XuatSac,
    Kha,
    TrungBinh,
    Yeu,
    Kem
}
internal class BTVNbuoi3
{
  
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        static string XoaDau(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            // Dòng này trả kết quả ra ngoài và xử lý nốt chữ đ/Đ
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC)
                .Replace("đ", "d").Replace("Đ", "D");
        }
        static void bai1()
        {
            //Bài 1: Tính Tiền Điện Sinh Hoạt Gia Đình Theo Bậc Thang(EVN)
            //Tình huống thực tế: Tập đoàn Điện lực Việt Nam(EVN) áp dụng biểu giá điện sinh hoạt bậc thang lũy tiến
            //để khuyến khích người dân tiết kiệm điện.Hãy viết chương trình tính hóa đơn tiền điện hàng tháng cho một
            //hộ gia đình.
            Console.Write("Nhap chi so dien cu: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Nhap chi so dien moi: ");
            int b = int.Parse(Console.ReadLine());
            if (a <= b)
            {
                int c = b - a;
                double T = 0;
                if (c < 50)
                    {
                    T = c * 1.806;
                    }
                else if (c < 100)
                    {
                    T = 50 * 1.806 + (c - 50) * 1.866;
                }
                else if (c < 200)
                    {
                    T = 50 * 1.806 + 50 * 1.866 + (c - 100) * 2.167;
                }
                else if (c < 300)
                    {
                    T = 50 * 1.806 + 50 * 1.866 + 100 * 2.167 + (c - 200) * 2.729;
                }
                else
                {
                    T = 50 * 1.806 + 50 * 1.866 + 100 * 2.167 + 100 * 2.729 + (c - 300) * 3.05;
                }
                Console.WriteLine($"So dien tieu thu: {c}");
                Console.WriteLine($"Tien dien chua thue: {T:F5}");
                Console.WriteLine($"Thue Vat: {T*0.08:F5}");
                Console.WriteLine($"Tong thanh toan: {T * 1.08:F5}");
            }
            else
            {
                return;
            }
            
            
        }
        static void bai2()
        {
            //Bài 2: Hệ Thống Theo Dõi Chỉ Số BMI & Đánh Giá Tình Trạng Sức Khỏe
            //Tình huống thực tế: Một ứng dụng theo dõi sức khỏe cá nhân cần tính chỉ số khối cơ thể(BMI -Body Mass
            //Index) dựa trên chiều cao và cân nặng do người dùng cung cấp, đồng thời đưa ra lời khuyên về cân nặng lý
            //tưởng
            Console.Write("Nhap can nang: ");
            float a = float.Parse(Console.ReadLine());
            Console.Write("Nhap chieu cao: ");
            float b = float.Parse(Console.ReadLine());
            double BMI = a / Math.Pow(b, 2);
            string c = "";
            if (BMI<18.5)
            {
                c = "Gay (Thieu can)";
            }    
            else if (BMI<23)
            {
                c = "Binh thuong (Ly tuong)";
            }
            else if (BMI<25)
            {
                c = "Thua can (Tien beo phi";
            }
            else 
            {
                c = "Beo phi";
            }
            double min = 18.5 * Math.Pow(b, 2);
            double max = 22.9 * Math.Pow(b, 2);
            Console.WriteLine($"Chi so BMI cua ban: {BMI:F2}");
            Console.WriteLine($"Phan loai suc khoe: {c}");
            Console.WriteLine($"Khuyen dung: Can nang ly tuong cua ban nen tu {min:F2} kg cho den {max:F2} kg");
        }
        static void bai3()
        {
            //Bài 3: Ứng Dụng Quy Đổi Tiền Tệ Ngoại Tệ Đa Tỷ Giá Ngân Hàng
            //Tình huống thực tế: Một quầy đổi tiền tại sân bay cần ứng dụng tính toán nhanh số tiền khách hàng nhận
            //được khi đổi từ Việt Nam Đồng(VND) sang các loại ngoại tệ phổ biến(USD, EUR, JPY, GBP) có tính phí dịch
            //vụ.
            Console.Write("Nhap so tien VND: ");
            decimal a = decimal.Parse(Console.ReadLine());
            decimal tygia = 0;
            string ten = "";
            Console.Write("Chon ngoai te ( 1-USD 2-EUR 3-JPY, 4-GBP ): ");
            int b = int.Parse(Console.ReadLine());
            CurrencyType choice = (CurrencyType)b;
            switch (choice)
            {
                case CurrencyType.USD:
                    tygia = 25400m;
                    ten = "USD";
                    break; 

                case CurrencyType.EUR:
                    tygia = 27200m;
                    ten = "EUR";
                    break;

                case CurrencyType.JPY:
                    tygia = 165m;
                    ten = "JPY";
                    break;
                case CurrencyType.GBP:
                    tygia = 32100m;
                    ten = "GBP";
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le");
                    return;
            }
            Console.WriteLine($"Phi dich vu: {a*0.005m:F3}");
            Console.WriteLine($"So tien VNĐ thuc te doi: {a * 0.995m:F3}");
            Console.WriteLine($"So tien {ten} nhan duoc: {a / tygia:F3}");
        }
        static void bai4()
        {
            //Bài 4: Tính Tuổi Chính Xác &Đếm Ngược Ngày Sinh Nhật
            //Tình huống thực tế: Hệ thống chăm sóc khách hàng của một công ty bán lẻ cần tự động tính tuổi chính xác
            //của khách hàng và đếm số ngày còn lại đến sinh nhật tiếp theo để gửi voucher ưu đãi
            Console.Write("Nhap ngay sinh (dd/MM/yyyy): ");
            string Ngaysinh = Console.ReadLine();
            if (DateTime.TryParseExact(Ngaysinh, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaysinh))
            {
                DateTime homnay = DateTime.Now.Date;
                int tuoi = homnay.Year - ngaysinh.Year;
                if (homnay.Month < ngaysinh.Month || (homnay.Month == ngaysinh.Month && homnay.Day < ngaysinh.Day))
                {
                    tuoi--;
                }
                TimeSpan thoigiandasong = homnay - ngaysinh.Date;
                int tongsongay = thoigiandasong.Days;
                DateTime sinhnhatnamnay = new DateTime(homnay.Year, ngaysinh.Month, ngaysinh.Day);
                DateTime sinhnhattieptheo = sinhnhatnamnay;
                if (sinhnhatnamnay < homnay)
                {
                    sinhnhattieptheo = sinhnhatnamnay.AddYears(1);
                }
                TimeSpan thoigianchodoi = sinhnhattieptheo - homnay;
                int songayconlai = thoigianchodoi.Days;
                Console.WriteLine($"Tuoi hien tai: {tuoi} tuoi");
                Console.WriteLine($"Ban da song tong cong: {tongsongay:N0} ngay");
                if (songayconlai == 0)
                {
                    Console.WriteLine("Hom nay la sinh nhat ban!");
                }
                else
                {
                    Console.WriteLine($"Sinh nhat tiep theo con: {songayconlai} ngay nua");
                }
            }
            else
            {
                // Xử lý khi người dùng nhập sai định dạng
                Console.WriteLine("Loi: Dinh dang ngay sinh ko hop le. Vui long nhap theo chuan dd/MM/yyyy.");
            }
        }   
        static void bai5()
        {
            //Bài 5: Quản Lý Điểm Học Phần & Quy Đổi Thang Điểm GPA(4.0)
            //Tình huống thực tế: Hệ thống quản lý đào tạo đại học cần tính điểm trung bình tín chỉ(GPA) học kỳ cho
            //sinh viên dựa trên điểm số các môn học và quy đổi sang thang điểm chữ(A, B, C, D, F) cùng thang điểm 4
            Console.Write("Nhap tin chi C# (0-4): ");
            int tcCsharp = int.Parse(Console.ReadLine());
            Console.Write("Nhap diem C# (0-10): ");
            double diemCsharp = double.Parse(Console.ReadLine());
            Console.Write("Nhap tin chi Toan (0-4): ");
            int tcToan = int.Parse(Console.ReadLine());
            Console.Write("Nhap diem Toan (0-10): ");
            double diemToan = double.Parse(Console.ReadLine());
            Console.Write("Nhap tin chi TA (0-4): ");
            int tcTA = int.Parse(Console.ReadLine());
            Console.Write("Nhap diem TA (0-10): ");
            double diemTA = double.Parse(Console.ReadLine());
            if (tcCsharp < 0 || tcCsharp > 4 || diemCsharp < 0 || diemCsharp > 10 || tcToan < 0 || tcToan > 4 || diemToan < 0 || diemToan > 10 || tcTA < 0 || tcTA > 4 || diemTA < 0 || diemTA > 10)
            {
                Console.WriteLine("Loi: Điem phai tu 0-10 va tin chi tu 0-4. Vui long chay lai!");
                return; 
            }
            int tongtinchi = tcCsharp + tcToan + tcTA;
            double diemTB10 = (diemCsharp * tcCsharp + diemToan * tcToan + diemTA * tcTA) / tongtinchi;
            string diemChu = "";
            double diemGPA = 0;
            HocLuc xepLoai; 
            if (diemTB10 >= 8.5)
            {
                diemChu = "A"; diemGPA = 4.0; xepLoai = HocLuc.XuatSac;
            }
            else if (diemTB10 >= 7.0)
            {
                diemChu = "B"; diemGPA = 3.0; xepLoai = HocLuc.Kha;
            }
            else if (diemTB10 >= 5.5)
            {
                diemChu = "C"; diemGPA = 2.0; xepLoai = HocLuc.TrungBinh;
            }
            else if (diemTB10 >= 4.0)
            {
                diemChu = "D"; diemGPA = 1.0; xepLoai = HocLuc.Yeu;
            }
            else
            {
                diemChu = "F"; diemGPA = 0.0; xepLoai = HocLuc.Kem;
            }
            Console.WriteLine($"Diem TB thang 10: {diemTB10:F2}");
            Console.WriteLine($"Diem chu quy doi: {diemChu}");
            Console.WriteLine($"Diem GPA thang 4: {diemGPA:F1}");
            Console.WriteLine($"Xep loai hoc luc: {xepLoai}"); 
        }
        static void bai6()
        {
            //Bài 6: Chuẩn Hóa Họ Tên Người Dùng &Tự Động Tạo Email / Username
            //Tình huống thực tế: Bộ phận Nhân sự(HR) cần một công cụ xử lý dữ liệu thô nhập vào từ biểu mẫu đăng
            //ký.Họ tên nhập vào thường bị lỗi thừa khoảng trắng, hoa thường lộn xộn.Cần chuẩn hóa tên và tạo tài
            //khoản công ty
            Console.Write("Nhap ho va ten tho: ");
            string name = Console.ReadLine();
            string cleanname = name.Trim();
            string[] mang = name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < mang.Length; i++)
            {
                string tuHienTai = mang[i].ToLower();
                mang[i] = char.ToUpper(tuHienTai[0]) + tuHienTai.Substring(1);
            }
            string hoten = string.Join(" ", mang);
            string ho = mang[0];
            string tenChinh = mang[mang.Length - 1];
            string tenDem = "";
            string tenDemLienNhau = "";

            if (mang.Length > 2)
            {
                tenDem = string.Join(" ", mang, 1, mang.Length - 2);
                tenDemLienNhau = string.Join("", mang, 1, mang.Length - 2);
            }
            string RawUsername = tenChinh + "." + ho + tenDemLienNhau;
            string Username = XoaDau(RawUsername).ToLower();
            string email = Username + "@company.edu.vn";
            Console.WriteLine($"Ho ten chuan hoa: {hoten}");
            Console.WriteLine($"Ho: {ho} | Ten dem: {tenDem} | Ten: {tenChinh}");
            Console.WriteLine($"Username tao tu dong: {Username}");
            Console.WriteLine($"Email cap phat: {email}");
        }
        /*static void bai7()
        {
            //Bài 7: Lập Kế Hoạch Chi Phí Nhiên Liệu & Chia Sẻ Chuyến Đi(Car - pooling)
            //Tình huống thực tế: Một nhóm bạn lên kế hoạch đi phượt bằng xe ô tô cá nhân. Họ cần một máy tính bỏ
            //túi để ước tính tổng lượng nhiên liệu tiêu thụ, tổng chi phí xăng dầu và chia đều cho từng thành viên.
        }
        static void bai8()
        {
            //Bài 8: Kiểm Tra Mã Xác Thực OTP &Quản Lý Thời Gian Hiệu Lực
            //Tình huống thực tế: Hệ thống bảo mật ngân hàng gửi mã xác thực OTP gồm 6 chữ số đến điện thoại người
            //dùng.Mã OTP chỉ có hiệu lực trong vòng 5 phút(300 giây) kể từ thời điểm phát hành.
        }
        static void bai9()
        {
            //Bài 9: Máy Tính Lương Gross -Net & Thuế TNCN Nhân Viên
            //Tình huống thực tế: Phòng kế toán cần phần mềm tự động tính tiền lương thực nhận(Net Salary) từ lương
            //thỏa thuận(Gross Salary) sau khi trừ các khoản bảo hiểm bắt buộc và Thuế thu nhập cá nhân(TNCN)
        }
        static void bai10()
        {
            //Bài 10: Quản Lý Tồn Kho &Xử Lý Giá Trị Khuyết Thiếu(Nullable Types)
            //Tình huống thực tế: Trong phần mềm quản lý kho hàng e-Commerce, một số mặt hàng mới nhập có thể
            //chưa được cập nhật số lượng(Quantity = null) hoặc chưa có ngày dự kiến nhập hàng tiếp theo(RestockDate
            //= null).
        }
        static void bai11()
        {
            //Bài 11: Tính Lãi Suất Tiết Kiệm Ngân Hàng & Dự Toán Tích Lũy
            //Tình huống thực tế: Khách hàng muốn gửi tiết kiệm tại ngân hàng.Chương trình cần hỗ trợ tính toán tổng
            //số tiền cả gốc lẫn lãi thu được sau kỳ hạn gửi theo 2 phương thức: Lãi đơn và Lãi kép.
        }
        static void bai12()
        {
            //Bài 12: Bộ Mã Hóa & Giải Mã Tin Nhắn Mật Mã Caesar(Caesar Cipher)
            //Tình huống thực tế: Trong một ứng dụng trò chuyện bảo mật, các tin nhắn văn bản ngắn cần được mã hóa
            //đơn giản bằng thuật toán Caesar Cipher(dịch chuyển ký tự trong bảng mã ASCII) trước khi lưu trữ.
        }
        static void bai13()
        {
            //Bài 13: Bãi Đỗ Xe Thông Minh & Tính Phí Gửi Xe Theo Thời Gian
            //Tình huống thực tế: Hệ thống thẻ từ bãi đỗ xe thông minh tự động ghi nhận thời điểm xe vào và xe ra để
            //tính chính xác phí gửi xe dựa trên loại phương tiện và thời lượng đỗ.
        }
        static void bai14()
        {
            //Bài 14: Xử Lý Chuỗi Số An Toàn &Kiểm Tra Tràn Số(Overflow Exception)
            //Tình huống thực tế: Trong các ứng dụng nhận dữ liệu từ người dùng hoặc file ngoại vi, dữ liệu nhập vào có
            //thể không phải là số hợp lệ hoặc vượt quá khả năng lưu trữ của kiểu dữ liệu. Cần xử lý an toàn
        }
        static void bai15()
        {
            //Bài 15: Hệ Thống Bán Vé Rạp Chiếu Phim & Chiết Khấu Tự Động
            //Tình huống thực tế: Rạp chiếu phim Cinema X áp dụng chính sách giá vé linh hoạt phụ thuộc vào đối
            //tượng khách hàng, ngày trong tuần và các chương trình khuyến mãi tự động.
        }*/
        bai6();
    }
}

