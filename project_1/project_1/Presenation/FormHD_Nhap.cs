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
                hs.QueQuan = IO.ReadString(40, 4);
                hs.DToan = double.Parse("0" + IO.ReadNumber(16, 6));
                hs.DLy = double.Parse("0" + IO.ReadNumber(34, 6));
                hs.DHoa = double.Parse("0" + IO.ReadNumber(55, 6));
                Console.SetCursorPosition(50, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) Demo.Program.Hien();
                else if (kt.Key == ConsoleKey.V) Hien(1, 13, hocsinh.LayDSHocSinh(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter) hocsinh.ThemHocSinh(hs);
            } while (true);
        }
        public void SuaHocSinh()
        {
            IHocSinhBLL hocsinh = new HocSinhBLL();
            Console.Clear();
            IO.BoxTitle("CẠP NHAT THONG TIN HOC SINH ", 1, 1, 10, 79);
            IO.Writexy("Ma hs:", 5, 4);
            IO.Writexy("Ho ten:", 20, 4);
            IO.Writexy("Que quan:", 45, 4);
            IO.Writexy("Diem toan:", 5, 6);
            IO.Writexy("Diem ly:", 25, 6);
            IO.Writexy("Diem hoa:", 45, 6);
            IO.Writexy("----------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter de cap nhat, Esc de thoat, V xem chi tiet!", 5, 8);
            Hien(1, 13, hocsinh.LayDSHocSinh(), 5, 0);
            int mahs;
            string hoten;
            string quequan;
            double dtoan;
            double dly;
            double dhoa;

            mahs = int.Parse(IO.ReadNumber(12, 4));
            HocSinh hs = hocsinh.LayHocSinh(mahs);
            IO.Writexy(hs.Hoten, 28, 4);
            IO.Writexy(hs.QueQuan, 55, 4);
            IO.Writexy(hs.DToan.ToString(), 16, 6);
            IO.Writexy(hs.DLy.ToString(), 34, 6);
            IO.Writexy(hs.DHoa.ToString(), 55, 6);

            hoten = IO.ReadString(28, 4);
            if (hoten != hs.Hoten && hoten != null) hs.Hoten = hoten;
            quequan = IO.ReadString(55, 4);
            if (quequan != hs.QueQuan && quequan != null) hs.QueQuan = quequan;
            dtoan = double.Parse("0" + IO.ReadNumber(16, 6));
            if (dtoan != hs.DToan && dtoan != 0) hs.DToan = dtoan;
            dly = double.Parse("0" + IO.ReadNumber(34, 6));
            if (dly != hs.DLy && dly != 0) hs.DLy = dly;
            dhoa = double.Parse("0" + IO.ReadNumber(55, 6));
            if (dhoa != hs.DHoa && dhoa != 0) hs.DHoa = dhoa;


            Console.SetCursorPosition(60, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape) Demo.Program.Hien();
            else if (kt.Key == ConsoleKey.V) Hien(1, 13, hocsinh.LayDSHocSinh(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                hocsinh.SuaHocSinh(hs);
                Hien(1, 13, hocsinh.LayDSHocSinh(), 5, 1);
            }
            Demo.Program.Hien();
        }
        public void Xoa()
        {
            int mahs = 0;
            do
            {
                Console.Clear();
                IHocSinhBLL hocsinh = new HocSinhBLL();
                Console.Clear();
                IO.BoxTitle("NHAP THONG TIN DOI TUONG CAN XOA ", 1, 1, 5, 79);
                IO.Writexy("Ma hoc sinh:", 5, 4);
                Hien(1, 8, hocsinh.LayDSHocSinh(), 5, 0);
                mahs = int.Parse(IO.ReadNumber(18, 4));
                if (mahs == 0) break;
                else hocsinh.XoaHocSinh(mahs);
                Hien(1, 8, hocsinh.LayDSHocSinh(), 5, 1);
            } while (true);
            Demo.Program.Hien();
        }
        public void Tim()
        {
            string hoten = "";
            do
            {
                Console.Clear();
                IHocSinhBLL hocsinh = new HocSinhBLL();
                Console.Clear();
                IO.BoxTitle("NHAP THONG TIN CAN TIM KIEM ", 1, 1, 5, 79);
                IO.Writexy("Ho ten:", 5, 4);
                Hien(1, 8, hocsinh.LayDSHocSinh(), 5, 0);
                hoten = IO.ReadString(13, 4);
                List<HocSinh> list = hocsinh.TimHocSinh(new HocSinh(0, hoten, null, 0, 0, 0));
                Hien(1, 8, list, 5, 1);
                if (hoten == "") break;
            } while (true);
            Demo.Program.Hien();
        }
        public void Hien20()
        {
            IHocSinhBLL hocsinh = new HocSinhBLL();
            Console.Clear();
            Hien(1, 1, hocsinh.LayDSHocSinh(), 5, 1);
            Demo.Program.Hien();
        }
        public void Hien(int xx, int yy, List<HocSinh> list, int n, int type)
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
                IO.Writexy("                     DANH SACH HOC SINH                              ", x, y);
                IO.Writexy("┌───────┬────────┬──────────┬──────────┬──────────┬──────────┬──────┐", x, y + 1);
                IO.Writexy("│ Ma HS │ Ho ten │ Que quan │Diem toan │ Diem ly  │ Diem hoa │ Tong │", x, y + 2);
                IO.Writexy("├───────┼────────┼──────────┼──────────┼──────────┼──────────┼──────┤", x, y + 3);
                y = y + 4;
                for (int i = dau; i < cuoi; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].MaHs.ToString(), x + 1, y + d, 8);
                    IO.Writexy("│", x + 8, y + d);
                    IO.Writexy(list[i].Hoten, x + 9, y + d, 9);
                    IO.Writexy("│", x + 17, y + d);
                    IO.Writexy(list[i].QueQuan, x + 18, y + d, 11);
                    IO.Writexy("│", x + 28, y + d);
                    IO.Writexy(list[i].DToan.ToString(), x + 29, y + d, 11);
                    IO.Writexy("│", x + 39, y + d);
                    IO.Writexy(list[i].DLy.ToString(), x + 40, y + d, 11);
                    IO.Writexy("│", x + 50, y + d);
                    IO.Writexy(list[i].DHoa.ToString(), x + 51, y + d, 11);
                    IO.Writexy("│", x + 61, y + d);
                    IO.Writexy(list[i].DTong.ToString(), x + 62, y + d, 7);
                    IO.Writexy("│", x + 68, y + d);
                    if (i < cuoi - 1)
                        IO.Writexy("├───────┼────────┼──────────┼──────────┼──────────┼──────────┼──────┤", x, y + d + 1);
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
