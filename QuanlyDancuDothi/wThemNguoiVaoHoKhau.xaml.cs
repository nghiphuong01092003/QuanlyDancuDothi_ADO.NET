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
    /// Interaction logic for wThemNguoiVaoHoKhau.xaml
    /// </summary>
    public partial class wThemNguoiVaoHoKhau : Window
    {
        ComboBoxData comboBoxData = new ComboBoxData();
        HoKhauDAO hkDao = new HoKhauDAO();
        KhaiSinhDAO ksDao = new KhaiSinhDAO();
        public wThemNguoiVaoHoKhau()
        {
            InitializeComponent();
            cmb_quanhe.ItemsSource = comboBoxData.QuanHe();
        }
        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btn_DienTT_HoKhau_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = hkDao.HienThiThongTinHoKhau3(txt_hokhau_mahokhau.Text);
            if (dataTable.Rows.Count > 0)
            {
                txt_hokhau_hotenchuho.Text = dataTable.Rows[0]["HoTenKS"].ToString();
                txt_hokhau_makschuho.Text = dataTable.Rows[0]["KhaiSinhChuHo"].ToString();
                txt_hokhau_diachi.Text = dataTable.Rows[0]["DiaChi"].ToString();
                hkDao.HienThiThongTinNguoiThamGia(dtg_Nguoithamgia, txt_hokhau_mahokhau.Text);
            }
            else
            {
                MessageBox.Show("Hộ khẩu không tồn tại!");
            }
        }
        private void dtg_Nguoithamgia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = (DataRowView)dtg_Nguoithamgia.SelectedItem;
            if (rowView != null)
            {
                txt_hokhau_maksnguoithamgia.Text = rowView["KhaiSinhNguoiThamGia"].ToString();
                txt_hokhau_hotennguoithamgia.Text = rowView["HoTenKS"].ToString();
                cmb_quanhe.Text = rowView["QuanHeVoiChuHo"].ToString();
            }
        }
        private void btn_DienTT_NguoiThamGia_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = ksDao.KiemTraThongTinKhaiSinh(txt_hokhau_maksnguoithamgia.Text);
            if (dataTable.Rows.Count > 0)
            {
                txt_hokhau_hotennguoithamgia.Text = dataTable.Rows[0]["HoTenKS"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_nhapkhau_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = ksDao.KiemTraThongTinKhaiSinh(txt_hokhau_makschuho.Text.Trim());
            if (cmb_quanhe.SelectedIndex >= 0)
            {
                if (dataTable.Rows.Count > 0)
                {
                    QuanHe quanHe = new QuanHe(txt_hokhau_maksnguoithamgia.Text, cmb_quanhe.SelectedItem.ToString(), txt_hokhau_mahokhau.Text, txt_hokhau_hotennguoithamgia.Text);
                    hkDao.ThemNguoiThamGia(quanHe);
                    hkDao.HienThiThongTinNguoiThamGia(dtg_Nguoithamgia, txt_hokhau_mahokhau.Text);
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
