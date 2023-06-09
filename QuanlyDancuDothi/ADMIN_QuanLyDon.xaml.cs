using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for ADMIN_QuanLyDon.xaml
    /// </summary>
    public partial class ADMIN_QuanLyDon : Window
    {
        public static string search;
        CongDanDAO CDDao = new CongDanDAO();
        ThueDAO thDao = new ThueDAO();
        HoKhauDAO hkDao = new HoKhauDAO();
        public ADMIN_QuanLyDon()
        {
            InitializeComponent();
            btn_QuanLyDon.Background = Brushes.MistyRose;
        }

        private void btn_TrangChu_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_TrangChu trangChu = new ADMIN_TrangChu();
            trangChu.Show();
            Close();
        }

        private void btn_CongDan_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_CongDan congDan = new ADMIN_CongDan();
            congDan.Show();
            Close();
        }
        private void btn_danhgia_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_DanhGia danhGia = new ADMIN_DanhGia();
            danhGia.Show();
            Close();
        }
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_LogOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt9 = hkDao.HienThiThongTinHoKhau(search);
            if (dt9.Rows.Count > 0)
            {
                HoKhau hk = new HoKhau(dt9.Rows[0]["MaHK"].ToString(), dt9.Rows[0]["KhaiSinhChuHo"].ToString(), dt9.Rows[0]["HotenChuHo"].ToString(),
                dt9.Rows[0]["DiaChi"].ToString());
                QuanHe quanHe = new QuanHe(dt9.Rows[0]["KhaiSinhChuHo"].ToString(), dt9.Rows[0]["QuanHeVoiChuHo"].ToString(), dt9.Rows[0]["MaHK"].ToString(), dt9.Rows[0]["Hotennguoithan"].ToString());
                txt_hk_mahk.Text = hk.Mahk.ToString().Trim();
                txt_hk_diachi.Text = hk.Diachi.ToString().Trim();
                txt_hk_chuho.Text = hk.Hotenchuho.ToString().Trim();
                txt_hk_cccdchuho.Text = hk.MaKSchuho.ToString().Trim();
                txt_hk_cccdnt.Text = quanHe.MaKSnguoithan.ToString().Trim();
                txt_hk_hotennt.Text = quanHe.Hoten.ToString().Trim();
                txt_hk_quanhent.Text = quanHe.Quanhe.ToString().Trim();
            }
            hkDao.HienThiThongTinHoKhau2(search, dtg_Hokhau);

            DataTable dt1 = thDao.HienThiThongTinThue(search);
            if (dt1.Rows.Count > 0)
            {
                Thue thue = new Thue(dt1.Rows[0]["Masothue"].ToString(), dt1.Rows[0]["Coquanthue"].ToString(), dt1.Rows[0]["HoTen"].ToString(), dt1.Rows[0]["SoCMT_CCCD"].ToString(), Convert.ToDateTime(dt1.Rows[0]["Ngaythaydoithongtingannhat"]));
                txt_cccd.Text = thue.Socmt_cccd.ToString().Trim();
                txt_coquanthue.Text = thue.Coquanthue.ToString().Trim();
                txt_Masothue.Text = thue.Masothue.ToString().Trim();
                txt_Ngaythaydoi.Text = thue.Ngaythaydoithongtingannhat.ToString("dd/MM/yyyy").Trim();
                txt_thue_nguoinopthue.Text = thue.Hoten.ToString().Trim();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TabItem_Loaded(sender, e);
        }
        private void btn_TraCuu_ThongTin_Click(object sender, RoutedEventArgs e)
        {
            search = txt_tt_keyword.Text;
            TabItem_Loaded(sender, e);
        }
        private void btn_giaydkkh_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = CDDao.KiemTraDuLieuCongDan(search);
            if (dataTable.Rows.Count > 0)
            {
                Đơn cnkh = new Đơn();
                cnkh.Show();
                cnkh.tab_cnkh.IsSelected = true;
                Close();
            }
        }
        private void btn_xem_ks_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = CDDao.KiemTraDuLieuCongDan(search);
            if (dataTable.Rows.Count > 0)
            {
                Đơn ks = new Đơn();
                ks.Show();
                ks.tab_khaisinh.IsSelected = true;
                Close();
            }
        }
        private void btn_tamtru_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = CDDao.KiemTraDuLieuCongDan(search);
            if (dataTable.Rows.Count > 0)
            {
                Đơn tt = new Đơn();
                tt.Show();
                tt.tab_tamtru.IsSelected = true;
                Close();
            }
        }
        private void btn_tamvang_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = CDDao.KiemTraDuLieuCongDan(search);
            if (dataTable.Rows.Count > 0)
            {
                Đơn tv = new Đơn();
                tv.Show();
                tv.tab_tamvang.IsSelected = true;
                Close();
            }
        }
        private void btn_xem_ct_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = CDDao.KiemTraDuLieuCongDan(search);
            if (dataTable.Rows.Count > 0)
            {
                Đơn ct = new Đơn();
                ct.Show();
                ct.tab_chungtu.IsSelected = true;
                Close();
            }
        }
        private void btn_xem_lh_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = CDDao.KiemTraDuLieuCongDan(search);
            if (dataTable.Rows.Count > 0)
            {
                Đơn lh = new Đơn();
                lh.Show();
                lh.tab_lyhon.IsSelected = true;
                Close();
            }
        }
    }
}
