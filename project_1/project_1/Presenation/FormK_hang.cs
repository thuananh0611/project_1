using System;
using project_1.Utility;
using System.Text;
using project_1.Entities;
using project_1.Business;
namespace project_1.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt
    //ra trong Interface của Business
    public class FormK_Hang
    {
        public void Nhap()
        {
            do
            {
                IK_HangBLL khachhang = new K_HangBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN KHÁCH HÀNG", 1, 1, 10, 79);
                IO.Writexy("Mã khách hàng:", 5, 4);
                IO.Writexy("Họ tên:", 30, 4);
                IO.Writexy("Địa chỉ:", 5, 6);
                IO.Writexy("Ngày sinh:", 25, 6);
                IO.Writexy("Số điện thoại:", 45, 6);
                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 8);
                Hien(1, 13, khachhang.LayDSK_Hang(), 5, 0);
                K_Hang kh = new K_Hang();
                kh.Makh = int.Parse("0" + IO.ReadNumber(13, 4));
                kh.Hoten = IO.ReadString(40, 4);
                kh.Diachi = IO.ReadString(16, 6);
                kh.Ngaysinh = DateTime.Parse("0" + IO.ReadNumber(34, 6));
                kh.Sdt = IO.ReadString(55, 6);
                Console.SetCursorPosition(50, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) project_1.Program.Hien();
                else if (kt.Key == ConsoleKey.V) Hien(1, 13, khachhang.LayDSK_Hang(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter) khachhang.ThemK_Hang(kh);
            } while (true);
        }
        public void SuaK_Hang()
        {
            IK_HangBLL khachhang = new K_HangBLL();
            Console.Clear();
            IO.BoxTitle("CẬP NHẬT THÔNG TIN KHÁCH HÀNG ", 1, 1, 10, 79);
            IO.Writexy("Mã khách hàng:", 5, 4);
            IO.Writexy("Họ tên:", 20, 4);
            IO.Writexy("Địa chỉ:", 45, 4);
            IO.Writexy("Ngày sinh:", 5, 6);
            IO.Writexy("Số điện thoại:", 25, 6);
            IO.Writexy("----------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter de cap nhat, Esc de thoat, V xem chi tiet!", 5, 8);
            Hien(1, 13, khachhang.LayDSK_Hang(), 5, 0);
            int makh;
            string hoten;
            string diachi;
            DateTime ngaysinh;
            string sdt;

            makh = int.Parse(IO.ReadNumber(12, 4));
            K_Hang kh = khachhang.LayK_Hang(makh);
            IO.Writexy(kh.Hoten, 28, 4);
            IO.Writexy(kh.Diachi, 55, 4);
            IO.Writexy(kh.Ngaysinh.ToString(), 16, 6);
            IO.Writexy(kh.Sdt.ToString(), 34, 6);
            
            hoten = IO.ReadString(28, 4);
            if (hoten != kh.Hoten && hoten != null) kh.Hoten = hoten;
            diachi = IO.ReadString(55, 4);
            if (diachi != kh.Diachi && diachi != null) kh.Diachi = diachi;
            ngaysinh = DateTime.Parse("0" + IO.ReadNumber(16, 6));
            if (ngaysinh != kh.Ngaysinh && ngaysinh != null) kh.Ngaysinh = ngaysinh;
            sdt = IO.ReadString(34, 6);
            if (sdt != kh.Sdt && sdt != null) kh.Sdt = sdt;


            Console.SetCursorPosition(60, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape) project_1.Program.Hien();
            else if (kt.Key == ConsoleKey.V) Hien(1, 13, khachhang.LayDSK_Hang(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                khachhang.SuaK_Hang(kh);
                Hien(1, 13, khachhang.LayDSK_Hang(), 5, 1);
            }
            project_1.Program.Hien();
        }

      

        public void Xoa()
        {
            int makh = 0;
            do
            {
                Console.Clear();
                IK_HangBLL khachhang = new K_HangBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN ĐỐI TƯỢNG CẦN XÓA", 1, 1, 5, 79);
                IO.Writexy("Mã khách hàng:", 5, 4);
                Hien(1, 8, khachhang.LayDSK_Hang(), 5, 0);
                makh = int.Parse(IO.ReadNumber(18, 4));
                if (makh == 0) break;
                else khachhang.XoaK_Hang(makh);
                Hien(1, 8, khachhang.LayDSK_Hang(), 5, 1);
            } while (true);
            project_1.Program.Hien();
        }
        public void Tim()
        {
            string hoten = "";
            do
            {
                Console.Clear();
                IK_HangBLL khachhang = new K_HangBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN CẦN TÌM KIẾM", 1, 1, 5, 79);
                IO.Writexy("Ho ten:", 5, 4);
                Hien(1, 8, khachhang.LayDSK_Hang(), 5, 0);
                hoten = IO.ReadString(13, 4);
                List<K_Hang> list = khachhang.TimK_Hang(new K_Hang(0, hoten, null, DateTime.Parse(null), null));
                Hien(1, 8, list, 5, 1);
                if (hoten == "") break;
            } while (true);
            project_1.Program.Hien();
        }
       
        public void Hien(int xx, int yy, List<K_Hang> list, int n, int type)
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
                IO.Writexy("                DANH SÁCH KHÁCH HÀNG               ", x, y);
                IO.Writexy("┌───────┬────────┬──────────┬──────────┬──────────┐", x, y + 1);
                IO.Writexy("│ Ma KH │ Họ tên │ Địa chỉ  │Ngày sinh │  Số ĐT   │", x, y + 2);
                IO.Writexy("├───────┼────────┼──────────┼──────────┼──────────┤", x, y + 3);
                y = y + 4;
                for (int i = dau; i < cuoi; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].Makh.ToString(), x + 1, y + d, 8);
                    IO.Writexy("│", x + 8, y + d);
                    IO.Writexy(list[i].Hoten, x + 9, y + d, 9);
                    IO.Writexy("│", x + 17, y + d);
                    IO.Writexy(list[i].Diachi, x + 18, y + d, 11);
                    IO.Writexy("│", x + 28, y + d);
                    IO.Writexy(list[i].Ngaysinh.ToString(), x + 29, y + d, 11);
                    IO.Writexy("│", x + 39, y + d);
                    IO.Writexy(list[i].Sdt.ToString(), x + 40, y + d, 11);
                    IO.Writexy("│", x + 50, y + d);
                    IO.Writexy("│", x + 68, y + d);
                    if (i < cuoi - 1)
                        IO.Writexy("├───────┼────────┼──────────┼──────────┼──────────┤", x, y + d + 1);
                    y = y + 1;
                    d = d + 1;
                }
                IO.Writexy("└───────┴────────┴──────────┴──────────┴──────────┘", x, y + d - 1);
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
