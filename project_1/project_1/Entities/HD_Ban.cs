using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Entities
{
    public class HD_Ban
    {
        #region Các thành phần dữ liệu
        private int mhdb;
        private int manv;
        private string tenhd;
        private int mdv;
        private int makh;
        private double thanhtien;
        private double vat;
        #endregion

        #region Các thuộc tính
        
        public int Mhdb
        {
            get { return mhdb; }
            set { if (value != 0) mhdb = value; }
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
        
        public int Mdv
        {
            get { return mdv; }
            set { if (value != 0) mdv = value; }
        }
        public int Makh
        {
            get { return makh; }
            set { if (value != 0) makh = value; }
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
            this.mhdb = hdb.mhdb;
            this.manv = hdb.manv;
            this.tenhd = hdb.tenhd;
            this.mdv = hdb.mdv;
            this.makh = hdb.makh;
            this.thanhtien = hdb.thanhtien;
            this.vat = hdb.vat;
        }
        public HD_Ban(int mhdb, int manv, string tenhd, int mdv, int makh, double thanhtien, double vat)
        {
            this.mhdb = mhdb;
            this.manv = manv;
            this.tenhd = tenhd;
            this.mdv = mdv;
            this.makh = makh;
            this.thanhtien = thanhtien;
            this.vat = vat;
        }
        #endregion

    }
}
