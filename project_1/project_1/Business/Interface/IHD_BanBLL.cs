using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;
namespace project_1.Business
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface IHD_BanBLL
    {
        List<HD_Ban> LayDSHD_Ban();
        void ThemHD_Ban(HD_Ban hdb);
        void XoaHD_Ban(int mhdb);
        void SuaHD_Ban(HD_Ban hdb);
        List<HD_Ban> TimHD_Ban(HD_Ban hdb);

        HD_Ban LayHD_Ban(int mhdb);
    }
}
