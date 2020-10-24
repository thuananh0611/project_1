using System;
using project_1.Utility;
using System.Text;
namespace Demo.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuDemo : Menu
    {
        public MenuDemo(string[] mn) : base(mn) { }
        public override void ThucHien(int vitri)
        {
            FormK_hang hocsinh = new FormK_hang();
            switch (vitri)
            {
                case 0:
                    hocsinh.Nhap();
                    break;
                case 1:
                    hocsinh.Tim();
                    break;
                case 2:
                    hocsinh.Xoa();
                    break;
                case 3:
                    hocsinh.SuaKhachHang();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
