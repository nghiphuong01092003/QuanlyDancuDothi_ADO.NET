
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
    /// Interaction logic for wDonTamVang.xaml
    /// </summary>
    public partial class wDonTamVang : Window
    {
        KiemTraDuLieu kt = new KiemTraDuLieu();
        CongDanDAO cdDao = new CongDanDAO();
        TamVangDAO tvDao = new TamVangDAO();
        public wDonTamVang()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btn_DienTT_TamVang_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_tamvang_cccd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                txt_tamvang_hoten.Text = dataTable.Rows[0]["HoTen"].ToString().Trim();
                dtp_tamvang_ngaycapcccd.Text = dataTable.Rows[0]["NgcCccd"].ToString().Trim();
                dtp_tamvang_ngaysinh.Text = dataTable.Rows[0]["NgaySinh"].ToString().Trim();
                txt_tamvang_noicapcccd.Text = dataTable.Rows[0]["NcCccd"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_Them_ThongTin_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_tamvang_cccd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                if (kt.checkThemTamVang(txt_tamvang_cccd, dtp_tamvang_ngaydk, txt_tamvang_noichuyendi, txt_tamvang_noichuyenden, txt_tamvang_hoten, dtp_tamvang_ngaysinh, dtp_tamvang_ngaycapcccd,
                txt_tamvang_noicapcccd, dtp_tamvang_ngaydi, dtp_tamvang_ngayve, txt_tamvang_lydo))
                {
                    TamVang tamVang = new TamVang(txt_tamvang_matv.Text, txt_tamvang_cccd.Text, Convert.ToDateTime(dtp_tamvang_ngaydk.Text.Trim()), txt_tamvang_noichuyendi.Text, txt_tamvang_noichuyenden.Text, txt_tamvang_hoten.Text, Convert.ToDateTime(dtp_tamvang_ngaysinh.Text.Trim()), Convert.ToDateTime(dtp_tamvang_ngaycapcccd.Text.Trim()), txt_tamvang_noicapcccd.Text, Convert.ToDateTime(dtp_tamvang_ngaydi.Text.Trim()), Convert.ToDateTime(dtp_tamvang_ngayve.Text.Trim()), txt_tamvang_lydo.Text);
                    tvDao.ThemThongTinTamVang(tamVang);
                }
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
    }
}
