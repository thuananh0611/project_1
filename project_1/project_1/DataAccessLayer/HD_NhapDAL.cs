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
                    list.Add(new HD_Nhap(int.Parse(a[0]), int.Parse(a[1]), a[2], a[3], double.Parse(a[4])));

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
            fwrite.Write(mhdn + "#" +  hdn.Manv + "#"  + hdn.Tenhd + "#" + hdn.Ngay + "#" + hdn.Tongtien);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<HD_Nhap> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].Mhdn + "#" + list[i].Manv + "#" + list[i].Tenhd   + "#" + list[i].Ngay + "#" + list[i].Tongtien);
            fwrite.Close();
        }
        public double TongTien(int mhdn)
        {
            StreamReader sr = new StreamReader(txtfile);

            string s;
            double tongtien = 0;

            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('#');
                if (tmp[0] == mhdn.ToString())
                {
                    StreamReader sr1 = new StreamReader("Data/CTHDN.txt");
                    string s1;
                    while ((s1 = sr1.ReadLine()) != null)
                    {
                        string[] tmp1 = s1.Split('#');
                        if (tmp1[0] == tmp[0])
                        {
                            double tt = double.Parse(tmp1[5]);
                            tongtien += tt;
                        }
                    }
                    sr1.Close();
                }
            }
            sr.Close();
            return tongtien;
        }
        public double LayGN(int masp)
        {
            CTHDNDAL cthdnDAL = new CTHDNDAL();
            return cthdnDAL.LayGN(masp);
        }

    }
}