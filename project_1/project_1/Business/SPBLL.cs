using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;


namespace project_1.Business
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IDichVuBLL
    public class SPBLL : ISPBLL
    {
        private ISPDAL spDA = new SPDAL();
        //Thực thi các yêu cầu
        public List<SP> LayDSSP()
        {
            return spDA.GetData();
        }
        public void ThemSP(SP sp)
        {

            if (sp.Manv == 1 && sp.Masp != 0 && sp.Tensp != "")
            {
                sp.Masp = sp.Masp;
                sp.Tensp = project_1.Utility.CongCu.ChuanHoaXau(sp.Tensp);
                spDA.Insert(sp);
            }
            else
                throw new Exception("Du lieu sai");
        }
        public SP LaySP(int masp)
        {
            int i;
            List<SP> list = spDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Masp == masp) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Khong ton tai ma nay");

        }
        public void XoaSP(int masp)
        {
            int i;
            List<SP> list = spDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Masp == masp) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                spDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void SuaSP(SP sp)
        {
            int i;
            List<SP> list = spDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Masp == sp.Masp) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(sp, i);
                spDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai dv nay");
        }
        public List<SP> TimSP(SP sp)
        {
            List<SP> list = spDA.GetData();
            List<SP> kq = new List<SP>();
            //Voi gai tri ngam dinh ban dau
            if (sp.Tensp == null && sp.Masp == 0)
            {
                kq = list;
            }
            //Tim theo tên dịch vụ
            if (sp.Tensp != null && sp.Masp == 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Tensp.IndexOf(sp.Tensp) >= 0)
                    {
                        kq.Add(new SP(list[i]));
                    }
            }

            //Tim theo ma
            else if (sp.Tensp == null && sp.Masp != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Masp >= 0)
                    {
                        kq.Add(new SP(list[i]));
                    }
            }
            //Tim ket hop giua ten va mã sản phẩm
            else if (sp.Tensp != null && sp.Masp != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Tensp.IndexOf(sp.Tensp) >= 0 && list[i].Masp >= 0)
                    {
                        kq.Add(new SP(list[i]));
                    }
            }

            else kq = null;
            return kq;
        }
        

        public bool KT_MaSP(int masp)
        {
            bool kt = false;
            List<SP> list = spDA.GetData();
            for (int i = 0; i < list.Count; ++i) 
            { 
                if (list[i].Masp == masp)
                {
                    kt = true;
                    break;
                }
            }

            return kt;
        }

    }
}
