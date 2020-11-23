using System;
using System.Collections;
using System.Text;
using project_1.Utility;
using project_1.Entities;
using project_1.DataAccessLayer;
using project_1.DataAccessLayer.Interface;
using project_1.Business.Interface;

namespace project_1.Business
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IKhachHangBLL
    public class K_HangBLL : IK_HangBLL
    {
        private IK_HangDAL khDAL = new K_HangDAL();
        public List<K_Hang> LayDSKhachHang()
        {
            return khDAL.GetData();
        }
        public void ThemKhachHang(K_Hang kh)
        {
            if (kh.tenKH != "" && kh.diaChi != "" && kh.soDT != "")
            {
                kh.tenKH = CongCu.ChuanHoaXau(kh.tenKH);
                kh.diaChi = CongCu.ChuanHoaXau(kh.diaChi);
                kh.soDT = CongCu.CatXau(kh.soDT);
                khDAL.Insert(kh);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public K_Hang LayKhachHang(string makh)
        {
            int i;
            List<K_Hang> list = khDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maKH == makh)
                    break;
            if (i < list.Count)
                return list[i];
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void XoaKhachHang(string makh)
        {
            int i;
            List<K_Hang> list = khDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maKH == makh)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                khDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaKhachHang(K_Hang kh)
        {
            int i;
            List<K_Hang> list = khDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maKH == kh.maKH)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(kh, i);
                khDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public List<K_Hang> TimKhachHang(K_Hang kh)
        {
            List<K_Hang> list = khDAL.GetData();
            List<K_Hang> kq = new List<K_Hang>();
            if (kh.maKH == null && kh.tenKH == null)
            {
                kq = list;
            }
            if (kh.tenKH != null && kh.maKH == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].tenKH.IndexOf(kh.tenKH) >= 0)
                        kq.Add(new K_Hang(list[i]));
            }
            else if (kh.tenKH == null && kh.maKH != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maKH == kh.maKH)
                        kq.Add(new K_Hang(list[i]));
            }
            else
                kq = null;
            return kq;
        }
        public bool KT_MaKhachHang(string makh)
        {
            List<K_Hang> list = khDAL.GetData();
            Node<K_Hang> tmp = list.L;
            bool kt = false;
            while (tmp != null)
            {
                if (tmp.Info.maKH == makh)
                {
                    kt = true;
                    break;
                }
                else
                    tmp = tmp.Link;
            }
            return kt;
        }
        public bool KT_TenKhachHang(string tenkh)
        {
            List<K_Hang> list = khDAL.GetData();
            Node<K_Hang> tmp = list.L;
            bool kt = false;
            while (tmp != null)
            {
                if (tmp.Info.tenKH == tenkh)
                {
                    kt = true;
                    break;
                }
                else
                    tmp = tmp.Link;
            }
            return kt;
        }
    }
}
