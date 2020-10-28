using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;
namespace Demo.Business
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface IDichVuBLL
    {
        List<DichVu> LayDSDichVu();
        void ThemDichVu(DichVu dv);
        void XoaDichVu(int madv);
        void SuaDichVu(DichVu dv);
        List<DichVu> TimDichVu(DichVu dv);
        
        DichVu LayDichVu(int madv);
    }
}
