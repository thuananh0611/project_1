using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;
namespace project_1.Business
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface IHD_NhapBLL
    {
        List<HD_Nhap> LayDSHD_Nhap();
        void ThemHD_Nhap(HD_Nhap hdn);
        void XoaHD_Nhap(int mahdn);
        void SuaHD_Nhap(HD_Nhap hdn);
        List<HD_Nhap> TimHD_Nhap(HD_Nhap hdn);

        HD_Nhap LayHD_Nhap(int mahdn);
    }
}
