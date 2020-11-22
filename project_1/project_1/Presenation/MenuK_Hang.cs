using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using project_1.Utility;
using project_1.Entities;
using project_1.Business;
using FormK_Hang;

namespace project_1.Presenation
{
    public class GiaoDien
    {
        static DanhSachK_Hang dskh = new DanhSachK_Hang();
        /*static DanhSachLop dsl = new DanhSachLop();*/

        public void GiaoDienChinh()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("\t***********************************************************");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*          HỆ THỐNG QUẢN LÝ KHÁCH HÀNG CỦA TMV            *");
            Console.WriteLine("\t*      ============================================       *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*             ||  ====================  ||                *");
            Console.WriteLine("\t*             ||  1. Quản lý .......    ||                *");
            Console.WriteLine("\t*             ||  2. Quản lý KHÁCH HÀNG ||                *");
            Console.WriteLine("\t*             ||  3. Tìm kiếm thông tin ||                *");
            Console.WriteLine("\t*             ||  4. AAAAAAAA           ||                *");
            Console.WriteLine("\t*             ||  5. Sao lưu dự phòng   ||                *");
            Console.WriteLine("\t*             ||  6. Hướng dẫn sử dụng  ||                *");
            Console.WriteLine("\t*             ||  0. Thoát              ||                *");
            Console.WriteLine("\t*             ||  ====================  ||                *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*      ============================================       *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t***********************************************************");
            Console.Write("\n               Bạn chọn chức năng nào? ");

        }
        public void MenuChinh()
        {
            int ch;
            do
            {
                GiaoDienChinh();
                ch = int.Parse(Console.ReadLine());
                if (ch >= 1 && ch <= 5)
                {
                    /*dsl.doctep();*/
                    dskh.doctep();
                    Console.WriteLine("Dữ liệu vừa được load từ tệp!");
                }
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Chức năng chưa xây dựng. Vui lòng trở lại sau..");
                        Console.ReadKey(); break;
                    case 2:
                        MenuK_Hang();
                        Console.ReadKey(); break;
                    case 3:
                        MenuTimKiem();
                        Console.ReadKey(); break;
                    case 4:
                        Console.WriteLine("Chức năng chưa xây dựng. Vui lòng trở lại sau..");
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
        public void GiaoDienK_Hang()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("\t***********************************************************");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*          HỆ THỐNG QUẢN LÝ KHÁCH HÀNG CỦA TMV            *");
            Console.WriteLine("\t*      ============================================       *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*             ||  =========================  ||           *");
            Console.WriteLine("\t*             ||  1. Thêm KHÁCH HÀNG         ||           *");
            Console.WriteLine("\t*             ||  2. Sửa thông tin KHÁCH HÀNG||           *");
            Console.WriteLine("\t*             ||  3. Xóa thông tin kHÁCH HÀNG||           *");
            Console.WriteLine("\t*             ||  4. Hiển thị DS KHÁCH HÀNG  ||           *");
            Console.WriteLine("\t*             ||  0. Thoát                   ||           *");
            Console.WriteLine("\t*             ||  =========================  ||           *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*      ============================================       *");
            Console.WriteLine("\t***********************************************************");
            Console.Write("\n\t               Bạn chọn chức năng nào? ");
        }
        public void MenuK_Hang()
        {
            int chon;
            do
            {
                GiaoDienK_Hang();
                chon = int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case 1: dskh.Insert(); Console.ReadKey(); break;
                    case 2: dskh.Update(); Console.ReadKey(); break;
                    case 3: dskh.Delete(); Console.ReadKey(); break;
                    case 4: dskh.hienthi(); Console.ReadKey(); break;
                }
            } while (chon != 0);

        }
        
        public void GiaoDienTimKiem()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("\t***********************************************************");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*          HỆ THỐNG QUẢN LÝ KHÁCH HÀNG CỦA TMV            *");
            Console.WriteLine("\t*        ==========================================       *");
            Console.WriteLine("\t*                                                         *");
            Console.WriteLine("\t*                          TÌM KIẾM                       *");
            Console.WriteLine("\t*            ||  ============================  ||         *");
            Console.WriteLine("\t*            ||  1. Tìm kiếm theo mã KH        ||         *");
            Console.WriteLine("\t*            ||  2. Tìm kiếm theo tên KH       ||         *");
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
                    case 1:
                        Console.Write("Nhập mã kh cần tìm:");
                        int ma = int.Parse(Console.ReadLine());
                        Nodekh tmp = dskh.SearchMa(ma);
                        if (tmp != null) tmp.kh.hienthi();
                        else Console.WriteLine("Không thấy khách hàng!");
                        Console.ReadKey(); break;
                    case 2:
                        Console.Write("Nhập tên KH cần tìm");
                        string ten = Console.ReadLine();
                        dskh.SearchTen(ten);
                        Console.ReadKey(); break;
                }
            } while (chon != 0);

        }
        

    }
}
