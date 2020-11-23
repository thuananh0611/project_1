using System;
using System.Collections;
using System.Text;
using project_1.Utility;
using project_1.Entities;

namespace project_1.Business.Interface
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface IK_HangBLL
    {
        List<K_Hang> LayDSKhachHang();
        void ThemKhachHang(K_Hang kh);
        void XoaKhachHang(string makh);
        void SuaKhachHang(K_Hang kh);
        List<K_Hang> TimKhachHang(K_Hang kh);
        K_Hang LayKhachHang(string makh);
    }
}