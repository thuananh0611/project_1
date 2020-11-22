using System;
using project_1.Utility;
using System.Text;
namespace project_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.UTF8;
            Dangnhap lg = new Dangnhap();
            bool ok = lg.Hien(10, 5, "1", "1");
            if (ok)
            {
                Hien();
            }
            else Environment.Exit(0);

        }
        public static void Hien()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn ={
                            " F1.Nhap danh sach khach hang ",
                            " F2.Tim khach hang ",
                            " F3.Xoa thong tin khach hang ",
                            " F4.Sua thong tin khach hang ",
                            " F5.Ket thuc "
                        };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            project_1.Presenation.MenuK_Hang mndemo = new project_1.Presenation.MenuK_Hang(mn);
            mndemo.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
    }
}
