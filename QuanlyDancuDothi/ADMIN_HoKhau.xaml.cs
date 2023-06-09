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
    /// Interaction logic for ADMIN_HoKhau.xaml
    /// </summary>
    public partial class ADMIN_HoKhau : Window
    {
        ComboBoxData comboBoxData = new ComboBoxData();
        HoKhauDAO hkDao = new HoKhauDAO();
        KhaiSinhDAO ksDao = new KhaiSinhDAO();
        public ADMIN_HoKhau()
        {
            InitializeComponent();
            cmb_quanhe.ItemsSource = comboBoxData.QuanHe();
        }
        private void btn_Dong_Hokhau_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void dtg_Nguoithamgia_Loaded(object sender, RoutedEventArgs e)
        {
            hkDao.HienThiChiTietHoKhau(dtg_Nguoithamgia, txt_hokhau_mahokhau.Text);
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
        private void btn_DienTT_HoKhau_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = ksDao.KiemTraThongTinKhaiSinh(txt_hokhau_maksnguoithamgia.Text);
            if (dataTable.Rows.Count > 0)
            {
                txt_hokhau_hotennguoithamgia.Text = dataTable.Rows[0]["HoTenKS"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Người này không có trong hệ thống!");
            }
        }
        private void btn_Them_Nguoithamgia_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = ksDao.KiemTraThongTinKhaiSinh(txt_hokhau_makschuho.Text.Trim());
            if (cmb_quanhe.SelectedIndex >= 0)
            {
                if (dataTable.Rows.Count > 0)
                {
                    QuanHe quanHe = new QuanHe(txt_hokhau_maksnguoithamgia.Text, cmb_quanhe.SelectedItem.ToString(), txt_hokhau_mahokhau.Text, txt_hokhau_maksnguoithamgia.Text);
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
        private void btn_CatKhau_Nguoithamgia_Click(object sender, RoutedEventArgs e)
        {
            QuanHe quanHe = new QuanHe(txt_hokhau_maksnguoithamgia.Text, cmb_quanhe.SelectedItem.ToString(), txt_hokhau_mahokhau.Text, txt_hokhau_hotennguoithamgia.Text);
            hkDao.CatKhau(quanHe);
            dtg_Nguoithamgia_Loaded(sender, e);
        }
    }
}
