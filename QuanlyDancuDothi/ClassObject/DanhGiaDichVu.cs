using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyDancuDothi.ClassObject
{
    public class DanhGiaDichVu
    {
        private string danhgia;
        private int tongquan;
        private int thuantien;
        private int dedang;
        private int chinhxac;
        private int trucquan;
        public string Danhgia { get { return danhgia; } set { danhgia = value; } }
        public int Tongquan { get { return tongquan; } set { tongquan = value; } }
        public int Thuantien { get { return thuantien; } set { thuantien = value; } }
        public int Dedang { get { return dedang; } set { dedang = value; } }
        public int Chinhxac { get { return chinhxac; } set { chinhxac = value; } }
        public int Trucquan { get { return trucquan; } set { trucquan = value; } }
        public DanhGiaDichVu(string danhgia, int tongquan, int thuantien, int dedang, int chinhxac, int trucquan)
        {
            this.danhgia = danhgia;
            this.tongquan = tongquan;
            this.thuantien = thuantien;
            this.dedang = dedang;
            this.chinhxac = chinhxac;
            this.trucquan = trucquan;
        }
    }
}
