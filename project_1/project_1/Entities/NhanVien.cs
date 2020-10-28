using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Entities
{
    public class NhanVien
    {
        #region Các thành phần dữ liệu
        private string mnv;
        private string mlnv;
        private string tennv;
        private string diachi ;
        private string sdt;
        #endregion

        #region Các thuộc tính
        public string Mnv
        {
            get { return mnv; }
            set
            {
                if (value != "")
                    mnv = value;
            }
        }
        public string Mlnv
        {
            get { return mlnv; }
            set
            {
                if (value != "")
                    mlnv = value;
            }
        }
        public string Tennv
        {
            get { return tennv; }
            set
            {
                if (value != "")
                    tennv = value;
            }
        }
        
        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        
        public string Sdt
        {
            get { return sdt; }
            set
            {
                if (value != "")
                    sdt = value;
            }
        }

        #endregion

        #region Các phương thức
        public NhanVien() { }
        //Phương thức thiết lập sao chép
        public NhanVien(NhanVien nv)
        {
            this.mnv = nv.mnv;
            this.mlnv = nv.mlnv;
            this.tennv = nv.tennv;
            this.diachi = nv.diachi;
            this.sdt = nv.sdt;
        }
        public NhanVien(string mnv, string mlnv, string tennv, string diachi, string sdt)
        {
            this.mnv = mnv;
            this.mlnv = mlnv;
            this.tennv = tennv;
            this.diachi = diachi;
            this.sdt = sdt;
            
        }
        #endregion
    }
}
