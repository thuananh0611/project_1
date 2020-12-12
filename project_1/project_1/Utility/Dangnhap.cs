using System;
using project_1.DataAccessLayer;
using project_1.Business;
using project_1.Entities;
using project_1.Presenation;
namespace project_1.Utility
{
    public class DangNhap
    {
        private string taikhoan;
        private string matkhau;
        public string TaiKhoan
        {
            get
            {
                return taikhoan;
            }
            set
            {
                taikhoan = value;
            }
        }
        public string Matkhau
        {
            get
            {
                return matkhau;
            }
            set
            {
                matkhau = value;
            }
        }
        public DangNhap()
        {

        }
        public void Hien(int x, int y)
        {
            GiaodienNV nv = new GiaodienNV();
            GiaodienQL ql = new GiaodienQL();
            Console.BackgroundColor = ConsoleColor.Black;
            IO.BoxTitle("ĐĂNG NHẬP", x, y, 15, 60);
            IO.Writexy("Tài khoản:", x + 3, y + 5);
            IO.Writexy("Mật khẩu:", x + 3, y + 8);
            IO.Writexy("Đăng Nhập", x + 40, y + 10);
            IO.Writexy("Ngầm định(Quản lý : ql, nhân viên: nv, pass : 1234 )", x + 2, y + 12, ConsoleColor.Black, ConsoleColor.White);
            //Console.ReadKey();
            IO.Writexy("                                                    ", x + 2, y + 12, ConsoleColor.Black, ConsoleColor.White);
            do
            {
                this.taikhoan = IO.ReadString(x + 15, y + 5);
                this.matkhau = IO.ReadPassword(x + 15, y + 8);
                IO.Writexy("Nhấn Enter để đăng nhập hoặc nhấn phím ESC để thoát...", x + 2, y + 12);
                IO.Writexy("Đăng Nhập", x + 40, y + 10, ConsoleColor.Black, ConsoleColor.White);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Enter)
                {
                    if (taikhoan == "ql" && matkhau == "1234")
                        ql.MenuChinh();
                    else if (taikhoan == "nv" && matkhau == "1234")
                        nv.MenuChinh();
                    else
                    {
                        IO.Clear(x + 2, y + 12, 55, ConsoleColor.Black);
                        IO.Writexy("Tài khoản hoặc mật khẩu nhập sai, mời nhập lại...", x + 2, y + 12, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 14, y + 5, 30, ConsoleColor.Black);
                        IO.Clear(x + 14, y + 8, 30, ConsoleColor.Black);
                    }
                }
            } while (true);
        }
        
    }
}
