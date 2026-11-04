using System;
using System.Collections.Generic;

namespace RealFlyweightPattern_Nhanvienbanhang
{
    // Flyweight chứa thông tin chung
    public class HangSanXuat
    {
        public string TenHang { get; set; }
        public string QuocGia { get; set; }
        public HangSanXuat(string ten, string quocGia) { TenHang = ten; QuocGia = quocGia; }
    }

    // Factory quản lý Flyweight
    public class HangFactory
    {
        private static Dictionary<string, HangSanXuat> _hangs = new Dictionary<string, HangSanXuat>();

        public static HangSanXuat GetHang(string ten, string quocGia)
        {
            if (!_hangs.ContainsKey(ten))
            {
                _hangs[ten] = new HangSanXuat(ten, quocGia);
            }
            return _hangs[ten];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== REAL FLYWEIGHT: TỐI ƯU DỮ LIỆU SẢN PHẨM ===");

            var hang1 = HangFactory.GetHang("Samsung", "Hàn Quốc");
            var hang2 = HangFactory.GetHang("Samsung", "Hàn Quốc");

            if (object.ReferenceEquals(hang1, hang2))
            {
                Console.WriteLine("=> Cùng chia sẻ 1 đối tượng Hãng Sản Xuất 'Samsung' trong bộ nhớ RAM!");
            }

            Console.ReadLine();
        }
    }
}