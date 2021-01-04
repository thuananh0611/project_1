using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;
namespace project_1.Business
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface ISPBLL
    {
        List<SP> LayDSSP();
        void ThemSP(SP sp);
        void XoaSP(int masp);
        void SuaSP(SP sp);
        List<SP> TimSP(SP sp);

        SP LaySP(int masp);
    }
}
