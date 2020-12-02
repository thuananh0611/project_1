using System;
using project_1.Utility;
using System.Text;
using System.Configuration;
using System.IO;
using project_1.Entities;
namespace project_1.DataAccessLayer
{
    class HD_BanDAL : IHD_BanDAL
    {
        //Xác định đường dẫn của tệp dữ liệu HD_Ban.txt
        private string txtfile = "Data/HD_Ban.txt";
        //Lấy toàn bộ dữ liệu có trong file HD_Ban.txt đưa vào một danh sách
        public List<HD_Ban> GetData()
        {
            List<HD_Ban> list = new List<HD_Ban>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = project_1.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new HD_Ban(int.Parse(a[0]), int.Parse(a[1]), a[2], int.Parse(a[3]), int.Parse(a[4]), double.Parse(a[5]), double.Parse(a[6])));
                    s = fread.ReadLine();
                }
            }
            fread.Close();
            return list;
        }
        //Lấy mã hóa đơn bán trong bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int MaHDB
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
        //Chèn một bản ghi hóa đơn bán vào tệp
        public void Insert(HD_Ban hdb)
        {
            int mhdb = MaHDB + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(mhdb + "#" + hdb.Manv + "#" + hdb.Tenhd + "#" + hdb.Manv + "#" + hdb.Makh + "#" + hdb.Thanhtien + "#" + hdb.VAT);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<HD_Ban> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].Mhdb + "#" + list[i].Manv + "#" + list[i].Tenhd + "#" + list[i].Mdv + "#" + list[i].Makh + "#" + list[i].Thanhtien + "#" + list[i].VAT);
            fwrite.Close();
        }
    }
}