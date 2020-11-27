using System;
using System.Collections;
using System.Text;
using project_1.Utility;
using project_1.Entities;

namespace project_1.Business.Interface
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface IHDBanBLL
    {
        List<HDBan> LayDSHDBan();
        void ThemHDBan(HDBan hdb);
        void XoaHDBan(string mahdb);
        void SuaHDBan(HDBan hdb);
        List<HDBan> TimHDBan(HDBan hdb);
        HDBan LayHDBan(string mahdb);
    }
}
