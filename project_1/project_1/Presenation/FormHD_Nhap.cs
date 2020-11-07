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
                IO.BoxTitle("NHẬP THÔNG TIN HÓA ĐƠN NHẬP", 1, 1, 10, 79);
                IO.Writexy("Mã loại:", 5, 4);
                IO.Writexy("Mã hóa đơn nhập:", 30, 4);
                IO.Writexy("Mã nhân viên:", 5, 6);
                IO.Writexy("Tên hóa đơn:", 25, 6);
                IO.Writexy("Mã sản phẩm:", 45, 6);
                IO.Writexy("Số lượng:", 45, 6);
                IO.Writexy("Mã nhà cung cấp:", 45, 6);
                IO.Writexy("Đơn vị:", 45, 6);
                IO.Writexy("Giá nhập:", 45, 6);
                IO.Writexy("Thành tiền:", 45, 6);
                IO.Writexy("Vat:", 45, 6);


                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 8);
                Hien(1, 13, hdnhap.LayDSHD_Nhap(), 5, 0);
                HD_Nhap hdn = new HD_Nhap();
                hdn.Mal = IO.ReadString(13, 4);
                hdn.Mhdn = IO.ReadString(23, 4);
                hdn.Manv = IO.ReadString(33, 4);
                hdn.Tenhd = IO.ReadString(43, 4);
                hdn.Msp = IO.ReadString(53, 4);
                hdn.Sl = int.Parse("0" + IO.ReadNumber(63, 4));
                hdn.Mancc = IO.ReadString(23, 5);
                hdn.Donvi = IO.ReadString(33, 5);
                hdn.Gianhap = double.Parse("0" + IO.ReadNumber(43, 5));
                hdn.Thanhtien = double.Parse("0" + IO.ReadNumber(53, 5));
                hdn.VAT = double.Parse("0" + IO.ReadNumber(63, 5));
                Console.SetCursorPosition(50, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) project_1.Program.Hien();
                else if (kt.Key == ConsoleKey.V) Hien(1, 13, hdnhap.LayDSHD_Nhap(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter) hdnhap.ThemHD_Nhap(hdn);
            } while (true);
        }
        public void SuaHD_Nhap()
        {
            IHD_NhapBLL hdnhap = new HD_NhapBLL();
            Console.Clear();
            IO.BoxTitle("CẬP NHẬT THÔNG TIN HÓA ĐƠN NHẬP", 1, 1, 10, 79);
            IO.Writexy("Mã loại hóa đơn:", 5, 4);
            IO.Writexy("Mã hóa đơn nhập:", 20, 4);
            IO.Writexy("Mã nhân viên nhập:", 45, 4);
            IO.Writexy("Tên hóa đơn nhập:", 5, 6);
            IO.Writexy("Mã sản phẩm:", 25, 6);
            IO.Writexy("Số lượng nhập:", 45, 6);
            IO.Writexy("Mã nhà cung cấp:", 45, 7);
            IO.Writexy("Đơn vị tính:", 45, 7);
            IO.Writexy("Giá nhập:", 45, 7);
            IO.Writexy("Thành tiền:", 45, 7);
            IO.Writexy("VAT:", 45, 7);
            IO.Writexy("----------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter de cap nhat, Esc de thoat, V xem chi tiet!", 5, 8);
            Hien(1, 13, hdnhap.LayDSHD_Nhap(), 5, 0);
            string mal;
            string mhdn;
            string manv;
            string tenhd;
            string msp;
            int sl;
            string mancc;
            string donvi;
            double gianhap;
            double thanhtien;
            double vat;
            mhdn = IO.ReadString(12, 4);
            HD_Nhap hdn = hdnhap.LayHD_Nhap(mhdn);
            IO.Writexy(hdn.Mal, 28, 4);
            IO.Writexy(hdn.Manv, 55, 4);
            IO.Writexy(hdn.Tenhd, 65, 4);
            IO.Writexy(hdn.Msp, 75, 4);
            IO.Writexy(hdn.Sl.ToString(), 85, 4);
            IO.Writexy(hdn.Mancc, 25, 5);
            IO.Writexy(hdn.Donvi, 35, 5);
            IO.Writexy(hdn.Gianhap.ToString(), 45, 5);
            IO.Writexy(hdn.Thanhtien.ToString(), 55, 5);
            IO.Writexy(hdn.VAT.ToString(), 65, 5);
            

            mal = IO.ReadString(28, 4);
            if (mal != hdn.Mal && mal != null) hdn.Mal = mal;
            manv = IO.ReadString(55, 4);
            if (manv != hdn.Manv && manv != null) hdn.Manv = manv;
            tenhd = IO.ReadString(65, 4);
            if (tenhd != hdn.Tenhd && tenhd != null) hdn.Tenhd = tenhd;
            msp = IO.ReadString(75, 4);
            if (msp != hdn.Msp && msp != null) hdn.Msp = msp;
            sl = int.Parse("0" + IO.ReadNumber(85, 4));
            if (sl != hdn.Sl && sl != 0) hdn.Sl = sl;
            mancc = IO.ReadString(25, 5);
            if (mancc != hdn.Mancc && mancc != null) hdn.Mancc = mancc;
            donvi = IO.ReadString(35, 5);
            if (donvi != hdn.Donvi && donvi != null) hdn.Donvi = donvi;
            gianhap = double.Parse("0" + IO.ReadNumber(45, 5));
            if (gianhap != hdn.Gianhap && gianhap != 0) hdn.Gianhap = gianhap;
            thanhtien = double.Parse("0" + IO.ReadNumber(55, 5));
            if (thanhtien != hdn.Thanhtien && thanhtien != 0) hdn.Thanhtien = thanhtien;
            vat = double.Parse("0" + IO.ReadNumber(65, 5));
            if (vat != hdn.VAT && vat != 0) hdn.VAT = vat;


            Console.SetCursorPosition(60, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape) project_1.Program.Hien();
            else if (kt.Key == ConsoleKey.V) Hien(1, 13, hdnhap.LayDSHD_Nhap(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                hdnhap.SuaHD_Nhap(hdn);
                Hien(1, 13, hdnhap.LayDSHD_Nhap(), 5, 1);
            }
            project_1.Program.Hien();
        }
        public void Xoa()
        {
            string mhdn = "";
            do
            {
                Console.Clear();
                IHD_NhapBLL hdnhap = new HD_NhapBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN ĐỐI TƯỢNG CẦN XÓA", 1, 1, 5, 79);
                IO.Writexy("Mã hóa đơn nhập:", 5, 4);
                Hien(1, 8, hdnhap.LayDSHD_Nhap(), 5, 0);
                mhdn = IO.ReadString(18, 4);
                if (mhdn == null) break;
                else hdnhap.XoaHD_Nhap(mhdn);
                Hien(1, 8, hdnhap.LayDSHD_Nhap(), 5, 1);
            } while (true);
            project_1.Program.Hien();
        }
        public void Tim()
        {
            string tenhd = "";
            do
            {
                Console.Clear();
                IHD_NhapBLL hdnhap = new HD_NhapBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN CẦN TÌM KIẾM", 1, 1, 5, 79);
                IO.Writexy("Tên hóa đơn nhập:", 5, 4);
                Hien(1, 8, hdnhap.LayDSHD_Nhap(), 5, 0);
                tenhd = IO.ReadString(13, 4);
                List<HD_Nhap> list = hdnhap.TimHD_Nhap(new HD_Nhap(null, null, null, tenhd, null, 0, null, null, 0, 0, 0));
                Hien(1, 8, list, 5, 1);
                if (tenhd == "") break;
            } while (true);
            project_1.Program.Hien();
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
                IO.Writexy("┌─────────┬──────────┬──────────────┬────────────┬─────────────┬──────────┬─────────────────┬─────────────┬──────────┬────────────┬─────────┐", x, y + 1);
                IO.Writexy("│ Mã loại │  Mã HDN  │ Mã nhân viên │Tên hóa đơn │ Mã sản phẩm │ Số lượng │ Mã nhà cung cấp │ Đơn vị tính │ Giá nhập │ Thành tiền │   VAT   │", x, y + 2);
                IO.Writexy("├─────────┼──────────┼──────────────┼────────────┼─────────────┼──────────┼─────────────────┼─────────────┼──────────┼────────────┼─────────┤", x, y + 3);
                y = y + 4;
                for (int i = dau; i < cuoi; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].Mal, x + 1, y + d, 8);
                    IO.Writexy("│", x + 8, y + d);
                    IO.Writexy(list[i].Mhdn, x + 9, y + d, 9);
                    IO.Writexy("│", x + 17, y + d);
                    IO.Writexy(list[i].Manv, x + 18, y + d, 11);
                    IO.Writexy("│", x + 28, y + d);
                    IO.Writexy(list[i].Tenhd, x + 18, y + d, 11);
                    IO.Writexy("│", x + 28, y + d);
                    IO.Writexy(list[i].Msp, x + 18, y + d, 11);
                    IO.Writexy("│", x + 28, y + d);
                    IO.Writexy(list[i].Sl.ToString(), x + 29, y + d, 11);
                    IO.Writexy("│", x + 39, y + d);
                    IO.Writexy(list[i].Mancc, x + 18, y + d, 11);
                    IO.Writexy("│", x + 28, y + d);
                    IO.Writexy(list[i].Donvi, x + 18, y + d, 11);
                    IO.Writexy("│", x + 28, y + d);
                    IO.Writexy(list[i].Gianhap.ToString(), x + 40, y + d, 11);
                    IO.Writexy("│", x + 50, y + d);
                    IO.Writexy(list[i].Thanhtien.ToString(), x + 51, y + d, 11);
                    IO.Writexy("│", x + 61, y + d);
                    IO.Writexy(list[i].VAT.ToString(), x + 62, y + d, 7);
                    IO.Writexy("│", x + 68, y + d);
                    if (i < cuoi - 1)
                        IO.Writexy("├─────────┼──────────┼──────────────┼────────────┼─────────────┼──────────┼─────────────────┼─────────────┼──────────┼────────────┼─────────┤", x, y + d + 1);
                    y = y + 1;
                    d = d + 1;
                }
                IO.Writexy("└───────┴────────┴──────────┴──────────────┴─────────────┴────────────┴────────┴──────────┴─────────────────┴──────────┴────────────────┘", x, y + d - 1);
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
