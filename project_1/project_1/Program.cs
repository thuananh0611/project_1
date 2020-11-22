using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using project_1.Presenation;
using project_1.Utility;


namespace project_1
{
    public class Program
    {
        static void Main(string[] args)
        {
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
            Console.OutputEncoding = Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetWindowSize(76, 40);
            Console.SetCursorPosition(20, 20);
            Console.Clear();

            project_1.Presenation.GiaoDien gd = new GiaoDien();
            gd.MenuChinh();
            Console.ReadKey();
        }
    }
    /*class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetWindowSize(76, 40);
            Console.SetCursorPosition(20, 20);
            project_1.Presenation.MenuK_Hang mn = new MenuK_Hang();
            mn.MenuChinh();
        }

    }*/
}