using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;
namespace project_1.Business
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface INha_CCBLL
    {
        List<Nha_CC> LayDSNha_CC();
        void ThemNha_CC(Nha_CC ncc);
        void XoaNha_CC(string mancc);
        void SuaNha_CC(Nha_CC ncc);
        List<Nha_CC> TimNha_CC(Nha_CC ncc);

        Nha_CC LayNha_CC(string mancc);
    }
}
