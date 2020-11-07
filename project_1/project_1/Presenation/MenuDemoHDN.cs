using System;
using project_1.Utility;
using System.Text;
namespace project_1.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuDemoHDN : Menu
    {
        public MenuDemoHDN(string[] mn) : base(mn) { }
        public override void ThucHien(int vitri)
        {
            FormHD_Nhap hdn = new FormHD_Nhap();
            switch (vitri)
            {
                case 0:
                    hdn.Nhap();
                    break;
                case 1:
                    hdn.Tim();
                    break;
                case 2:
                    hdn.Xoa();
                    break;
                case 3:
                    hdn.SuaHD_Nhap();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
