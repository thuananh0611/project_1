using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Entities
{
    public class Nha_CC
    {
        #region Các thành phần dữ liệu
        private string mancc;
        private string tenncc;
        private string diachi;
        private string sdt;
        #endregion

        #region Các thuộc tính
        public string Mancc
        {
            get { return mancc; }
            set { if (value != "") mancc = value; }
        }
        public string Tenncc
        {
            get { return tenncc; }
            set { if (value != "") tenncc = value; }
        }
        public string Diachi
        {
            get { return diachi; }
            set { if (value != "") diachi = value; }
        }
        public string Sdt
        {
            get { return sdt; }
            set { if (value != "") sdt = value; }
        }
        #endregion

        #region Các phương thức
        public Nha_CC() { }
        //Phương thức thiết lập sao chép
        public Nha_CC(Nha_CC ncc)
        {
            this.mancc = ncc.mancc;
            this.tenncc = ncc.tenncc;
            this.diachi = ncc.diachi;
            this.sdt = ncc.sdt;
        }
        public Nha_CC(string mancc, string tenncc, string diachi, string sdt)
        {
            this.mancc = mancc;
            this.tenncc = tenncc;
            this.diachi = diachi;
            this.sdt = sdt;
        }
        #endregion
    }
}
