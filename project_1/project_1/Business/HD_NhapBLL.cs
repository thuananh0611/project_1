using System;
using project_1.Utility;
using System.Text;
using project_1.DataAccessLayer;
using project_1.Entities;


namespace project_1.Business
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IHD_NhapBLL
    public class HD_NhapBLL : IHD_NhapBLL
    {
        private IHD_NhapDAL hdnDA = new HD_NhapDAL();
        //Thực thi các yêu cầu
        public List<HD_Nhap> LayDSHD_Nhap()
        {
            return hdnDA.GetData();
        }
        public void ThemHD_Nhap(HD_Nhap hdn)
        {
            if (hdn.Mhdn != 0)
            {
                hdn.Mhdn = hdn.Mhdn;
                hdnDA.Insert(hdn);
            }
            else
                throw new Exception("Du lieu sai");
        }
        public HD_Nhap LayHD_Nhap(int mhdn)
        {
            int i;
            List<HD_Nhap> list = hdnDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mhdn == mhdn) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Khong ton tai ma nay");

        }
        public void XoaHD_Nhap(int mhdn)
        {
            int i;
            List<HD_Nhap> list = hdnDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Mhdn == mhdn) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                hdnDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void SuaHD_Nhap(HD_Nhap hdn)
        {
            List<HD_Nhap> list = hdnDA.GetData();
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].Mhdn == hdn.Mhdn)
                {
                    list[i].Manv = hdn.Manv;
                    list[i].Tenhd = hdn.Tenhd;
                    list[i].Ngay = hdn.Ngay;
                    list[i].Tongtien = hdn.Tongtien;
                    hdnDA.Update(list);
                }
                else
                {
                    IO.Writexy(list[i].Mhdn.ToString(), 5, 13); continue;
                }

                //if (i < list.Count)
                //{
                //    list.RemoveAt(i);
                //    list.Add(hdn, i);
                //    hdnDA.Update(list);
                //}
                //else
                //{
                //    //IO.Writexy(list[i].Mhdn.ToString(), 5, 13);
                //    throw new Exception("Khong ton tai hd nhap nay");

                //}
            }


        }
        public List<HD_Nhap> TimHD_Nhap(HD_Nhap hdn)
        {
            List<HD_Nhap> list = hdnDA.GetData();
            List<HD_Nhap> kq = new List<HD_Nhap>();
            //Voi gai tri ngam dinh ban dau
            if (hdn.Mhdn == 0 && hdn.Tenhd == null)
            {
                kq = list;
            }
            //Tim theo tên hóa đơn nhập
            if (hdn.Tenhd != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Tenhd.IndexOf(hdn.Tenhd) >= 0)
                    {
                        kq.Add(new HD_Nhap(list[i]));
                    }
            }

            //Tim theo mã hóa đơn nhập
            else if (hdn.Mhdn != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Mhdn >= 0)
                    {
                        kq.Add(new HD_Nhap(list[i]));
                    }
            }
            //Tim ket hop giua tên va mã hóa đơn
            else if (hdn.Tenhd != null && hdn.Mhdn != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Tenhd.IndexOf(hdn.Tenhd) >= 0 && list[i].Mhdn >= 0)
                    {
                        kq.Add(new HD_Nhap(list[i]));
                    }
            }

            else kq = null;
            return kq;
        }
        public bool KT_MaHDN(int mhdn)
        {
            bool kt = false;
            List<HD_Nhap> list = hdnDA.GetData();
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
        public double LayGN(int masp)
        {
            CTHDNDAL cthdnDAL = new CTHDNDAL();
            return cthdnDAL.LayGN(masp);
        }

        public double TongTien(int mhdn)
        {
            HD_NhapDAL hdnDAL = new HD_NhapDAL();
            return hdnDAL.TongTien(mhdn);
        }

    }
}
