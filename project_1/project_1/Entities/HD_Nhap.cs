using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Entities
{
    public class HD_Nhap
    {
        #region Các thành phần dữ liệu
        private int mhdn;
        private int manv;
        private string tenhd;
        private string ngay;
        private double tongtien;
        #endregion

        #region Các thuộc tính
        public int Mhdn
        {
            get { return mhdn; }
            set { if (value != 0) mhdn = value; }
        }
        public int Manv
        {
            get { return manv; }
            set { if (value != 0) manv = value; }
        }
        public string Tenhd
        {
            get { return tenhd; }
            set { if (value != "") tenhd = value; }
        }
        
        public string Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }
        public double Tongtien
        {
            get { return tongtien; }
            set { if (value > 0) tongtien = value; }
        }
        #endregion

        #region Các phương thức
        public HD_Nhap() { }
        //Phương thức thiết lập sao chép
        public HD_Nhap(HD_Nhap hdn)
        {
            this.mhdn = hdn.mhdn;
            this.manv = hdn.manv;
            this.tenhd = hdn.tenhd;
            this.ngay = hdn.ngay;
            this.tongtien = hdn.tongtien;
        }
        public HD_Nhap(int mhdn, int manv, string tenhd, string ngay, double tongtien)
        {
            this.mhdn = mhdn;
            this.manv = manv;
            this.tenhd = tenhd;
            this.ngay = ngay;
            this.tongtien = tongtien;
        }
        #endregion
    }
}
