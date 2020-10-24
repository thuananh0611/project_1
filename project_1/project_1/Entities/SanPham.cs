using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Entities
{
    public class SanPham
    {
        #region Các thành phần dữ liệu
        private string msp;
        private string ml;
        private string tensp;
        private double gia;
        private string donvi;
        private DateTime ngay;
        private int slnv;
        private int slhc;
        #endregion

        #region Các thuộc tính
        public string Msp
        {
            get { return msp; }
            set
            {
                if (value != "")
                    msp = value;
            }
        }
        public string Ml
        {
            get { return ml; }
            set
            {
                if (value != "")
                    ml = value;
            }
        }
        public string Tensp
        {
            get { return tensp; }
            set
            {
                if (value != "")
                    tensp = value;
            }
        }
        public double Gia
        {
            get { return gia; }
            set { if (value > 0) gia = value; }
        }
        public string Donvi
        {
            get { return donvi; }
            set { donvi = value; }
        }
        public DateTime Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }
        public int Slnv
        {
            get { return slnv; }
            set
            {
                if (value >= 0)
                    slnv = value;
            }
        }
        public int Slhc
        {
            get { return slhc; }
            set
            {
                if (value >= 0)
                    slhc = value;
            }
        }
        #endregion

        #region Các phương thức
        public SanPham() { }
        //Phương thức thiết lập sao chép
        public SanPham(SanPham sp)
        {
            this.msp = sp.msp;
            this.ml = sp.ml;
            this.tensp = sp.tensp;
            this.gia = sp.gia;
            this.donvi = sp.donvi;
            this.ngay = sp.ngay;
            this.slnv = sp.slnv;
            this.slhc = sp.slhc;
        }
        public SanPham(string msp, string ml, string tensp, double gia, string donvi, DateTime ngay, int slnv, int slhc)
        {
            this.msp = msp;
            this.ml = ml;
            this.tensp = tensp;
            this.gia = gia;
            this.donvi = donvi;
            this.ngay = ngay;
            this.slnv = slnv;
            this.slhc = slhc;
        }
        #endregion
    }
}
