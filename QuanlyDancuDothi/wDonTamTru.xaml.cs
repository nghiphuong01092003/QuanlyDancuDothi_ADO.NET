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
    /// Interaction logic for wDonTamTru.xaml
    /// </summary>
    public partial class wDonTamTru : Window
    {
        KiemTraDuLieu kt = new KiemTraDuLieu();
        CongDanDAO cdDao = new CongDanDAO();
        TamTruDAO ttDao = new TamTruDAO();
        public wDonTamTru()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btn_DienTT_Tamtru_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_tamtru_cccd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                txt_tamtru_hoten.Text = dataTable.Rows[0]["HoTen"].ToString().Trim();
                dtp_tamtru_ngaycapcccd.Text = dataTable.Rows[0]["NgcCccd"].ToString().Trim();
                dtp_tamtru_ngaysinh.Text = dataTable.Rows[0]["NgaySinh"].ToString().Trim();
                txt_tamtru_noicapcccd.Text = dataTable.Rows[0]["NcCccd"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_Them_ThongTin_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_tamtru_cccd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                if (kt.checkThemTamTru(txt_tamtru_cccd, dtp_tamtru_ngaydk, txt_tamtru_noidk, txt_tamtru_hoten, dtp_tamtru_ngaysinh, txt_tamtru_noicapcccd, dtp_tamtru_ngaycapcccd, dtp_tamtru_ngayden, dtp_tamtru_ngaydi, txt_tamtru_lydo))
                {
                    TamTru tamTru = new TamTru(txt_tamtru_MaTamTru.Text, txt_tamtru_cccd.Text, Convert.ToDateTime(dtp_tamtru_ngaydk.Text.Trim()), txt_tamtru_noidk.Text, txt_tamtru_hoten.Text, Convert.ToDateTime(dtp_tamtru_ngaysinh.Text.Trim()), txt_tamtru_noicapcccd.Text, Convert.ToDateTime(dtp_tamtru_ngaycapcccd.Text.Trim()), Convert.ToDateTime(dtp_tamtru_ngayden.Text.Trim()), Convert.ToDateTime(dtp_tamtru_ngaydi.Text.Trim()), txt_tamtru_lydo.Text);
                    ttDao.ThemThongTinTamTru(tamTru);
                }
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
    }
}
