using System;
using System.IO;
using System.Text;
using project_1.Business;
using project_1.DataAccessLayer;
using project_1.Entities;
using project_1.Utility;

namespace project_1.Presenation
{
    class FormThongKe
    {
        public void TongG()
        {
            Console.WriteLine("Tổng giá dịch vụ của Thẩm mỹ viện");
            Console.WriteLine("---------------------------------");
            StreamReader file = File.OpenText("Data/Dv.txt");
            string s = file.ReadLine();
            double g = 0;
            s = project_1.Utility.CongCu.CatXau(s);
            string[] a = s.Split('#');
            g += double.Parse(a[2]);
            Console.WriteLine(g);
        }
        
        public void TimNVHD()
        {
            Console.WriteLine("Nhân viên có địa chỉ ở Hải Dương");
            Console.WriteLine("--------------------------------");
            INhanVienBLL nvien = new NhanVienBLL();
            List<NhanVien> list = nvien.LayDSNhanVien();
            for(int i = 0; i <list.Count; i++)
            {
                if (list[i].Diachi == "Hải Dương")
                {
                    Console.WriteLine("{0}\t{1}\t{2}", list[i].Mnv, list[i].Tennv, list[i].Sdt);
                }    
            }
            Console.ReadKey();
        }
        private string txtfile = "Data/HD_Ban.txt";

        public void TimHDBM()
        {
            Console.WriteLine("Hóa đơn có giá trị lớn nhất");
            Console.WriteLine("---------------------------");
            IHD_BanBLL hdban = new HD_BanBLL();
            List<HD_Ban> list = hdban.LayDSHD_Ban();
            HD_Ban hdb = new HD_Ban();
            double Max = double.MinValue;
            for (int i = 0; i < list.Count; i++)
            {
                if (Max < list[i].Thanhtien)
                {
                    Max = list[i].Thanhtien;
                }
                
            }
            Console.WriteLine("Giá trị của hóa đơn bán lớn nhất là: {0} ", Max);
            StreamReader fread = File.OpenText(txtfile);
            /*string s = fread.ReadLine();
            if (s == Max.ToString())
            {
                s = project_1.Utility.CongCu.CatXau(s);
                string[] a = s.Split('#');
                Console.WriteLine("{0}\t{1}\t{2}", int.Parse(a[0]), a[2], a[3]);
            }
            s = fread.ReadLine();
            fread.Close();*/
            string s;
            string ten = "";
            int ma = 0;
            while ((s = fread.ReadLine()) != null)
            {
                String[] tmp = s.Split('#');
                if (tmp[5] == Max.ToString())
                {
                    ma = int.Parse(tmp[0]);
                    ten = tmp[2];
                }
            }
            Console.WriteLine("Mã hóa đơn\tTên hóa đơn");
            Console.WriteLine(ma.ToString() + "\t\t" + ten);
            fread.Close();
            
        }
    }
}
