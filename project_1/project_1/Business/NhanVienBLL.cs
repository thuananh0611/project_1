using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;


namespace project_1.Business
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại INhanVienBLL
    public class NhanVienBLL : INhanVienBLL
    {
        private INhanVienDAL nvDA = new NhanVienDAL();
        //Thực thi các yêu cầu
        public List<NhanVien> LayDSNhanVien()
        {
            return nvDA.GetData();
        }
        public void ThemNhanVien(NhanVien nv)
        {
            if (nv.Mnv != 0 && nv.Tennv != "")
            {
                nv.Mnv = nv.Mnv;
                nv.Tennv = project_1.Utility.CongCu.ChuanHoaXau(nv.Tennv);
                nvDA.Insert(nv);
            }
            else
                throw new Exception("Du lieu sai");
        }
        public NhanVien LayNhanVien(int mnv)
        {
            int i;
            List<NhanVien> list = nvDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mnv == mnv) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Khong ton tai ma nay");

        }
        public void XoaNhanVien(int mnv)
        {
            int i;
            List<NhanVien> list = nvDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mnv == mnv) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                nvDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void SuaNhanVien(NhanVien nv)
        {
            int i;
            List<NhanVien> list = nvDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mnv == nv.Mnv) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(nv, i);
                nvDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai nv nay");
        }
        public List<NhanVien> TimNhanVien(NhanVien nv)
        {
            List<NhanVien> list = nvDA.GetData();
            List<NhanVien> kq = new List<NhanVien>();
            //Voi gai tri ngam dinh ban dau
            if (nv.Mnv == 0 && nv.Tennv == null)
            {
                kq = list;
            }
            //Tim theo tên nhan vien
            if (nv.Tennv != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Tennv.IndexOf(nv.Tennv) >= 0)
                    {
                        kq.Add(new NhanVien(list[i]));
                    }
            }

            //Tim theo mã nhan vien
            else if (nv.Mnv != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Mnv >= 0)
                    {
                        kq.Add(new NhanVien(list[i]));
                    }
            }
            //Tim ket hop giua tên va mã loai nhan vien
            else if (nv.Mnv == 0 && nv.Tennv != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Mnv >= 0 && list[i].Tennv.IndexOf(nv.Tennv) >= 0)
                    {
                        kq.Add(new NhanVien(list[i]));
                    }
            }

            else kq = null;
            return kq;
        }
        public bool KT_MaNV(int mnv)
        {
            bool kt = false;
            List<NhanVien> list = nvDA.GetData();
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].Mnv == mnv)
                {
                    kt = true;
                    break;
                }
            }

            return kt;
        }


    }
}