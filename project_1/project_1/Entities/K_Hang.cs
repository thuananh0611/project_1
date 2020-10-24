using System;
using project_1.Utility;
using System.Text;

namespace project_1.Entities
{
    //Khai báo các thông tin liên quan đến khách hàng
    public class K_Hang
    {
        #region Các thành phần dữ liệu
            private int makh;
            private string hoten;
            private string diachi;
            private DateTime ngaysinh;
            private string sdt;
        #endregion

        #region Các thuộc tính
        public int Makh
        {
            get { return makh; }
            set
            {
                if (value >= 1)
                    makh = value;
            }
        }
        public string Hoten
        {
            get
            {
                return hoten;
            }
            set
            {
                if (value != "")
                    hoten = value;
            }
        }
        public string Diachi
        {
            get { return diachi; }
            set
            {
                if (value != "")
                    diachi = value;
            }
        }
        public DateTime Ngaysinh
        {
            get { return ngaysinh; }
            set
            {
                ngaysinh = value;
            }
        }
        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }
        #endregion

        #region Các phương thức
        public K_Hang() { }
        //Phương thức thiết lập sao chép
        public K_Hang(K_Hang kh)
        {
            this.makh = kh.makh;
            this.hoten = kh.hoten;
            this.diachi = kh.diachi;
            this.ngaysinh = kh.ngaysinh;
            this.sdt = kh.sdt;
        }
        public K_Hang(int makh, string hoten, string diachi, DateTime ngaysinh, string sdt)
        {
            this.makh = makh;
            this.hoten = hoten;
            this.diachi = diachi;
            this.ngaysinh = ngaysinh;
            this.sdt = sdt;
        }
        #endregion
    }
}