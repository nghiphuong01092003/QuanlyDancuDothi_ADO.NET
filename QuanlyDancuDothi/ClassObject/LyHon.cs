using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyDancuDothi.ClassObject
{
    public class LyHon
    {
        private string malh;
        private string macnkh;
        private string cccdnguoinopdon;
        private string hotennguoinopdon;
        private string cccdvo;
        private string hotenvo;
        private string cccdchong;
        private string hotenchong;
        private string noidk;
        private DateTime ngaydk;
        private string lydo;
        public string Malh { get { return malh; } set { malh = value; } }
        public string Macnkh { get { return macnkh; } set { macnkh = value; } }
        public string Cccdvo { get { return cccdvo; } set { cccdvo = value; } }
        public string Hotenvo { get { return hotenvo; } set { hotenvo = value; } }
        public string Cccdnguoinopdon { get { return cccdnguoinopdon; } set { cccdnguoinopdon = value; } }
        public string Hotennguoinopdon { get { return hotennguoinopdon; } set { hotennguoinopdon = value; } }
        public string Cccdchong { get { return cccdchong; } set { cccdchong = value; } }
        public string Hotenchong { get { return hotenchong; } set { hotenchong = value; } }
        public string Noidk { get { return noidk; } set { noidk = value; } }
        public DateTime Ngaydk { get { return ngaydk; } set { ngaydk = value; } }
        public string Lydo { get { return lydo; } set { lydo = value; } }
        public LyHon(string malh, string macnkh, string cccdnguoinopdon, string hotennguoinopdon, string cccdvo, string hotenvo, string cccdchong, string hotenchong, string noidk, DateTime ngaydk, string lydo)
        {
            this.malh = malh;
            this.macnkh = macnkh;
            this.cccdnguoinopdon = cccdnguoinopdon;
            this.hotennguoinopdon = hotennguoinopdon;
            this.cccdvo = cccdvo;
            this.hotenvo = hotenvo;
            this.cccdchong = cccdchong;
            this.hotenchong = hotenchong;
            this.noidk = noidk;
            this.ngaydk = ngaydk;
            this.lydo = lydo;
        }
    }
}
