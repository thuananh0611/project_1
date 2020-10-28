using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;
namespace project_1.DataAccessLayer
{
    //Xác định các yêu cầu cần phait thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    public interface INhanVienDAL
    {
        List<NhanVien> GetData();
        void Insert(NhanVien nv);
        void Update(List<NhanVien> List);
    }
}