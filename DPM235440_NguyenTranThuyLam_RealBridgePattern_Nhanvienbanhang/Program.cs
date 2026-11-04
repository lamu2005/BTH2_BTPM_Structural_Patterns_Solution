using System;

namespace RealBridgePattern_Nhanvienbanhang
{
    public interface IPhuongThucThanhToan
    {
        string XuLy(double soTien);
    }

    public class TienMat : IPhuongThucThanhToan
    {
        public string XuLy(double soTien) => $"Thu tiền mặt: {soTien:N0} VNĐ";
    }

    public class ChuyenKhoan : IPhuongThucThanhToan
    {
        public string XuLy(double soTien) => $"Chuyển khoản QR: {soTien:N0} VNĐ";
    }

    public abstract class HoaDon
    {
        protected IPhuongThucThanhToan phuongThuc;
        public HoaDon(IPhuongThucThanhToan pt) => phuongThuc = pt;
        public abstract void InHoaDon(double tongTien);
    }

    public class HoaDonBanLe : HoaDon
    {
        public HoaDonBanLe(IPhuongThucThanhToan pt) : base(pt) { }
        public override void InHoaDon(double tongTien)
        {
            Console.WriteLine($"[HÓA ĐƠN BÁN LẺ] {phuongThuc.XuLy(tongTien)}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== REAL BRIDGE: QUẢN LÝ HÓA ĐƠN & THANH TOÁN ===");

            HoaDon hd1 = new HoaDonBanLe(new TienMat());
            hd1.InHoaDon(150000);

            HoaDon hd2 = new HoaDonBanLe(new ChuyenKhoan());
            hd2.InHoaDon(2500000);

            Console.ReadLine();
        }
    }
}