using System;
using project_1.Utility;
using System.Text;
namespace project_1.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuDemoNV : Menu
    {
        public MenuDemoNV(string[] mn) : base(mn) { }
        public override void ThucHien(int vitri)
        {
            FormNhanVien nv = new FormNhanVien();
            switch (vitri)
            {
                case 0:
                    nv.Nhap();
                    break;
                case 1:
                    nv.Tim();
                    break;
                case 2:
                    nv.Xoa();
                    break;
                case 3:
                    nv.SuaNhanVien();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
