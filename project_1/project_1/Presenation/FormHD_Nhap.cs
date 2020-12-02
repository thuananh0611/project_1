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
                IO.BoxTitle("NHẬP THÔNG TIN HÓA ĐƠN NHẬP", 1, 1, 10, 90);
                IO.Writexy("Mã hóa đơn nhập:", 5, 4);
                IO.Writexy("Tên hóa đơn nhập:", 33, 4);
                IO.Writexy("Mã nhân viên:", 66, 4);
                IO.Writexy("Số lượng:", 25, 6);
                IO.Writexy("Mã nhà cung cấp:", 5, 6);
                IO.Writexy("Đơn vị:", 32, 6);
                IO.Writexy("Giá nhâp:", 50, 6);
                IO.Writexy("Vat:", 70, 6);
                IO.Writexy("Thành tiền:", 85, 6);
                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 8);
                Hien(1, 13, hdnhap.LayDSHD_Nhap(), 5, 0);
                HD_Nhap hdn = new HD_Nhap();
                hdn.Mhdn = int.Parse("0" + IO.ReadNumber(23, 4));
                hdn.Tenhd = IO.ReadString(51, 4);
                hdn.Manv = int.Parse("0" + IO.ReadString(80, 4));
                hdn.Sl = int.Parse("0" + IO.ReadNumber(63, 4));
                hdn.Mancc = int.Parse("0" + IO.ReadString(22, 6));
                hdn.Donvi = IO.ReadString(40, 6);
                hdn.Gianhap = double.Parse("0" + IO.ReadNumber(60, 6));
                hdn.VAT = double.Parse("0" + IO.ReadNumber(75, 6));
                hdn.Thanhtien = double.Parse("0" + IO.ReadNumber(97, 6));
                Console.SetCursorPosition(50, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.V) Hien(1, 13, hdnhap.LayDSHD_Nhap(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter) hdnhap.ThemHD_Nhap(hdn);
            } while (true);
        }
        public void SuaHD_Nhap()
        {
            IHD_NhapBLL hdnhap = new HD_NhapBLL();
            Console.Clear();
            IO.Writexy("Mã hóa đơn nhập:", 5, 4);
            IO.Writexy("Tên hóa đơn nhập:", 33, 4);
            IO.Writexy("Mã nhân viên:", 66, 4);
            IO.Writexy("Số lượng:", 25, 6);
            IO.Writexy("Mã nhà cung cấp:", 5, 6);
            IO.Writexy("Đơn vị:", 32, 6);
            IO.Writexy("Giá nhâp:", 50, 6);
            IO.Writexy("Vat:", 70, 6);
            IO.Writexy("Thành tiền:", 85, 6);
            IO.Writexy("----------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter de cap nhat, Esc de thoat, V xem chi tiet!", 5, 8);
            Hien(1, 13, hdnhap.LayDSHD_Nhap(), 5, 0);
            int mhdn;
            string tenhd;
            int manv;
            int sl;
            int mancc;
            string donvi;
            double gianhap;
            double vat;
            double thanhtien;
            mhdn = int.Parse("0" + IO.ReadString(13, 4));
            HD_Nhap hdn = hdnhap.LayHD_Nhap(mhdn);
            hdn.Tenhd = IO.ReadString(51, 4);
            hdn.Manv = int.Parse("0" + IO.ReadNumber(80, 4));
            hdn.Sl = int.Parse("0" + IO.ReadNumber(63, 4));
            hdn.Mancc = int.Parse("0" + IO.ReadString(22, 6));
            hdn.Donvi = IO.ReadString(40, 6);
            hdn.Gianhap = double.Parse("0" + IO.ReadNumber(60, 6));
            hdn.VAT = double.Parse("0" + IO.ReadNumber(75, 6));
            hdn.Thanhtien = double.Parse("0" + IO.ReadNumber(97, 6));


            mhdn = int.Parse("0" + IO.ReadNumber(13, 4));
            if (mhdn != hdn.Mhdn && mhdn != 0) hdn.Mhdn = mhdn;
            tenhd = IO.ReadString(51, 4);
            if (tenhd != hdn.Tenhd && tenhd != null) hdn.Tenhd = tenhd;
            manv = int.Parse("0" + IO.ReadNumber(80, 4));
            if (manv != hdn.Manv && manv != 0) hdn.Manv = manv;
            sl = int.Parse("0" + IO.ReadNumber(63, 4));
            if (sl != hdn.Sl && sl != 0) hdn.Sl = sl;
            mancc = int.Parse("0" + IO.ReadString(22, 6));
            if (mancc != hdn.Mancc && mancc != 0) hdn.Mancc = mancc;
            donvi = IO.ReadString(40, 6);
            if (donvi != hdn.Donvi && donvi != null) hdn.Donvi = donvi;
            gianhap = double.Parse("0" + IO.ReadNumber(60, 6));
            if (gianhap != hdn.Gianhap && gianhap != 0) hdn.Gianhap = gianhap;
            vat = double.Parse("0" + IO.ReadNumber(75, 6));
            if (vat != hdn.VAT && vat != 0) hdn.VAT = vat;
            thanhtien = double.Parse("0" + IO.ReadNumber(97, 6));
            if (thanhtien != hdn.Thanhtien && thanhtien != 0) hdn.Thanhtien = thanhtien;


            Console.SetCursorPosition(60, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.V) Hien(1, 13, hdnhap.LayDSHD_Nhap(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                hdnhap.SuaHD_Nhap(hdn);
                Hien(1, 13, hdnhap.LayDSHD_Nhap(), 5, 1);
            }
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
                mhdn = int.Parse("0" + IO.ReadString(13, 4));
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
                IO.Writexy("Tên hóa đơn nhập:", 5, 4);
                Hien(1, 8, hdnhap.LayDSHD_Nhap(), 5, 0);
                mhdn = int.Parse(IO.ReadNumber(13, 4));
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
                IO.Writexy("┌─────────┬─────────────────────────────────┬──────────────┬──────────┬─────────────────┬─────────────┬──────────┬─────────┬────────────┐", x, y + 1);
                IO.Writexy("│ Mã HDN  │          Tên hóa đơn            │ Mã nhân viên │ Số lượng │ Mã nhà cung cấp │ Đơn vị tính │ Giá nhập │   VAT   │ Thành tiền │", x, y + 2);
                IO.Writexy("├─────────┼─────────────────────────────────┼──────────────┼──────────┼─────────────────┼─────────────┼──────────┼─────────┼────────────┤", x, y + 3);
                y = y + 4;
                for (int i = dau; i < cuoi; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].Mhdn.ToString(), x + 1, y + d, 9);
                    IO.Writexy("│", x + 10, y + d);
                    IO.Writexy(list[i].Tenhd, x + 11, y + d, 33);
                    IO.Writexy("│", x + 44, y + d);
                    IO.Writexy(list[i].Manv.ToString(), x + 45, y + d, 14);
                    IO.Writexy("│", x + 59, y + d);
                    IO.Writexy(list[i].Sl.ToString(), x + 60, y + d, 10);
                    IO.Writexy("│", x + 70, y + d);
                    IO.Writexy(list[i].Mancc.ToString(), x + 61, y + d, 17);
                    IO.Writexy("│", x + 78, y + d);
                    IO.Writexy(list[i].Donvi, x + 79, y + d, 13);
                    IO.Writexy("│", x + 92, y + d);
                    IO.Writexy(list[i].Gianhap.ToString(), x + 93, y + d, 10);
                    IO.Writexy("│", x + 103, y + d);
                    IO.Writexy(list[i].VAT.ToString(), x + 104, y + d, 9);
                    IO.Writexy("│", x + 113, y + d);
                    IO.Writexy(list[i].Thanhtien.ToString(), x + 114, y + d, 12);
                    IO.Writexy("│", x + 126, y + d);
                    if (i < cuoi - 1)
                        IO.Writexy("├─────────┼─────────────────────────────────┼──────────────┼──────────┼─────────────────┼─────────────┼──────────┼─────────┼────────────┤", x, y + d + 1);
                    y = y + 1;
                    d = d + 1;
                }
                IO.Writexy("└─────────┴─────────────────────────────────┴──────────────┴──────────┴─────────────────┴─────────────┴──────────┴─────────┴────────────┘", x, y + d - 1);
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
