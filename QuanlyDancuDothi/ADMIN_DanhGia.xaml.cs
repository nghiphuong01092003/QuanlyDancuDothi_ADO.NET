using MaterialDesignThemes.Wpf;
using QuanlyDancuDothi.ClassDAO;
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
    /// Interaction logic for ADMIN_DanhGia.xaml
    /// </summary>
    public partial class ADMIN_DanhGia : Window
    {
        DanhGiaDAO dgDao = new DanhGiaDAO();
        public ADMIN_DanhGia()
        {
            InitializeComponent();
            btn_danhgia.Background = Brushes.MistyRose;
        }

        private void btn_TrangChu_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_TrangChu trangChu = new ADMIN_TrangChu();
            trangChu.Show();
            Close();
        }

        private void btn_congdan_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_CongDan congDan = new ADMIN_CongDan();
            congDan.Show();
            Close();
        }

        private void btn_QuanLyDon_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_QuanLyDon quanLyDon = new ADMIN_QuanLyDon();
            quanLyDon.Show();
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

        private void dtg_DanhGia_Loaded(object sender, RoutedEventArgs e)
        {
            dgDao.HienThiDanhGia(dtg_DanhGia);
        }

        private void dtg_DanhGia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = (DataRowView)dtg_DanhGia.SelectedItem;
            if (rowView != null)
            {
                txt_cccd.Text = rowView["CCCD"].ToString();
                txt_danhgia_hoten.Text = rowView["HoTen"].ToString();
                txtPhanhoi.Text = rowView["DanhGia"].ToString();
                rate_tongquan.Value = Convert.ToDouble(rowView["Tongquan"]);
                rate_chinhxac.Value = Convert.ToDouble(rowView["Chinhxac"]);
                rate_dedang.Value = Convert.ToDouble(rowView["Dedang"]);
                rate_thuantien.Value = Convert.ToDouble(rowView["Thuantien"]);
                rate_trucquan.Value = Convert.ToDouble(rowView["Trucquan"]);
            }
        }
    }
}
