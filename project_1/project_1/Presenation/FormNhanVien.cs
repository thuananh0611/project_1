using System;
using project_1.Utility;
using System.Text;
using project_1.Entities;
using project_1.Business;
namespace project_1.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt
    //ra trong Interface của Business
    public class FormNhanVien
    {
        public void Nhap()
        {
            do
            {
                INhanVienBLL nhanvien = new NhanVienBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN NHÂN VIÊN", 1, 1, 10, 79);
                IO.Writexy("Mã nhân viên:", 5, 4);
                IO.Writexy("Họ tên:", 30, 4);
                IO.Writexy("Địa chỉ:", 5, 6);
                IO.Writexy("Số điện thoại:", 25, 6);
                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 8);
                Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 0);
                NhanVien nv = new NhanVien();
                nv.Mnv = int.Parse("0" + IO.ReadNumber(20, 4));
                nv.Tennv = IO.ReadString(38, 4);
                nv.Diachi = IO.ReadString(13, 6);
                nv.Sdt = IO.ReadString(35, 6);
                Console.SetCursorPosition(50, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.V) Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter) nhanvien.ThemNhanVien(nv);
            } while (true);
        }
        public void SuaNhanVien()
        {
            INhanVienBLL nhanvien = new NhanVienBLL();
            Console.Clear();
            IO.BoxTitle("CẬP NHẬT THÔNG TIN NHÂN VIÊN ", 1, 1, 10, 79);
            IO.Writexy("Mã nhân viên:", 5, 4);
            IO.Writexy("Họ tên:", 30, 4);
            IO.Writexy("Địa chỉ:", 5, 6);
            IO.Writexy("Số điện thoại:", 25, 6);
            IO.Writexy("----------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter de cap nhat, Esc de thoat, V xem chi tiet!", 5, 8);
            Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 0);
            int manv;
            string tennv;
            string diachi;
            string sdt;

            manv = int.Parse(IO.ReadNumber(12, 4));
            NhanVien nv = nhanvien.LayNhanVien(manv);
            IO.Writexy(nv.Tennv, 28, 4);
            IO.Writexy(nv.Diachi, 55, 4);
            IO.Writexy(nv.Sdt, 16, 6);

            tennv = IO.ReadString(28, 4);
            if (tennv != nv.Tennv && tennv != null) nv.Tennv = tennv;
            diachi = IO.ReadString(55, 4);
            if (diachi != nv.Diachi && diachi != null) nv.Diachi = diachi;
            sdt = IO.ReadString(16, 6);
            if (sdt != nv.Sdt && sdt != null) nv.Sdt = sdt;

            Console.SetCursorPosition(60, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.V) Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                nhanvien.SuaNhanVien(nv);
                Hien(1, 13, nhanvien.LayDSNhanVien(), 5, 1);
            }
        }



        public void Xoa()
        {
            int manv = 0;
            do
            {
                Console.Clear();
                INhanVienBLL nhanvien = new NhanVienBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN ĐỐI TƯỢNG CẦN XÓA", 1, 1, 5, 79);
                IO.Writexy("Mã nhân viên:", 5, 4);
                Hien(1, 8, nhanvien.LayDSNhanVien(), 5, 0);
                manv = int.Parse(IO.ReadNumber(14, 4));
                if (manv == 0) break;
                else nhanvien.XoaNhanVien(manv);
                Hien(1, 8, nhanvien.LayDSNhanVien(), 5, 1);
            } while (true);
        }
        public void Tim()
        {
            string hoten = "";
            do
            {
                Console.Clear();
                INhanVienBLL nhanvien = new NhanVienBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN CẦN TÌM KIẾM", 1, 1, 5, 79);
                IO.Writexy("Họ tên nhân viên:", 5, 4);
                Hien(1, 8, nhanvien.LayDSNhanVien(), 5, 0);
                hoten = IO.ReadString(22, 4);
                List<NhanVien> list = nhanvien.TimNhanVien(new NhanVien(0, hoten, null, null));
                Hien(1, 8, list, 5, 1);
                if (hoten == "") break;
            } while (true);
        }

        public void Hien(int xx, int yy, List<NhanVien> list, int n, int type)
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
                IO.Writexy("                DANH SÁCH NHÂN VIÊN               ", x, y);
                IO.Writexy("┌───────┬───────────────┬──────────┬───────────┐", x, y + 1);
                IO.Writexy("│ Mã NV │     Họ tên    │ Địa chỉ  │  Số ĐT    │", x, y + 2);
                IO.Writexy("├───────┼───────────────┼──────────┼───────────┤", x, y + 3);
                y = y + 4;
                for (int i = dau; i < cuoi; i++)
                {
                    IO.Writexy("|", x, y + d, 8);
                    IO.Writexy(list[i].Mnv.ToString(), x + 1, y + d, 8);
                    IO.Writexy("|", x + 8, y + d);
                    IO.Writexy(list[i].Tennv, x + 10, y + d, 15);
                    IO.Writexy("|", x + 24, y + d);
                    IO.Writexy(list[i].Diachi, x + 26, y + d, 10);
                    IO.Writexy("|", x + 35, y + d);
                    IO.Writexy(list[i].Sdt, x + 37, y + d, 10);
                    IO.Writexy("|", x + 47, y + d);
                    if (i < cuoi - 1)
                        IO.Writexy("├───────┼───────────────┼──────────┼───────────┤", x, y + d + 1);
                    y = y + 1;
                    d = d + 1;
                }
                IO.Writexy("└───────┴───────────────┴──────────┴───────────┘", x, y + d - 1);
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