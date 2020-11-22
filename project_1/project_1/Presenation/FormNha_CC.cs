﻿using System;
using project_1.Utility;
using System.Text;
using project_1.Entities;
using project_1.Business;
namespace project_1.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt
    //ra trong Interface của Business
    public class FormNha_CC
    {
        public void Nhap()
        {
            do
            {
                INha_CCBLL nccap = new Nha_CCBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN NHÀ CUNG CẤP", 1, 1, 10, 79);
                IO.Writexy("Mã nhà cung cấp:", 5, 4);
                IO.Writexy("Tên nhà cung cấp:", 30, 4);
                IO.Writexy("Địa chỉ nhà cung cấp:", 5, 6);
                IO.Writexy("Số điện thoại:", 25, 6);
                
                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 8);
                Hien(1, 13, nccap.LayDSNha_CC(), 5, 0);
                Nha_CC ncc = new Nha_CC();
                ncc.Mancc = IO.ReadString(13, 4);
                ncc.Tenncc = IO.ReadString(40, 4);
                ncc.Diachi = IO.ReadString(16, 6);
                ncc.Sdt = IO.ReadString(34, 6);
                
                Console.SetCursorPosition(50, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) project_1.Program.Hien();
                else if (kt.Key == ConsoleKey.V) Hien(1, 13, nccap.LayDSNha_CC(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter) nccap.ThemNha_CC(ncc);
            } while (true);
        }
        public void SuaNha_CC()
        {
            INha_CCBLL nccap = new Nha_CCBLL();
            Console.Clear();
            IO.BoxTitle("CẬP NHẬT THÔNG TIN NHÀ CUNG CẤP", 1, 1, 10, 79);
            IO.Writexy("Mã nhà cung cấp:", 5, 4);
            IO.Writexy("Tên nhà cung cấp:", 20, 4);
            IO.Writexy("Địa chỉ:", 45, 4);
            IO.Writexy("Số điện thoại:", 5, 6);
            
            
            IO.Writexy("----------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter de cap nhat, Esc de thoat, V xem chi tiet!", 5, 8);
            Hien(1, 13, nccap.LayDSNha_CC(), 5, 0);
            string mancc;
            string tenncc;
            string diachi;
            string sdt;

            mancc = IO.ReadString(12, 4);
            Nha_CC ncc = nccap.LayNha_CC(mancc);
            IO.Writexy(ncc.Tenncc, 28, 4);
            IO.Writexy(ncc.Diachi, 55, 4);
            IO.Writexy(ncc.Sdt, 16, 6);
            

            tenncc = IO.ReadString(28, 4);
            if (tenncc != ncc.Tenncc && tenncc != null) ncc.Tenncc = tenncc;
            diachi = IO.ReadString(55, 4);
            if (diachi != ncc.Diachi && diachi != null) ncc.Diachi = diachi;
            sdt = IO.ReadString(16, 6);
            if (sdt != ncc.Sdt && sdt != null) ncc.Sdt= sdt;
            


            Console.SetCursorPosition(60, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape) project_1.Program.Hien();
            else if (kt.Key == ConsoleKey.V) Hien(1, 13, nccap.LayDSNha_CC(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                nccap.SuaNha_CC(ncc);
                Hien(1, 13, nccap.LayDSNha_CC(), 5, 1);
            }
            project_1.Program.Hien();
        }
        public void Xoa()
        {
            string mancc = "";
            do
            {
                Console.Clear();
                INha_CCBLL nccap = new Nha_CCBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN ĐỐI TƯỢNG CẦN XÓA", 1, 1, 5, 79);
                IO.Writexy("Mã nhà cung cấp:", 5, 4);
                Hien(1, 8, nccap.LayDSNha_CC(), 5, 0);
                mancc = IO.ReadString(18, 4);
                if (mancc == null) break;
                else nccap.XoaNha_CC(mancc);
                Hien(1, 8, nccap.LayDSNha_CC(), 5, 1);
            } while (true);
            project_1.Program.Hien();
        }
        public void Tim()
        {
            string tenncc = "";
            do
            {
                Console.Clear();
                INha_CCBLL nccap = new Nha_CCBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN CẦN TÌM KIẾM", 1, 1, 5, 79);
                IO.Writexy("Tên nhà cung cấp: ", 5, 4);
                Hien(1, 8, nccap.LayDSNha_CC(), 5, 0);
                tenncc = IO.ReadString(13, 4);
                List<Nha_CC> list = nccap.TimNha_CC(new Nha_CC(null, tenncc, null, null));
                Hien(1, 8, list, 5, 1);
                if (tenncc == "") break;
            } while (true);
            project_1.Program.Hien();
        }
        
        public void Hien(int xx, int yy, List<Nha_CC> list, int n, int type)
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
                IO.Writexy("                     DANH SÁCH NHÀ CUNG CẤP                              ", x, y);
                IO.Writexy("┌─────────────────┬──────────────────┬─────────┬───────────────┐", x, y + 1);
                IO.Writexy("│ Mã nhà cung cấp │ Tên nhà cung cấp │ Địa chỉ │ Số điện thoại │", x, y + 2);
                IO.Writexy("├─────────────────┼──────────────────┼─────────┼───────────────┤", x, y + 3);
                y = y + 4;
                for (int i = dau; i < cuoi; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].Mancc, x + 1, y + d, 8);
                    IO.Writexy("│", x + 8, y + d);
                    IO.Writexy(list[i].Tenncc, x + 9, y + d, 9);
                    IO.Writexy("│", x + 17, y + d);
                    IO.Writexy(list[i].Diachi, x + 18, y + d, 11);
                    IO.Writexy("│", x + 28, y + d);
                    IO.Writexy(list[i].Sdt, x + 29, y + d, 11);
                    
                    if (i < cuoi - 1)
                        IO.Writexy("├─────────────────┼──────────────────┼─────────┼───────────────┤", x, y + d + 1);
                    y = y + 1;
                    d = d + 1;
                }
                IO.Writexy("└─────────────────┴──────────────────┴─────────┴───────────────┘", x, y + d - 1);
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
        public class MenuDemoNCC : Menu
        {
            public MenuDemoNCC(string[] mn) : base(mn) { }
            public override void ThucHien(int vitri)
            {
                FormNha_CC ncc = new FormNha_CC();
                switch (vitri)
                {
                    case 0:
                        ncc.Nhap();
                        break;
                    case 1:
                        ncc.Tim();
                        break;
                    case 2:
                        ncc.Xoa();
                        break;
                    case 3:
                        ncc.SuaNha_CC();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }

    }
}
