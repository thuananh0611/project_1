using System;
using project_1.Utility;
using System.Text;
using System.Configuration;
using System.IO;
using project_1.Entities;
namespace project_1.DataAccessLayer
{
    class SanPhamDAL : ISanPhamDAL
    {
        //Xác định đường dẫn của tệp dữ liệu SanPham.txt
        private string txtfile = "SanPham.txt";
        //Lấy toàn bộ dữ liệu có trong file SanPham.txt đưa vào một danh sách
        public List<SanPham> GetData()
        {
            List<SanPham> list = new List<SanPham>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = project_1.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new SanPham(a[0], a[1], a[2], double.Parse(a[3]), a[4], DateTime.Parse(a[5]), int.Parse(a[6]), int.Parse(a[7])));

                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã sản phẩm trong bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int MaSP
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
        //Chèn một bản ghi sản phẩm vào tệp
        public void Insert(SanPham sp)
        {
            int msp = MaSP + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(msp + "#" + sp.Ml + "#" + sp.Tensp + "#" + sp.Gia + "#" + sp.Donvi + "#" + sp.Ngay + "#" + sp.Slnv + "#" + sp.Slhc);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<SanPham> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].Msp + "#" + list[i].Ml + "#" + list[i].Tensp + "#" + list[i].Gia + "#" + list[i].Donvi + "#" + list[i].Ngay + "#" + list[i].Slnv + "#" + list[i].Slhc);
            fwrite.Close();
        }
    }
}