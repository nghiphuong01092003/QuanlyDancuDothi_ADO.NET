using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyDancuDothi.ClassObject
{
    public class DangNhap
    {
        private string tendangnhap;
        private string matkhau;

        public string Tendangnhap { get { return tendangnhap; } set { tendangnhap = value; } }
        public string Matkhau { get { return matkhau; } set { matkhau = value; } }
        public DangNhap(string tendangnhap, string matkhau)
        {
            this.tendangnhap = tendangnhap;
            this.matkhau = matkhau;
        }
    }
}
