using System;
using project_1.Utility;
using System.Text;
namespace project_1.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuDemo : Menu
    {
        public MenuDemo(string[] mn) : base(mn) { }
        public override void ThucHien(int vitri)
        {
            FormK_hang khachhang = new FormK_hang();
            switch (vitri)
            {
                case 0:
                    khachhang.Nhap();
                    break;
                case 1:
                    khachhang.Tim();
                    break;
                case 2:
                    khachhang.Xoa();
                    break;
                case 3:
                    khachhang.SuaKhachHang();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
