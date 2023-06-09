using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyDancuDothi.ClassObject
{
    public class Thue
    {
        private string masothue;
        private string coquanthue;
        private string hoten;
        private string socmt_cccd;
        private DateTime ngaythaydoithongtingannhat;
        public string Masothue { get { return masothue; } set { masothue = value; } }
        public string Coquanthue { get { return coquanthue; } set { coquanthue = value; } }
        public string Hoten { get { return hoten; } set { hoten = value; } }
        public string Socmt_cccd { get { return socmt_cccd; } set { socmt_cccd = value; } }
        public DateTime Ngaythaydoithongtingannhat { get { return ngaythaydoithongtingannhat; } set { ngaythaydoithongtingannhat = value; } }
        public Thue(string masothue, string coquanthue, string hoten, string socmt_cccd, DateTime ngaythaydoithongtingannhat)
        {
            this.masothue = masothue;
            this.coquanthue = coquanthue;
            this.hoten = hoten;
            this.socmt_cccd = socmt_cccd;
            this.ngaythaydoithongtingannhat = ngaythaydoithongtingannhat;
        }
    }
}
