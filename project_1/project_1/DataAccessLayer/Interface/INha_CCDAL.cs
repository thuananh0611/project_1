using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;
namespace project_1.DataAccessLayer
{
    //Xác định các yêu cầu cần phait thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    public interface INha_CCDAL
    {
        List<Nha_CC> GetData();
        void Insert(Nha_CC ncc);
        void Update(List<Nha_CC> List);
    }
}