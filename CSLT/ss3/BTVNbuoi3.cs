using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class BTVNbuoi3
{
    public static void Main()
    {
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
            if a <= b
                {
                int c = b - a;
                if c < 50
                    {
                    double T = c * 1.806;
                    return;
                }
                else if c < 100
                    {
                    double T = 50 * 1.806 + (c - 50) * 1.866;
                }
                else if c < 200
                    {
                    double T = 50 * 1.806 + 50 * 1.866 + (c - 100) * 2.167;
                }
                else if c < 300
                    {
                    double T = 50 * 1.806 + 50 * 1.866 + 100 * 2.167 + (c - 200) * 2.729;
                }
                else
                {
                    double T = 50 * 1.806 + 50 * 1.866 + 100 * 2.167 + 100 * 2.729 + (c - 300) * 3.05;
                }
            }
            else
            {
                break;
            }
        }
        /*static void bai2()
        {
            //Bài 2: Hệ Thống Theo Dõi Chỉ Số BMI & Đánh Giá Tình Trạng Sức Khỏe
            //Tình huống thực tế: Một ứng dụng theo dõi sức khỏe cá nhân cần tính chỉ số khối cơ thể(BMI -Body Mass
            //Index) dựa trên chiều cao và cân nặng do người dùng cung cấp, đồng thời đưa ra lời khuyên về cân nặng lý
            //tưởng
        }
        static void bai3()
        {
            //Bài 3: Ứng Dụng Quy Đổi Tiền Tệ Ngoại Tệ Đa Tỷ Giá Ngân Hàng
            //Tình huống thực tế: Một quầy đổi tiền tại sân bay cần ứng dụng tính toán nhanh số tiền khách hàng nhận
            //được khi đổi từ Việt Nam Đồng(VND) sang các loại ngoại tệ phổ biến(USD, EUR, JPY, GBP) có tính phí dịch
            //vụ.
        }
        static void bai4()
        {
            //Bài 4: Tính Tuổi Chính Xác &Đếm Ngược Ngày Sinh Nhật
            //Tình huống thực tế: Hệ thống chăm sóc khách hàng của một công ty bán lẻ cần tự động tính tuổi chính xác
            //của khách hàng và đếm số ngày còn lại đến sinh nhật tiếp theo để gửi voucher ưu đãi
        }
        static void bai5()
        {
            //Bài 5: Quản Lý Điểm Học Phần & Quy Đổi Thang Điểm GPA(4.0)
            //Tình huống thực tế: Hệ thống quản lý đào tạo đại học cần tính điểm trung bình tín chỉ(GPA) học kỳ cho
            //sinh viên dựa trên điểm số các môn học và quy đổi sang thang điểm chữ(A, B, C, D, F) cùng thang điểm 4
        }
        static void bai6()
        {
            //Bài 6: Chuẩn Hóa Họ Tên Người Dùng &Tự Động Tạo Email / Username
            //Tình huống thực tế: Bộ phận Nhân sự(HR) cần một công cụ xử lý dữ liệu thô nhập vào từ biểu mẫu đăng
            //ký.Họ tên nhập vào thường bị lỗi thừa khoảng trắng, hoa thường lộn xộn.Cần chuẩn hóa tên và tạo tài
            //khoản công ty
        }
        static void bai7()
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
        bai1()
        /*bai2()
        bai3()
        bai4()
        bai5()
        bai6()
        bai7()
        bai8()
        bai9()
        bai10()
        bai11()
        bai12()
        bai13()
        bai14()
        bai15()*/
    }
}

