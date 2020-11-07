using System;
using project_1.Utility;
using System.Text;
namespace project_1.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuDemoHDB : Menu
    {
        public MenuDemoHDB(string[] mn) : base(mn) { }
        public override void ThucHien(int vitri)
        {
            FormHD_Ban hdb = new FormHD_Ban();
            switch (vitri)
            {
                case 0:
                    hdb.Nhap();
                    break;
                case 1:
                    hdb.Tim();
                    break;
                case 2:
                    hdb.Xoa();
                    break;
                case 3:
                    hdb.SuaHD_Ban();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
