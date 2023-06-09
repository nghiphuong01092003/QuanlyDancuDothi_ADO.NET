using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyDancuDothi.ClassObject
{
    public class CongDan
    {
        private string hoten;
        private string gioitinh;
        private string cccd;
        private DateTime ngaysinh;
        private string noisinh;
        private string quoctich;
        private string dantoc;
        private string quequan;
        private string noiohientai;
        private string nccccd;
        private DateTime ngccccd;
        private string sdt;
        private string email;
        private string maks;

        public string Hoten { get { return hoten; } set { hoten = value; } }
        public string Gioitinh { get { return gioitinh; } set { gioitinh = value; } }
        public string Cccd { get { return cccd; } set { cccd = value; } }
        public DateTime Ngaysinh { get { return ngaysinh; } set { ngaysinh = value; } }
        public string Noisinh { get { return noisinh; } set { noisinh = value; } }
        public string Quoctich { get { return quoctich; } set { quoctich = value; } }
        public string Dantoc { get { return dantoc; } set { dantoc = value; } }
        public string Quequan { get { return quequan; } set { quequan = value; } }
        public string Noiohientai { get { return noiohientai; } set { noiohientai = value; } }
        public string Nccccd { get { return nccccd; } set { nccccd = value; } }
        public DateTime Ngccccd { get { return ngccccd; } set { ngccccd = value; } }
        public string Sdt { get { return sdt; } set { sdt = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Maks { get { return maks; } set { maks = value; } }
        public CongDan(string hoten, string gioitinh, string cccd, DateTime ngaysinh, string noisinh, string quoctich, string dantoc, string quequan, string noiohientai, string nccccd, DateTime ngccccd, string sdt, string email, string maks)
        {
            this.hoten = hoten;
            this.gioitinh = gioitinh;
            this.cccd = cccd;
            this.ngaysinh = ngaysinh;
            this.noisinh = noisinh;
            this.quoctich = quoctich;
            this.dantoc = dantoc;
            this.quequan = quequan;
            this.noiohientai = noiohientai;
            this.nccccd = nccccd;
            this.ngccccd = ngccccd;
            this.sdt = sdt;
            this.email = email;
            this.maks = maks;
        }
    }
}
