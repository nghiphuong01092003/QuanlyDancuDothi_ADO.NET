using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using MaterialDesignThemes.Wpf;
using QuanlyDancuDothi.DBConnect;
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
using System.Data;
using QuanlyDancuDothi.ClassDAO;
using QuanlyDancuDothi.ClassObject;

namespace QuanlyDancuDothi
{
    /// <summary>
    /// Interaction logic for USER_TrangChu.xaml
    /// </summary>
    public partial class USER_TrangChu : Window
    {
        TrangChuDAO tcDao = new TrangChuDAO();
        PieChartData chartData = new PieChartData();
        DanhGiaDAO dgDao = new DanhGiaDAO();
        public USER_TrangChu()
        {
            InitializeComponent();
            rtb_TongQuan.Value = dgDao.TongQuan();
            rtb_ThuanTien.Value = dgDao.ThuanTien();
            rtb_TrucQuan.Value = dgDao.TrucQuan();
            rtb_DeDang.Value = dgDao.DeDang();
            rtb_ChinhXac.Value = dgDao.ChinhXac();
            btn_User_TrangChu.Background = Brushes.MistyRose;
            PieChart_GioiTinh.Series = chartData.GioiTinhData();
            PieChart_KetHon.Series = chartData.KetHonData();
            PieChart_LyHon.Series = chartData.LyHonData();
            txt_TongDanSo.Text = tcDao.DemSoCongDan().ToString();
            txt_TuoiTrungBinh.Text = tcDao.DoTuoiTrungBinh().ToString();
            txt_TuoiLaoDong.Text = tcDao.SoNguoiTrongDoTuoiLaoDong().ToString();
            DataTable dataTable = tcDao.ThongTinNguoiDung(Login.taikhoan);
            CongDan congDan = new CongDan(dataTable.Rows[0]["HoTen"].ToString(), dataTable.Rows[0]["GioiTinh"].ToString(), dataTable.Rows[0]["CCCD"].ToString(), Convert.ToDateTime(dataTable.Rows[0]["NgaySinh"]), dataTable.Rows[0]["NoiSinh"].ToString(), dataTable.Rows[0]["QuocTich"].ToString(), dataTable.Rows[0]["DanToc"].ToString(), dataTable.Rows[0]["QueQuan"].ToString(),
                dataTable.Rows[0]["DiaChi"].ToString(), dataTable.Rows[0]["NcCccd"].ToString(), Convert.ToDateTime(dataTable.Rows[0]["NgcCccd"]), dataTable.Rows[0]["SDT"].ToString(), dataTable.Rows[0]["Email"].ToString(), dataTable.Rows[0]["MaKS"].ToString());
            txt_CCCD.Text = congDan.Cccd.ToString().Trim();
            txt_Giotinh.Text = congDan.Gioitinh.ToString().Trim();
            txt_Hoten.Text = congDan.Hoten.ToString().Trim();
            txt_Ngaysinh.Text = congDan.Ngaysinh.ToString("dd/MM/yyyy").Trim();
            txt_Sdt.Text = congDan.Sdt.ToString().Trim();
            txt_Email.Text = congDan.Email.ToString().Trim();
            txt_NgayThang.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
        public void btn_User_CongDan_Click(object sender, RoutedEventArgs e)
        {
            USER_CongDan congDan = new USER_CongDan();
            congDan.Show();
            Close();
        }
        private void btn_User_QuanLyDon_Click(object sender, RoutedEventArgs e)
        {
            USER_QuanLyDon quanLyDon = new USER_QuanLyDon();
            quanLyDon.Show();
            Close();
        }
        private void btn_LogOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
        private void btn_danhgia_Click(object sender, RoutedEventArgs e)
        {
            USER_DanhGia danhGia = new USER_DanhGia();
            danhGia.Show();
        }
        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
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
