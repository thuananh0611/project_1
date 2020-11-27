using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;


namespace project_1.Business
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại INha_CCBLL
    public class Nha_CCBLL : INha_CCBLL
    {
        private INha_CCDAL nccDA = new Nha_CCDAL();
        //Thực thi các yêu cầu
        public List<Nha_CC> LayDSNha_CC()
        {
            return nccDA.GetData();
        }
        public void ThemNha_CC(Nha_CC ncc)
        {
            if (ncc.Mancc != "" && ncc.Tenncc != "")
            {
                ncc.Mancc = project_1.Utility.CongCu.ChuanHoaXau(ncc.Mancc);
                ncc.Tenncc = project_1.Utility.CongCu.ChuanHoaXau(ncc.Tenncc);
                nccDA.Insert(ncc);
            }
            else
                throw new Exception("Du lieu sai");
        }
        public Nha_CC LayNha_CC(string mancc)
        {
            int i;
            List<Nha_CC> list = nccDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mancc == mancc) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Khong ton tai ma nay");

        }
        public void XoaNha_CC(string mancc)
        {
            int i;
            List<Nha_CC> list = nccDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mancc == mancc) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                nccDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void SuaNha_CC(Nha_CC ncc)
        {
            int i;
            List<Nha_CC> list = nccDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mancc == ncc.Mancc) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(ncc, i);
                nccDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai nha cc nay");
        }
        public List<Nha_CC> TimNha_CC(Nha_CC ncc)
        {
            List<Nha_CC> list = nccDA.GetData();
            List<Nha_CC> kq = new List<Nha_CC>();
            //Voi gai tri ngam dinh ban dau
            if (ncc.Mancc == null && ncc.Tenncc == null && ncc.Diachi == null)
            {
                kq = list;
            }
            //Tim theo tên nha cung cap
            if (ncc.Mancc == null && ncc.Tenncc != null && ncc.Diachi == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Tenncc.IndexOf(ncc.Tenncc) >= 0)
                    {
                        kq.Add(new Nha_CC(list[i]));
                    }
            }

            //Tim theo mã nha cung cap
            else if (ncc.Mancc != null && ncc.Tenncc == "" && ncc.Diachi == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Mancc.IndexOf(ncc.Mancc) >= 0)
                    {
                        kq.Add(new Nha_CC(list[i]));
                    }
            }
            //Tim ket hop giua tên va mã nha cung cap
            else if (ncc.Mancc != null && ncc.Tenncc != "" && ncc.Diachi == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Mancc.IndexOf(ncc.Mancc) >= 0 && list[i].Tenncc.IndexOf(ncc.Mancc) >= 0)
                    {
                        kq.Add(new Nha_CC(list[i]));
                    }
            }

            else kq = null;
            return kq;
        }

       
    }
}
