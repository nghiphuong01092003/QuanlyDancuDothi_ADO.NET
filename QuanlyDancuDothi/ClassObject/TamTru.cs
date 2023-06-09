using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyDancuDothi.ClassObject
{
    public class TamTru
    {
        private string matt;
        private string cccd;
        private DateTime ngaydk;
        private string noidk;
        private string hoten;
        private DateTime ngaysinh;
        private string noicapcccd;
        private DateTime ngaycapcccd;
        private DateTime ngayden;
        private DateTime ngaydi;
        private string lydo;

        public string Matt { get { return matt; } set { matt = value; } }
        public string Cccd { get { return cccd; } set { cccd = value; } }
        public DateTime Ngaydk { get { return ngaydk; } set { ngaydk = value; } }
        public string Noidk { get { return noidk; } set { noidk = value; } }
        public string Hoten { get { return hoten; } set { hoten = value; } }
        public DateTime Ngaysinh { get { return ngaysinh; } set { ngaysinh = value; } }
        public string Noicapcccd { get { return noicapcccd; } set { noicapcccd = value; } }
        public DateTime Ngaycapcccd { get { return ngaycapcccd; } set { ngaycapcccd = value; } }
        public DateTime Ngayden { get { return ngayden; } set { ngayden = value; } }
        public DateTime Ngaydi { get { return ngaydi; } set { ngaydi = value; } }
        public string Lydo { get { return lydo; } set { lydo = value; } }
        public TamTru(string matt, string cccd, DateTime ngaydk, string noidk, string hoten, DateTime ngaysinh, string noicapcccd, DateTime ngaycapcccd, DateTime ngayden, DateTime ngaydi, string lydo)
        {
            this.matt = matt;
            this.cccd = cccd;
            this.ngaydk = ngaydk;
            this.noidk = noidk;
            this.hoten = hoten;
            this.ngaysinh = ngaysinh;
            this.noicapcccd = noicapcccd;
            this.ngaycapcccd = ngaycapcccd;
            this.ngayden = ngayden;
            this.ngaydi = ngaydi;
            this.lydo = lydo;
        }
    }
}
