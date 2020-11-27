using System;
using System.Collections;
using System.Text;
using System.IO;
using project_1.Utility;
using project_1.Entities;
using project_1.DataAccessLayer.Interface;
using System.Text.RegularExpressions;

namespace project_1.DataAccessLayer
{
    class N_ViênDAL : IN_ViênDAL
    {
        private string txtfile = "Data/N_Viên.txt";
        public List<N_Vien> GetData()
        {
            List<N_Vien> list = new List<N_Vien>();
            StreamReader sr = File.OpenText(txtfile);
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new N_Vien(a[0], a[1], a[2], a[3], a[4], a[5], a[6]));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public string maNV
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
                    return "NV0";
                else
                {
                    string[] a = tmp.Split('\t');
                    return a[0];
                }
            }
        }
        public void Insert(N_Vien nv)
        {
            int manv = CongCu.TachSo(maNV) + 1;
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine();
            sw.Write("NV" + manv + "\t" + nv.tenNV + "\t" + nv.ngaySinh + "\t" + nv.gioiTinh + "\t" + nv.diaChi + "\t" + nv.soDT + "\t" + nv.loaiNV);
            sw.Close();
        }
        public void Update(List<N_Vien> list)
        {
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maNV + "\t" + list[i].tenNV + "\t" + list[i].ngaySinh + "\t" + list[i].gioiTinh + "\t" + list[i].diaChi + "\t" + list[i].soDT + "\t" + list[i].loaiNV);
            sw.Close();
        }
    }
}
