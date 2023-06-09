using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyDancuDothi.ClassObject
{
    public class GiayChungTu
    {
        private string mact;
        private string hoten;
        private string cccd;
        private DateTime ngaysinh;
        private DateTime ngaymat;
        private string noimat;
        private string nguyennhan;
        public string Mact { get { return mact; } set { mact = value; } }
        public string Hoten { get { return hoten; } set { hoten = value; } }
        public string Cccd { get { return cccd; } set { cccd = value; } }
        public DateTime Ngaysinh { get { return ngaysinh; } set { ngaysinh = value; } }
        public DateTime Ngaymat { get { return ngaymat; } set { ngaymat = value; } }
        public string Noimat { get { return noimat; } set { noimat = value; } }
        public string Nguyennhan { get { return nguyennhan; } set { nguyennhan = value; } }
        public GiayChungTu(string mact, string hoten, string cccd, DateTime ngaysinh, DateTime ngaymat, string noimat, string nguyennhan)
        {
            this.mact = mact;
            this.hoten = hoten;
            this.cccd = cccd;
            this.ngaysinh = ngaysinh;
            this.ngaymat = ngaymat;
            this.noimat = noimat;
            this.nguyennhan = nguyennhan;
        }
    }
}
