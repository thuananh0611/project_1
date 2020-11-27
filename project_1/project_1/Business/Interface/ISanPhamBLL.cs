using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;
namespace project_1.Business
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface ISanPhamBLL
    {
        List<SanPham> LayDSSanPham();
        void ThemSanPham(SanPham sp);
        void XoaSanPham(string msp);
        void SuaSanPham(SanPham sp);
        List<SanPham> TimSanPham(SanPham sp);

        SanPham LaySanPham(string msp);
    }
}
