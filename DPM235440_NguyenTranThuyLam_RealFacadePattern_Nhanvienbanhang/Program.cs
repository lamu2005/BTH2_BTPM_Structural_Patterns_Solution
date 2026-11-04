using System;

namespace RealFacadePattern_Nhanvienbanhang
{
    public class QuanLyKho { public void TruKho(string sp) => Console.WriteLine($"-> Đã trừ kho sản phẩm: {sp}"); }
    public class ThanhToan { public void XuLy(double tien) => Console.WriteLine($"-> Đã xử lý thanh toán: {tien:N0} VNĐ"); }
    public class InHoaDon { public void In() => Console.WriteLine("-> Đã in hóa đơn cho khách"); }

    public class BanHangFacade
    {
        private QuanLyKho _kho = new QuanLyKho();
        private ThanhToan _thanhToan = new ThanhToan();
        private InHoaDon _inHoaDon = new InHoaDon();

        public void BanHangTaiKhai(string sanPham, double giaTien)
        {
            Console.WriteLine($"=== BẮT ĐẦU XỬ LÝ ĐƠN HÀNG: {sanPham} ===");
            _kho.TruKho(sanPham);
            _thanhToan.XuLy(giaTien);
            _inHoaDon.In();
            Console.WriteLine("=== ĐƠN HÀNG HOÀN TẤT ===");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            BanHangFacade facade = new BanHangFacade();
            facade.BanHangTaiKhai("Laptop Dell", 15000000);
            Console.ReadLine();
        }
    }
}