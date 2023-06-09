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
    /// Interaction logic for wHoKhau.xaml
    /// </summary>
    public partial class wHoKhau : Window
    {
        ComboBoxData comboBoxData = new ComboBoxData();
        HoKhauDAO hkDao = new HoKhauDAO();
        KhaiSinhDAO ksDao = new KhaiSinhDAO();
        public wHoKhau()
        {
            InitializeComponent();
            cmb_hokhau_tinhthanh.ItemsSource = comboBoxData.TinhThanh();
        }
        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void cmb_hokhau_tinhthanh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedTinhThanh = cmb_hokhau_tinhthanh.SelectedItem.ToString().Trim();
            switch (selectedTinhThanh)
            {
                case "Bình Dương":
                    cmb_hokhau_quanhuyen.ItemsSource = comboBoxData.QuanHuyenBinhDuong();
                    break;
                case "Đồng Nai":
                    cmb_hokhau_quanhuyen.ItemsSource = comboBoxData.QuanHuyenDongNai();
                    break;
                case "Hà Nội":
                    cmb_hokhau_quanhuyen.ItemsSource = comboBoxData.QuanHuyenHaNoi();
                    break;
                case "TP. Hồ Chí Minh":
                    cmb_hokhau_quanhuyen.ItemsSource = comboBoxData.QuanHuyenHCM();
                    break;
                default:
                    break;
            }
        }
        private void cmb_hokhau_quanhuyen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedQuanHuyen = cmb_hokhau_quanhuyen.SelectedItem.ToString();
            switch (selectedQuanHuyen)
            {
                case "Thủ Dầu Một":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaThuDauMot();
                    break;
                case "Bến Cát":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaBenCat();
                    break;
                case "Dĩ An":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaDiAn();
                    break;
                case "Thuận An":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaThuanAn();
                    break;
                case "Biên Hòa":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaBienHoa();
                    break;
                case "Long Khánh":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaLongKhanh();
                    break;
                case "Tân Phú":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaTanPhu();
                    break;
                case "Trảng Bom":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaTrangBom();
                    break;
                case "Ba Đình":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaBaDinh();
                    break;
                case "Hoàn Kiếm":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaHoanKiem();
                    break;
                case "Đống Đa":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaDongDa();
                    break;
                case "Cầu Giấy":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaCauGiay();
                    break;
                case "Quận 1":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaQuan1();
                    break;
                case "Quận 3":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaQuan3();
                    break;
                case "Thành phố Thủ Đức":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaThuDuc();
                    break;
                case "Gò Vấp":
                    cmb_hokhau_xaphuong.ItemsSource = comboBoxData.PhuongXaGoVap();
                    break;
                default:
                    break;
            }
        }
        private void btn_DienTT_HoKhau_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = ksDao.KiemTraThongTinKhaiSinh(txt_hokhau_makschuho.Text);
            if (dataTable.Rows.Count > 0)
            {
                if (Convert.ToInt32(dataTable.Rows[0]["Tuoi"]) >= 18)
                    txt_hokhau_hotenchuho.Text = dataTable.Rows[0]["HoTen"].ToString();
                else
                {
                    MessageBox.Show("Người này chưa đủ 18 tuổi!");
                }
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_Them_ThongTin_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = ksDao.KiemTraThongTinKhaiSinh(txt_hokhau_makschuho.Text.Trim());
            if (cmb_hokhau_quanhuyen.SelectedIndex >= 0 && cmb_hokhau_tinhthanh.SelectedIndex >= 0 && cmb_hokhau_xaphuong.SelectedIndex >= 0 && txt_hokhau_sonha.Text != "")
            {
                if (dataTable.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dataTable.Rows[0]["Tuoi"]) >= 18)
                    {
                        HoKhau hoKhau = new HoKhau(txt_hokhau_mahk.Text, txt_hokhau_makschuho.Text, txt_hokhau_hotenchuho.Text, txt_hokhau_sonha.Text + ", " + cmb_hokhau_xaphuong.SelectedItem.ToString() + ", " + cmb_hokhau_quanhuyen.SelectedItem.ToString() + ", " + cmb_hokhau_tinhthanh.SelectedItem.ToString());
                        hkDao.ThemThongTinHoKhau(hoKhau);
                    }
                    else
                    {
                        MessageBox.Show("Người này chưa đủ 18 tuổi!");
                    }
                }
                else
                {
                    MessageBox.Show("Người này không tồn tại trong hệ thống!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
        }
    }
}
