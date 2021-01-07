using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;
namespace project_1.Business
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface ICTHDNBLL
    {
        List<CTHDN> LayDSCTHDN();
        void ThemCTHDN(CTHDN cthdn);
        void XoaCTHDN(int mahdn);
        void SuaCTHDN(CTHDN cthdn);
        List<CTHDN> TimCTHDN(CTHDN cthdn);

        CTHDN LayCTHDN(int mahdn);
    }
}
