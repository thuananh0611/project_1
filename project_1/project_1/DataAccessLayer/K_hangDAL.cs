using System;
using project_1.Utility;
using System.Text;
using System.Configuration;
using System.IO;
using project_1.Entities;
namespace project_1.DataAccessLayer
{
    class K_HangDAL : IK_HangDAL
    {
        //Xác định đường dẫn của tệp dữ liệu K_Hang.txt
        private string txtfile = "Data/K_Hang.txt";
        //Lấy toàn bộ dữ liệu có trong file K_Hang.txt đưa vào một danh sách
        public List<K_Hang> GetData()
        {
            List<K_Hang> list = new List<K_Hang>();
            StreamReader sr = File.OpenText(txtfile);
            var s = sr.ReadLine();
            while ( s != null)
            {


                if (s != "")
                {
                    s = project_1.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new K_Hang(int.Parse(a[0]), a[1], a[2], a[3], a[4]));
                    
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        //Lấy mã khách hàng trong bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int MaKH
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
        public void Insert(K_Hang kh)
        {
            int makh = MaKH + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(makh + "#" + kh.Hoten + "#" + kh.Diachi + "#" + kh.Ngaysinh + "#" + kh.Sdt);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<K_Hang> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].Makh + "#" + list[i].Hoten + "#" + list[i].Diachi + "#" + list[i].Ngaysinh + "#" + list[i].Sdt);
            fwrite.Close();
        }
    }
}