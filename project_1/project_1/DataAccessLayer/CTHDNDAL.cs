using System;
using project_1.Utility;
using System.Text;
using System.Configuration;
using System.IO;
using project_1.Entities;
namespace project_1.DataAccessLayer
{
    class CTHDNDAL : ICTHDNDAL
    {
        //Xác định đường dẫn của tệp dữ liệu CTHDN.txt
        private string txtfile = "Data/CTHDN.txt";
        //Lấy toàn bộ dữ liệu có trong file CTHDN.txt đưa vào một danh sách
        public List<CTHDN> GetData()
        {
            List<CTHDN> list = new List<CTHDN>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = project_1.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new CTHDN(int.Parse(a[0]), int.Parse(a[1]), int.Parse(a[2]), double.Parse(a[3]), int.Parse(a[4]), double.Parse(a[5])));

                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã hóa đơn nhập trong bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int MaHDN
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
        //Chèn một bản ghi hóa đơn nhập vào tệp
        public void Insert(CTHDN cthdn)
        {
            int mhdn = MaHDN + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(mhdn + "#" + cthdn.Mancc + cthdn.Masp + "#" + cthdn.Gianhap + "#" + cthdn.Gianhap + "#" + cthdn.Thanhtien);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<CTHDN> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.Write(list[i].Mhdn + "#" + list[i].Mancc + list[i].Masp + "#" + list[i].Gianhap + "#" + list[i].Gianhap + "#" + list[i].Thanhtien);
            fwrite.Close();
        }
    }
}