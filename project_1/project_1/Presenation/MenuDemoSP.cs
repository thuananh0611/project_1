using System;
using project_1.Utility;
using System.Text;
namespace project_1.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuDemoSP : Menu
    {
        public MenuDemoSP(string[] mn) : base(mn) { }
        public override void ThucHien(int vitri)
        {
            FormSanPham sp = new FormSanPham();
            switch (vitri)
            {
                case 0:
                    sp.Nhap();
                    break;
                case 1:
                    sp.Tim();
                    break;
                case 2:
                    sp.Xoa();
                    break;
                case 3:
                    sp.SuaSanPham();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
