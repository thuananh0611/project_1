using System;
using System.Collections;
using System.Text;
using project_1.Utility;
using project_1.Entities;

namespace project_1.Business.Interface
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface IN_ViênBLL
    {
        List<N_Vien> LayDSNhanVien();
        void ThemNhanVien(N_Vien nv);
        void XoaNhanVien(string manv);
        void SuaNhanVien(N_Vien nv);
        List<N_Vien> TimNhanVien(N_Vien nv);
        N_Vien LayNhanVien(string manv);
    }
}
