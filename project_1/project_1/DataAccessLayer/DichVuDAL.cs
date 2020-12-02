using System;
using project_1.Utility;
using System.Text;
using System.Configuration;
using System.IO;
using project_1.Entities;
namespace project_1.DataAccessLayer
{
    class DichVuDAL : IDichVuDAL
    {
        //Xác định đường dẫn của tệp dữ liệu DichVu.txt
        private string txtfile = "Data/Dv.txt";
        //Lấy toàn bộ dữ liệu có trong file DichVu.txt đưa vào một danh sách
        public List<DichVu> GetData()
        {
            List<DichVu> list = new List<DichVu>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = project_1.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new DichVu(int.Parse(a[0]), a[1], double.Parse(a[2]), a[3], a[4]));

                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã dịch vụ trong bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int MaDV
        {
            get
            {
                StreamReader fread = File.OpenText(txtfile);
                string s = fread.ReadLine();
                string tmp = "";
                while (s != null)
                {
                    if (s != null) tmp = s;
                    s = fread.ReadLine();
                }
                fread.Close();
                if (tmp == "") return 0;
                else
                {
                    tmp = project_1.Utility.CongCu.ChuanHoaXau(tmp);
                    string[] a = tmp.Split('#');
                    return int.Parse(a[0]);
                }
            }
        }
        //Chèn một bản ghi khách hàng vào tệp
        public void Insert(DichVu dv)
        {
            int madv = MaDV + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(madv + "#" + dv.Tendv + "#" + dv.Gia + "#" + dv.Donvi + "#" + dv.Ngay);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<DichVu> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].Madv + "#" + list[i].Tendv + "#" + list[i].Gia + "#" + list[i].Donvi + "#" + list[i].Ngay);
            fwrite.Close();
        }
    }
}