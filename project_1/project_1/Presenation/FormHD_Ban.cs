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
                IO.BoxTitle("NHẬP THÔNG TIN HÓA ĐƠN BÁN", 1, 1, 13, 90);
                IO.Writexy("Mã hdb:", 5, 4);
                IO.Writexy("Tên NV:", 23, 4);
                IO.Writexy("Tên HDB:", 41, 4);
                IO.Writexy("Mã DV:", 5, 6);
                IO.Writexy("Mã KH:", 22, 6);
                IO.Writexy("Thành tiền:", 39, 6);
                IO.Writexy("Vat:", 61, 6);
                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 8);
                Hien(1, 15, hdban.LayDSHD_Ban(), 5, 0);
                HD_Ban hdb = new HD_Ban();
                hdb.Mhdb = int.Parse("0" + IO.ReadNumber(13, 4));
                hdb.Manv = int.Parse("0" + IO.ReadNumber(31, 4));
                hdb.Tenhd = IO.ReadString(50, 4);
                hdb.Mdv = int.Parse("0" + IO.ReadNumber(12, 6));
                hdb.Makh = int.Parse("0" + IO.ReadString(29, 6));
                hdb.Thanhtien = double.Parse("0" + IO.ReadString(51, 6));
                hdb.VAT = double.Parse("0" + IO.ReadNumber(65, 6));
                Console.SetCursorPosition(50, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.V) Hien(1, 13, hdban.LayDSHD_Ban(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter) hdban.ThemHD_Ban(hdb);
            } while (true);
        }
        public void SuaHD_Ban()
        {
            do
            {
                IHD_BanBLL hdban = new HD_BanBLL();
                Console.Clear();
                IO.BoxTitle("CẬP NHẬT THÔNG TIN HÓA ĐƠN BÁN", 1, 1, 12, 85);
                IO.Writexy("Mã hóa đơn:", 5, 4);
                IO.Writexy("Mã nhân viên nhập:", 26, 4);
                IO.Writexy("Tên hóa đơn bán:", 5, 6);
                IO.Writexy("Mã dịch vụ:", 5, 8);
                IO.Writexy("Mã khách hàng:", 25, 8);
                IO.Writexy("Thành tiền:", 50, 8);
                IO.Writexy("VAT:", 72, 8);
                IO.Writexy("----------------------------------------------------------------------------", 2, 9);
                IO.Writexy("Enter de cap nhat, Esc de thoat, V xem chi tiet!", 5, 10);
                Hien(1, 15, hdban.LayDSHD_Ban(), 5, 0);
                int mhdb;
                int manv;
                string tenhd;
                int mdv;
                int makh;
                double thanhtien;
                double vat;

                mhdb = int.Parse("0" + IO.ReadNumber(16, 4));
                HD_Ban hdb = hdban.LayHD_Ban(mhdb);
                IO.Writexy("         ", 45, 4);
                IO.Writexy("         ", 22, 6);
                IO.Writexy("    ", 20, 8);
                IO.Writexy("    ", 40, 8);
                IO.Writexy("       ", 62, 8);
                IO.Writexy("       ", 77, 8);

                mhdb = int.Parse("0" + IO.ReadNumber(16, 4));
                if (mhdb != hdb.Mhdb && mhdb != 0) hdb.Mhdb = mhdb;
                manv = int.Parse("0" + IO.ReadNumber(44, 4));
                if (manv != hdb.Manv && manv != 0) hdb.Manv = manv;
                tenhd = IO.ReadString(21, 6);
                if (tenhd != hdb.Tenhd && tenhd != null) hdb.Tenhd = tenhd;
                mdv = int.Parse("0" + IO.ReadNumber(16, 8));
                if (mdv != hdb.Mdv && mdv != 0) hdb.Mdv = mdv;
                makh = int.Parse("0" + IO.ReadNumber(40, 8));
                if (makh != hdb.Makh && makh != 0) hdb.Makh = makh;
                thanhtien = double.Parse("0" + IO.ReadNumber(62, 8));
                if (thanhtien != hdb.Thanhtien && thanhtien != 0) hdb.Thanhtien = thanhtien;
                vat = double.Parse("0" + IO.ReadNumber(77, 8));
                if (vat != hdb.VAT && vat != 0) hdb.VAT = vat;


                Console.SetCursorPosition(50, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.V) Hien(1, 15, hdban.LayDSHD_Ban(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                {
                    hdban.SuaHD_Ban(hdb);
                    Hien(1, 13, hdban.LayDSHD_Ban(), 5, 1);
                }
            } while (true);
            
        }
        public void Xoa()
        {
            int mhdb = 0;
            do
            {
                Console.Clear();
                IHD_BanBLL hdban = new HD_BanBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN ĐỐI TƯỢNG CẦN XÓA", 1, 1, 5, 79);
                IO.Writexy("Mã hóa đơn bán:", 5, 4);
                Hien(22, 20, hdban.LayDSHD_Ban(), 5, 0);
                mhdb = int.Parse("0" + IO.ReadNumber(20, 4));
                if (mhdb == 0) break;
                else hdban.XoaHD_Ban(mhdb);
                Hien(1, 8, hdban.LayDSHD_Ban(), 5, 1);
            } while (true);
           
        }
        public void Tim()
        {
            int mhdb = 0;
            do
            {
                Console.Clear();
                IHD_BanBLL hdban = new HD_BanBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN CẦN TÌM KIẾM", 1, 1, 5, 79);
                IO.Writexy("Mã hóa đơn bán:", 5, 4);
                Hien(1, 8, hdban.LayDSHD_Ban(), 5, 0);
                mhdb = int.Parse("0" + IO.ReadNumber(20, 4));
                List<HD_Ban> list = hdban.TimHD_Ban(new HD_Ban(mhdb, 0, null, 0, 0, 0, 0));
                Hien(1, 8, list, 5, 1);
                if (mhdb == 0) break;
            } while (true);
            
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
                IO.Writexy("┌───────┬────────┬─────────────────────────────┬─────────┬──────────┬────────────┬─────────┐", x, y + 1);
                IO.Writexy("│Mã HDB │  Mã NV │          Tên HDB            │  Mã DV  │  Mã KH   │ Thành tiền │   VAT   │", x, y + 2);
                IO.Writexy("├───────┼────────┼─────────────────────────────┼─────────┼──────────┼────────────┼─────────┤", x, y + 3);
                y = y + 4;
                for (int i = dau; i < cuoi; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].Mhdb.ToString(), x + 1, y + d, 8);
                    IO.Writexy("│", x + 8, y + d);
                    IO.Writexy(list[i].Manv.ToString(), x + 9, y + d, 9);
                    IO.Writexy("│", x + 17, y + d);
                    IO.Writexy(list[i].Tenhd, x + 18, y + d, 30);
                    IO.Writexy("│", x + 47, y + d);
                    IO.Writexy(list[i].Mdv.ToString(), x + 48, y + d, 9);
                    IO.Writexy("│", x + 57, y + d);
                    IO.Writexy(list[i].Makh.ToString(), x + 58, y + d, 10);
                    IO.Writexy("│", x + 68, y + d);
                    IO.Writexy(list[i].Thanhtien.ToString(), x + 69, y + d, 12);
                    IO.Writexy("|", x + 81, y + d);
                    IO.Writexy(list[i].VAT.ToString(), x + 82, y + d, 9);
                    IO.Writexy("│", x + 91, y + d);
                    if (i < cuoi - 1)
                        IO.Writexy("├───────┼────────┼─────────────────────────────┼─────────┼──────────┼────────────┼─────────┤", x, y + d + 1);
                    y = y + 1;
                    d = d + 1;
                }
                IO.Writexy("└───────┴────────┴─────────────────────────────┴─────────┴──────────┴────────────┴─────────┘", x, y + d - 1);
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
