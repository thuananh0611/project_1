using System;
using System.Collections;
using System.Text;
using System.IO;
using project_1.Utility;
using project_1.Entities;
using project_1.DataAccessLayer.Interface;

namespace project_1.DataAccessLayer
{
    class K_HangDAL : IK_HangDAL
    {
        private string txtfile = "Data/K_Hang.txt";
        public List<K_Hang> GetData()
        {
            List<K_Hang> list = new List<K_Hang>();
            StreamReader sr = File.OpenText(txtfile);
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new K_Hang(a[0], a[1], a[2], a[3]));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public string maKH
        {
            get
            {
                StreamReader sr = File.OpenText(txtfile);
                string s = sr.ReadLine();
                string tmp = "";
                while (s != null)
                {
                    if (s != "")
                        tmp = s;
                    s = sr.ReadLine();
                }
                sr.Close();
                if (tmp == "")
                    return "KH0";
                else
                {
                    string[] a = tmp.Split('\t');
                    return a[0];
                }
            }
        }
        public void Insert(K_Hang kh)
        {
            int makh = CongCu.TachSo(maKH) + 1;
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine();
            sw.Write("KH" + makh + "\t" + kh.tenKH + "\t" + kh.diaChi + "\t" + kh.soDT);
            sw.Close();
        }
        public void Update(List<K_Hang> list)
        {
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maKH + "\t" + list[i].tenKH + "\t" + list[i].diaChi + "\t" + list[i].soDT);
            sw.Close();
        }
    }
}
