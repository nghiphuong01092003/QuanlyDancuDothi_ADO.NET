using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyDancuDothi.ClassObject
{
    public class HoKhau
    {
        private string mahk;
        private string makschuho;
        private string hotenchuho;
        private string diachi;

        public string Mahk { get { return mahk; } set { mahk = value; } }
        public string MaKSchuho { get { return makschuho; } set { makschuho = value; } }
        public string Diachi { get { return diachi; } set { diachi = value; } }
        public string Hotenchuho { get { return hotenchuho; } set { hotenchuho = value; } }


        public HoKhau(string mahk, string makschuho, string hotenchuho, string diachi)
        {
            this.mahk = mahk;
            this.makschuho = makschuho;
            this.hotenchuho = hotenchuho;
            this.diachi = diachi;
        }
    }
}
