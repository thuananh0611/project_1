using System;
using project_1.Utility;
using System.Text;
using System.Configuration;
using System.IO;
using project_1.Entities;
namespace project_1.DataAccessLayer
{
    class Nha_CCDAL : INha_CCDAL
    {
        //Xác định đường dẫn của tệp dữ liệu Nha_CC.txt
        private string txtfile = "Data/Nha_CC.txt";
        //Lấy toàn bộ dữ liệu có trong file Nha_CC.txt đưa vào một danh sách
        public List<Nha_CC> GetData()
        {
            List<Nha_CC> list = new List<Nha_CC>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = project_1.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new Nha_CC(int.Parse(a[0]), a[1], a[2], a[3]));

                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã nhà cung cấp trong bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int MaNCC
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
        //Chèn một bản ghi nhà cung cấp vào tệp
        public void Insert(Nha_CC ncc)
        {
            int mancc = MaNCC + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(mancc + "#" + ncc.Tenncc + "#" + ncc.Diachi + "#" + ncc.Sdt);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<Nha_CC> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].Mancc + "#" + list[i].Tenncc + "#" + list[i].Diachi + "#" + list[i].Sdt);
            fwrite.Close();
        }
    }
}