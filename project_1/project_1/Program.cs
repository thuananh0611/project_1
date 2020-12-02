using System;
using System.Text;
using project_1.Utility;
using project_1.Presenation;
namespace project_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.Unicode;
            DangNhap lg = new DangNhap();
            bool ok1 = lg.Hien(10, 5, "ql", "1234");
            if (ok1)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetWindowSize(76, 40);
                Console.SetCursorPosition(20, 20);
                GiaodienQL ql = new GiaodienQL();
                ql.GiaoDienChinh();
            }
            bool ok2 = lg.Hien(10, 5, "nv", "1234");
            if (ok2)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetWindowSize(76, 40);
                Console.SetCursorPosition(20, 20);
                GiaodienNV nv = new GiaodienNV();
                nv.GiaoDienDV();
            }
            Console.ReadKey();
        }
       
    }
}