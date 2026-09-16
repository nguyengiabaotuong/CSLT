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
enum StockStatus
{
    OutOfStock,   
    LowStock,     
    InStock,      
    Discontinued  
}
enum VehicleType
{
    Motorbike=1,
    Car=2,
    Truck=3
}
enum CustomerType
{
    Child = 1, 
    Student = 2,
    Adult = 3,
    Senior = 4
}
internal class BTVNbuoi3
{
  
    public static void Main3()
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
            string name = Console.ReadLine().Trim();
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
        static void bai7()
        {
            //Bài 7: Lập Kế Hoạch Chi Phí Nhiên Liệu & Chia Sẻ Chuyến Đi(Car - pooling)
            //Tình huống thực tế: Một nhóm bạn lên kế hoạch đi phượt bằng xe ô tô cá nhân. Họ cần một máy tính bỏ
            //túi để ước tính tổng lượng nhiên liệu tiêu thụ, tổng chi phí xăng dầu và chia đều cho từng thành viên.
            Console.Write("Nhap khoang cach chuyen di (km): ");
            double dis = double.Parse(Console.ReadLine());
            Console.Write("Nhap muc tieu thu nhien lieu trung binh cua xe (lit/100km): ");
            double consume = double.Parse(Console.ReadLine());
            Console.Write("Nhap gia xang hien tai (VND/lit): ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Nhap so luong nguoi tham gia chuyen di: ");
            double songuoi = int.Parse(Console.ReadLine());
            double solit = (dis / 100) * consume;
            decimal chiphi = (decimal)solit * price;
            decimal chiphi1ng = chiphi / (decimal)songuoi;
            decimal chiphithuc = Math.Ceiling(chiphi1ng / 1000m) * 1000m;
            Console.WriteLine($"Tong nhien lieu tieu thu: {solit} lit");
            Console.WriteLine($"Tong chi phi: {chiphi} VND");
            Console.WriteLine($"Chi phi moi nguoi: {chiphithuc} VND");
        }
        static void bai8()
        {
            //Bài 8: Kiểm Tra Mã Xác Thực OTP &Quản Lý Thời Gian Hiệu Lực
            //Tình huống thực tế: Hệ thống bảo mật ngân hàng gửi mã xác thực OTP gồm 6 chữ số đến điện thoại người
            //dùng.Mã OTP chỉ có hiệu lực trong vòng 5 phút(300 giây) kể từ thời điểm phát hành.
            string Otp = "839201";
            DateTime tgtao = DateTime.Now;
            Console.Write("Ma OTP nhan duoc: ");
            string InputOtp = Console.ReadLine().Trim();
            Console.Write("Thoi gian troi qua: ");
            int tgtroi = int.Parse(Console.ReadLine());
            DateTime Time = tgtao.AddSeconds(tgtroi);
            // Lớp 1: Kiểm tra định dạng (Đúng 6 ký tự VÀ toàn bộ phải là số)
            // Lệnh int.TryParse(..., out _) sẽ kiểm tra xem chuỗi có ép thành số được không. 
            // Ký hiệu "out _" nghĩa là ta chỉ cần biết kết quả Đúng/Sai chứ không cần lưu lại giá trị số đó.
            if (InputOtp.Length != 6 || !int.TryParse(InputOtp, out _))
            {
                Console.WriteLine("Trang thai xac thuc: LOI - Dinh dang OTP khong hop le (Phai bao gom 6 chu so).");
                return; 
            }
            if (InputOtp != Otp)
            {
                Console.WriteLine("Trang thai xac thuc: LOI - Ma OTP khong chinh xac.");
                return;
            }
            TimeSpan timeDif = Time - tgtao;
            if (timeDif.TotalSeconds > 300)
            {
                Console.WriteLine("Trang thai xac thuc: LOI - Ma OTP da het han. Vui long yeu cau ma moi.");
                return;
            }
            Console.WriteLine("Trang thai xac thuc: THANH CONG - Giao dich da duoc phe duyet.");
        }
        static void bai9()
        {
            //Bài 9: Máy Tính Lương Gross -Net & Thuế TNCN Nhân Viên
            //Tình huống thực tế: Phòng kế toán cần phần mềm tự động tính tiền lương thực nhận(Net Salary) từ lương
            //thỏa thuận(Gross Salary) sau khi trừ các khoản bảo hiểm bắt buộc và Thuế thu nhập cá nhân(TNCN)
            Console.Write("Luong Gross (VNĐ): ");
            decimal gross = decimal.Parse(Console.ReadLine());
            Console.Write("So nguoi phu thuoc: ");
            int phuthuoc = int.Parse(Console.ReadLine());
            decimal baohiem = gross * 0.105m;
            decimal giamtrubanthan = 11000000m;
            decimal giamtruphuthuoc = phuthuoc * 4400000m;
            decimal thuNhapChiuThue = gross - baohiem - giamtrubanthan - giamtruphuthuoc;
            if (thuNhapChiuThue < 0)
                thuNhapChiuThue = 0;
            decimal thueTNCN = 0;
            if (thuNhapChiuThue > 0)
            {
                if (thuNhapChiuThue <= 5000000m)
                    thueTNCN = thuNhapChiuThue * 0.05m;
                else if (thuNhapChiuThue <= 10000000m)
                    thueTNCN = (5000000m * 0.05m) + ((thuNhapChiuThue - 5000000m) * 0.10m);
                else 
                    thueTNCN = (5000000m * 0.05m) + (5000000m * 0.10m) + ((thuNhapChiuThue - 10000000m) * 0.15m);
            }
            decimal net = gross - baohiem - thueTNCN;
            Console.WriteLine($"Giam tru bao hiem (10.5%): {baohiem:N0} VNĐ");
            Console.WriteLine($"Thu nhap chiu thue: {thuNhapChiuThue:N0} VNĐ");
            Console.WriteLine($"Thue TNCN phai nop: {thueTNCN:N0} VNĐ");
            Console.WriteLine($"LUONG NET THUC NHAN: {net:N0} VNĐ");
        }
        static void bai10()
        {
            //Bài 10: Quản Lý Tồn Kho &Xử Lý Giá Trị Khuyết Thiếu(Nullable Types)
            //Tình huống thực tế: Trong phần mềm quản lý kho hàng e-Commerce, một số mặt hàng mới nhập có thể
            //chưa được cập nhật số lượng(Quantity = null) hoặc chưa có ngày dự kiến nhập hàng tiếp theo(RestockDate
            //= null).
            string ma = "KB-09";
            string ten = "Ban phim Co Akko";
            int? quantity = 5;
            int minThreshold = 10;
            DateTime? restockDate = DateTime.Now.AddDays(7);

            // 2. Xử lý số lượng hiển thị bằng toán tử ??
            // Nếu quantity null, tự động gán hiển thị bằng 0
            int hienthi = quantity ?? 0;
            // 3. Đánh giá trạng thái kho hàng
            StockStatus status;
            if (quantity == null || quantity == 0)
            {
                status = StockStatus.OutOfStock;
            }
            else if (quantity < minThreshold)
            {
                status = StockStatus.LowStock;
            }
            else
            {
                status = StockStatus.InStock;
            }

            // 4. Xử lý ngày nhập hàng an toàn bằng ?. và ??
            // Nếu restockDate có dữ liệu thì ToString, nếu cả cụm phía trước null thì in câu thông báo
            string ngaynhap = restockDate?.ToString("dd/MM/yyyy") ?? "Chua co lich nhap hang";
            Console.WriteLine($"San pham: {ten} (Ma: {ma})");
            if (quantity == null)
                Console.WriteLine($"So luong hien thi: {hienthi} (Canh bao: Du lieu trong)");
            else
                Console.WriteLine($"So luong hien thi: {hienthi}");
            string statusVN = status switch
            {
                StockStatus.OutOfStock => "OutOfStock (Het hang)",
                StockStatus.LowStock => "LowStock (Sap het hang)",
                StockStatus.InStock => "InStock (Con hang)",
                _ => "Khong xac dinh"
            };
            Console.WriteLine($"Trang thai kho: {statusVN}");
            Console.WriteLine($"Du kien nhap hang: {ngaynhap}");
        }
        static void bai11()
        {
            //Bài 11: Tính Lãi Suất Tiết Kiệm Ngân Hàng & Dự Toán Tích Lũy
            //Tình huống thực tế: Khách hàng muốn gửi tiết kiệm tại ngân hàng.Chương trình cần hỗ trợ tính toán tổng
            //số tiền cả gốc lẫn lãi thu được sau kỳ hạn gửi theo 2 phương thức: Lãi đơn và Lãi kép.
            Console.Write("So tien gui ban dau P (VNĐ): ");
            decimal P = decimal.Parse(Console.ReadLine());
            Console.Write("Lai suat (%/nam): ");
            double r = double.Parse(Console.ReadLine());
            Console.Write("Ky han gui (thang): ");
            int n = int.Parse(Console.ReadLine());
            decimal don = (decimal)((double)P * (r / 100) * (n / 12.0));
            decimal kep = P * (decimal)(Math.Pow((double)(1+(r/100)/12),n))-P;
            Console.WriteLine($"Tong tien lai (lai don): {don:N0}");
            Console.WriteLine($"Tong tien lai (lai kep): {kep:N0}");
            decimal ss = 0;
            if (don>kep)
            {
                ss = don - kep;
                Console.WriteLine($"Loi nhuan chenh lech: {ss:N0} VNĐ (Lai don toi uu hon)");
            }
            else if (kep>don)
            {
                ss = kep - don;
                Console.WriteLine($"Loi nhuan chenh lech: {ss:N0} VNĐ (Lai kep toi uu hon)");
            }
            else Console.WriteLine($"Loi nhuan chenh lech: {ss} VNĐ (Hai phuong thuc bang nhau)");
        }
        static void bai12()
        {
            //Bài 12: Bộ Mã Hóa & Giải Mã Tin Nhắn Mật Mã Caesar(Caesar Cipher)
            //Tình huống thực tế: Trong một ứng dụng trò chuyện bảo mật, các tin nhắn văn bản ngắn cần được mã hóa
            //đơn giản bằng thuật toán Caesar Cipher(dịch chuyển ký tự trong bảng mã ASCII) trước khi lưu trữ.
            Console.Write("Van ban goc: ");
            string Text = Console.ReadLine();
            Console.Write("Khoa dich chuyen (Shift Key k): ");
            int k = int.Parse(Console.ReadLine());
            k = k % 26;
            string encryptedText = "";
            string decryptedText = "";
            // 1. BỘ MÃ HÓA (Encoder)
            // Duyệt qua từng ký tự (char) trong chuỗi văn bản
            foreach (char c in Text)
            {
                if (char.IsUpper(c))
                {
                    char newChar = (char)('A' + (c - 'A' + k) % 26);
                    encryptedText += newChar;
                }
                else if (char.IsLower(c)) 
                {
                    char newChar = (char)('a' + (c - 'a' + k) % 26);
                    encryptedText += newChar;
                }
                else
                {
                    // Nếu là số, dấu cách, dấu câu -> Nối thẳng vào không cần mã hóa
                    encryptedText += c;
                }
            }

            // 2. BỘ GIẢI MÃ (Decoder)
            int reverseKey = 26 - k;
            foreach (char c in encryptedText)
            {
                if (char.IsUpper(c))
                {
                    char newChar = (char)('A' + (c - 'A' + reverseKey) % 26);
                    decryptedText += newChar;
                }
                else if (char.IsLower(c))
                {
                    char newChar = (char)('a' + (c - 'a' + reverseKey) % 26);
                    decryptedText += newChar;
                }
                else
                {
                    decryptedText += c;
                }
            }
            Console.WriteLine($"Van ban Ma hoa: {encryptedText}");
            Console.WriteLine($"Van ban Giai ma: {decryptedText}");
        }
        static void bai13()
        {
            //Bài 13: Bãi Đỗ Xe Thông Minh & Tính Phí Gửi Xe Theo Thời Gian
            //Tình huống thực tế: Hệ thống thẻ từ bãi đỗ xe thông minh tự động ghi nhận thời điểm xe vào và xe ra để
            //tính chính xác phí gửi xe dựa trên loại phương tiện và thời lượng đỗ.
            Console.WriteLine("Chon loai xe (1: Motorbike, 2: Car, 3: Truck): ");
            int typeInput = int.Parse(Console.ReadLine());
            VehicleType vehicle = (VehicleType)typeInput;
            // Nhập thời gian (Dùng ParseExact để ép buộc người dùng gõ đúng format)
            string format = "yyyy-MM-dd HH:mm";
            Console.Write($"Gio vao ({format}): ");
            DateTime checkIn = DateTime.ParseExact(Console.ReadLine(), format, null);
            Console.Write($"Gio ra ({format}): ");
            DateTime checkOut = DateTime.ParseExact(Console.ReadLine(), format, null);
            TimeSpan duration = checkOut - checkIn;
            double rawHours = duration.TotalHours;
            int billedHours = (int)Math.Ceiling(rawHours); 
            decimal baseFee = 0m;      
            decimal extraRate = 0m;    
            switch (vehicle)
            {
                case VehicleType.Motorbike:
                    baseFee = 5000m; extraRate = 2000m; break;
                case VehicleType.Car:
                    baseFee = 20000m; extraRate = 10000m; break;
                case VehicleType.Truck:
                    baseFee = 50000m; extraRate = 25000m; break;
            }
            decimal totalFee = 0;
            decimal extraFee = 0;
            int extraHours = 0;
            if (billedHours <= 2)
            {
                totalFee = baseFee; 
            }
            else
            {
                extraHours = billedHours - 2; 
                extraFee = extraHours * extraRate;
                totalFee = baseFee + extraFee;
            }
            decimal overnight = 0;
            if (checkOut.Date > checkIn.Date)
            {
                overnight = 30000m;
                totalFee += overnight;
            }
            Console.WriteLine($"Loai xe: {vehicle}");
            Console.WriteLine($"Tong thoi gian do: {rawHours:F2} gio -> Tinh phi: {billedHours} gio");
            Console.WriteLine($"Phi 2 gio dau: {baseFee:N0} VNĐ");
            if (billedHours > 2)
            {
                Console.WriteLine($"Phi {extraHours} gio tiep theo: {extraFee:N0} VNĐ ({extraRate:N0} x {extraHours})");
            }

            if (overnight > 0)
            {
                Console.WriteLine($"Phu phi qua đêm: {overnight:N0} VNĐ");
            }

            Console.WriteLine($"TONG PHI DO XE: {totalFee:N0} VNĐ");
        }
        static void bai14()
        {
            //Bài 14: Xử Lý Chuỗi Số An Toàn &Kiểm Tra Tràn Số(Overflow Exception)
            //Tình huống thực tế: Trong các ứng dụng nhận dữ liệu từ người dùng hoặc file ngoại vi, dữ liệu nhập vào có
            //thể không phải là số hợp lệ hoặc vượt quá khả năng lưu trữ của kiểu dữ liệu. Cần xử lý an toàn
            int number;
            // 1. VÒNG LẶP BẮT LỖI VỚI TRYPARSE
            while (true)
            {
                Console.Write("Nhap chuoi so: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("[Loi] Du lieu nhap khong phai la so nguyen hop le. Vui long nhap lai!\n");
                }
            }
            Console.WriteLine($"Kiểm tra Parse: Thành công! Giá trị int = {number}");
            // 2. KIỂM TRA SỨC CHỨA CỦA KIỂU DỮ LIỆU NHỎ HƠN
            bool isByte = number >= byte.MinValue && number <= byte.MaxValue;     
            bool isShort = number >= short.MinValue && number <= short.MaxValue;  

            if (isByte)
            {
                Console.WriteLine("Phu hop kieu byte: CO (Vua van trong dai 0-255)");
            }
            else if (isShort)
            {
                Console.WriteLine("Phu hop kieu short: CO (Vua van trong dai -32,768 đến 32,767)");
            }
            else
            {
                Console.WriteLine("Phu hop kieu byte/short: KHONG (Chi chua duoc trong int hoac long)");
            }
            // 3. TÍNH TỔNG CÁC CHỮ SỐ (Dùng chuỗi để tách từng số cho dễ)
            string numStr = Math.Abs(number).ToString(); 
            int sum = 0;
            List<string> digits = new List<string>();
            foreach (char c in numStr)
            {
                int digit = int.Parse(c.ToString());
                sum += digit;
                digits.Add(digit.ToString());
            }
            Console.WriteLine($"Tong cac chu so: {string.Join(" + ", digits)} = {sum}");
            // 4. KIỂM TRA TRÀN SỐ VỚI KHỐI CHECKED
            if (number == 0 || number == 1 || number == -1)
            {
                Console.WriteLine($"So {number} khi nhan tich luy se khong bao gio bi tran so.");
            }
            else
            {
                try
                {
                    // Khối checked ép máy tính phải báo lỗi nếu kết quả vượt quá giới hạn của kiểu int
                    checked
                    {
                        int result = number*number;
                        Console.WriteLine("Kiem tra Tran so: An toan trong pham vi int32.");
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Kiem tra Tran so: [Canh bao] Phat hien tran so (OverflowException)! Con so da vo mang.");
                }
            }
    }
        static void bai15()
        {
            //Bài 15: Hệ Thống Bán Vé Rạp Chiếu Phim & Chiết Khấu Tự Động
            //Tình huống thực tế: Rạp chiếu phim Cinema X áp dụng chính sách giá vé linh hoạt phụ thuộc vào đối
            //tượng khách hàng, ngày trong tuần và các chương trình khuyến mãi tự động.
            decimal baseprice = 100000m;
            Console.Write("Chon loai khach (1: Child, 2: Student, 3: Adult, 4: Senior): ");
            CustomerType customer = (CustomerType)int.Parse(Console.ReadLine());
            bool hasStudentId = false;
            if (customer == CustomerType.Student)
            {
                Console.Write("Co the SV hop le khong? (true/false): ");
                hasStudentId = bool.Parse(Console.ReadLine());
            }
            Console.Write("Ngay xem (Monday -> Sunday): ");
            DayOfWeek day;
            // Dùng Enum.TryParse để dịch chữ tiếng Anh người dùng gõ thành kiểu DayOfWeek của hệ thống
            while (!Enum.TryParse(Console.ReadLine(), true, out day))
                Console.Write("Sai dinh dang ngay! Vui long nhap lai tieng Anh (vd: Monday): ");
            decimal discount = 0m;
            string discountLabel = "Khong co khuyen mai"; 

            if (customer == CustomerType.Child || customer == CustomerType.Senior)
            {
                discount = baseprice * 0.5m;
                discountLabel = (customer == CustomerType.Child) ? "Giam gia Tre em (50%)" : "Giam gia Cao tuoi (50%)";
            }
            else if (customer == CustomerType.Student && hasStudentId && (day >= DayOfWeek.Monday && day <= DayOfWeek.Thursday))
            {
                // && (VÀ): Bắt buộc phải thỏa mãn ĐỒNG THỜI cả 3 điều kiện: Là SV + Có thẻ + Ngày từ T2 đến T5
                discount = baseprice * 0.3m;
                discountLabel = "Giam gia SV (30%)";
            }
            else if (customer == CustomerType.Adult && day == DayOfWeek.Wednesday)
            {
                discount = baseprice * 0.2m;
                discountLabel = "Thu 4 Vui ve (20%)";
            }
            decimal surcharge = 0m;
            if (day == DayOfWeek.Friday || day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
                surcharge = 20000m;
            decimal finalprice = baseprice - discount + surcharge;
            Console.WriteLine($"Gia ve goc: {baseprice:N0} VNĐ");
            if (discount > 0)
                Console.WriteLine($"{discountLabel}: - {discount:N0} VNĐ");
            Console.WriteLine($"Phu thu cuoi tuan: {surcharge:N0} VNĐ");
            Console.WriteLine($"TONG TIEN VE: {finalprice:N0} VNĐ");
        }
        bai15();
    }
}

