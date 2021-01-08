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
        
        //Chèn một bản ghi hóa đơn nhập vào tệp
        public void Insert(CTHDN cthdn)
        {
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine(cthdn.Mhdn + "#" + cthdn.Mancc + "#" + cthdn.Masp + "#" + cthdn.Gianhap + "#" + cthdn.Soluong + "#" + cthdn.Thanhtien);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<CTHDN> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].Mhdn + "#" + list[i].Mancc + "#" + list[i].Masp + "#" + list[i].Gianhap + "#" + list[i].Soluong + "#" + list[i].Thanhtien);
            fwrite.Close();
        }
        public double LayGN(int masp)
        {
            StreamReader sr = new StreamReader("Data/SP.txt");

            string s;
            double gn = 0;

            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('#');
                if (tmp[1] == masp.ToString())
                {
                    StreamReader sr1 = new StreamReader(txtfile);
                    string s1;
                    while ((s1 = sr1.ReadLine()) != null)
                    {
                        string[] tmp1 = s1.Split('#');
                        if (tmp1[2] == tmp[1])
                        {
                            string cc = tmp[3];
                            tmp1[3] = tmp[3];
                            gn = Convert.ToDouble(cc);
                        }
                    }
                    sr1.Close();
                }
            }
            sr.Close();
            return gn;
        }


    }
}