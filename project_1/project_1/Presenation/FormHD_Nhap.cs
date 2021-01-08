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
                INhanVienBLL nhanvien = new NhanVienBLL();
                INha_CCBLL ncc = new Nha_CCBLL();
                ISPBLL sanpham = new SPBLL();
                FormNhanVien fnv = new FormNhanVien();
                FormNha_CC fncc = new FormNha_CC();
                FormSP fsp = new FormSP();
                NhanVienBLL nvBLL = new NhanVienBLL();
                Nha_CCBLL nccBLL = new Nha_CCBLL();
                ICTHDNBLL cthdnhap = new CTHDNBLL();
                HD_NhapBLL hdnBLL = new HD_NhapBLL();
                SPBLL spBLL = new SPBLL();
                CTHDN cthdn = new CTHDN();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN HÓA ĐƠN NHẬP", 1, 1, 14, 90);
                IO.Writexy("Mã hdn: ", 5, 4);
                IO.Writexy("Mã nhân viên: ", 20, 4);
                IO.Writexy("Tên hóa đơn: ", 41, 4);
                IO.Writexy("Ngày:", 5, 6);
                IO.Writexy("Tổng tiền: ", 20, 6);
                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Nhập thông tin chi tiết hóa đơn nhập", 2, 8);
                IO.Writexy("Mã hóa đơn nhập: ", 5, 9);
                IO.Writexy("Mã nhà cc: ", 28, 9);
                IO.Writexy("Mã sản phẩm: ", 45, 9);
                IO.Writexy("Giá nhập: ", 5, 10);
                IO.Writexy("Số lượng nhập: ", 30, 10);
                IO.Writexy("Thành tiền: ", 56, 10);
                IO.Writexy("----------------------------------------------------------------------------", 2, 11);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 12);
                Hien(1, 15, hdnhap.LayDSHD_Nhap(), 5, 0);
                HD_Nhap hdn = new HD_Nhap();
                do
                {
                    hdn.Mhdn = int.Parse("0" + IO.ReadNumber(13, 4));
                    if (hdn.Mhdn <= 0)
                    {
                        IO.Clear(13, 4, 5, ConsoleColor.Black);
                        IO.Writexy("                                                            ", 5, 13);
                        IO.Writexy("Mã hóa đơn nhập sai...", 5, 13);
                    }
                    else if (hdnBLL.KT_MaHDN(hdn.Mhdn) == true)
                    {
                        IO.Clear(13, 4, 5, ConsoleColor.Black);
                        IO.Clear(5, 11, 60, ConsoleColor.Black);
                        IO.Writexy("                                                            ", 5, 13);
                        IO.Writexy("Mã hóa đơn đã tồn tại...Mời nhập mới...", 5, 13);
                    }
                    else
                        hdn.Mhdn = hdn.Mhdn;
                } while (hdn.Mhdn <= 0 || hdnBLL.KT_MaHDN(hdn.Mhdn) == true);

                do
                {
                    hdn.Manv = int.Parse("0" + IO.ReadNumber(34, 4));
                    if (hdn.Manv <= 0)
                    {
                        IO.Clear(5, 11, 60, ConsoleColor.Black);
                        IO.Clear(34, 4, 5, ConsoleColor.Black);
                        IO.Writexy("                                                            ", 5, 13);
                        IO.Writexy("Mã nhân viên nhập sai...Mời nhập lại...", 5, 13);
                    }
                    else if (nvBLL.KT_MaNV(hdn.Manv) == false)
                    {
                        IO.Clear(34, 4, 5, ConsoleColor.Black);
                        IO.Clear(5, 11, 60, ConsoleColor.Black);
                        IO.Writexy("                                                            ", 5, 13);
                        IO.Writexy("Mã nhân viên không tồn tại...Nhập mã khác", 5, 13);
                    }
                    else
                    {
                        hdn.Manv = hdn.Manv;
                        List<NhanVien> listnv = nhanvien.TimNhanVien(new NhanVien(hdn.Manv, null, null, null));
                        fnv.Hien(1, 15, listnv, 5, 0);
                    }
                } while (hdn.Manv <= 0 || nvBLL.KT_MaNV(hdn.Manv) == false);

                do
                {
                    hdn.Tenhd = IO.ReadString(54, 4);
                    if (hdn.Tenhd == null)
                    {
                        IO.Clear(5, 11, 60, ConsoleColor.Black);
                        IO.Writexy("                                                            ", 5, 13);
                        IO.Writexy("Tên hóa đơn nhập sai...", 5, 13);
                    }
                    else hdn.Tenhd = hdn.Tenhd;
                } while (hdn.Tenhd == null);
                do
                {
                    hdn.Ngay = IO.ReadString(10, 6);
                    if (hdn.Ngay == null)
                    {
                        IO.Clear(5, 11, 60, ConsoleColor.Black);
                        IO.Writexy("                                                            ", 5, 13);
                        IO.Writexy("Ngày không hợp lệ...", 5, 13);
                    }
                    else hdn.Ngay = hdn.Ngay;
                } while (hdn.Ngay == null);
                while(true)
                {
                    cthdn.Mhdn = hdn.Mhdn;
                    IO.Writexy( cthdn.Mhdn.ToString(),22, 9);
                    fncc.Hien(1, 15, ncc.LayDSNha_CC(), 5, 0);
                    Console.SetCursorPosition(39, 9);
                    do
                    {
                        cthdn.Mancc = int.Parse(IO.ReadNumber(39, 9));
                        if (nccBLL.KT_MaNCC(cthdn.Mancc) == false)
                        {
                            IO.Clear(39, 9, 5, ConsoleColor.Black);
                            IO.Writexy("                                                            ", 5, 13);
                            IO.Writexy("Mã nhà cung cấp không tồn tại...", 5, 13);
                        }
                        else if (cthdn.Mancc == 0)
                        {
                            IO.Clear(39, 9, 5, ConsoleColor.Black);
                            IO.Writexy("                                                            ", 5, 13);
                            IO.Writexy("Mã nhà cung cấp sai...", 5, 13);
                        }
                        else cthdn.Mancc = cthdn.Mancc;
                    } while (nccBLL.KT_MaNCC(cthdn.Mancc) == false);
                    fsp.Hien(1, 15, sanpham.LayDSSP(), 5, 0);
                    Console.SetCursorPosition(58, 9);

                    do
                    {
                        cthdn.Masp = int.Parse(IO.ReadNumber(58, 9));
                        if (cthdn.Masp == 0)
                        {
                            IO.Clear(58, 8, 5, ConsoleColor.Black);
                            IO.Writexy("                                                            ", 5, 13);
                            IO.Writexy("Mã sản phẩm nhập sai định dạng...", 5, 13);
                        }
                        else if (spBLL.KT_MaSP(cthdn.Masp) == false)
                        {
                            IO.Clear(58, 8, 5, ConsoleColor.Black);
                            IO.Writexy("                                                            ", 5, 13);
                            IO.Writexy("Mã sản phẩm không tồn tại...", 5, 13);
                        }
                        else cthdn.Masp = cthdn.Masp;
                    } while (cthdn.Masp == 0 || spBLL.KT_MaSP(cthdn.Masp) == false);
                    if (spBLL.KT_MaSP(cthdn.Masp) == true)
                    {
                        IO.Writexy(hdnBLL.LayGN(cthdn.Masp).ToString(), 20, 10);
                        cthdn.Gianhap = hdnBLL.LayGN(cthdn.Masp);
                    }
                    Console.SetCursorPosition(45, 10);

                    do
                    {
                        cthdn.Soluong = int.Parse(IO.ReadNumber(46, 10));
                        if (cthdn.Soluong <= 0)
                        {
                            IO.Writexy("     ", 46, 10);
                            IO.Writexy("                                                            ", 5, 13);
                            IO.Writexy("Nhập lại số lượng...", 5, 13);
                        }
                        else cthdn.Soluong = cthdn.Soluong;
                    } while (cthdn.Soluong <= 0);
                    cthdnhap.ThemCTHDN(cthdn);
                    
                    cthdn.Thanhtien = cthdn.Gianhap * cthdn.Soluong;
                    hdn.Tongtien += cthdn.Thanhtien;
                    IO.Writexy(cthdn.Thanhtien.ToString(), 68, 10);
                    Console.SetCursorPosition(50, 10);
                    IO.Writexy("Nhập tiếp? (C/K)...", 5, 13);
                    ConsoleKeyInfo c = Console.ReadKey();
                    if (c.KeyChar != 'c')
                        break;
            }
            IO.Writexy(hdn.Tongtien.ToString(), 31, 6);
            hdnhap.ThemHD_Nhap(hdn);
                Console.SetCursorPosition(50, 12);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
               break;
            else if (kt.Key == ConsoleKey.V) Hien(1, 15, hdnhap.LayDSHD_Nhap(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
                {
                    IO.Writexy("                                                            ", 5, 13);
                    IO.Writexy("Hóa đơn nhập thêm thành công...", 5, 13);
                    hdnhap.ThemHD_Nhap(hdn); 
                }
            } while (true);
        }
        public void SuaHD_Nhap()
        {
            do
            {
                IHD_NhapBLL hdnhap = new HD_NhapBLL();
                INhanVienBLL nhanvien = new NhanVienBLL();
                INha_CCBLL ncc = new Nha_CCBLL();
                ISPBLL sanpham = new SPBLL();
                FormNhanVien fnv = new FormNhanVien();
                FormNha_CC fncc = new FormNha_CC();
                FormSP fsp = new FormSP();
                NhanVienBLL nvBLL = new NhanVienBLL();
                Nha_CCBLL nccBLL = new Nha_CCBLL();
                ICTHDNBLL cthdnhap = new CTHDNBLL();
                HD_NhapBLL hdnBLL = new HD_NhapBLL();
                SPBLL spBLL = new SPBLL();
                CTHDN cthdn = new CTHDN();
                Console.Clear();
                IO.BoxTitle("SỬA THÔNG TIN HÓA ĐƠN NHẬP", 1, 1, 14, 90);
                IO.Writexy("Mã hdn: ", 5, 4);
                IO.Writexy("Mã nhân viên: ", 20, 4);
                IO.Writexy("Tên hóa đơn: ", 41, 4);
                IO.Writexy("Ngày:", 5, 6);
                IO.Writexy("Tổng tiền: ", 20, 6);
                IO.Writexy("----------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Nhập thông tin chi tiết hóa đơn nhập", 2, 8);
                IO.Writexy("Mã hóa đơn nhập: ", 5, 9);
                IO.Writexy("Mã nhà cc: ", 28, 9);
                IO.Writexy("Mã sản phẩm: ", 45, 9);
                IO.Writexy("Giá nhập: ", 5, 10);
                IO.Writexy("Số lượng nhập: ", 30, 10);
                IO.Writexy("Thành tiền: ", 56, 10);
                IO.Writexy("----------------------------------------------------------------------------", 2, 11);
                IO.Writexy("Enter de nhap, Esc de thoat, V xem chi tiet!", 5, 12);
                Hien(1, 15, hdnhap.LayDSHD_Nhap(), 5, 0);
                int mhdn;
                int manv;
                double s=0;
                string tenhd;
                string ngay;
                int mancc;
                int masp;
                int soluong;
                mhdn = int.Parse("0" + IO.ReadNumber(13, 4));
                HD_Nhap hdn = hdnhap.LayHD_Nhap(mhdn);
                IO.Writexy("    ", 34, 4); //mã nv
                IO.Writexy("                    ", 54, 4); //tên hóa đơn
                IO.Writexy("        ", 11, 6); //ngày
                IO.Writexy("    ", 22, 9);//mã cthdn 
                IO.Writexy("    ", 39, 9);//mã ncc
                IO.Writexy("    ", 58, 9);//mã sp
                IO.Writexy("          ", 20, 10);//giá
                IO.Writexy("    ", 46, 10);//số lượng
                IO.Writexy("          ", 68, 10); //thành tiền
                IO.Writexy("          ", 31, 6);// tổng tiền
                do
                {
                    manv = int.Parse("0" + IO.ReadNumber(34, 4));
                    if (manv <= 0)
                    {
                        IO.Clear(5, 11, 60, ConsoleColor.Black);
                        IO.Clear(34, 4, 5, ConsoleColor.Black);
                        IO.Writexy("                                                            ", 5, 13);
                        IO.Writexy("Mã nhân viên nhập sai...Mời nhập lại...", 5, 13);
                    }
                    else if (nvBLL.KT_MaNV(manv) == false)
                    {
                        IO.Clear(34, 4, 5, ConsoleColor.Black);
                        IO.Clear(5, 11, 60, ConsoleColor.Black);
                        IO.Writexy("                                                            ", 5, 13);
                        IO.Writexy("Mã nhân viên không tồn tại...Nhập mã khác", 5, 13);
                    }
                    else
                    {
                        hdn.Manv = manv;
                        List<NhanVien> listnv = nhanvien.TimNhanVien(new NhanVien(manv, null, null, null));
                        fnv.Hien(1, 15, listnv, 1, 0);
                    }
                } while (manv <= 0 || nvBLL.KT_MaNV(manv) == false);

                do
                {
                    tenhd = IO.ReadString(54, 4);
                    if (hdn.Tenhd == null)
                    {
                        IO.Clear(5, 11, 60, ConsoleColor.Black);
                        IO.Writexy("                                                            ", 5, 13);
                        IO.Writexy("Tên hóa đơn nhập sai...", 5, 13);
                    }
                    else hdn.Tenhd = tenhd;
                } while (tenhd == null);
                do
                {
                    ngay = IO.ReadString(10, 6);
                    if (hdn.Ngay == null)
                    {
                        IO.Clear(5, 11, 60, ConsoleColor.Black);
                        IO.Writexy("                                                            ", 5, 13);
                        IO.Writexy("Ngày không hợp lệ...", 5, 13);
                    }
                    else hdn.Ngay = ngay;
                } while (ngay == null);
                
                cthdnhap.XoaCTHDN(hdn.Mhdn);
                while (true)
                {
                    cthdn.Mhdn = hdn.Mhdn;
                    IO.Writexy(cthdn.Mhdn.ToString(), 22, 9);
                    fncc.Hien(1, 15, ncc.LayDSNha_CC(), 5, 0);
                    Console.SetCursorPosition(39, 9);
                    
                    do
                    {
                        mancc = int.Parse(IO.ReadNumber(39, 9));
                        if (nccBLL.KT_MaNCC(mancc) == false)
                        {
                            IO.Clear(39, 9, 5, ConsoleColor.Black);
                            IO.Writexy("                                                            ", 5, 13);
                            IO.Writexy("Mã nhà cung cấp không tồn tại...", 5, 13);
                        }
                        else if (mancc == 0)
                        {
                            IO.Clear(39, 9, 5, ConsoleColor.Black);
                            IO.Writexy("                                                            ", 5, 13);
                            IO.Writexy("Mã nhà cung cấp sai...", 5, 13);
                        }
                        else cthdn.Mancc = mancc;
                    } while (nccBLL.KT_MaNCC(mancc) == false);
                    fsp.Hien(1, 15, sanpham.LayDSSP(), 5, 0);
                    Console.SetCursorPosition(58, 9);

                    do
                    {
                        masp = int.Parse(IO.ReadNumber(58, 9));
                        if (masp == 0)
                        {
                            IO.Clear(58, 8, 5, ConsoleColor.Black);
                            IO.Writexy("                                                            ", 5, 13);
                            IO.Writexy("Mã sản phẩm nhập sai định dạng...", 5, 13);
                        }
                        else if (spBLL.KT_MaSP(masp) == false)
                        {
                            IO.Clear(58, 8, 5, ConsoleColor.Black);
                            IO.Writexy("                                                            ", 5, 13);
                            IO.Writexy("Mã sản phẩm không tồn tại...", 5, 13);
                        }
                        else cthdn.Masp = masp;
                    } while (masp == 0 || spBLL.KT_MaSP(masp) == false);
                    if (spBLL.KT_MaSP(masp) == true)
                    {
                        IO.Writexy(hdnBLL.LayGN(masp).ToString(), 20, 10);
                        cthdn.Gianhap = hdnBLL.LayGN(masp);
                    }
                    Console.SetCursorPosition(45, 10);

                    do
                    {
                        soluong = int.Parse(IO.ReadNumber(46, 10));
                        if (soluong <= 0)
                        {
                            IO.Writexy("     ", 46, 10);
                            IO.Writexy("                                                            ", 5, 13);
                            IO.Writexy("Nhập lại số lượng...", 5, 13);
                        }
                        else cthdn.Soluong = soluong;
                    } while (soluong <= 0);
                    //cthdnhap.SuaCTHDN(cthdn);
                    cthdn.Thanhtien = cthdn.Gianhap * cthdn.Soluong;
                    s += cthdn.Thanhtien;
                    IO.Writexy(cthdn.Thanhtien.ToString(), 68, 10);
                    Console.SetCursorPosition(50, 10);
                    cthdnhap.ThemCTHDN(cthdn);
                    IO.Writexy("Nhập tiếp? (C/K)...", 5, 13);
                    ConsoleKeyInfo c = Console.ReadKey();
                    if (c.KeyChar != 'c')
                        break;
                }
                IO.Writexy(hdn.Tongtien.ToString(), 31, 6);
                hdn.Tongtien = s;
                hdnhap.SuaHD_Nhap(hdn);
                Console.SetCursorPosition(50, 12);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    break;
                else if (kt.Key == ConsoleKey.V) Hien(1, 15, hdnhap.LayDSHD_Nhap(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                {
                    //hdnhap.SuaHD_Nhap(hdn);
                    
                    
                    //cthdnhap.SuaCTHDN(cthdn);
                    Hien(1, 15, hdnhap.LayDSHD_Nhap(), 5, 1);
                }
            } while (true);
        }
        public void Xoa()
        {
            int mhdn = 0;
            do
            {
                Console.Clear();
                IHD_NhapBLL hdnhap = new HD_NhapBLL();
                ICTHDNBLL cthdnhap = new CTHDNBLL();
                Console.Clear();
                IO.BoxTitle("NHẬP THÔNG TIN ĐỐI TƯỢNG CẦN XÓA", 1, 1, 5, 79);
                IO.Writexy("Mã hóa đơn nhập:", 5, 4);
                Hien(1, 8, hdnhap.LayDSHD_Nhap(), 5, 0);
                mhdn = int.Parse("0" + IO.ReadString(22, 4));
                if (mhdn == 0) break;
                else
                {
                    hdnhap.XoaHD_Nhap(mhdn);
                    cthdnhap.XoaCTHDN(mhdn);
                }
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
                IO.Writexy("Mã hóa đơn nhập:", 5, 4);
                Hien(1, 8, hdnhap.LayDSHD_Nhap(), 5, 0);
                mhdn = int.Parse(IO.ReadNumber(23, 4));
                List<HD_Nhap> list = hdnhap.TimHD_Nhap(new HD_Nhap(mhdn, 0, null, null, 0));
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
                IO.Writexy("┌────────┬───────┬──────────────────────────┬──────────┬─────────────┐", x, y + 1);
                IO.Writexy("│ Mã HDN │ Mã NV │     Tên hóa đơn nhập     │   Ngày   │  Tổng tiền  │", x, y + 2);
                IO.Writexy("├────────┼───────┼──────────────────────────┼──────────┼─────────────┤", x, y + 3);
                y = y + 4;
                for (int i = dau; i < cuoi; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].Mhdn.ToString(), x + 1, y + d, 8);
                    IO.Writexy("│", x + 9, y + d);
                    IO.Writexy(list[i].Manv.ToString(), x + 10, y + d, 7);
                    IO.Writexy("│", x + 17, y + d);
                    IO.Writexy(list[i].Tenhd, x + 18, y + d, 26);
                    IO.Writexy("│", x + 44, y + d);
                    IO.Writexy(list[i].Ngay, x + 45, y + d, 10);
                    IO.Writexy("│", x + 55, y + d);
                    IO.Writexy(list[i].Tongtien.ToString(), x + 56, y + d, 13);
                    IO.Writexy("│", x + 69, y + d);
                    if (i < cuoi - 1)
                        IO.Writexy("├────────┼───────┼──────────────────────────┼──────────┼─────────────┤", x, y + d + 1);
                    y = y + 1;
                    d = d + 1;
                }
                IO.Writexy("└────────┴───────┴──────────────────────────┴──────────┴─────────────┘", x, y + d - 1);
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
        public void HienCT(int xx, int yy, List<CTHDN> list, int n, int type)
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
                IO.Writexy("                     DANH SÁCH CT HÓA ĐƠN NHẬP                             ", x, y);
                IO.Writexy("┌────────┬────────┬───────┬─────────────────┬───────────────────┬──────────────┐", x, y + 1);
                IO.Writexy("│ Mã HDN │ Mã NCC | Mã SP │    Giá nhập     │   Số lượng nhập   │  Thành tiền  │", x, y + 2);
                IO.Writexy("├────────┼────────┼───────┼─────────────────┼───────────────────┼──────────────┤", x, y + 3);
                y = y + 4;
                for (int i = dau; i < cuoi; i++)
                {
                    IO.Writexy("│", x, y + d, 8);
                    IO.Writexy(list[i].Mhdn.ToString(), x + 1, y + d, 8);
                    IO.Writexy("│", x + 9, y + d);
                    IO.Writexy(list[i].Mancc.ToString(), x + 10, y + d, 8);
                    IO.Writexy("│", x + 18, y + d);
                    IO.Writexy(list[i].Masp.ToString(), x + 19, y + d, 7);
                    IO.Writexy("│", x + 26, y + d);
                    IO.Writexy(list[i].Gianhap.ToString(), x + 27, y + d, 17);
                    IO.Writexy("│", x + 44, y + d);
                    IO.Writexy(list[i].Soluong.ToString(), x + 45, y + d, 19);
                    IO.Writexy("│", x + 64, y + d);
                    IO.Writexy(list[i].Thanhtien.ToString(), x + 65, y + d, 14);
                    IO.Writexy("│", x + 79, y + d);
                    if (i < cuoi - 1)
                        IO.Writexy("├────────┼────────┼───────┼─────────────────┼───────────────────┼──────────────┤", x, y + d + 1);
                    y = y + 1;
                    d = d + 1;
                }
                IO.Writexy("└────────┴────────┴───────┴─────────────────┴───────────────────┴──────────────┘", x, y + d - 1);
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
        public void XemCT()
        {
            Console.Clear();
            ICTHDNBLL cthdnhap = new CTHDNBLL();
            HienCT(1, 1, cthdnhap.LayDSCTHDN(), 10, 1);
        }


    }
}
