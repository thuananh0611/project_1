using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Entities
{
    public class NhanVien
    {
        #region Các thành phần dữ liệu
        private int mnv;
        private string tennv;
        private string diachi;
        private string sdt;
        #endregion

        #region Các thuộc tính
        public int Mnv
        {
            get { return mnv; }
            set
            {
                if (value != 0)
                    mnv = value;
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
            this.tennv = nv.tennv;
            this.diachi = nv.diachi;
            this.sdt = nv.sdt;
        }
        public NhanVien(int mnv, string tennv, string diachi, string sdt)
        {
            this.mnv = mnv;
            this.tennv = tennv;
            this.diachi = diachi;
            this.sdt = sdt;

        }
        #endregion
    }
}