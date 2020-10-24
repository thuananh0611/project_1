using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Entities
{
    public class DichVu
    {
        //khai báo các thông tin liên quan đến dịch vụ
        #region Các thành phần dữ liệu
        private string madv;
        private string ml;
        private string tendv;
        private double gia;
        private string donvi;
        private DateTime ngay;
        #endregion

        #region Các thuộc tính
        public string Madv
        {
            get { return madv; }
            set { if (value != "") madv = value; }
        }
        public string Ml
        {
            get { return ml; }
            set { if (value != "") ml = value; }
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
        public DateTime Ngay
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
            this.ml = dv.ml;
            this.tendv = dv.tendv;
            this.gia = dv.gia;
            this.donvi = dv.donvi;
            this.ngay = dv.ngay;
        }
        public DichVu(string madv, string ml, string tendv, double gia, string donvi, DateTime ngay)
        {
            this.madv = madv;
            this.ml = ml;
            this.tendv = tendv;
            this.gia = gia;
            this.donvi = donvi;
            this.ngay = ngay;
        }
        #endregion
    }
}
