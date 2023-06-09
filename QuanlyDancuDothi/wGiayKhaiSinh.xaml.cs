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
    /// Interaction logic for wGiayKhaiSinh.xaml
    /// </summary>
    public partial class wGiayKhaiSinh : Window
    {
        ComboBoxData comboBoxData = new ComboBoxData();
        KiemTraDuLieu kt = new KiemTraDuLieu();
        KhaiSinhDAO ksDao = new KhaiSinhDAO();
        CongDanDAO cdDao = new CongDanDAO();
        public wGiayKhaiSinh()
        {
            InitializeComponent();
            cmb_khaisinh_gioitinh.ItemsSource = comboBoxData.GioiTinh();
            cmb_khaisinh_dantoc.ItemsSource = comboBoxData.DanToc();
            cmb_khaisinh_noisinh.ItemsSource = cmb_khaisinh_quequan.ItemsSource = cmb_khaisinh_noidk.ItemsSource = comboBoxData.TinhThanh();
            cmb_khaisinh_quanhe.ItemsSource = comboBoxData.QuanHeKS();
            cmb_khaisinh_quoctich.ItemsSource = comboBoxData.QuocTich();

        }
        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void txt_khaisinh_cha_LostFocus(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_khaisinh_cha.Text.Trim());
            if (dataTable.Rows.Count > 0 )
            {
                txt_khaisinh_cha.Text = dataTable.Rows[0]["HoTen"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            } 
                
        }
        private void txt_khaisinh_me_LostFocus(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_khaisinh_me.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                txt_khaisinh_me.Text = dataTable.Rows[0]["HoTen"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void txt_khaisinh_ngkhaisinh_LostFocus(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_khaisinh_ngkhaisinh.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                txt_khaisinh_ngkhaisinh.Text = dataTable.Rows[0]["HoTen"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_Them_ThongTin_Click(object sender, RoutedEventArgs e)
        {
            if (kt.checkThemKS(txt_khaisinh_hoten, cmb_khaisinh_gioitinh, dtp_khaisinh_ngaysinh, cmb_khaisinh_noisinh, cmb_khaisinh_dantoc, cmb_khaisinh_quoctich, cmb_khaisinh_quequan, txt_khaisinh_cha, txt_khaisinh_me, txt_khaisinh_ngkhaisinh, cmb_khaisinh_quanhe, dtp_khaisinh_ngaydk, cmb_khaisinh_noidk))
            {
                KhaiSinh khaiSinh = new KhaiSinh(txt_khaisinh_maks.Text, txt_khaisinh_hoten.Text, cmb_khaisinh_gioitinh.Text, Convert.ToDateTime(dtp_khaisinh_ngaysinh.Text.Trim()), cmb_khaisinh_noisinh.Text, cmb_khaisinh_dantoc.Text, cmb_khaisinh_quoctich.Text, cmb_khaisinh_quequan.Text, txt_khaisinh_cha.Text, txt_khaisinh_me.Text, txt_khaisinh_ngkhaisinh.Text, cmb_khaisinh_quanhe.Text, Convert.ToDateTime(dtp_khaisinh_ngaydk.Text.Trim()), cmb_khaisinh_noidk.Text);
                ksDao.ThemThongTinKhaiSinh(khaiSinh);
            }
        }
    }
}
