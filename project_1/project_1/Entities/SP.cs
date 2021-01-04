using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Entities
{
    public class SP
    {
        //khai báo các thông tin liên quan đến dịch vụ
        #region Các thành phần dữ liệu
        private int manv;
        private int masp;
        private string tensp;
        private double gia;
        private string donvi;
        private string ngay;
        #endregion

        #region Các thuộc tính
        public int Manv
        {
            get { return manv; }
            set { if (value == 1) manv = value; }
        }
        public int Masp
        {
            get { return masp; }
            set { if (value >= 0) masp = value; }
        }

        public string Tensp
        {
            get { return tensp; }
            set { tensp = value; }
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
        public string Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }
        #endregion

        #region Các phương thức
        public SP() { }
        //Phương thức thiết lập sap chép
        public SP(SP sp)
        {
            this.manv = sp.manv;
            this.masp = sp.masp;
            this.tensp = sp.tensp;
            this.gia = sp.gia;
            this.donvi = sp.donvi;
            this.ngay = sp.ngay;
        }
        public SP(int manv,int masp, string tensp, double gia, string donvi, string ngay)
        {
            this.manv = manv;
            this.masp = masp;
            this.tensp = tensp;
            this.gia = gia;
            this.donvi = donvi;
            this.ngay = ngay;
        }
        #endregion
    }
}