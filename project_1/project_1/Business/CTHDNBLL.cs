using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;


namespace project_1.Business
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại ICTHDNBLL
    public class CTHDNBLL : ICTHDNBLL
    {
        private ICTHDNDAL cthdnDA = new CTHDNDAL();
        //Thực thi các yêu cầu
        public List<CTHDN> LayDSCTHDN()
        {
            return cthdnDA.GetData();
        }
        public void ThemCTHDN(CTHDN cthdn)
        {
            if (cthdn.Mhdn != 0 && cthdn.Mancc != 0 && cthdn.Masp != 0)
            {
                cthdn.Mhdn = cthdn.Mhdn;
                cthdn.Mancc = cthdn.Mancc;
                cthdn.Masp = cthdn.Masp;
                cthdnDA.Insert(cthdn);
            }
            else
                throw new Exception("Dữ liệu sai");
        }
        public CTHDN LayCTHDN(int mhdn)
        {
            int i;
            List<CTHDN> list = cthdnDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mhdn == mhdn) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Không tồn tại mã này");

        }
        public void XoaCTHDN(int mhdn)
        {
            int i;
            List<CTHDN> list = cthdnDA.GetData();
            for (i = 0; i < list.Count; ++i)
            { if (list[i].Mhdn == mhdn)
                {
                    list.RemoveAt(i);
                    i--;
                } }
            cthdnDA.Update(list);
            //if (i < list.Count)
            //{
            //    list.RemoveAt(i);
            //    cthdnDA.Update(list);
            //}
            //else
            //    throw new Exception("Không tồn tại mã này");
        }
        public void SuaCTHDN(CTHDN cthdn)
        {
            int i;
            List<CTHDN> list = cthdnDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mhdn == cthdn.Mhdn) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(cthdn, i);
                cthdnDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại chi tiết hdn này");
        }
        public List<CTHDN> TimCTHDN(CTHDN cthdn)
        {
            List<CTHDN> list = cthdnDA.GetData();
            List<CTHDN> kq = new List<CTHDN>();
            //Voi gia tri ngam dinh ban dau
            if (cthdn.Mhdn == 0 && cthdn.Mancc == 0)
            {
                kq = list;
            }
            //Tim theo mã hóa đơn nhập
            else if (cthdn.Mhdn != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Mhdn >= 0)
                    {
                        kq.Add(new CTHDN(list[i]));
                    }
            }
            else kq = null;
            return kq;
        }
        public bool KT_MaHDN(int mhdn)
        {
            bool kt = false;
            List<CTHDN> list = cthdnDA.GetData();
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].Mhdn == mhdn)
                {
                    kt = true;
                    break;
                }
            }

            return kt;
        }



    }
}
