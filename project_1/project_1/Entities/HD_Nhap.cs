using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Entities
{
    public class HD_Nhap
    {
        #region Các thành phần dữ liệu
        private int mhdn;
        private string tenhd;
        private int manv;
        private int sl;
        private int mancc;
        private string donvi;
        private double gianhap;
        private double thanhtien;
        private double vat;
        #endregion

        #region Các thuộc tính
        public int Mhdn
        {
            get { return mhdn; }
            set { if (value != 0) mhdn = value; }
        }
        public string Tenhd
        {
            get { return tenhd; }
            set { if (value != "") tenhd = value; }
        }
        public int Manv
        {
            get { return manv; }
            set { if (value != 0) manv = value; }
        }
        public int Sl
        {
            get { return sl; }
            set { if (value >= 0) sl = value; }
        }

        public int Mancc
        {
            get { return mancc; }
            set { if (value != 0) mancc = value; }
        }
        public string Donvi
        {
            get { return donvi; }
            set { donvi = value; }
        }
        public double Gianhap
        {
            get { return gianhap; }
            set { if (value > 0) gianhap = value; }
        }
        public double Thanhtien
        {
            get { return thanhtien = sl * gianhap + vat ; }
            set { if (value > 0) thanhtien = value; }
        }
        public double VAT
        {
            get { return vat; }
            set { if (value > 0) vat = value; }
        }
        #endregion

        #region Các phương thức
        public HD_Nhap() { }
        //Phương thức thiết lập sao chép
        public HD_Nhap(HD_Nhap hdn)
        {
            this.mhdn = hdn.mhdn;
            this.tenhd = hdn.tenhd;
            this.manv = hdn.manv;
            this.sl = hdn.sl;
            this.mancc = hdn.mancc;
            this.donvi = hdn.donvi;
            this.gianhap = hdn.gianhap;
            this.thanhtien = hdn.thanhtien;
            this.vat = hdn.vat;
        }
        public HD_Nhap(int mhdn, string tenhd, int manv, int sl, int mancc, string donvi, double gianhap, double thanhtien, double vat)
        {
            this.mhdn = mhdn;
            this.tenhd = tenhd;
            this.manv = manv;
            this.sl = sl;
            this.mancc = mancc;
            this.donvi = donvi;
            this.gianhap = gianhap;
            this.thanhtien = thanhtien;
            this.vat = vat;
        }
        #endregion
    }
}
