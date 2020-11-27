using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;


namespace project_1.Business
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại ISanPhamBLL
    public class SanPhamBLL : ISanPhamBLL
    {
        private ISanPhamDAL spDA = new SanPhamDAL();
        //Thực thi các yêu cầu
        public List<SanPham> LayDSSanPham()
        {
            return spDA.GetData();
        }
        public void ThemSanPham(SanPham sp)
        {
            if (sp.Msp != "" && sp.Tensp != "")
            {
                sp.Msp = project_1.Utility.CongCu.ChuanHoaXau(sp.Msp);
                sp.Tensp = project_1.Utility.CongCu.ChuanHoaXau(sp.Tensp);
                spDA.Insert(sp);
            }
            else
                throw new Exception("Du lieu sai");
        }
        public SanPham LaySanPham(string msp)
        {
            int i;
            List<SanPham> list = spDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Msp == msp) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Khong ton tai ma nay");

        }
        public void XoaSanPham(string msp)
        {
            int i;
            List<SanPham> list = spDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Msp == msp) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                spDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void SuaSanPham(SanPham sp)
        {
            int i;
            List<SanPham> list = spDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Msp == sp.Msp) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(sp, i);
                spDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai sp nay");
        }
        public List<SanPham> TimSanPham(SanPham sp)
        {
            List<SanPham> list = spDA.GetData();
            List<SanPham> kq = new List<SanPham>();
            //Voi gai tri ngam dinh ban dau
            if (sp.Msp == null && sp.Ml == null && sp.Tensp == null)
            {
                kq = list;
            }
            //Tim theo tên san pham
            if (sp.Msp == null && sp.Ml == null && sp.Tensp != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Tensp.IndexOf(sp.Tensp) >= 0)
                    {
                        kq.Add(new SanPham(list[i]));
                    }
            }

            //Tim theo ma san pham
            else if (sp.Msp != null && sp.Ml == null && sp.Tensp == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Msp.IndexOf(sp.Msp) >= 0)
                    {
                        kq.Add(new SanPham(list[i]));
                    }
            }
            //Tim ket hop giua ten va ma san pham
            else if (sp.Msp != null && sp.Ml == null && sp.Tensp != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Tensp.IndexOf(sp.Tensp) >= 0 && list[i].Msp.IndexOf(sp.Msp) >= 0)
                    {
                        kq.Add(new SanPham(list[i]));
                    }
            }

            else kq = null;
            return kq;
        }

    }
}
