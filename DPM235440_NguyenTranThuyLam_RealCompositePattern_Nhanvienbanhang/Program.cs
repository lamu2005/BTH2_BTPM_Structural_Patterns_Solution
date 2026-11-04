using System;
using System.Collections.Generic;

namespace RealCompositePattern_Nhanvienbanhang
{
    public abstract class Component
    {
        public string Ten { get; set; }
        public Component(string ten) => Ten = ten;
        public abstract void Display(int indent);
    }

    public class SanPham : Component
    {
        public double Gia { get; set; }
        public SanPham(string ten, double gia) : base(ten) => Gia = gia;

        public override void Display(int indent)
        {
            Console.WriteLine(new string('-', indent) + $" [Sản phẩm] {Ten} - {Gia:N0} VNĐ");
        }
    }

    public class DanhMuc : Component
    {
        private List<Component> _children = new List<Component>();
        public DanhMuc(string ten) : base(ten) { }

        public void Add(Component c) => _children.Add(c);

        public override void Display(int indent)
        {
            Console.WriteLine(new string('-', indent) + $" [+ Danh mục] {Ten}");
            foreach (var child in _children)
            {
                child.Display(indent + 2);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== REAL COMPOSITE: QUẢN LÝ DANH MỤC SẢN PHẨM ===");

            DanhMuc root = new DanhMuc("Siêu Thị Điện Máy");
            DanhMuc dmDienThoai = new DanhMuc("Điện thoại");

            dmDienThoai.Add(new SanPham("iPhone 15 Pro", 28000000));
            dmDienThoai.Add(new SanPham("Samsung S24 Ultra", 26000000));

            root.Add(dmDienThoai);
            root.Add(new SanPham("Tủ lạnh Panasonic", 12000000));

            root.Display(1);
            Console.ReadLine();
        }
    }
}