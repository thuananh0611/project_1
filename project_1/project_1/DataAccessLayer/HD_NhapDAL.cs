using System;
using project_1.Utility;
using System.Text;
using System.Configuration;
using System.IO;
using project_1.Entities;
namespace project_1.DataAccessLayer
{
    class HD_NhapDAL : IHD_NhapDAL
    {
        //Xác định đường dẫn của tệp dữ liệu HD_Nhap.txt
        private string txtfile = "Data/HD_Nhap.txt";
        //Lấy toàn bộ dữ liệu có trong file HD_Nhap.txt đưa vào một danh sách
        public List<HD_Nhap> GetData()
        {
            List<HD_Nhap> list = new List<HD_Nhap>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = project_1.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new HD_Nhap(int.Parse(a[0]), a[1], int.Parse(a[2]), int.Parse(a[3]),int.Parse(a[4]), a[5], double.Parse(a[6]), double.Parse(a[7]), double.Parse(a[8])));

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
        public void Insert(HD_Nhap hdn)
        {
            int mhdn = MaHDN + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(mhdn + "#" + hdn.Tenhd + "#" + hdn.Manv + "#" + "#" + hdn.Sl + "#" + hdn.Mancc + hdn.Donvi + "#" + hdn.Gianhap + "#" + hdn.VAT + "#" + hdn.Thanhtien);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<HD_Nhap> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.Write(list[i].Mhdn + "#" + list[i].Tenhd + "#" + list[i].Manv + "#"  + list[i].Sl + "#" + list[i].Mancc + list[i].Donvi + "#" + list[i].Gianhap + "#" + list[i].VAT + "#" + list[i].Thanhtien);
            fwrite.Close();
        }
    }
}