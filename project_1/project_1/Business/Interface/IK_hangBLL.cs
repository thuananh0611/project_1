using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;
namespace project_1.Business
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface IK_HangBLL
    {
        List<K_Hang> LayDSK_Hang();
        void ThemK_Hang(K_Hang kh);
        void XoaK_Hang(int makh);
        void SuaK_Hang(K_Hang kh);
        List<K_Hang> TimK_Hang(K_Hang kh);

        K_Hang LayK_Hang(int makh);
    }
}
