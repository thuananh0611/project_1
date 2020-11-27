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
            private string ngaysinh;
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
        public string Ngaysinh
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
        public K_Hang(int makh, string hoten, string diachi, string ngaysinh, string sdt)
        {
            this.makh = makh;
            this.hoten = hoten;
            this.diachi = diachi;
            this.ngaysinh = ngaysinh;
            this.sdt = sdt;
        }
        
        public K_Hang nhap()
        {
            //Mã tự tăng
            //Mặc định mã kh không bị trùng
            K_Hang kh = new K_Hang();
            do
            {
                Console.Write("Nhập mã khách hàng: ");
                kh.Makh = int.Parse(Console.ReadLine());
            } while (kh.makh <= 0);
            do
            {
                Console.Write("Nhập họ và tên khách hàng: ");
                kh.Hoten = Console.ReadLine();
            } while (kh.hoten != null);
            do
            {
                Console.Write("Nhập địa chỉ: ");
                kh.Diachi = Console.ReadLine();
            } while (kh.diachi != null);
            do
            {
                Console.Write("Nhập ngày sinh khách hàng: ");
                kh.Ngaysinh = Console.ReadLine();
            } while (kh.ngaysinh != null);
            do
            {
                Console.Write("Nhập số điện thoại: ");
                kh.Sdt = Console.ReadLine();
            } while (kh.sdt != null);
            return kh;
        }
        public void hienthi()
        {
            Console.WriteLine("{0,8}\t{1,25}\t{2,3}\t{3,4}\t{4,6}", this.makh, this.hoten, this.diachi, this.ngaysinh, this.sdt);
        }
        #endregion
    }
}