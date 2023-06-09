using MaterialDesignThemes.Wpf;
using QuanlyDancuDothi.DBConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;
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
    /// Interaction logic for USER_QuanLyDon.xaml
    /// </summary>
    public partial class USER_QuanLyDon : Window
    {
        public USER_QuanLyDon()
        {
            InitializeComponent();
            btn_User_QuanLyDon.Background = Brushes.MistyRose;
            txt_NgayThang.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void btn_User_TrangChu_Click(object sender, RoutedEventArgs e)
        {
            USER_TrangChu trangChu = new USER_TrangChu();
            trangChu.Show();
            Close();
        }

        public void btn_User_CongDan_Click(object sender, RoutedEventArgs e)
        {
            USER_CongDan congDan = new USER_CongDan();
            congDan.Show();
            Close();
        }
        private void btn_danhgia_Click(object sender, RoutedEventArgs e)
        {
            USER_DanhGia danhGia = new USER_DanhGia();
            danhGia.Show();
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
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        private void btn_LogOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btn_tamtru_Click(object sender, RoutedEventArgs e)
        {
            wDonTamTru donTamTru = new wDonTamTru();
            donTamTru.Show();
        }
        private void btn_tamvang_Click(object sender, RoutedEventArgs e)
        {
            wDonTamVang donTamVang = new wDonTamVang();
            donTamVang.Show();
        }
        private void btn_giaydkkh_Click(object sender, RoutedEventArgs e)
        {
            wGiayDangKiKetHon giayDangKiKetHon = new wGiayDangKiKetHon();
            giayDangKiKetHon.Show();
        }
        private void btn_KhaiSinh_Click(object sender, RoutedEventArgs e)
        {
            wGiayKhaiSinh giayKhaiSinh = new wGiayKhaiSinh();
            giayKhaiSinh.Show();
        }
        private void btn_donlyhon_Click(object sender, RoutedEventArgs e)
        {
            wDonLyHon donLyHon = new wDonLyHon();
            donLyHon.Show();
        }
        private void btn_GiayChungTu_Click(object sender, RoutedEventArgs e)
        {
            wGiayChungTu giayChungTu = new wGiayChungTu();
            giayChungTu.Show();
        }
        private void btn_hokhau_Click(object sender, RoutedEventArgs e)
        {
            wHoKhau hoKhau = new wHoKhau();
            hoKhau.Show();
        }
        private void btn_catkhau_Click(object sender, RoutedEventArgs e)
        {
            wCatKhau catKhau = new wCatKhau();
            catKhau.Show();
        }
        private void btn_ThemNguoi_Click(object sender, RoutedEventArgs e)
        {
            wThemNguoiVaoHoKhau wThemNguoi = new wThemNguoiVaoHoKhau();
            wThemNguoi.Show();
        }
    }
}
