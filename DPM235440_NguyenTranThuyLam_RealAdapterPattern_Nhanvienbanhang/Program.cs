using System;

namespace RealAdapterPattern_Nhanvienbanhang
{
    // Interface chuẩn của hệ thống cửa hàng
    public interface IThanhToanChuan
    {
        void ThanhToan(double soTien);
    }

    // Class dịch vụ bên thứ 3 (MoMo API) có hàm khác chuẩn
    public class MoMoService
    {
        public void SendPayment(double amount)
        {
            Console.WriteLine($"[MoMo API] Đã nhận thanh toán qua ví MoMo: {amount:N0} VNĐ");
        }
    }

    // Adapter giúp biến đổi MoMoService thành IThanhToanChuan
    public class MoMoAdapter : IThanhToanChuan
    {
        private readonly MoMoService _moMoService;
        public MoMoAdapter(MoMoService moMoService) => _moMoService = moMoService;

        public void ThanhToan(double soTien)
        {
            _moMoService.SendPayment(soTien);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== REAL ADAPTER: THANH TOÁN BÁN HÀNG ===");

            IThanhToanChuan thanhToan = new MoMoAdapter(new MoMoService());
            thanhToan.ThanhToan(500000);

            Console.ReadLine();
        }
    }
}