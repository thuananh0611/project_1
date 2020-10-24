using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Entities
{
    public class HD_Nhap
    {
        #region Các thành phần dữ liệu
        private string mal;
        private string mhdb;
        private string manv;
        private string tenhd;
        private string msp;
        private int sl;
        private string mancc;
        private string donvi;
        private double gianhap;
        private double thanhtien;
        private double vat;
        #endregion

        #region Các thuộc tính
        public string Mal
        {
            get { return mal; }
            set { if (value != "") mal = value; }
        }
        public string Mhdb
        {
            get { return mhdb; }
            set { if (value != "") mhdb = value; }
        }
        public string Manv
        {
            get { return manv; }
            set { if (value != "") manv = value; }
        }
        public string Tenhd
        {
            get { return tenhd; }
            set { if (value != "") tenhd = value; }
        }
        public string Msp
        {
            get { return msp; }
            set { if (value != "") msp = value; }
        }
        public int Sl
        {
            get { return sl; }
            set { if (value >= 0) sl = value; }
        }
        
        public string Mancc
        {
            get { return mancc; }
            set { if (value != "") mancc = value; }
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
            get { return thanhtien; }
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
            this.mal = hdn.mal;
            this.mhdb = hdn.mhdb;
            this.manv = hdn.manv;
            this.tenhd = hdn.tenhd;
            this.msp = hdn.msp;
            this.sl = hdn.sl;
            this.mancc = hdn.mancc;
            this.donvi = hdn.donvi;
            this.gianhap = hdn.gianhap;
            this.thanhtien = hdn.thanhtien;
            this.vat = hdn.vat;
        }
        public HD_Nhap(string mal, string mhdb, string manv, string tenhd, string msp, int sl, string mancc, string donvi, double gianhap, double thanhtien, double vat)
        {
            this.mal = mal;
            this.mhdb = mhdb;
            this.manv = manv;
            this.tenhd = tenhd;
            this.msp = msp;
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
