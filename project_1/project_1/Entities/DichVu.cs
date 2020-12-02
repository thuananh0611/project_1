using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Entities
{
    public class DichVu
    {
        //khai báo các thông tin liên quan đến dịch vụ
        #region Các thành phần dữ liệu
        private int madv;
        private string tendv;
        private double gia;
        private string donvi;
        private string ngay;
        #endregion

        #region Các thuộc tính
        public int Madv
        {
            get { return madv; }
            set { if (value >= 0 ) madv = value; }
        }
        
        public string Tendv
        {
            get { return tendv; }
            set { tendv = value; }
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
        public DichVu() { }
        //Phương thức thiết lập sap chép
        public DichVu(DichVu dv)
        {
            this.madv = dv.madv;
            this.tendv = dv.tendv;
            this.gia = dv.gia;
            this.donvi = dv.donvi;
            this.ngay = dv.ngay;
        }
        public DichVu(int madv, string tendv, double gia, string donvi, string ngay)
        {
            this.madv = madv;
            this.tendv = tendv;
            this.gia = gia;
            this.donvi = donvi;
            this.ngay = ngay;
        }
        #endregion
    }
}