using System;

namespace RealProxyPattern_Nhanvienbanhang
{
    public interface IQuanLyDonHang
    {
        void HuyDonHang(string maDon);
    }

    public class QuanLyDonHangThuc : IQuanLyDonHang
    {
        public void HuyDonHang(string maDon)
        {
            Console.WriteLine($"[HỆ THỐNG] Đã hủy thành công đơn hàng: {maDon}");
        }
    }

    public class ProxyQuanLyDonHang : IQuanLyDonHang
    {
        private QuanLyDonHangThuc _quanLyThuc;
        private string _chucVu;

        public ProxyQuanLyDonHang(string chucVu) => _chucVu = chucVu;

        public void HuyDonHang(string maDon)
        {
            if (_chucVu == "QuanLy")
            {
                if (_quanLyThuc == null) _quanLyThuc = new QuanLyDonHangThuc();
                _quanLyThuc.HuyDonHang(maDon);
            }
            else
            {
                Console.WriteLine($"[TỪ CHỐI] Vị trí '{_chucVu}' không có quyền hủy đơn hàng {maDon}!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== REAL PROXY: KIỂM TRA QUYỀN HỦY ĐƠN ===");

            IQuanLyDonHang nv1 = new ProxyQuanLyDonHang("ThuNgan");
            nv1.HuyDonHang("DH001"); // Bị từ chối

            IQuanLyDonHang nv2 = new ProxyQuanLyDonHang("QuanLy");
            nv2.HuyDonHang("DH002"); // Được duyệt

            Console.ReadLine();
        }
    }
}