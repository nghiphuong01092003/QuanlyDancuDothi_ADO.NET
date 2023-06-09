using MaterialDesignThemes.Wpf;
using QuanlyDancuDothi.ClassDAO;
using QuanlyDancuDothi.ClassObject;
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

namespace QuanlyDancuDothi
{
    /// <summary>
    /// Interaction logic for USER_DanhGia.xaml
    /// </summary>
    public partial class USER_DanhGia : Window
    {
        DanhGiaDAO dgDAO = new DanhGiaDAO();
        public USER_DanhGia()
        {
            InitializeComponent();
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

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_phanhoi_Click(object sender, RoutedEventArgs e)
        {
            DanhGiaDichVu dg = new DanhGiaDichVu(txtPhanhoi.Text, (int)rate_tongquan.Value, (int)rate_thuantien.Value, (int)rate_chinhxac.Value, (int)rate_dedang.Value, (int)rate_trucquan.Value);
            dgDAO.GuiDanhGia(dg, Login.taikhoan);
        }
    }
}
