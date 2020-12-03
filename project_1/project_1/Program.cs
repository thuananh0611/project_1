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
            
            Console.SetWindowSize(76, 40);
            Console.SetCursorPosition(20, 20);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            lg.Hien(26, 7);
            Console.ReadKey();
        }
       
    }
}