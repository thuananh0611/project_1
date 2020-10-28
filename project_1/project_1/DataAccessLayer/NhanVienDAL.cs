using System;
using project_1.Utility;
using System.Text;
using System.Configuration;
using System.IO;
using project_1.Entities;
namespace project_1.DataAccessLayer
{
    class NhanVienDAL : INhanVienDAL
    {
        //Xác định đường dẫn của tệp dữ liệu NhanVien.txt
        private string txtfile = "NhanVien.txt";
        //Lấy toàn bộ dữ liệu có trong file NhanVien.txt đưa vào một danh sách
        public List<NhanVien> GetData()
        {
            List<NhanVien> list = new List<NhanVien>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = project_1.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new NhanVien(a[0], a[1], a[2], a[3], a[4]));

                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã nhân viên trong bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int MaNV
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
        //Chèn một bản ghi nhân viên vào tệp
        public void Insert(NhanVien nv)
        {
            int mnv = MaNV + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(mnv + "#" + nv.Mlnv + "#" + nv.Tennv + "#" + nv.Diachi + "#" + nv.Sdt);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<NhanVien> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].Mnv + "#" + list[i].Mlnv + "#" + list[i].Tennv + "#" + list[i].Diachi + "#" + list[i].Diachi + "#" + list[i].Sdt);
            fwrite.Close();
        }
    }
}