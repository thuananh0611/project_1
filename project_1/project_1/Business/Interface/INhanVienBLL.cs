﻿using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;
namespace project_1.Business
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface INhanVienBLL
    {
        List<NhanVien> LayDSNhanVien();
        void ThemNhanVien(NhanVien nv);
        void XoaNhanVien(string mnv);
        void SuaNhanVien(NhanVien nv);
        List<NhanVien> TimNhanVien(NhanVien nv);
        
        NhanVien LayNhanVien(string manv);
    }
}
