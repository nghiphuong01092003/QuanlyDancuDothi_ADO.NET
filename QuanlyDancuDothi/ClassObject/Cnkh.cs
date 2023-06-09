using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyDancuDothi.ClassObject
{
    public class Cnkh
    {
        private string macnkh;
        private string hotenvo;
        private string hotenchong;
        private DateTime ngaysinhvo;
        private DateTime ngaysinhchong;
        private string dantocvo;
        private string dantocchong;
        private string quoctichvo;
        private string quoctichchong;
        private string noicutruvo;
        private string noicutruchong;
        private string cccdvo;
        private string cccdchong;
        private string noidk;
        private DateTime ngaydk;
        public string Macnkh { get { return macnkh; } set { macnkh = value; } }
        public string Hotenvo { get { return hotenvo; } set { hotenvo = value; } }
        public string Hotenchong { get { return hotenchong; } set { hotenchong = value; } }
        public DateTime Ngaysinhvo { get { return ngaysinhvo; } set { ngaysinhvo = value; } }
        public DateTime Ngaysinhchong { get { return ngaysinhchong; } set { ngaysinhchong = value; } }
        public string Dantocvo { get { return dantocvo; } set { dantocvo = value; } }
        public string Dantocchong { get { return dantocchong; } set { dantocchong = value; } }
        public string Quoctichvo { get { return quoctichvo; } set { quoctichvo = value; } }
        public string Quoctichchong { get { return quoctichchong; } set { quoctichchong = value; } }
        public string Noicutruvo { get { return noicutruvo; } set { noicutruvo = value; } }
        public string Noicutruchong { get { return noicutruchong; } set { noicutruchong = value; } }
        public string Cccdvo { get { return cccdvo; } set { cccdvo = value; } }
        public string Cccdchong { get { return cccdchong; } set { cccdchong = value; } }
        public string Noidk { get { return noidk; } set { noidk = value; } }
        public DateTime Ngaydk { get { return ngaydk; } set { ngaydk = value; } }
        public Cnkh(string macnkh, string hotenvo, string hotenchong, DateTime ngaysinhvo, DateTime ngaysinhchong, string dantocvo, string dantocchong, string quoctichvo, string quoctichchong, string noicutruvo, string noicutruchong, string cccdvo, string cccdchong, string noidk, DateTime ngaydk)
        {
            this.macnkh = macnkh;
            this.hotenvo = hotenvo;
            this.hotenchong = hotenchong;
            this.ngaysinhvo = ngaysinhvo;
            this.ngaysinhchong = ngaysinhchong;
            this.dantocvo = dantocvo;
            this.dantocchong = dantocchong;
            this.quoctichvo = quoctichvo;
            this.quoctichchong = quoctichchong;
            this.noicutruvo = noicutruvo;
            this.noicutruchong = noicutruchong;
            this.cccdvo = cccdvo;
            this.cccdchong = cccdchong;
            this.noidk = noidk;
            this.ngaydk = ngaydk;
        }
    }
}
