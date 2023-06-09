using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
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
using QuanlyDancuDothi.DBConnect;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using QuanlyDancuDothi.ClassDAO;

namespace QuanlyDancuDothi
{
    /// <summary>
    /// Interaction logic for ADMIN_TrangChu.xaml
    /// </summary>
    public partial class ADMIN_TrangChu : Window
    {
        TrangChuDAO tcDao = new TrangChuDAO();
        DanhGiaDAO dgDao = new DanhGiaDAO();
        PieChartData chartData = new PieChartData();
        public ADMIN_TrangChu()
        {
            InitializeComponent();
            btn_trangchu.Background = Brushes.MistyRose;
            rtb_TongQuan.Value = dgDao.TongQuan();
            rtb_ThuanTien.Value = dgDao.ThuanTien();
            rtb_TrucQuan.Value = dgDao.TrucQuan();
            rtb_DeDang.Value = dgDao.DeDang();
            rtb_ChinhXac.Value = dgDao.ChinhXac();
            PieChart_GioiTinh.Series = chartData.GioiTinhData();
            PieChart_KetHon.Series = chartData.KetHonData();
            PieChart_LyHon.Series = chartData.LyHonData();
            txt_TongDanSo.Text = tcDao.DemSoCongDan().ToString();
            txt_TuoiTrungBinh.Text = tcDao.DoTuoiTrungBinh().ToString();
            txt_TrongTuoiLaoDong.Text = tcDao.SoNguoiTrongDoTuoiLaoDong().ToString();
            txt_NgayThang.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        private void btn_CongDan_Click(object sender, RoutedEventArgs e)
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
        private void PieChart_DataClick(object sender, ChartPoint chartPoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartPoint.ChartView;
            foreach (PieSeries pieSeries in chart.Series)
                pieSeries.PushOut = 0;
            var selecionarSeries = (PieSeries)chartPoint.SeriesView;
            selecionarSeries.PushOut = 0;
        }
    }
}
