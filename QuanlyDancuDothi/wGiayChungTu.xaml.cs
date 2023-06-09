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
    /// Interaction logic for wGiayChungTu.xaml
    /// </summary>
    public partial class wGiayChungTu : Window
    {
        KiemTraDuLieu kt = new KiemTraDuLieu();
        CongDanDAO cdDao = new CongDanDAO();
        ChungTuDAO ctDao = new ChungTuDAO();
        public wGiayChungTu()
        {
            InitializeComponent();
        }
        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btn_DienTT_ChungTu_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_chungtu_cccd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                txt_chungtu_hoten.Text = dataTable.Rows[0]["HoTen"].ToString().Trim();
                dtp_chungtu_ngaysinh.Text = dataTable.Rows[0]["NgaySinh"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_Them_ThongTin_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_chungtu_cccd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                if (kt.checkThemChungTu(txt_chungtu_hoten, txt_chungtu_cccd, dtp_chungtu_ngaysinh, dtp_chungtu_ngaymat, txt_chungtu_noimat, txt_chungtu_nguyennhan))
                {
                    GiayChungTu giayChungTu = new GiayChungTu(txt_chungtu_maso.Text, txt_chungtu_hoten.Text, txt_chungtu_cccd.Text, Convert.ToDateTime(dtp_chungtu_ngaysinh.Text.Trim()), Convert.ToDateTime(dtp_chungtu_ngaymat.Text.Trim()), txt_chungtu_noimat.Text, txt_chungtu_nguyennhan.Text);
                    ctDao.ThemThongTinChungTu(giayChungTu);
                }
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
    }
}
