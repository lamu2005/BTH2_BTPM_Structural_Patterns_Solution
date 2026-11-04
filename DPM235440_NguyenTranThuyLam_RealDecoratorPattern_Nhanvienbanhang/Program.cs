using System;

namespace RealDecoratorPattern_Nhanvienbanhang
{
    public interface IDonHang
    {
        string GetMoTa();
        double TinhTongTien();
    }

    public class DonHangGoc : IDonHang
    {
        public string GetMoTa() => "Đơn hàng cơ bản";
        public double TinhTongTien() => 500000;
    }

    public abstract class DonHangDecorator : IDonHang
    {
        protected IDonHang _donHang;
        public DonHangDecorator(IDonHang dh) => _donHang = dh;
        public virtual string GetMoTa() => _donHang.GetMoTa();
        public virtual double TinhTongTien() => _donHang.TinhTongTien();
    }

    public class GoiQuaDecorator : DonHangDecorator
    {
        public GoiQuaDecorator(IDonHang dh) : base(dh) { }
        public override string GetMoTa() => base.GetMoTa() + " + Dịch vụ Gói Quà (20k)";
        public override double TinhTongTien() => base.TinhTongTien() + 20000;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== REAL DECORATOR: DỊCH VỤ ĐƠN HÀNG ===");

            IDonHang dh = new DonHangGoc();
            dh = new GoiQuaDecorator(dh); // Thêm gói quà

            Console.WriteLine($"Mô tả: {dh.GetMoTa()}");
            Console.WriteLine($"Tổng chi phí: {dh.TinhTongTien():N0} VNĐ");

            Console.ReadLine();
        }
    }
}