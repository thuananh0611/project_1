﻿using System;
using System.Collections.Generic;
using System.Text;

namespace project_1.Entities
{
    public class K_Hang
    {
        private string MaKH;
        private string TenKH;
        private string DiaChi;
        private string SoDT;

        public K_Hang()
        {
        }
        public K_Hang(string makh, string tenkh, string diachi, string sdt)
        {
            this.MaKH = makh;
            this.TenKH = tenkh;
            this.DiaChi = diachi;
            this.SoDT = sdt;
        }
        public K_Hang(K_Hang kh)
        {
            this.MaKH = kh.MaKH;
            this.TenKH = kh.TenKH;
            this.DiaChi = kh.DiaChi;
            this.SoDT = kh.SoDT;
        }

        public string maKH
        {
            get
            {
                return MaKH;
            }
            set
            {
                if (value != "")
                    MaKH = value;
            }
        }
        public string tenKH
        {
            get
            {
                return TenKH;
            }
            set
            {
                if (value != "")
                    TenKH = value;
            }
        }
        public string diaChi
        {
            get
            {
                return DiaChi;
            }
            set
            {
                if (value != "")
                    DiaChi = value;
            }
        }
        public string soDT
        {
            get
            {
                return SoDT;
            }
            set
            {
                if (value != "")
                    SoDT = value;
            }
        }
    }
}
