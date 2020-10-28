using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;
namespace project_1.DataAccessLayer
{
    //Xác định các yêu cầu cần phai thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    public interface ISanPhamDAL
    {
        List<SanPham> GetData();
        void Insert(SanPham sp);
        void Update(List<SanPham> List);
    }
}