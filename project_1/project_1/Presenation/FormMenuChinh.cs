using System;
using project_1.Utility;
using System.Text;
using project_1.Presenation;
using project_1.Business;
using project_1.Entities;
using project_1.DataAccessLayer;

namespace FormMenuChinh
{
    public class GiaoDien
    {
        

        public void GiaoDienChinh()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("\t**************************************************************");
            Console.WriteLine("\t*                                                            *");
            Console.WriteLine("\t*          HỆ THỐNG QUẢN LÝ THẨM MỸ VIỆN LACASA              *");
            Console.WriteLine("\t*      ============================================          *");
            Console.WriteLine("\t*                                                            *");
            Console.WriteLine("\t*             ||  ====================     ||                *");
            Console.WriteLine("\t*             ||  1. Quản lý dịch vụ       ||                *");
            Console.WriteLine("\t*             ||  2. Quản lý sản phẩm      ||                *");
            Console.WriteLine("\t*             ||  3. Quản lý hóa đơn bán   ||                *");
            Console.WriteLine("\t*             ||  4. Quản lý hóa đơn nhập  ||                *");
            Console.WriteLine("\t*             ||  5. Quản lý nhà cung cấp  ||                *");
            Console.WriteLine("\t*             ||  6. Quản lý khách hàng    ||                *");
            Console.WriteLine("\t*             ||  7. Quản lý nhân viên     ||                *");
            Console.WriteLine("\t*             ||  0. Thoát                 ||                *");
            Console.WriteLine("\t*             ||  ======================   ||                *");
            Console.WriteLine("\t*                                                            *");
            Console.WriteLine("\t*      ===============================================       *");
            Console.WriteLine("\t*                                                            *");
            Console.WriteLine("\t**************************************************************");
            Console.Write("\n               Bạn chọn chức năng nào? ");

        }
        public void MenuChinh()
        {
            int ch;
            do
            {
                GiaoDienChinh();
                ch = int.Parse(Console.ReadLine());
                
                switch (ch)
                {
                    case 1:
                        MenuDemoDV;
                        Console.ReadKey(); break;
                    case 2:
                        MenuDemoSP;
                        Console.ReadKey(); break;
                    case 3:
                        MenuTimKiem();
                        Console.ReadKey(); break;
                    case 4:
                        MenuThongKe();
                        Console.ReadKey(); break;
                    case 5:
                        Console.WriteLine("Chức năng chưa xây dựng. Vui lòng trở lại sau..");
                        Console.ReadKey(); break;
                    case 6:
                        Console.WriteLine("Hướng dẫn sử dụng như sau:...\nNhấn 0 để thoát\n Nhấn số tương ứng từng chức năng\n Gluck");
                        Console.ReadKey(); break;
                    case 0:
                        Console.WriteLine("Nhấn phím bất kỳ đêt thoát khỏi chương trình");
                        Console.ReadKey(); Environment.Exit(0); break;
                }
            } while (true);

        }
        public void GiaoDienHocSinh()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("\t***********************************************************");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*          HỆ THỐNG QUẢN LÝ HỌC SINH TRUNG HỌC            *");
            Console.WriteLine("\t*      ============================================       *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*             ||  =========================  ||           *");
            Console.WriteLine("\t*             ||  1. Thêm HỌC SINH           ||           *");
            Console.WriteLine("\t*             ||  2. Sửa thông tin HỌC SINH  ||           *");
            Console.WriteLine("\t*             ||  3. Xóa thông tin HỌC SINH  ||           *");
            Console.WriteLine("\t*             ||  4. Hiển thị DS HỌC SINH    ||           *");
            Console.WriteLine("\t*             ||  0. Thoát                   ||           *");
            Console.WriteLine("\t*             ||  =========================  ||           *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*      ============================================       *");
            Console.WriteLine("\t***********************************************************");
            Console.Write("\n\t               Bạn chọn chức năng nào? ");
        }
        public void MenuHocSinh()
        {
            int chon;
            do
            {
                GiaoDienHocSinh();
                chon = int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case 1: dshs.Insert(dsl); Console.ReadKey(); break;
                    case 2: dshs.Update(dsl); Console.ReadKey(); break;
                    case 3: dshs.Delete(dsl); Console.ReadKey(); break;
                    case 4: dshs.hienthi(); Console.ReadKey(); break;
                }
            } while (chon != 0);

        }
        public void GiaoDienLop()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("\t***********************************************************");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*          HỆ THỐNG QUẢN LÝ HỌC SINH TRUNG HỌC            *");
            Console.WriteLine("\t*      ============================================       *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*                     QUẢN LÝ LỚP HỌC                     *");
            Console.WriteLine("\t*              ||  ====================  ||               *");
            Console.WriteLine("\t*              ||  1. Thêm lỚP           ||               *");
            Console.WriteLine("\t*              ||  2. Sửa tên LỚP        ||               *");
            Console.WriteLine("\t*              ||  3. Hiển thị LỚP       ||               *");
            Console.WriteLine("\t*              ||  0. Thoát              ||               *");
            Console.WriteLine("\t*              ||  ====================  ||               *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*      ============================================       *");
            Console.WriteLine("\t***********************************************************");
            Console.Write("\n\t               Bạn chọn chức năng nào? ");
        }
        public void MenuLop()
        {
            int chon;
            do
            {
                Console.Clear();
                GiaoDienLop();
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1: dsl.Insert(); Console.ReadKey(); break;
                    case 2: dsl.UpdateName(); Console.ReadKey(); break;
                    case 3: dsl.hienthi(); Console.ReadKey(); break;

                }
            } while (chon != 0);

        }
        public void GiaoDienTimKiem()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("\t***********************************************************");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*          HỆ THỐNG QUẢN LÝ HỌC SINH TRUNG HỌC            *");
            Console.WriteLine("\t*        ==========================================       *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*                          TÌM KIẾM                       *");
            Console.WriteLine("\t*            ||  ============================  ||         *");
            Console.WriteLine("\t*            ||  1. Tìm kiếm theo mã lỚP       ||         *");
            Console.WriteLine("\t*            ||  2. Tìm kiếm theo tên lỚP      ||         *");
            Console.WriteLine("\t*            ||  3. Tìm kiếm theo mã HỌC SINH  ||         *");
            Console.WriteLine("\t*            ||  4. Tìm kiếm theo tên HỌC SINH ||         *");
            Console.WriteLine("\t*            ||  0. Thoát                      ||         *");
            Console.WriteLine("\t*            ||  ============================  ||         *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*        ==========================================       *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t***********************************************************");
            Console.Write("\n                  Bạn chọn chức năng nào? ");
        }
        public void MenuTimKiem()
        {
            int chon;
            do
            {
                GiaoDienTimKiem();
                chon = int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case 1: Console.WriteLine("Tương tự tìm kiếm Học sinh!"); Console.ReadKey(); break;
                    case 2: Console.WriteLine("Tương tự tìm kiếm Học sinh!"); Console.ReadKey(); break;
                    case 3:
                        Console.Write("nhap ma HS can tim:");
                        int ma = int.Parse(Console.ReadLine());
                        Nodehs tmp = dshs.SearchMa(ma);
                        if (tmp != null) tmp.hs.hienthi();
                        else Console.WriteLine("Ko thay SV");
                        Console.ReadKey(); break;
                    case 4:
                        Console.Write("nhap ten HS can tim:");
                        string ten = Console.ReadLine();
                        dshs.SearchTen(ten);
                        Console.ReadKey(); break;
                }
            } while (chon != 0);

        }
        public void GiaoDienThongKe()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("\t***********************************************************");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*          HỆ THỐNG QUẢN LÝ HỌC SINH TRUNG HỌC            *");
            Console.WriteLine("\t*      ============================================       *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*                          THỐNG KÊ                       *");
            Console.WriteLine("\t*        ||  ===============================  ||          *");
            Console.WriteLine("\t*        ||  1. Thống kê số lớp theo khối     ||          *");
            Console.WriteLine("\t*        ||  2. Thống kê số HỌC SINH theo khối||          *");
            Console.WriteLine("\t*        ||  3. Thống kê học lực              ||          *");
            Console.WriteLine("\t*        ||  4. Thống kê học lực theo khối    ||          *");
            Console.WriteLine("\t*        ||  0. Thoát                         ||          *");
            Console.WriteLine("\t*        ||  ===============================  ||          *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*      ============================================       *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t***********************************************************");
            Console.Write("\n                   Bạn chọn chức năng nào? ");
        }
        public void MenuThongKe()
        {
            int chon;
            do
            {
                GiaoDienThongKe();
                chon = int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case 1:
                        dsl.Thongke();
                        Console.ReadKey(); break;
                    case 2: Console.WriteLine("Tương tự CN1, xây dựng sau:"); Console.ReadKey(); break;
                    case 3:
                        dshs.ThongkeTyLe();
                        Console.ReadKey(); break;
                    case 4:
                        dshs.SortLop();
                        Console.WriteLine("DS học sinh theo lớp");
                        dshs.hienthi();
                        Console.ReadKey(); break;
                }
            } while (chon != 0);

        }

    }
}
