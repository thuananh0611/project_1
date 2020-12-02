using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Presenation
{
    public class GiaodienNV
    {
        FormDichVu dv = new FormDichVu();
        FormHD_Ban hdb = new FormHD_Ban();
        FormHD_Nhap hdn = new FormHD_Nhap();
        FormK_Hang kh = new FormK_Hang();
        FormNhanVien nv = new FormNhanVien();
        FormNha_CC ncc = new FormNha_CC();
        public void GiaoDienChinh()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("\t****************************************************************");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*            HỆ THỐNG QUẢN LÝ THẨM MỸ VIỆN LACASA              *");
            Console.WriteLine("\t*                    Người dùng: Nhân viên                     *");
            Console.WriteLine("\t*      =================================================       *");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*             ||  =========================  ||                *");
            Console.WriteLine("\t*             ||  1. Quản lý DỊCH VỤ         ||                *");
            Console.WriteLine("\t*             ||  2. Quản lý HÓA ĐƠN BÁN     ||                *");
            Console.WriteLine("\t*             ||  3. Quản lý HÓA ĐƠN NHẬP    ||                *");
            Console.WriteLine("\t*             ||  4. Quản lý KHÁCH HÀNG      ||                *");
            Console.WriteLine("\t*             ||  5. Quản lý NHÀ CUNG CẤP    ||                *");
            Console.WriteLine("\t*             ||  6. Thống kê                ||                *");
            Console.WriteLine("\t*             ||  7. Sao kê dữ liệu          ||                *");
            Console.WriteLine("\t*             ||  8. Hướng dẫn sử dụng       ||                *");
            Console.WriteLine("\t*             ||  0. Thoát                   ||                *");
            Console.WriteLine("\t*             ||  =========================  ||                *");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*      =================================================       *");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t****************************************************************");
            Console.Write("\n                        Bạn chọn chức năng nào? ");

        }
        public void MenuChinh()
        {
            int ch;
            do
            {
                GiaoDienChinh();
                ch = int.Parse(Console.ReadLine());
                if (ch >= 1 && ch <= 8)
                {
                    Console.WriteLine("Dữ liệu vừa được load từ tệp!");
                }
                switch (ch)
                {
                    case 1:
                        MenuDV();
                        Console.ReadKey(); break;
                    case 2:
                        MenuHDB();
                        Console.ReadKey(); break;
                    case 3:
                        MenuHDN();
                        Console.ReadKey(); break;
                    case 4:
                        MenuKH();
                        Console.ReadKey(); break;
                    case 5:
                        MenuNCC();
                        Console.ReadKey(); break;
                    case 6:
                        Console.WriteLine("Chức năng chưa được hoàn thiện. Xin vui lòng chọn chức năng khác...");
                        Console.ReadKey(); break;
                    case 7:
                        Console.WriteLine("Chức năng chưa được hoàn thiện. Xin vui lòng chọn chức năng khác...");
                        Console.ReadKey(); break;
                    case 8:
                        Console.WriteLine("Chức năng chưa được hoàn thiện. Xin vui lòng chọn chức năng khác...");
                        Console.ReadKey(); break;
                    case 0:
                        Console.WriteLine("Nhấn phím bất kỳ đêt thoát khỏi chương trình");
                        Console.ReadKey(); Environment.Exit(0); break;
                }
            } while (true);
        }
        public void GiaoDienDV()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("\t****************************************************************");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*            HỆ THỐNG QUẢN LÝ THẨM MỸ VIỆN LACASA              *");
            Console.WriteLine("\t*                    Người dùng: Quản lý                       *");
            Console.WriteLine("\t*      =================================================       *");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*                     QUẢN LÝ DỊCH VỤ                          *");
            Console.WriteLine("\t*              ||  =========================  ||               *");
            Console.WriteLine("\t*              ||  1. Thêm dịch vụ            ||               *");
            Console.WriteLine("\t*              ||  2. Tìm dịch vụ             ||               *");
            Console.WriteLine("\t*              ||  3. Xóa dịch vụ             ||               *");
            Console.WriteLine("\t*              ||  4. Sửa dịch vụ             ||               *");
            Console.WriteLine("\t*              ||  0. Thoát                   ||               *");
            Console.WriteLine("\t*              ||  =========================  ||               *");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*      =================================================       *");
            Console.WriteLine("\t****************************************************************");
            Console.Write("\n\t               Bạn chọn chức năng nào? ");
        }
        public void MenuDV()
        {
            int chon;
            do
            {
                Console.Clear();
                GiaoDienDV();
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1: dv.Nhap(); Console.ReadKey(); break;
                    case 2: dv.Tim(); Console.ReadKey(); break;
                    case 3: dv.Xoa(); Console.ReadKey(); break;
                    case 4: dv.SuaDichVu(); Console.ReadKey(); break;

                }
            } while (chon != 0);

        }
        public void GiaoDienHDB()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("\t****************************************************************");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*            HỆ THỐNG QUẢN LÝ THẨM MỸ VIỆN LACASA              *");
            Console.WriteLine("\t*                    Người dùng: Quản lý                       *");
            Console.WriteLine("\t*      =================================================       *");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*                     QUẢN LÝ HÓA ĐƠN BÁN                      *");
            Console.WriteLine("\t*              ||  =========================  ||               *");
            Console.WriteLine("\t*              ||  1. Thêm hóa đơn bán        ||               *");
            Console.WriteLine("\t*              ||  2. Tìm hóa đơn bán         ||               *");
            Console.WriteLine("\t*              ||  3. Xóa hóa đơn bán         ||               *");
            Console.WriteLine("\t*              ||  4. Sửa hóa đơn bán         ||               *");
            Console.WriteLine("\t*              ||  0. Thoát                   ||               *");
            Console.WriteLine("\t*              ||  =========================  ||               *");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*      =================================================       *");
            Console.WriteLine("\t****************************************************************");
            Console.Write("\n\t               Bạn chọn chức năng nào? ");
        }
        public void MenuHDB()
        {
            int chon;
            do
            {
                Console.Clear();
                GiaoDienHDB();
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1: hdb.Nhap(); Console.ReadKey(); break;
                    case 2: hdb.Tim(); Console.ReadKey(); break;
                    case 3: hdb.Xoa(); Console.ReadKey(); break;
                    case 4: hdb.SuaHD_Ban(); Console.ReadKey(); break;
                }
            } while (chon != 0);

        }
        public void GiaoDienHDN()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("\t****************************************************************");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*            HỆ THỐNG QUẢN LÝ THẨM MỸ VIỆN LACASA              *");
            Console.WriteLine("\t*                    Người dùng: Quản lý                       *");
            Console.WriteLine("\t*      =================================================       *");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*                     QUẢN LÝ HÓA ĐƠN NHẬP                     *");
            Console.WriteLine("\t*              ||  =========================  ||               *");
            Console.WriteLine("\t*              ||  1. Thêm hóa đơn nhập       ||               *");
            Console.WriteLine("\t*              ||  2. Tìm hóa đơn nhập        ||               *");
            Console.WriteLine("\t*              ||  3. Xóa hóa đơn nhập        ||               *");
            Console.WriteLine("\t*              ||  4. Sửa hóa đơn nhập        ||               *");
            Console.WriteLine("\t*              ||  0. Thoát                   ||               *");
            Console.WriteLine("\t*              ||  =========================  ||               *");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*      =================================================       *");
            Console.WriteLine("\t****************************************************************");
            Console.Write("\n\t               Bạn chọn chức năng nào? ");
        }
        public void MenuHDN()
        {
            int chon;
            do
            {
                Console.Clear();
                GiaoDienHDN();
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1: hdn.Nhap(); Console.ReadKey(); break;
                    case 2: hdn.Tim(); Console.ReadKey(); break;
                    case 3: hdn.Xoa(); Console.ReadKey(); break;
                    case 4: hdn.SuaHD_Nhap(); Console.ReadKey(); break;

                }
            } while (chon != 0);

        }
        public void GiaoDienKH()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("\t****************************************************************");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*            HỆ THỐNG QUẢN LÝ THẨM MỸ VIỆN LACASA              *");
            Console.WriteLine("\t*                    Người dùng: Quản lý                       *");
            Console.WriteLine("\t*      =================================================       *");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*                     QUẢN LÝ KHÁCH HÀNG                       *");
            Console.WriteLine("\t*              ||  =========================  ||               *");
            Console.WriteLine("\t*              ||  1. Thêm khách hàng         ||               *");
            Console.WriteLine("\t*              ||  2. Tìm khách hàng          ||               *");
            Console.WriteLine("\t*              ||  3. Xóa khách hàng          ||               *");
            Console.WriteLine("\t*              ||  4. Sửa khách hàng             ||               *");
            Console.WriteLine("\t*              ||  0. Thoát                   ||               *");
            Console.WriteLine("\t*              ||  =========================  ||               *");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*      =================================================       *");
            Console.WriteLine("\t****************************************************************");
            Console.Write("\n\t               Bạn chọn chức năng nào? ");
        }
        public void MenuKH()
        {
            int chon;
            do
            {
                Console.Clear();
                GiaoDienKH();
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1: kh.Nhap(); Console.ReadKey(); break;
                    case 2: kh.Tim(); Console.ReadKey(); break;
                    case 3: kh.Xoa(); Console.ReadKey(); break;
                    case 4: kh.SuaK_Hang(); Console.ReadKey(); break;

                }
            } while (chon != 0);

        }
        public void GiaoDienNCC()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("\t****************************************************************");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*            HỆ THỐNG QUẢN LÝ THẨM MỸ VIỆN LACASA              *");
            Console.WriteLine("\t*                    Người dùng: Quản lý                       *");
            Console.WriteLine("\t*      =================================================       *");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*                     QUẢN LÝ NHÀ CUNG CẤP                     *");
            Console.WriteLine("\t*              ||  =========================  ||               *");
            Console.WriteLine("\t*              ||  1. Thêm nhà cung cấp       ||               *");
            Console.WriteLine("\t*              ||  2. Tìm nhà cung cấp        ||               *");
            Console.WriteLine("\t*              ||  3. Xóa nhà cung cấp        ||               *");
            Console.WriteLine("\t*              ||  4. Sửa nhà cung cấp        ||               *");
            Console.WriteLine("\t*              ||  0. Thoát                   ||               *");
            Console.WriteLine("\t*              ||  =========================  ||               *");
            Console.WriteLine("\t*                                                              *");
            Console.WriteLine("\t*      =================================================       *");
            Console.WriteLine("\t****************************************************************");
            Console.Write("\n\t               Bạn chọn chức năng nào? ");
        }
        public void MenuNCC()
        {
            int chon;
            do
            {
                Console.Clear();
                GiaoDienNCC();
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1: ncc.Nhap(); Console.ReadKey(); break;
                    case 2: ncc.Tim(); Console.ReadKey(); break;
                    case 3: ncc.Xoa(); Console.ReadKey(); break;
                    case 4: ncc.SuaNha_CC(); Console.ReadKey(); break;

                }
            } while (chon != 0);
        }
    }
}
