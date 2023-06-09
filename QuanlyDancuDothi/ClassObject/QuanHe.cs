using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyDancuDothi.ClassObject
{
    public class QuanHe
    {
        private string maksnguoithan;
        private string quanhe;
        private string mahk;
        private string hoten;
        public string MaKSnguoithan { get { return maksnguoithan; } set { maksnguoithan = value; } }
        public string MaHK { get { return mahk; } set { mahk = value; } }
        public string Quanhe { get { return quanhe; } set { quanhe = value; } }
        public string Hoten { get { return hoten; } set { hoten = value; } }
        public QuanHe(string maksnguoithan, string quanhe, string mahk, string hoten)
        {
            this.maksnguoithan = maksnguoithan;
            this.quanhe = quanhe;
            this.mahk = mahk;
            this.hoten = hoten;
        }
    }
}
