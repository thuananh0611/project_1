using System;
using project_1.DataAccessLayer;
using project_1.Business;
using project_1.Entities;
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
        public bool Hien(int x, int y, string taikhoan, string matkhau)
        {

            IO.BoxTitle("DANG NHAP", x, y, 15, 60);
            IO.Writexy("Tai khoan:", x + 3, y + 5);
            IO.Writexy("Mat khau:", x + 3, y + 8);
            IO.Writexy("Dang Nhap", x + 40, y + 10);
            IO.Writexy("Ngam dinh(Quản lý : ql, nhân viên: nv, pass : 1234 )", x + 2, y + 12, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
            IO.Writexy("                                     ", x + 2, y + 12, ConsoleColor.Black, ConsoleColor.White);
            do
            {
                this.taikhoan = IO.ReadString(x + 15, y + 5);
                this.matkhau = IO.ReadPassword(x + 15, y + 8);
                IO.Writexy("Nhan Enter de dang nhap hoac nhan phim ESC de thoat...", x + 2, y + 12);
                IO.Writexy("Dang Nhap", x + 40, y + 10, ConsoleColor.Blue, ConsoleColor.White);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Enter)
                {
                    if (KT_DangNhap(user, pass) == true || user == "admin" && pass == "admin")
                        FormMenuChinh.HienMNC(29, 5, ConsoleColor.Black, ConsoleColor.White);
                    else
                    {
                        IO.Clear(x + 2, y + 12, 55, ConsoleColor.Black);
                        IO.Writexy("Tai khoan hoac mat khau sai, xin hay nhap lai...", x + 2, y + 12, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 15, y + 5, 30, ConsoleColor.Black);
                        IO.Clear(x + 15, y + 8, 30, ConsoleColor.Black);
                    }
                }
                else return false;
            } while (true);
        }
        public bool KT_DangNhap(string user, string pass)
        {
            NhanVienDAL nvDAL = new NhanVienDAL();
            List<NhanVien> list = nvDAL.GetData();
            Node<NhanVien> tmp = list.L;
            bool kt = false;
            while (tmp != null)
            {
                if (tmp.Info.Mnv == user && tmp.Info.pass)
                {
                    kt = true;
                    break;
                }
                else
                    tmp = tmp.Link;
            }
            return kt;
        }
    }
}
