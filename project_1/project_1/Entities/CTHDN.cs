using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Entities
{
    public class CTHDN
    {
        #region Các thành phần dữ liệu
        private int mhdn;
        private int mancc;
        private int masp;
        private int soluong;
        private double gianhap;
        private double thanhtien;
        #endregion

        #region Các thuộc tính
        public int Mhdn
        {
            get { return mhdn; }
            set { if (value > 0) mhdn = value; }
        }
        public int Mancc
        {
            get { return mancc; }
            set { if (value > 0) mancc = value; }
        }
        public int Masp
        {
            get { return masp; }
            set { if (value > 0) masp = value; }
        }
        
        public double Gianhap
        {
            get { return gianhap; }
            set { if (value > 0) gianhap = value; }
        }
        public int Soluong
        {
            get { return soluong; }
            set { if (value > 0) soluong = value; }
        }
        public double Thanhtien
        {
            get { return thanhtien = gianhap * soluong; }
            set { if (value > 0) thanhtien = value; }
        }
        #endregion

        #region Các phương thức
        public CTHDN() { }
        //Phương thức thiết lập sao chép
        public CTHDN(CTHDN cthdn)
        {
            this.mhdn = cthdn.mhdn;
            this.mancc = cthdn.mancc;
            this.masp = cthdn.masp;
            this.gianhap = cthdn.gianhap;
            this.soluong = cthdn.soluong;
            this.thanhtien = cthdn.thanhtien;
        }
        public CTHDN(int mhdn, int mancc, int masp, double gianhap, int soluong, double thanhtien)
        {
            this.mhdn = mhdn;
            this.mancc = mancc;
            this.masp = masp;
            this.gianhap = gianhap;
            this.soluong = soluong;
            this.thanhtien = thanhtien;
        }
        #endregion
    }
}
