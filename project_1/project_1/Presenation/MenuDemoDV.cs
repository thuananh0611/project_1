using System;
using project_1.Utility;
using System.Text;
namespace project_1.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuDemoDV : Menu
    {
        public MenuDemoDV(string[] mn) : base(mn) { }
        public override void ThucHien(int vitri)
        {
            FormDichVu dichvu = new FormDichVu();
            switch (vitri)
            {
                case 0:
                    dichvu.Nhap();
                    break;
                case 1:
                    dichvu.Tim();
                    break;
                case 2:
                    dichvu.Xoa();
                    break;
                case 3:
                    dichvu.SuaDichVu();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
