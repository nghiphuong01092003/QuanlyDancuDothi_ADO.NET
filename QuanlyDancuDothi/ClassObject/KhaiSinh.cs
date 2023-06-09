using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyDancuDothi.ClassObject
{
    public class KhaiSinh
    {
        private string maks;
        private string hotenks;
        private string gioitinh;
        private DateTime ngaysinh;
        private string noisinh;
        private string dantoc;
        private string quoctich;
        private string quequan;
        private string cha;
        private string me;
        private string nguoikhaisinh;
        private string quanhe;
        private DateTime ngaydk;
        private string noidk;
        public string Maks { get { return maks; } set { maks = value; } }
        public string HotenKS { get { return hotenks; } set { hotenks = value; } }
        public string Gioitinh { get { return gioitinh; } set { gioitinh = value; } }
        public DateTime Ngaysinh { get { return ngaysinh; } set { ngaysinh = value; } }
        public string Noisinh { get { return noisinh; } set { noisinh = value; } }
        public string Dantoc { get { return dantoc; } set { dantoc = value; } }
        public string Quoctich { get { return quoctich; } set { quoctich = value; } }
        public string Quequan { get { return quequan; } set { quequan = value; } }
        public string Cha { get { return cha; } set { cha = value; } }
        public string Me { get { return me; } set { me = value; } }
        public string Nguoikhaisinh { get { return nguoikhaisinh; } set { nguoikhaisinh = value; } }
        public string Quanhe { get { return quanhe; } set { quanhe = value; } }
        public DateTime Ngaydk { get { return ngaydk; } set { ngaydk = value; } }
        public string Noidk { get { return noidk; } set { noidk = value; } }
        public KhaiSinh(string maks, string hotenks, string gioitinh, DateTime ngaysinh, string noisinh, string dantoc, string quoctich, string quequan, string cha, string me, string nguoikhaisinh, string quanhe, DateTime ngaydk, string noidk)
        {
            this.maks = maks;
            this.hotenks = hotenks;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
            this.noisinh = noisinh;
            this.dantoc = dantoc;
            this.quoctich = quoctich;
            this.quequan = quequan;
            this.cha = cha;
            this.me = me;
            this.nguoikhaisinh = nguoikhaisinh;
            this.quanhe = quanhe;
            this.ngaydk = ngaydk;
            this.noidk = noidk;
        }
    }
}
