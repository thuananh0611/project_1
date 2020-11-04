using System;
using project_1.Utility;
using System.Text;
using project_1.Entities;
using project_1.Business;
namespace project_1.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt
    //ra trong Interface của Business
    public class FormHD_Ban
    {
        public void Nhap()
        {
            do
            {
                IHD_BanBLL hdban = new HD_BanBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN HÓA ĐƠN BÁN", 1, 1, 10, 79);
                IO.Writexy("Mã loại hóa đơn:", 5, 4);
                IO.Writexy("Mã nhân viên nhập:", 30, 4);
                IO.Writexy("Tên hóa đơn bán:", 5, 6);
                IO.Writexy("Mã sản phẩm:", 25, 6);
                IO.Writexy("Mã dịch vụ:", 45, 6);
                IO.Writexy("Mã khách hàng:", 45, 6);
                IO.Writexy("Thành tiền:", 45, 6);
                IO.Writexy("VAT:", 45, 6);
                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 8);
                Hien(1, 13, hdban.LayDSHD_Ban(), 5, 0);
                HD_Ban hdb = new HD_Ban();
                hdb.Mal = IO.ReadString(13, 4);
                hdb.Mhdb = IO.ReadString(40, 4);
                hdb.Manv = IO.ReadString(16, 6);
                hdb.Tenhd = IO.ReadString(34, 6);
                hdb.Msp =  IO.ReadNumber(55, 6);
                hdb.Mdv = IO.ReadString(13, 4);
                hdb.Makh = IO.ReadString(13, 4);
                hdb.Thanhtien = double.Parse("0" + IO.ReadNumber(13, 4));
                Console.SetCursorPosition(50, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) project_1.Program.Hien();
                else if (kt.Key == ConsoleKey.V) Hien(1, 13, hdban.LayDSHD_Ban(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter) hdban.ThemHD_Ban(hdb);
            } while (true);
        }
        public void SuaHD_Ban()
        {
            IHD_BanBLL hdban = new HD_BanBLL();
            Console.Clear();
            IO.BoxTitle("CẬP NHẬT THÔNG TIN HÓA ĐƠN BÁN", 1, 1, 10, 79);
            IO.Writexy("Mã loại hóa đơn:", 5, 4);
            IO.Writexy("Mã hóa đơn bán:", 20, 4);
            IO.Writexy("Mã nhân viên:", 45, 4);
            IO.Writexy("Tên hóa đơn bán:", 5, 6);
            IO.Writexy("Mã sản phẩm:", 25, 6);
            IO.Writexy("Mã dịch vụ:", 45, 6);
            IO.Writexy("Mã khách hàng:", 45, 6);
            IO.Writexy("Thành tiền:", 45, 6);
            IO.Writexy("VAT:", 45, 6);
            IO.Writexy("----------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter de cap nhat, Esc de thoat, V xem chi tiet!", 5, 8);
            Hien(1, 13, hdban.LayDSHD_Ban(), 5, 0);
            string mal;
            string mhdb;
            string manv;
            string tenhd;
            string msp;
            string mdv;
            string makh;
            double thanhtien;
            double vat;

            mhdb = IO.ReadString(12, 4);
            HD_Ban hdb = hdban.LayHD_Ban(mhdb);
            IO.Writexy(hdb.Mal, 28, 4);
            IO.Writexy(hdb.Manv, 55, 4);
            IO.Writexy(hdb.Tenhd, 16, 6);
            IO.Writexy(hdb.Msp, 34, 6);
            IO.Writexy(hdb.Mdv, 34, 6);
            IO.Writexy(hdb.Makh, 34, 6);
            IO.Writexy(hdb.Thanhtien.ToString(), 55, 6);
            IO.Writexy(hdb.VAT.ToString(), 55, 6);

            mal = IO.ReadString(28, 4);
            if (mal != hdb.Mal && mal != null) hdb.Mal = mal;
            manv = IO.ReadString(28, 4);
            if (manv != hdb.Manv && manv != null) hdb.Manv = manv;
            tenhd = IO.ReadString(28, 4);
            if (tenhd != hdb.Tenhd && tenhd != null) hdb.Tenhd = tenhd;
            msp = IO.ReadString(28, 4);
            if (msp != hdb.Msp && msp != null) hdb.Msp = msp;
            mdv = IO.ReadString(28, 4);
            if (mdv != hdb.Mdv && mdv != null) hdb.Mdv = mdv;
            makh = IO.ReadString(28, 4);
            if (makh != hdb.Makh && makh != null) hdb.Makh = makh;
            thanhtien = double.Parse("0" + IO.ReadNumber(16, 6));
            if (thanhtien != hdb.Thanhtien && thanhtien != 0) hdb.Thanhtien = thanhtien;
            vat = double.Parse("0" + IO.ReadNumber(34, 6));
            if (vat != hdb.VAT && vat != 0) hdb.VAT = vat;


            Console.SetCursorPosition(60, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape) project_1.Program.Hien();
            else if (kt.Key == ConsoleKey.V) Hien(1, 13, hdban.LayDSHD_Ban(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                hdban.SuaHD_Ban(hdb);
                Hien(1, 13, hdban.LayDSHD_Ban(), 5, 1);
            }
            project_1.Program.Hien();
        }
        public void Xoa()
        {
            string mhdb = "";
            do
            {
                Console.Clear();
                IHD_BanBLL hdban = new HD_BanBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN ĐỐI TƯỢNG CẦN XÓA", 1, 1, 5, 79);
                IO.Writexy("Mã hóa đơn bán:", 5, 4);
                Hien(1, 8, hdban.LayDSHD_Ban(), 5, 0);
                mhdb = IO.ReadString(18, 4);
                if (mhdb == null) break;
                else hdban.XoaHD_Ban(mhdb);
                Hien(1, 8, hdban.LayDSHD_Ban(), 5, 1);
            } while (true);
            project_1.Program.Hien();
        }
        public void Tim()
        {
            string mhdb = "";
            do
            {
                Console.Clear();
                IHD_BanBLL hdban = new HD_BanBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN CẦN TÌM KIẾM", 1, 1, 5, 79);
                IO.Writexy("Mã hóa đơn bán:", 5, 4);
                Hien(1, 8, hdban.LayDSHD_Ban(), 5, 0);
                mhdb = IO.ReadString(13, 4);
                List<HD_Ban> list = hdban.TimHD_Ban(new HD_Ban(null, mhdb, null, null, null, null, null, 0, 0));
                Hien(1, 8, list, 5, 1);
                if (mhdb == "") break;
            } while (true);
            project_1.Program.Hien();
        }
        
        public void Hien(int xx, int yy, List<HD_Ban> list, int n, int type)
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
                IO.Writexy("                                  DANH SÁCH HÓA ĐƠN BÁN                                        ", x, y);
                IO.Writexy("┌───────┬────────┬──────────┬──────────┬──────────┬──────────┬─────────┬────────────┬─────────┐", x, y + 1);
                IO.Writexy("│Mã loại│ Mã HDB │  Mã NV   │ Tên HDB  │  Mã SP   │   Mã DV  │ Mã KH   │ Thành tiền │   VAT   │", x, y + 2);
                IO.Writexy("├───────┼────────┼──────────┼──────────┼──────────┼──────────┼─────────┼────────────┼─────────┤", x, y + 3);
                y = y + 4;
                for (int i = dau; i < cuoi; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].Mal.ToString(), x + 1, y + d, 8);
                    IO.Writexy("│", x + 8, y + d);
                    IO.Writexy(list[i].Mhdb, x + 9, y + d, 9);
                    IO.Writexy("│", x + 17, y + d);
                    IO.Writexy(list[i].Manv, x + 18, y + d, 11);
                    IO.Writexy("│", x + 28, y + d);
                    IO.Writexy(list[i].Tenhd, x + 29, y + d, 11);
                    IO.Writexy("│", x + 39, y + d);
                    IO.Writexy(list[i].Msp, x + 40, y + d, 11);
                    IO.Writexy("│", x + 50, y + d);
                    IO.Writexy(list[i].Mdv, x + 51, y + d, 11);
                    IO.Writexy("│", x + 61, y + d);
                    IO.Writexy(list[i].Makh, x + 62, y + d, 7);
                    IO.Writexy(list[i].Thanhtien.ToString(), x + 51, y + d, 11);
                    IO.Writexy("│", x + 61, y + d);
                    IO.Writexy(list[i].VAT.ToString(), x + 51, y + d, 11);
                    IO.Writexy("│", x + 61, y + d);
                    IO.Writexy("│", x + 68, y + d);
                    if (i < cuoi - 1)
                        IO.Writexy("├───────┼────────┼──────────┼──────────┼──────────┼──────────┼─────────┼────────────┼─────────┤", x, y + d + 1);
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

    }
}
