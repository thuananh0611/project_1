using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Entities
{
    public class HD_Ban
    {
        #region Các thành phần dữ liệu
            private string mal;
            private string mhdb;
            private string manv;
            private string tenhd;
            private string msp;
            private string mdv;
            private string makh;
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
        public string Mdv
        {
            get { return mdv; }
            set { if (value != "") mdv = value; }
        }
        public string Makh
        {
            get { return makh; }
            set { if (value != "") makh = value; }
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
        public HD_Ban() { }
        //Phương thức thiết lập sao chép
        public HD_Ban(HD_Ban hdb)
        {
            this.mal = hdb.mal;
            this.mhdb = hdb.mhdb;
            this.manv = hdb.manv;
            this.tenhd = hdb.tenhd;
            this.msp = hdb.msp;
            this.mdv = hdb.mdv;
            this.makh = hdb.makh;
            this.thanhtien = hdb.thanhtien;
            this.vat = hdb.vat;
        }
        public HD_Ban(string mal, string mhdb, string manv, string tenhd, string msp, string mdv, string makh, double thanhtien, double vat)
        {
            this.mal = mal;
            this.mhdb = mhdb;
            this.manv = manv;
            this.tenhd = tenhd;
            this.msp = msp;
            this.mdv = mdv;
            this.makh = makh;
            this.thanhtien = thanhtien;
            this.vat = vat;
        }
        #endregion

    }
}
