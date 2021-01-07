using System;
using project_1.Utility;
using System.Text;
using project_1.Entities;
using project_1.Business;
namespace project_1.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt
    //ra trong Interface của Business
    public class FormSP
    {
        public void Nhap()
        {
            do
            {
                ISPBLL sanpham = new SPBLL();
                SPBLL spBLL = new SPBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN SẢN PHẨM ", 1, 1, 10, 79);
                IO.Writexy("Mã nhân viên:", 5, 4);
                IO.Writexy("Mã sản phẩm:", 26, 4);
                IO.Writexy("Tên sản phẩm: ", 46, 4);
                IO.Writexy("Giá:", 5, 6);
                IO.Writexy("Đơn vị:", 25, 6);
                IO.Writexy("Ngày:", 45, 6);
                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 8);
                Hien(1, 13, sanpham.LayDSSP(), 5, 0);
                SP sp = new SP();
                do
                {
                    sp.Manv = int.Parse("0" + IO.ReadNumber(18, 4));
                    if (sp.Manv <= 0)
                    {
                        IO.Clear(18, 4, 5, ConsoleColor.Black);
                        IO.Writexy("Mã nhân viên nhập không phù hợp...", 5, 9);
                    }
                    else if (spBLL.KT_MaNV(sp.Manv) == false)
                    {
                        IO.Writexy("Mã nhân viên này chưa tồn tại...Mời nhập lại...", 5, 9);
                        IO.Clear(18, 4, 5, ConsoleColor.Black);
                    }
                    else
                        sp.Manv = sp.Manv;

                } while (sp.Manv <= 0 || spBLL.KT_MaNV(sp.Manv) == false );
                IO.Clear(5, 9, 60, ConsoleColor.Black);

                do
                {
                    sp.Masp = int.Parse("0" + IO.ReadNumber(38, 4));
                    if (spBLL.KT_MaSP(sp.Masp) == true)
                    {
                        IO.Clear(38, 4, 5, ConsoleColor.Black);
                        IO.Writexy("Mã sản phẩm đã tổn tại. Mời nhập mã khác.", 5, 9);
                    }
                    else if (sp.Masp <= 0)
                    {
                        IO.Clear(38, 4, 5, ConsoleColor.Black);
                        IO.Writexy("Mã sản phẩm không phù hợp. Mời nhập mã khác!", 5, 9);
                    }
                    else
                    {
                        sp.Masp = sp.Masp;
                        IO.Writexy("Mã sản phẩm đã được thêm mới!", 5, 9);
                    }

                } while (sp.Masp <= 0 || spBLL.KT_MaSP(sp.Masp) == true);
                sp.Tensp = IO.ReadString(59, 4);
                do
                {
                    sp.Gia = double.Parse("0" + IO.ReadNumber(9, 6));
                    if (sp.Gia <= 0)
                    {
                        IO.Clear(9, 6, 10, ConsoleColor.Black);
                        IO.Clear(5, 9, 60, ConsoleColor.Black);
                        IO.Writexy("Giá bán nhập sai. Mời nhập lại...", 5, 9);
                    }
                    else
                        sp.Gia = sp.Gia;
                } while (sp.Gia <= 0);
                sp.Donvi = IO.ReadString(32, 6);
                sp.Ngay = IO.ReadString(50, 6);
                Console.SetCursorPosition(50, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.V) Hien(1, 13, sanpham.LayDSSP(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter) sanpham.ThemSP(sp);
            } while (true);
        }
        public void SuaSP()
        {
            do
            {
                ISPBLL sanpham = new SPBLL();
                Console.Clear();
                IO.BoxTitle("CẬP NHẬT THÔNG TIN SẢN PHẨM ", 1, 1, 10, 79);
                IO.Writexy("Mã nhân viên:", 5, 4);
                IO.Writexy("Mã sản phẩm:", 26, 4);
                IO.Writexy("Tên sản phẩm: ", 46, 4);
                IO.Writexy("Giá:", 5, 6);
                IO.Writexy("Đơn vị:", 25, 6);
                IO.Writexy("Ngày:", 45, 6);
                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 8);
                Hien(1, 13, sanpham.LayDSSP(), 5, 0);
                int manv;
                int masp;
                string tensp;
                double gia;
                string donvi;
                string ngay;
                manv = int.Parse("0" + IO.ReadNumber(18, 4));
                if (manv == 1)
                {
                    masp = int.Parse("0" + IO.ReadNumber(38, 4));
                    SP sp = sanpham.LaySP(masp);
                    IO.Writexy("                ", 60, 4);
                    IO.Writexy("       ", 10, 6);
                    IO.Writexy("       ", 33, 6);
                    IO.Writexy("       ", 51, 6);

                    tensp = IO.ReadString(60, 4);
                    if (tensp != sp.Tensp && tensp != null) sp.Tensp = tensp;
                    gia = double.Parse("0" + IO.ReadNumber(10, 6));
                    if (gia != sp.Gia && gia != 0) sp.Gia = gia;
                    donvi = IO.ReadString(33, 6);
                    if (donvi != sp.Donvi && donvi != null) sp.Donvi = donvi;
                    ngay = IO.ReadString(51, 6);
                    if (ngay != sp.Ngay && ngay != null) sp.Ngay = ngay;
                    Console.SetCursorPosition(60, 8);
                    ConsoleKeyInfo kt = Console.ReadKey();
                    if (kt.Key == ConsoleKey.Escape)
                        break;
                    else if (kt.Key == ConsoleKey.V) Hien(1, 13, sanpham.LayDSSP(), 5, 1);
                    else if (kt.Key == ConsoleKey.Enter)
                    {
                        sanpham.SuaSP(sp);
                        Hien(1, 13, sanpham.LayDSSP(), 5, 1);
                    }
                }
                else
                {
                    IO.Clear(5, 9, 60, ConsoleColor.Black);
                    IO.Writexy("Bạn chưa đủ thẩm quyền để sửa...", 5, 9);
                }
            } while (true);

        }
        public void Xoa()
        {
            int masp = 0;
            int manv;
            do
            {
                Console.Clear();
                ISPBLL sanpham = new SPBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN ĐỐI TƯỢNG CẦN XÓA", 1, 1, 5, 79);
                IO.Writexy("Mã nhân viên: ", 5, 4);
                IO.Writexy("Mã sản phẩm:", 19, 4);
                Hien(1, 8, sanpham.LayDSSP(), 5, 0);
                manv = int.Parse(IO.ReadNumber(19, 4));
                masp = int.Parse(IO.ReadNumber(18, 4));
                if (masp == 0) break;
                else sanpham.XoaSP(masp);
                {
                    IO.Writexy("Nhân viên có mã {0} đã xóa sản phẩm thành công!", manv, 5, 6);
                    Hien(1, 8, sanpham.LayDSSP(), 5, 1);
                }
            } while (true);

        }
        public void Tim()
        {
            string tensp = "";
            do
            {
                Console.Clear();
                ISPBLL sanpham = new SPBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN CẦN TÌM KIẾM", 1, 1, 5, 79);
                IO.Writexy("Tên sản phẩm:", 9, 4);
                Hien(1, 8, sanpham.LayDSSP(), 5, 0);
                tensp = IO.ReadString(22, 4);
                List<SP> list = sanpham.TimSP(new SP(0, 0, tensp, 0, null, null));
                Hien(1, 8, list, 5, 1);
                if (tensp == "") break;
            } while (true);

        }

        public void Hien(int xx, int yy, List<SP> list, int n, int type)
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
                IO.Writexy("                     DANH SÁCH SẢN PHẨM                       ", x, y);
                IO.Writexy("┌───────┬───────┬─────────────────┬──────────┬──────────┬──────────┐", x, y + 1);
                IO.Writexy("│ Mã nv │ Mã sp │      Tên sp     │   Giá    │  Đơn vi  │   Ngày   │", x, y + 2);
                IO.Writexy("├───────┼───────┼─────────────────┼──────────┼──────────┼──────────┤", x, y + 3);
                y = y + 4;
                for (int i = dau; i < cuoi; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].Manv.ToString(), x + 1, y + d, 8);
                    IO.Writexy("│", x + 8, y + d);
                    IO.Writexy(list[i].Masp.ToString(), x + 10, y + d, 8);
                    IO.Writexy("│", x + 16, y + d);
                    IO.Writexy(list[i].Tensp, x + 17, y + d, 17);
                    IO.Writexy("│", x + 34, y + d);
                    IO.Writexy(list[i].Gia.ToString(), x + 35, y + d, 10);
                    IO.Writexy("│", x + 45, y + d);
                    IO.Writexy(list[i].Donvi.ToString(), x + 46, y + d, 10);
                    IO.Writexy("│", x + 56, y + d);
                    IO.Writexy(list[i].Ngay, x + 57, y + d, 10);
                    IO.Writexy("│", x + 67, y + d);

                    if (i < cuoi - 1)
                        IO.Writexy("├───────┼───────┼─────────────────┼──────────┼──────────┼──────────┤", x, y + d + 1);
                    y = y + 1;
                    d = d + 1;
                }
                IO.Writexy("└───────┴───────┴─────────────────┴──────────┴──────────┴──────────┘", x, y + d - 1);
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



    }
}
