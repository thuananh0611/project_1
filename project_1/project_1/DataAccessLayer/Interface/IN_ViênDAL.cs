using System;
using System.Collections;
using System.Text;
using project_1.Utility;
using project_1.Entities;

namespace project_1.DataAccessLayer.Interface
{
    //Xác định các yêu cầu cần phải thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    public interface IN_ViênDAL
    {
        List<N_Vien> GetData();
        void Insert(N_Vien nv);
        void Update(List<N_Vien> list);
    }
}
