using System;
using project_1.Utility;
using System.Text;
using project_1.Entities;
using project_1.Business;
namespace project_1.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt
    //ra trong Interface của Business
    public class FormSanPham
    {
        public void Nhap()
        {
            do
            {
                ISanPhamBLL sanpham = new SanPhamBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN SẢN PHẨM", 1, 1, 10, 79);
                IO.Writexy("Mã sản phẩm:", 5, 4);
                IO.Writexy("Mã loại:", 30, 4);
                IO.Writexy("Tên sản phẩm:", 5, 6);
                IO.Writexy("Giá:", 25, 6);
                IO.Writexy("Đơn vị:", 45, 6);
                IO.Writexy("Ngày:", 55, 6);
                IO.Writexy("Số lượng nhập về: ", 65, 6);
                IO.Writexy("Số lượng hiện có: ", 75, 6);
                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 8);
                Hien(1, 13, sanpham.LayDSSanPham(), 5, 0);
                SanPham sp = new SanPham();
                sp.Msp = IO.ReadString(13, 4);
                sp.Ml = IO.ReadString(40, 4);
                sp.Tensp = IO.ReadString(15, 5);
                sp.Gia = double.Parse("0" + IO.ReadNumber(25, 5));
                sp.Donvi = IO.ReadString(35, 5);
                sp.Ngay = DateTime.Parse("0" + IO.ReadNumber(45, 5));
                sp.Slnv = int.Parse("0" + IO.ReadNumber(34, 6));
                sp.Slhc = int.Parse("0" + IO.ReadNumber(55, 6));
                Console.SetCursorPosition(50, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) project_1.Program.Hien();
                else if (kt.Key == ConsoleKey.V) Hien(1, 13, sanpham.LayDSSanPham(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter) sanpham.ThemSanPham(sp);
            } while (true);
        }
        public void SuaSanPham()
        {
            ISanPhamBLL sanpham = new SanPhamBLL();
            Console.Clear();
            IO.BoxTitle("CẬP NHẬT THÔNG TIN SẢN PHẨM", 1, 1, 10, 79);
            IO.Writexy("Mã sản phẩm", 5, 4);
            IO.Writexy("Mã loại:", 20, 4);
            IO.Writexy("Tên sản phẩm:", 45, 4);
            IO.Writexy("Giá: ", 25, 5);
            IO.Writexy("Đơn vị: ", 35, 5);
            IO.Writexy("Ngày: ", 45, 5);
            IO.Writexy("Số lượng nhập về:", 5, 6);
            IO.Writexy("Số lượng hiện có:", 25, 6);
            IO.Writexy("----------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter de cap nhat, Esc de thoat, V xem chi tiet!", 5, 8);
            Hien(1, 13, sanpham.LayDSSanPham(), 5, 0);
            string msp;
            string ml;
            string tensp;
            double gia;
            string donvi;
            DateTime ngay;
            int slnv;
            int slhc;

            msp = IO.ReadString(12, 4);
            SanPham sp = sanpham.LaySanPham(msp);
            IO.Writexy(sp.Ml, 28, 4);
            IO.Writexy(sp.Tensp, 55, 4);
            IO.Writexy(sp.Gia.ToString(), 25, 5);
            IO.Writexy(sp.Donvi, 35, 5);
            IO.Writexy(sp.Ngay.ToString(), 45, 5);
            IO.Writexy(sp.Slnv.ToString(), 16, 6);
            IO.Writexy(sp.Slhc.ToString(), 34, 6);

            ml = IO.ReadString(28, 4);
            if (ml != sp.Ml && ml != null) sp.Ml = ml;
            tensp = IO.ReadString(55, 4);
            if (tensp != sp.Tensp && tensp != null) sp.Tensp = tensp;
            gia = double.Parse("0" + IO.ReadNumber(25, 5));
            if (gia != sp.Gia && gia != 0) sp.Gia = gia;
            donvi = IO.ReadString(35, 5);
            if (donvi != sp.Donvi && donvi != null) sp.Donvi = donvi;
            ngay = DateTime.Parse("0" + IO.ReadNumber(45, 5));
            if (ngay != sp.Ngay && ngay != DateTime.Parse(null)) sp.Ngay = ngay;
            slnv = int.Parse("0" + IO.ReadNumber(16, 6));
            if (slnv != sp.Slnv && slnv != 0) sp.Slnv = slnv;
            slhc = int.Parse("0" + IO.ReadNumber(34, 6));
            if (slhc != sp.Slhc && slhc != 0) sp.Slhc = slhc;


            Console.SetCursorPosition(60, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape) project_1.Program.Hien();
            else if (kt.Key == ConsoleKey.V) Hien(1, 13, sanpham.LayDSSanPham(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                sanpham.SuaSanPham(sp);
                Hien(1, 13, sanpham.LayDSSanPham(), 5, 1);
            }
            project_1.Program.Hien();
        }
        public void Xoa()
        {
            string msp = "";
            do
            {
                Console.Clear();
                ISanPhamBLL sanpham = new SanPhamBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN ĐỐI TƯỢNG CẦN XÓA", 1, 1, 5, 79);
                IO.Writexy("Mã sản phẩm:", 5, 4);
                Hien(1, 8, sanpham.LayDSSanPham(), 5, 0);
                msp = IO.ReadString(18, 4);
                if (msp == null) break;
                else sanpham.XoaSanPham(msp);
                Hien(1, 8, sanpham.LayDSSanPham(), 5, 1);
            } while (true);
            project_1.Program.Hien();
        }
        public void Tim()
        {
            string tensp = "";
            do
            {
                Console.Clear();
                ISanPhamBLL sanpham = new SanPhamBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN CẦN TÌM KIẾM", 1, 1, 5, 79);
                IO.Writexy("Tên sản phẩm:", 5, 4);
                Hien(1, 8, sanpham.LayDSSanPham(), 5, 0);
                tensp = IO.ReadString(13, 4);
                List<SanPham> list = sanpham.TimSanPham(new SanPham(null, null, tensp, 0, null, DateTime.Parse(null), 0, 0));
                Hien(1, 8, list, 5, 1);
                if (tensp == "") break;
            } while (true);
            project_1.Program.Hien();
        }
        
        public void Hien(int xx, int yy, List<SanPham> list, int n, int type)
        {
            int dau = 0; int curpage = 1; int totalpage = list.Count % n == 0 ? list.Count / n : list.Count / n + 1;
            int cuoi = list.Count <= n ? list.Count : n;
            int x, y, d;
            do
            {
                IO.Clear(xx, yy, 1500, ConsoleColor.Black);
                dau = (curpage - 1) * n;
                cuoi = curpage * n < list.Count ? curpage * n : list.Count;
                x = xx; y = yy; d = 0;
                IO.Writexy("                     DANH SÁCH SẢN PHẨM                              ", x, y);
                IO.Writexy("┌─────────────┬─────────┬──────────────┬──────────┬─────────┬──────────┬──────────────────┬──────────────────┐", x, y + 1);
                IO.Writexy("│ Mã sản phẩm │ Mã loại │ Tên sản phẩm │   Giá    │ Đơn vị  │   Ngày   │ Số lượng nhập về │ Số lượng hiện có │", x, y + 2);
                IO.Writexy("├─────────────┼─────────┼──────────────┼──────────┼─────────┼──────────┼──────────────────┼──────────────────┤", x, y + 3);
                y = y + 4;
                for (int i = dau; i < cuoi; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].Msp, x + 1, y + d, 8);
                    IO.Writexy("│", x + 8, y + d);
                    IO.Writexy(list[i].Ml, x + 9, y + d, 9);
                    IO.Writexy("│", x + 17, y + d);
                    IO.Writexy(list[i].Tensp, x + 18, y + d, 11);
                    IO.Writexy("│", x + 28, y + d);
                    IO.Writexy(list[i].Gia.ToString(), x + 29, y + d, 11);
                    IO.Writexy("│", x + 39, y + d);
                    IO.Writexy(list[i].Donvi, x + 40, y + d, 11);
                    IO.Writexy("│", x + 50, y + d);
                    IO.Writexy(list[i].Ngay.ToString(), x + 51, y + d, 11);
                    IO.Writexy("│", x + 61, y + d);
                    IO.Writexy(list[i].Slnv.ToString(), x + 62, y + d, 7);
                    IO.Writexy("│", x + 68, y + d);
                    IO.Writexy(list[i].Slhc.ToString(), x + 62, y + d, 7);
                    IO.Writexy("│", x + 68, y + d);
                    if (i < cuoi - 1)
                        IO.Writexy("├─────────────┼─────────┼──────────────┼──────────┼─────────┼──────────┼──────────────────┼──────────────────┤", x, y + d + 1);
                    y = y + 1;
                    d = d + 1;
                }
                IO.Writexy("└───────┴────────┴──────────┴──────────┴──────────┴──────────┴──────┘", x, y + d - 1);
                IO.Writexy(" Trang " + curpage + "/" + totalpage, x, y + d);
                IO.Writexy(" Trang " + curpage + "/" + totalpage + "          An PgUp, PgDn xem tiep, Esc de thoat...", x, y + d);

                if (type == 0) break;

                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.PageDown)
                {
                    if (curpage < totalpage) curpage = curpage + 1;
                    else curpage = 1;
                }
                else if (kt.Key == ConsoleKey.PageUp)
                {
                    if (curpage > 1) curpage = curpage - 1;
                    else curpage = totalpage;
                }
                else if (kt.Key == ConsoleKey.Escape) break;
            } while (true);
        }
        public class MenuDemoSP : Menu
        {
            public MenuDemoSP(string[] mn) : base(mn) { }
            public override void ThucHien(int vitri)
            {
                FormSanPham sp = new FormSanPham();
                switch (vitri)
                {
                    case 0:
                        sp.Nhap();
                        break;
                    case 1:
                        sp.Tim();
                        break;
                    case 2:
                        sp.Xoa();
                        break;
                    case 3:
                        sp.SuaSanPham();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }

    }
}
