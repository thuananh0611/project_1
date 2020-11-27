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
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại INhanVienBLL
    public class N_ViênBLL : IN_ViênBLL
    {
        private IN_ViênDAL nvDAL = new N_ViênDAL();
        public List<N_Vien> LayDSNhanVien()
        {
            return nvDAL.GetData();
        }
        public void ThemNhanVien(N_Vien nv)
        {
            if (nv.tenNV != "" && nv.ngaySinh != "" && nv.gioiTinh != "" && nv.diaChi != "" && nv.soDT != "" && nv.loaiNV != "")
            {
                nv.tenNV = CongCu.ChuanHoaXau(nv.tenNV);
                nv.ngaySinh = CongCu.CatXau(nv.ngaySinh);
                nv.gioiTinh = CongCu.ChuanHoaXau(nv.gioiTinh);
                nv.diaChi = CongCu.ChuanHoaXau(nv.diaChi);
                nv.soDT = CongCu.CatXau(nv.soDT);
                nv.loaiNV = CongCu.HoaDau(nv.loaiNV);
                nvDAL.Insert(nv);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public N_Vien LayNhanVien(string manv)
        {
            int i;
            List<N_Vien> list = nvDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maNV == manv)
                    break;
            if (i < list.Count)
                return list[i];
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void XoaNhanVien(string manv)
        {
            int i;
            List<N_Vien> list = nvDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maNV == manv)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                nvDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaNhanVien(N_Vien nv)
        {
            int i;
            List<N_Vien> list = nvDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maNV == nv.maNV)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(nv, i);
                nvDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public List<N_Vien> TimNhanVien(N_Vien nv)
        {
            List<N_Vien> list = nvDAL.GetData();
            List<N_Vien> kq = new List<N_Vien>();
            if (nv.maNV == null && nv.tenNV == null)
            {
                kq = list;
            }
            if (nv.tenNV != null && nv.maNV == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].tenNV.IndexOf(nv.tenNV) >= 0)
                        kq.Add(new N_Vien(list[i]));
            }
            else if (nv.tenNV == null && nv.maNV != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maNV == nv.maNV)
                        kq.Add(new N_Vien(list[i]));
            }
            else
                kq = null;
            return kq;
        }
        public bool KT_MaNhanVien(string manv)
        {
            List<N_Vien> list = nvDAL.GetData();
            Node<N_Vien> tmp = list.L;
            bool kt = false;
            while (tmp != null)
            {
                if (tmp.Info.maNV == manv)
                {
                    kt = true;
                    break;
                }
                else
                    tmp = tmp.Link;
            }
            return kt;
        }
        public bool KT_TenNhanVien(string tennv)
        {
            List<N_Vien> list = nvDAL.GetData();
            Node<N_Vien> tmp = list.L;
            bool kt = false;
            while (tmp != null)
            {
                if (tmp.Info.tenNV == tennv)
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
