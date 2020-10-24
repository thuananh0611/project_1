using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Utility
{
    class Dangnhap
    {
        private string taikhoan;
        private string matkhau;
        public string Taikhoan
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
        public Dangnhap()
        {

        }
        public bool Hien(int x, int y, string taikhoan, string matkhau)
        {
            IO.BoxTitle("DANG NHAP", x, y, 15, 60);
            IO.Writexy("Tai khoan:", x + 3, y + 5);
            IO.Writexy("Mat khau:", x + 3, y + 8);
            IO.Writexy("Dang Nhap", x + 40, y + 10);
            IO.Writexy("Ngam dinh(Tai khoan: 1 - Mat khau: 1)", x + 2, y + 12, ConsoleColor.Black, ConsoleColor.White);
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
                    if (this.taikhoan == taikhoan && this.matkhau == matkhau) return true;
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
    }
}
