using System;
using project_1.Utility;
using System.Text;
using project_1.Entities;
using project_1.Business;
namespace project_1.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt
    //ra trong Interface của Business
    public class FormDichVu
    {
        public void Nhap()
        {
            do
            {
                IDichVuBLL dichvu = new DichVuBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN DỊCH VỤ ", 1, 1, 10, 79);
                IO.Writexy("Mã dịch vụ:", 5, 4);
                IO.Writexy("Tên dịch vụ:", 30, 4);
                IO.Writexy("Giá:", 5, 6);
                IO.Writexy("Đơn vị:", 25, 6);
                IO.Writexy("Ngày:", 45, 6);
                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 8);
                Hien(1, 13, dichvu.LayDSDichVu(), 5, 0);
                DichVu dv = new DichVu();
                dv.Madv = int.Parse("0" + IO.ReadNumber(16, 4));
                dv.Tendv = IO.ReadString(42, 4);
                dv.Gia = double.Parse("0" + IO.ReadNumber(11, 6));
                dv.Donvi = IO.ReadString(34, 6);
                dv.Ngay = IO.ReadString(50, 6);
                Console.SetCursorPosition(50, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                
                 if (kt.Key == ConsoleKey.V) Hien(1, 13, dichvu.LayDSDichVu(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter) dichvu.ThemDichVu(dv);
            } while (true);
        }
        public void SuaDichVu()
        {
            IDichVuBLL dichvu = new DichVuBLL();
            Console.Clear();
            IO.BoxTitle("CẬP NHẬT THÔNG TIN DỊCH VỤ", 1, 1, 10, 79);
            IO.Writexy("Mã dv:", 5, 4);
            IO.Writexy("Mã loại:", 20, 4);
            IO.Writexy("Tên dịch vụ:", 45, 4);
            IO.Writexy("Giá:", 5, 6);
            IO.Writexy("Đơn vị:", 25, 6);
            IO.Writexy("Ngày:", 45, 6);
            IO.Writexy("----------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter de cap nhat, Esc de thoat, V xem chi tiet!", 5, 8);
            Hien(1, 13, dichvu.LayDSDichVu(), 5, 0);
            int madv;
            string tendv;
            double gia;
            string donvi;
            string ngay;

            madv = int.Parse("0" + IO.ReadNumber(12, 4));
            DichVu dv = dichvu.LayDichVu(madv);
            dv.Madv = int.Parse("0" + IO.ReadNumber(16, 4));
            dv.Tendv = IO.ReadString(42, 4);
            dv.Gia = double.Parse("0" + IO.ReadNumber(11, 6));
            dv.Donvi = IO.ReadString(34, 6);
            dv.Ngay = IO.ReadString(50, 6);

            madv = int.Parse("0" + IO.ReadNumber(28, 4));
            if (madv != dv.Madv && madv != 0) dv.Madv = madv;
            tendv = IO.ReadString(55, 4);
            if (tendv != dv.Tendv && tendv != null) dv.Tendv = tendv;
            gia = double.Parse("0" + IO.ReadNumber(16, 6));
            if (gia != dv.Gia && gia != 0) dv.Gia = gia;
            donvi = IO.ReadString(34, 6);
            if (donvi != dv.Donvi && donvi != null) dv.Donvi = donvi;
            ngay = IO.ReadString(55, 6);
            if (ngay != dv.Ngay && ngay != null) dv.Ngay = ngay;


            Console.SetCursorPosition(60, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
             if (kt.Key == ConsoleKey.V) Hien(1, 13, dichvu.LayDSDichVu(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                dichvu.SuaDichVu(dv);
                Hien(1, 13, dichvu.LayDSDichVu(), 5, 1);
            }
            
        }
        public void Xoa()
        {
            int madv = 0;
            do
            {
                Console.Clear();
                IDichVuBLL dichvu = new DichVuBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN ĐỐI TƯỢNG CẦN XÓA", 1, 1, 5, 79);
                IO.Writexy("Mã dịch vụ:", 5, 4);
                Hien(1, 8, dichvu.LayDSDichVu(), 5, 0);
                madv = int.Parse( IO.ReadNumber(18, 4));
                if (madv == 0) break;
                else dichvu.XoaDichVu(madv);
                Hien(1, 8, dichvu.LayDSDichVu(), 5, 1);
            } while (true);
            
        }
        public void Tim()
        {
            string tendv = "";
            do
            {
                Console.Clear();
                IDichVuBLL dichvu = new DichVuBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN CẦN TÌM KIẾM", 1, 1, 5, 79);
                IO.Writexy("Tên dịch vụ:", 5, 4);
                Hien(1, 8, dichvu.LayDSDichVu(), 5, 0);
                tendv = IO.ReadString(13, 4);
                List<DichVu> list = dichvu.TimDichVu(new DichVu(0, tendv, 0, null, null));
                Hien(1, 8, list, 5, 1);
                if (tendv == "") break;
            } while (true);
            
        }

        public void Hien(int xx, int yy, List<DichVu> list, int n, int type)
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
                IO.Writexy("                     DANH SÁCH DỊCH VỤ                        ", x, y);
                IO.Writexy("┌───────┬─────────────────┬──────────┬──────────┬──────────┐", x, y + 1);
                IO.Writexy("│ Mã dv │      Tên dv     │   Giá    │  Đơn vi  │   Ngày   │", x, y + 2);
                IO.Writexy("├───────┼─────────────────┼──────────┼──────────┼──────────┤", x, y + 3);
                y = y + 4;
                for (int i = dau; i < cuoi; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].Madv.ToString(), x + 1, y + d, 8);
                    IO.Writexy("│", x + 8, y + d);
                    IO.Writexy(list[i].Tendv, x + 9, y + d, 18);
                    IO.Writexy("│", x + 26, y + d);
                    IO.Writexy(list[i].Gia.ToString(), x + 27, y + d, 11);
                    IO.Writexy("│", x + 37, y + d);
                    IO.Writexy(list[i].Donvi.ToString(), x + 38, y + d, 11);
                    IO.Writexy("│", x + 48, y + d);
                    IO.Writexy(list[i].Ngay, x + 49, y + d, 11);
                    IO.Writexy("│", x + 59, y + d);
                    
                    if (i < cuoi - 1)
                        IO.Writexy("├───────┼─────────────────┼──────────┼──────────┼──────────┤", x, y + d + 1);
                    y = y + 1;
                    d = d + 1;
                }
                IO.Writexy("└───────┴─────────────────┴──────────┴──────────┴──────────┘", x, y + d - 1);
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
