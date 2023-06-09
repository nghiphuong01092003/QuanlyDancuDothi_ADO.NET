using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyDancuDothi.ClassObject
{
    public class TamVang
    {
        private string matv;
        private string cccd;
        private DateTime ngaydk;
        private string ncdi;
        private string ncden;
        private string hoten;
        private DateTime ngaysinh;
        private DateTime ngaycapcccd;
        private string noicapcccd;
        private DateTime ngaydi;
        private DateTime ngayve;
        private string lydo;
        public string Matv { get { return matv; } set { matv = value; } }
        public string Cccd { get { return cccd; } set { cccd = value; } }
        public DateTime Ngaydk { get { return ngaydk; } set { ngaydk = value; } }
        public string Ncdi { get { return ncdi; } set { ncdi = value; } }
        public string Ncden { get { return ncden; } set { ncden = value; } }
        public string Hoten { get { return hoten; } set { hoten = value; } }
        public DateTime Ngaysinh { get { return ngaysinh; } set { ngaysinh = value; } }
        public DateTime Ngaycapcccd { get { return ngaycapcccd; } set { ngaycapcccd = value; } }
        public string Noicapcccd { get { return noicapcccd; } set { noicapcccd = value; } }
        public DateTime Ngaydi { get { return ngaydi; } set { ngaydi = value; } }
        public DateTime Ngayve { get { return ngayve; } set { ngayve = value; } }
        public string Lydo { get { return lydo; } set { lydo = value; } }

        public TamVang(string matv, string cccd, DateTime ngaydk, string ncdi, string ncden, string hoten, DateTime ngaysinh, DateTime ngaycapcccd, string noicapcccd, DateTime ngaydi, DateTime ngayve, string lydo)
        {
            this.matv = matv;
            this.cccd = cccd;
            this.ngaydk = ngaydk;
            this.ncdi = ncdi;
            this.ncden = ncden;
            this.hoten = hoten;
            this.ngaysinh = ngaysinh;
            this.ngaycapcccd = ngaycapcccd;
            this.noicapcccd = noicapcccd;
            this.ngaydi = ngaydi;
            this.ngayve = ngayve;
            this.lydo = lydo;
        }
    }
}
