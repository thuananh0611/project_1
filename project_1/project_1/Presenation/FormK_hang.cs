﻿using System;
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
                K_HangBLL khBLL = new K_HangBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN KHÁCH HÀNG", 1, 1, 10, 79);
                IO.Writexy("Mã khách hàng:", 5, 4);
                IO.Writexy("Họ tên:", 30, 4);
                IO.Writexy("Địa chỉ:", 5, 6);
                IO.Writexy("Ngày sinh:", 25, 6);
                IO.Writexy("Số điện thoại:", 48, 6);
                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 8);
                Hien(1, 13, khachhang.LayDSK_Hang(), 5, 0);
                K_Hang kh = new K_Hang();
                do
                {
                    kh.Makh = int.Parse("0" + IO.ReadNumber(20, 4));
                    if (khBLL.KT_MaKH(kh.Makh) == true)
                    {
                        IO.Clear(20, 4, 5, ConsoleColor.Black);
                        IO.Clear(5, 9, 60, ConsoleColor.Black);
                        IO.Writexy("Mã khách hàng đã tổn tại. Mời nhập mã khác.", 5, 9);
                    }
                    else if (kh.Makh <= 0)
                    {
                        IO.Clear(20, 4, 5, ConsoleColor.Black);
                        IO.Writexy("Mã khách hàng không phù hợp. Mời nhập mã khác!", 5, 9);
                    }
                    else
                    {
                        kh.Makh = kh.Makh;
                        IO.Writexy("Mã khách hàng đã được thêm mới!", 5, 9);
                    }

                } while (kh.Makh <= 0 || khBLL.KT_MaKH(kh.Makh) == true);

                kh.Makh = int.Parse("0" + IO.ReadNumber(20, 4));
                kh.Hoten = IO.ReadString(38, 4);
                kh.Diachi = IO.ReadString(13, 6);
                kh.Ngaysinh = IO.ReadString(35, 6);
                kh.Sdt = IO.ReadString(62, 6);
                Console.SetCursorPosition(50, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.V) Hien(1, 13, khachhang.LayDSK_Hang(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter) khachhang.ThemK_Hang(kh);
            } while (true);
        }
        public void SuaK_Hang()
        {
            do
            {
                IK_HangBLL khachhang = new K_HangBLL();
                Console.Clear();
                IO.BoxTitle("CẬP NHẬT THÔNG TIN KHÁCH HÀNG ", 1, 1, 10, 79);
                IO.Writexy("Mã khách hàng:", 5, 4);
                IO.Writexy("Họ tên:", 30, 4);
                IO.Writexy("Địa chỉ:", 5, 6);
                IO.Writexy("Ngày sinh:", 25, 6);
                IO.Writexy("Số điện thoại:", 48, 6);
                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter de cap nhat, Esc de thoat, V xem chi tiet!", 5, 8);
                Hien(1, 13, khachhang.LayDSK_Hang(), 5, 0);
                int makh;
                string hoten;
                string diachi;
                string ngaysinh;
                string sdt;

                makh = int.Parse(IO.ReadNumber(20, 4));
                K_Hang kh = khachhang.LayK_Hang(makh);
                IO.Writexy("      ", 38, 4);
                IO.Writexy("      ", 14, 6);
                IO.Writexy("      ", 36, 6);
                IO.Writexy("      ", 62, 6);
                
                hoten = IO.ReadString(38, 4);
                if (hoten != kh.Hoten && hoten != null) kh.Hoten = hoten;
                diachi = IO.ReadString(14, 6);
                if (diachi != kh.Diachi && diachi != null) kh.Diachi = diachi;
                ngaysinh = IO.ReadString(36, 6);
                if (ngaysinh != kh.Ngaysinh && ngaysinh != null) kh.Ngaysinh = ngaysinh;
                sdt = IO.ReadString(62, 6);
                if (sdt != kh.Sdt && sdt != null) kh.Sdt = sdt;


                Console.SetCursorPosition(60, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.V) Hien(1, 13, khachhang.LayDSK_Hang(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                {
                    khachhang.SuaK_Hang(kh);
                    Hien(1, 13, khachhang.LayDSK_Hang(), 5, 1);
                }
            } while (true);
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
                makh = int.Parse(IO.ReadNumber(20, 4));
                if (makh == 0) break;
                else khachhang.XoaK_Hang(makh);
                Hien(1, 8, khachhang.LayDSK_Hang(), 5, 1);
            } while (true);
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
                List<K_Hang> list = khachhang.TimK_Hang(new K_Hang(0, hoten, null, null, null));
                Hien(1, 8, list, 5, 1);
                if (hoten == "") break;
            } while (true);
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
                    IO.Writexy("|", x, y + d, 8);
                    IO.Writexy(list[i].Makh.ToString(), x + 1, y + d, 6);
                    IO.Writexy("|", x + 8, y + d);
                    IO.Writexy(list[i].Hoten, x + 9, y + d, 7);
                    IO.Writexy("|", x + 17, y + d);
                    IO.Writexy(list[i].Diachi, x + 18, y + d, 9);
                    IO.Writexy("|", x + 28, y + d);
                    IO.Writexy(list[i].Ngaysinh.ToString(), x + 29, y + d, 9);
                    IO.Writexy("|", x + 39, y + d);
                    IO.Writexy(list[i].Sdt.ToString(), x + 40, y + d, 9);
                    IO.Writexy("|", x + 50, y + d);
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