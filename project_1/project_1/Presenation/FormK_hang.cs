using System;
using System.Collections.Generic;
using System.IO;
using project_1.Utility;
using project_1.DataAccessLayer;
using System.Text;
using project_1.Entities;
using project_1.Business;
namespace FormK_Hang
{
    public class Nodekh
    {
        public K_Hang kh;
        public Nodekh link;
    }
    class DanhSachK_Hang
    {
        public Nodekh ds = new Nodekh(); //Danh sách KH
        int n; //Số kh
        #region Đọc dữ liệu từ tệp K_Hang.txt và đẩy vào danh sách móc nối đơn ds; Hiện thị
        public Nodekh doctep()
        {
            ds = null;
            try
            {
                StreamReader fr = File.OpenText("Data/K_Hang.txt");
                n = 0;
                Nodekh tg;
                string s; //biến lưu dữ liệu đọc được từng dòng của tệp
                string[] con; //các trường DL tách từ ds
                // d = 5 số trường DL, d = so dau #+ 1; đối tượng khách hàng có 5 trường dl
                con = new string[5];
                while ((s = fr.ReadLine()) != null) //lần lượt đọc hết tệp
                {
                    if (s.Length > 0)
                    {
                        con = s.Split('#');
                        tg = new Nodekh(); tg.kh = new K_Hang();
                        tg.kh.Makh = int.Parse(con[0]);
                        tg.kh.Hoten = con[1];
                        tg.kh.Diachi = con[2];
                        tg.kh.Ngaysinh = con[3];
                        tg.kh.Sdt = con[4];
                        //Thêm thứ tự vừa đọc được từ tệp vào ds Kh kh
                        n++;
                        if (ds == null) ds = tg;
                        else
                        {
                            tg.link = ds;
                            ds = tg;
                        }
                    }

                }

                fr.Close();

            }
            catch (FileNotFoundException e) { Console.WriteLine(e); }
            return ds;
        }
        #endregion
        public void hienthi()
        {
            Nodekh tg = new Nodekh(); tg = this.ds;
            Console.WriteLine("\n Mã KH\t\t\t Họ tên \t Ngày sinh \t Số điện thoại");
            if (tg != null)
            {
                while (tg != null)
                {
                    Console.WriteLine("{0, 8}\t{1,25}\t{2, 3}\t{3, 4}\t{4, 6}", tg.kh.Makh, tg.kh.Hoten, tg.kh.Diachi, tg.kh.Ngaysinh, tg.kh.Sdt);
                    //tg.kh.hienthi(tg.kh);
                    tg = tg.link;
                }

            }
            else Console.WriteLine("Danh sách trống");
        }
        #region Thêm khachhang và ghi vào cuối tệp K_Hang.
        public bool ismsKHtg(int makh, Nodekh tgkh)
        {
            bool ok1 = true;
            if (tgkh.kh != null)
                while (tgkh != null)
                {
                    if (tgkh.kh.Makh == makh) ok1 = false;
                    tgkh = tgkh.link;
                }
            return ok1;
        }
        public void Insert ()
        {
            Nodekh tg = new Nodekh();
            tg.kh = new K_Hang(); tg.link = null;
            
            int makh;
            bool ok1; //kiểm tra mã kh có bị trùng kh?
            do
            {
                Console.Write("Nhập mã khách hàng: ");
                makh = int.Parse(Console.ReadLine());
                tg = this.ds;
                ok1 = ismsKHtg(makh, tg);
                if (!ok1)
                    Console.WriteLine("Dữ liệu không hợp lệ: mã khách hàng đã có! Mời nhập lại");

            } while (!ok1);
            tg.kh.Makh = makh;
            Console.Write("Nhập họ tên: ");
            tg.kh.Hoten = Console.ReadLine();
            Console.Write("Nhập địa chỉ: ");
            tg.kh.Diachi = Console.ReadLine();
            Console.Write("Nhập ngày sinh: ");
            tg.kh.Ngaysinh = Console.ReadLine();
            Console.Write("Nhập số điện thoại: ");
            tg.kh.Sdt = Console.ReadLine();
            GhiThem(tg, "Data/K_Hang.txt"); //Ghi dữ liệu vào cuối tệp
            //Cập nhật kh thêm vào biến ds
            tg.link = ds;
            ds = tg;
        }
        //Ghi thêm thông tin vào cuối tệp
        public void GhiThem(Nodekh tg, string filename)
        {
            StreamWriter fw = File.AppendText(filename);
            while (tg != null)
            {
                fw.WriteLine("\n{0}#{1}#{2}#{3}#{4}", tg.kh.Makh, tg.kh.Hoten, tg.kh.Diachi, tg.kh.Ngaysinh, tg.kh.Sdt);
                tg = tg.link;
            }
            fw.Close();
        }
        public void GhiMoi(Nodekh kh, string filename)
        {
            Nodekh tg = ds;
            StreamWriter fw = File.CreateText(filename);
            while(tg != null)
            {
                fw.WriteLine("\n{0}#{1}#{2}#{3}#{4}", tg.kh.Makh, tg.kh.Hoten, tg.kh.Diachi, tg.kh.Ngaysinh, tg.kh.Sdt);
                tg = tg.link;
            }
            fw.Close();
        }
        #endregion
        #region Sửa/Xóa 1 thông tin khách hàng: tìm theo mã kh, nếu có thì sửa/xóa
        public void Update()
        {
            Console.Write("\n Nhập mã khách hàng cần tìm: ");
            int ma = int.Parse(Console.ReadLine());
            Nodekh ds = this.doctep(); //Đọc dl từ tệp và đẩy vào biến chưa ds
            Nodekh tmp = SearchMa(ma); //Tìm kh có mã cần tìm và trả về 1 node tmp; tmp = null nếu không thấy, != null nếu thấy
            if (tmp != null) //tìm thấy kh có mã cần tìm => b1: lưu dl cũ sang tệp back up lưu K_Hang_Backup; b2: sửa tròn ds; b3: rồi ghi vào tệp K_Hang
            {
                Nodekh tg = ds;
                //b1: ghi dl back up vào tệp
                DateTime dt = DateTime.Now;
                string filenamebackup = "K_hang" + dt.ToString("dd-MM-yyyy") + ".txt";
                GhiMoi(tg, filenamebackup);
                //b2: nhập tt cần sửa tg1 và sửa tt trong biến chứa ds. Note: không được sửa mã khách hàng
                K_Hang tg1 = new K_Hang();
                tg1.Makh = ma;
                //nhập nốt những trường dl khác
                Console.Write("Nhập họ tên: ");
                tg1.Hoten = Console.ReadLine();
                Console.Write("Nhập địa chỉ: ");
                tg1.Diachi = Console.ReadLine();
                Console.Write("Nhập ngày sinh: ");
                tg1.Ngaysinh = Console.ReadLine();
                Console.Write("Nhập số điện thoại: ");
                tg1.Sdt = Console.ReadLine();
                tmp.kh = new K_Hang(tg1);
                //b3: ghi dl mới vào tệp K_hang.txt, bỏ dl cũ đi
                GhiMoi(ds, "K_Hang.txt");
            }
            else Console.WriteLine("\n Không thấy KH có mã" + ma);
        }
        public void Delete()
        {
            Console.Write("\n Nhập mã khách hàng cần xóa: ");
            int ma = int.Parse(Console.ReadLine());
            Nodekh tmp = SearchMa(ma); //Tìm kh có mã cần tìm và trả về 1 node tmp; tmp == null nếu không thấy, != null nếu thấy
            if (tmp != null) //Tìm thấy khách hàng có mã cần tìm 
            {
                Nodekh tg = ds;
                //b1: ghi dl backup vào tệp
                DateTime dt = DateTime.Now;
                string filenamebackup = "K_Hang" + dt.ToString("dd-MM-yyyy") + ".txt";
                GhiMoi(tg, filenamebackup);
                //b2: xóa node tmp trong biến chưa ds. Xét đủ tmp ở đầu, ở giữa
                tg = ds;
                if (tmp == tg) //tmp ở đầu
                    tg = tg.link;
                else
                {
                    while (tg.link != tmp) //tìm node trước tmp
                    {
                        tg = tg.link;
                    }
                    if (tmp.link == null) //tmp ở cuối
                        tg.link = null;
                    else //tmp ở giữa
                        tg.link = tg.link.link;
                }
                //b3: ghi dl mới vào tệp K_Hang.txt, bỏ dl cũ đi
                GhiMoi(tg, "Data/K_Hang.txt");
            }
            else Console.WriteLine("\n Không thấy Kh có mã" + ma);
        }
        #endregion

        #region Tìm kiếm khachhang theo ten/ma: vitri(kieumang)_node(kieu dsmn)/null nếu thấy/ không thấy
        public Nodekh SearchMa(int ma)
        {
            Nodekh ok = null;
            Nodekh tg = ds;
            while (tg != null)
            {
                if (tg.kh.Makh == ma)
                {
                    ok = tg; tg.kh.hienthi(); break;
                }
                tg = tg.link;
            }
            return ok;
        }
        public void SearchTen(string ten)
        {
            Nodekh tg = ds;
            int d = 0;
            while (tg != null)
            {
                if (tg.kh.Hoten.IndexOf(ten) >= 0)
                {
                    tg.kh.hienthi(); d++;
                }
                tg = tg.link;
            }
            if (d == 0) Console.WriteLine("Không có khách hàng nào có tên" + ten);
        }
        #endregion
    }

}