using QuanlyDancuDothi.ClassDAO;
using QuanlyDancuDothi.ClassObject;
using QuanlyDancuDothi.DBConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanlyDancuDothi
{
    /// <summary>
    /// Interaction logic for wDonLyHon.xaml
    /// </summary>
    public partial class wDonLyHon : Window
    {
        KiemTraDuLieu kt = new KiemTraDuLieu();
        LyHonDAO lhDao = new LyHonDAO();    
        CongDanDAO cdDao = new CongDanDAO();
        public wDonLyHon()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_DienTT_NguoiDK_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = lhDao.HienThiThongTinDonLyHon(txt_lyhon_cccdnguoinopdon.Text);
            if (dataTable.Rows.Count > 0)
            {
                txt_lyhon_hotennguoinopdon.Text = dataTable.Rows[0]["HoTenNguoiNopDon"].ToString().Trim();
                txt_lyhon_cccdvo.Text = dataTable.Rows[0]["CccdVo"].ToString().Trim();
                txt_lyhon_cccdchong.Text = dataTable.Rows[0]["CccdChong"].ToString().Trim();
                txt_lyhon_hotenchong.Text = dataTable.Rows[0]["HoTenChong"].ToString().Trim();
                txt_lyhon_hotenvo.Text = dataTable.Rows[0]["HoTenVo"].ToString().Trim();
                txt_lyhon_macnkh.Text = dataTable.Rows[0]["MaCnkh"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Không có thông tin về người này!");
            }
        }

        private void btn_Them_LyHon_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_lyhon_cccdnguoinopdon.Text);
            if (dataTable.Rows.Count > 0)
            {
                if (kt.checkThemLyHon(txt_lyhon_cccdnguoinopdon, txt_lyhon_hotennguoinopdon, txt_lyhon_cccdvo, txt_lyhon_hotenvo, txt_lyhon_cccdchong, txt_lyhon_hotenchong, txt_lyhon_noidk, dtp_lyhon_ngaydk, txt_lyhon_lydo))
                {
                    LyHon lyHon = new LyHon(txt_lyhon_malyhon.Text, txt_lyhon_macnkh.Text, txt_lyhon_cccdnguoinopdon.Text, txt_lyhon_hotennguoinopdon.Text, txt_lyhon_cccdvo.Text, txt_lyhon_hotenvo.Text, txt_lyhon_cccdchong.Text, txt_lyhon_hotenchong.Text, txt_lyhon_noidk.Text, Convert.ToDateTime(dtp_lyhon_ngaydk.Text.Trim()), txt_lyhon_lydo.Text);
                    lhDao.ThemThongTinLyHon(lyHon);
                }
            }
            else
            {
                MessageBox.Show("Không có thông tin về người này!");
            }
        }
    }
}
