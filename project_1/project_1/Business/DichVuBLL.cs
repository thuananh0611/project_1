using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;


namespace project_1.Business
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IDichVuBLL
    public class DichVuBLL : IDichVuBLL
    {
        private IDichVuDAL dvDA = new DichVuDAL();
        //Thực thi các yêu cầu
        public List<DichVu> LayDSDichVu()
        {
            return dvDA.GetData();
        }
        public void ThemDichVu(DichVu dv)
        {
            if (dv.Tendv != "" && dv.Donvi != "")
            {
                dv.Tendv = project_1.Utility.CongCu.ChuanHoaXau(dv.Tendv);
                dv.Donvi = project_1.Utility.CongCu.ChuanHoaXau(dv.Donvi);
                dvDA.Insert(dv);
            }
            else
                throw new Exception("Du lieu sai");
        }
        public DichVu LayDichVu(string madv)
        {
            int i;
            List<DichVu> list = dvDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Madv == madv) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Khong ton tai ma nay");

        }
        public void XoaDichVu(string madv)
        {
            int i;
            List<DichVu> list = dvDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Madv == madv) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                dvDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void SuaDichVu(DichVu dv)
        {
            int i;
            List<DichVu> list = dvDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Madv == dv.Madv) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(dv, i);
                dvDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai hs nay");
        }
        public List<DichVu> TimDichVu(DichVu dv)
        {
            List<DichVu> list = dvDA.GetData();
            List<DichVu> kq = new List<DichVu>();
            //Voi gai tri ngam dinh ban dau
            if (dv.Tendv == null && dv.Ml == null && dv.Madv == null)
            {
                kq = list;
            }
            //Tim theo tên dịch vụ
            if (dv.Tendv != null && dv.Madv == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Tendv.IndexOf(dv.Tendv) >= 0)
                    {
                        kq.Add(new DichVu(list[i]));
                    }
            }
            
            //Tim theo ma
            else if (dv.Tendv == null && dv.Madv != "")
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Madv.IndexOf(dv.Madv) >= 0)
                    {
                        kq.Add(new DichVu(list[i]));
                    }
            }
            //Tim ket hop giua ho ten va mã dịch vụ
            else if (dv.Tendv != null && dv.Madv != "")
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Tendv.IndexOf(dv.Tendv) >= 0 && list[i].Madv.IndexOf(dv.Madv) >= 0)
                    {
                        kq.Add(new DichVu(list[i]));
                    }
            }
            //Cac truong hop khac cac ban tu lam
            else kq = null;
            return kq;
        }
        
    }
}
