using System;
using project_1.Utility;
using System.Text;
namespace project_1.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuDemoNCC : Menu
    {
        public MenuDemoNCC(string[] mn) : base(mn) { }
        public override void ThucHien(int vitri)
        {
            FormNha_CC ncc = new FormNha_CC();
            switch (vitri)
            {
                case 0:
                    ncc.Nhap();
                    break;
                case 1:
                    ncc.Tim();
                    break;
                case 2:
                    ncc.Xoa();
                    break;
                case 3:
                    ncc.SuaNha_CC();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
