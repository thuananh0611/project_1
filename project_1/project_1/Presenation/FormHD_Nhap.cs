using System;
using project_1.Utility;
using System.Text;
using project_1.Entities;
using project_1.Business;
namespace project_1.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt
    //ra trong Interface của Business
    public class FormHD_Nhap
    {
        public void Nhap()
        {
            do
            {
                IHD_NhapBLL hdnhap = new HD_NhapBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN HÓA ĐƠN NHẬP", 1, 1, 13, 90);
                IO.Writexy("Mã hdn:", 5, 4);
                IO.Writexy("Tên hóa đơn:", 23, 4);
                IO.Writexy("Mã NV:", 56, 4);
                IO.Writexy("Số lượng:", 5, 6);
                IO.Writexy("Mã NCC:", 24, 6);
                IO.Writexy("Đơn vị:", 42, 6);
                IO.Writexy("Giá nhập:", 5, 8);
                IO.Writexy("Vat:", 25, 8);
                IO.Writexy("Thành tiền:", 40, 8);
                IO.Writexy("----------------------------------------------------------------------------", 2, 9);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 10);
                Hien(1, 15, hdnhap.LayDSHD_Nhap(), 5, 0);
                HD_Nhap hdn = new HD_Nhap();
                hdn.Mhdn = int.Parse("0" + IO.ReadNumber(13, 4));
                hdn.Tenhd = IO.ReadString(36, 4);
                hdn.Manv = int.Parse("0" + IO.ReadNumber(63, 4));
                hdn.Sl = int.Parse("0" + IO.ReadNumber(14, 6));
                hdn.Mancc = int.Parse("0" + IO.ReadNumber(32, 6));
                hdn.Donvi = IO.ReadString(50, 6);
                hdn.Gianhap = double.Parse("0" + IO.ReadNumber(15, 8));
                hdn.VAT = double.Parse("0" + IO.ReadNumber(30, 8));
                hdn.Thanhtien = double.Parse("0" + IO.ReadNumber(51, 8));
                Console.SetCursorPosition(50, 10);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.V) Hien(1, 15, hdnhap.LayDSHD_Nhap(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter) hdnhap.ThemHD_Nhap(hdn);
            } while (true);
        }
        public void SuaHD_Nhap()
        {
            do
            {
                IHD_NhapBLL hdnhap = new HD_NhapBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN HÓA ĐƠN NHẬP", 1, 1, 13, 90);
                IO.Writexy("Mã hdn:", 5, 4);
                IO.Writexy("Tên hóa đơn:", 23, 4);
                IO.Writexy("Mã NV:", 56, 4);
                IO.Writexy("Số lượng:", 5, 6);
                IO.Writexy("Mã NCC:", 24, 6);
                IO.Writexy("Đơn vị:", 42, 6);
                IO.Writexy("Giá nhập:", 5, 8);
                IO.Writexy("Vat:", 25, 8);
                IO.Writexy("Thành tiền:", 40, 8);
                IO.Writexy("----------------------------------------------------------------------------", 2, 9);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 10);
                Hien(1, 15, hdnhap.LayDSHD_Nhap(), 5, 0);
                int mhdn;
                string tenhd;
                int manv;
                int sl;
                int mancc;
                string donvi;
                double gianhap;
                double vat;
                double thanhtien;
                mhdn = int.Parse("0" + IO.ReadNumber(15, 4));
                HD_Nhap hdn = hdnhap.LayHD_Nhap(mhdn);
                IO.Writexy("    ", 35, 4);
                IO.Writexy("    ", 63, 4);
                IO.Writexy("    ", 16, 6);
                IO.Writexy("    ", 32, 6);
                IO.Writexy("    ", 50, 6);
                IO.Writexy("    ", 15, 8);
                IO.Writexy("    ", 30, 8);
                IO.Writexy("    ", 52, 8);

                mhdn = int.Parse("0" + IO.ReadNumber(15, 4));
                if (mhdn != hdn.Mhdn && mhdn != 0) hdn.Mhdn = mhdn;
                tenhd = IO.ReadString(36, 4);
                if (tenhd != hdn.Tenhd && tenhd != null) hdn.Tenhd = tenhd;
                manv = int.Parse("0" + IO.ReadNumber(63, 4));
                if (manv != hdn.Manv && manv != 0) hdn.Manv = manv;
                sl = int.Parse("0" + IO.ReadNumber(14, 6));
                if (sl != hdn.Sl && sl != 0) hdn.Sl = sl;
                mancc = int.Parse("0" + IO.ReadNumber(32, 6));
                if (mancc != hdn.Mancc && mancc != 0) hdn.Mancc = mancc;
                donvi = IO.ReadString(50, 6);
                if (donvi != hdn.Donvi && donvi != null) hdn.Donvi = donvi;
                gianhap = double.Parse("0" + IO.ReadNumber(15, 8));
                if (gianhap != hdn.Gianhap && gianhap != 0) hdn.Gianhap = gianhap;
                vat = double.Parse("0" + IO.ReadNumber(30, 8));
                if (vat != hdn.VAT && vat != 0) hdn.VAT = vat;
                thanhtien = double.Parse("0" + IO.ReadNumber(51, 8));
                if (thanhtien != hdn.Thanhtien && thanhtien != 0) hdn.Thanhtien = thanhtien;


                Console.SetCursorPosition(60, 10);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.V) Hien(1, 15, hdnhap.LayDSHD_Nhap(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                {
                    hdnhap.SuaHD_Nhap(hdn);
                    Hien(1, 15, hdnhap.LayDSHD_Nhap(), 5, 1);
                }
            } while (true);
        }
        public void Xoa()
        {
            int mhdn = 0;
            do
            {
                Console.Clear();
                IHD_NhapBLL hdnhap = new HD_NhapBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN ĐỐI TƯỢNG CẦN XÓA", 1, 1, 5, 79);
                IO.Writexy("Mã hóa đơn nhập:", 5, 4);
                Hien(1, 8, hdnhap.LayDSHD_Nhap(), 5, 0);
                mhdn = int.Parse("0" + IO.ReadString(22, 4));
                if (mhdn == 0) break;
                else hdnhap.XoaHD_Nhap(mhdn);
                Hien(1, 8, hdnhap.LayDSHD_Nhap(), 5, 1);
            } while (true);
        }
        public void Tim()
        {
            int mhdn = 0;
            do
            {
                Console.Clear();
                IHD_NhapBLL hdnhap = new HD_NhapBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN CẦN TÌM KIẾM", 1, 1, 5, 79);
                IO.Writexy("Mã hóa đơn nhập:", 5, 4);
                Hien(1, 8, hdnhap.LayDSHD_Nhap(), 5, 0);
                mhdn = int.Parse(IO.ReadNumber(23, 4));
                List<HD_Nhap> list = hdnhap.TimHD_Nhap(new HD_Nhap(mhdn, null, 0, 0, 0, null, 0, 0, 0));
                Hien(1, 8, list, 5, 1);
                if (mhdn == 0) break;
            } while (true);
        }

        public void Hien(int xx, int yy, List<HD_Nhap> list, int n, int type)
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
                IO.Writexy("                     DANH SÁCH HÓA ĐƠN NHẬP                             ", x, y);
                IO.Writexy("┌─────────┬───────────────────────────┬───────┬──────────┬────────┬─────────────┬──────────┬─────────┬────────────┐", x, y + 1);
                IO.Writexy("│ Mã HDN  │      Tên hóa đơn          │ Mã NV │ Số lượng │ Mã ncc │ Đơn vị tính │ Giá nhập │   VAT   │ Thành tiền │", x, y + 2);
                IO.Writexy("├─────────┼───────────────────────────┼───────┼──────────┼────────┼─────────────┼──────────┼─────────┼────────────┤", x, y + 3);
                y = y + 4;
                for (int i = dau; i < cuoi; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].Mhdn.ToString(), x + 1, y + d, 9);
                    IO.Writexy("│", x + 10, y + d);
                    IO.Writexy(list[i].Tenhd, x + 11, y + d, 27);
                    IO.Writexy("│", x + 38, y + d);
                    IO.Writexy(list[i].Manv.ToString(), x + 39, y + d, 7);
                    IO.Writexy("│", x + 46, y + d);
                    IO.Writexy(list[i].Sl.ToString(), x + 47, y + d, 10);
                    IO.Writexy("│", x + 57, y + d);
                    IO.Writexy(list[i].Mancc.ToString(), x + 58, y + d, 9);
                    IO.Writexy("│", x + 66, y + d);
                    IO.Writexy(list[i].Donvi, x + 68, y + d, 13);
                    IO.Writexy("│", x + 80, y + d);
                    IO.Writexy(list[i].Gianhap.ToString(), x + 82, y + d, 10);
                    IO.Writexy("│", x + 91, y + d);
                    IO.Writexy(list[i].VAT.ToString(), x + 92, y + d, 9);
                    IO.Writexy("│", x + 101, y + d);
                    IO.Writexy(list[i].Thanhtien.ToString(), x + 102, y + d, 12);
                    IO.Writexy("│", x + 114, y + d);
                    if (i < cuoi - 1)
                        IO.Writexy("├─────────┼───────────────────────────┼───────┼──────────┼────────┼─────────────┼──────────┼─────────┼────────────┤", x, y + d + 1);
                    y = y + 1;
                    d = d + 1;
                }
                IO.Writexy("└─────────┴───────────────────────────┴───────┴──────────┴────────┴─────────────┴──────────┴─────────┴────────────┘", x, y + d - 1);
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
