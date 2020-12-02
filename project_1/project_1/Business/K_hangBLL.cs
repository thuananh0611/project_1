using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;


namespace project_1.Business
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IK_hangBLL
    public class K_HangBLL : IK_HangBLL
    {
        private IK_HangDAL khDA = new K_HangDAL();
        //Thực thi các yêu cầu
        public List<K_Hang> LayDSK_Hang()
        {
            return khDA.GetData();
        }
        public void ThemK_Hang(K_Hang kh)
        {
            if (kh.Makh != 0 && kh.Hoten != "")
            {
                kh.Hoten = project_1.Utility.CongCu.ChuanHoaXau(kh.Hoten);

                khDA.Insert(kh);
            }
            else
                throw new Exception("Du lieu sai");
        }
        public K_Hang LayK_Hang(int makh)
        {
            int i;
            List<K_Hang> list = khDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Makh == makh) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Khong ton tai ma nay");

        }
        public void XoaK_Hang(int makh)
        {
            int i;
            List<K_Hang> list = khDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Makh == makh) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                khDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void SuaK_Hang(K_Hang kh)
        {
            int i;
            List<K_Hang> list = khDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Makh == kh.Makh) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(kh, i);
                khDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai kh nay");
        }
        public List<K_Hang> TimK_Hang(K_Hang kh)
        {
            List<K_Hang> list = khDA.GetData();
            List<K_Hang> kq = new List<K_Hang>();
            //Voi gai tri ngam dinh ban dau
            if (kh.Makh == 0 && kh.Hoten == null && kh.Diachi == null)
            {
                kq = list;
            }
            //Tim theo tên khách hàng
            if (kh.Hoten != null && kh.Makh == 0 && kh.Diachi == null)
            {
                for (int i = 0; i < list.Count; ++i)

                    if (list[i].Hoten.IndexOf(kh.Hoten) >= 0)
                    {
                        kq.Add(new K_Hang(list[i]));
                    }
            }

            //Tim theo mã khách hàng
            else if (kh.Hoten == null && kh.Makh != 0 && kh.Diachi == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Makh == kh.Makh)
                    {
                        kq.Add(new K_Hang(list[i]));
                    }
            }
            //Tim ket hop giua ten va mã khach hang
            else if (kh.Hoten != null && kh.Makh != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Hoten.IndexOf(kh.Hoten) >= 0 && list[i].Makh == kh.Makh)
                    {
                        kq.Add(new K_Hang(list[i]));
                    }
            }

            else kq = null;
            return kq;
        }

    }
}
