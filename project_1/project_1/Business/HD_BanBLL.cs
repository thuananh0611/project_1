using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;


namespace project_1.Business
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IHD_BanBLL
    public class HD_BanBLL : IHD_BanBLL
    {
        private IHD_BanDAL hdbDA = new HD_BanDAL();
        //Thực thi các yêu cầu
        public List<HD_Ban> LayDSHD_Ban()
        {
            return hdbDA.GetData();
        }
        public void ThemHD_Ban(HD_Ban hdb)
        {
            if ( hdb.Mhdb != 0)
            {
                hdbDA.Insert(hdb);
            }
            else
                throw new Exception("Du lieu sai");
        }
        public HD_Ban LayHD_Ban(int mhdb)
        {
            int i;
            List<HD_Ban> list = hdbDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mhdb == mhdb) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Khong ton tai ma nay");

        }
        public void XoaHD_Ban(int mhdb)
        {
            int i;
            List<HD_Ban> list = hdbDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mhdb == mhdb) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                hdbDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void SuaHD_Ban(HD_Ban hdb)
        {
            int i;
            List<HD_Ban> list = hdbDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mhdb == hdb.Mhdb) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(hdb, i);
                hdbDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai hd ban nay");
        }
        public List<HD_Ban> TimHD_Ban(HD_Ban hdb)
        {
            List<HD_Ban> list = hdbDA.GetData();
            List<HD_Ban> kq = new List<HD_Ban>();
            //Voi gai tri ngam dinh ban dau
            if (hdb.Mhdb == 0 && hdb.Tenhd == null)
            {
                kq = list;
            }
            //Tim theo tên hóa đơn bán
            if (hdb.Mhdb == 0 && hdb.Tenhd != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Tenhd.IndexOf(hdb.Tenhd) >= 0)
                    {
                        kq.Add(new HD_Ban(list[i]));
                    }
            }

            //Tim theo mã hóa đơn bán
            else if (hdb.Mhdb != 0 && hdb.Tenhd == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Mhdb >= 0)
                    {
                        kq.Add(new HD_Ban(list[i]));
                    }
            }
            //Tim ket hop giua tên va mã hóa đơn
            else if (hdb.Tenhd != null && hdb.Mhdb != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Tenhd.IndexOf(hdb.Tenhd) >= 0 && list[i].Mhdb >= 0)
                    {
                        kq.Add(new HD_Ban(list[i]));
                    }
            }

            else kq = null;
            return kq;
        }

    }
}
