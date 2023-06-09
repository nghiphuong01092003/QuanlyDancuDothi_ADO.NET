
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
    /// Interaction logic for wGiayDangKiKetHon.xaml
    /// </summary>
    public partial class wGiayDangKiKetHon : Window
    {
        KiemTraDuLieu kt = new KiemTraDuLieu();
        KetHonDAO khDao = new KetHonDAO();
        CongDanDAO cdDao = new CongDanDAO();
        public wGiayDangKiKetHon()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_DienTT_Vo_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_kethon_gtttvo.Text);
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0]["GioiTinh"].ToString() == "Nữ")
                    if (Convert.ToInt32(dataTable.Rows[0]["Tuoi"]) >= 18)
                        if (dataTable.Rows[0]["MaCnkh"].ToString() == "")
                        {
                            txt_kethon_dantocvo.Text = dataTable.Rows[0]["DanToc"].ToString().Trim();
                            txt_kethon_hotenvo.Text = dataTable.Rows[0]["Hoten"].ToString().Trim();
                            txt_kethon_noicutruvo.Text = dataTable.Rows[0]["DiaChi"].ToString().Trim();
                            txt_kethon_quoctichvo.Text = dataTable.Rows[0]["QuocTich"].ToString().Trim();
                            dtp_kethon_ngaysinhvo.Text = dataTable.Rows[0]["NgaySinh"].ToString().Trim();
                        }
                        else
                        {
                            MessageBox.Show("Người này đã kết hôn!");
                        }
                    else
                    {
                        MessageBox.Show("Người này chưa đủ tuổi kết hôn!");
                    }
                else
                {
                    MessageBox.Show("Giới tính người này không phù hợp!");
                }
            }
            else
            {
                MessageBox.Show("Người này không có trong hệ thống!");
            }
        }

        private void btn_DienTT_Chong_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_kethon_gtttchong.Text);
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0]["GioiTinh"].ToString() == "Nam")
                    if (Convert.ToInt32(dataTable.Rows[0]["Tuoi"]) >= 20)
                        if (dataTable.Rows[0]["MaCnkh"].ToString() == "")
                        {
                            txt_kethon_dantocchong.Text = dataTable.Rows[0]["DanToc"].ToString().Trim();
                            txt_kethon_hotenchong.Text = dataTable.Rows[0]["Hoten"].ToString().Trim();
                            txt_kethon_noicutruchong.Text = dataTable.Rows[0]["DiaChi"].ToString().Trim();
                            txt_kethon_quoctichchong.Text = dataTable.Rows[0]["QuocTich"].ToString().Trim();
                            dtp_kethon_ngaysinhchong.Text = dataTable.Rows[0]["NgaySinh"].ToString().Trim();
                        }
                        else
                        {
                            MessageBox.Show("Người này đã kết hôn!");
                        }
                    else
                    {
                        MessageBox.Show("Người này chưa đủ tuổi kết hôn!");
                    }
                else
                {
                    MessageBox.Show("Giới tính người này không phù hợp!");
                }
            }
            else
            {
                MessageBox.Show("Người này không có trong hệ thống!");
            }
        }

        private void btn_Them_ThongTin_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_kethon_gtttvo.Text);
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0]["GioiTinh"].ToString() == "Nữ")
                    if (Convert.ToInt32(dataTable.Rows[0]["Tuoi"]) >= 18)
                        if (dataTable.Rows[0]["MaCnkh"].ToString() == "")
                        {
                            DataTable dataTable2 = cdDao.KiemTraDuLieuCongDan(txt_kethon_gtttchong.Text);
                            if (dataTable2.Rows.Count > 0)
                            {
                                if (dataTable2.Rows[0]["GioiTinh"].ToString() == "Nam")
                                    if (Convert.ToInt32(dataTable2.Rows[0]["Tuoi"]) >= 20)
                                        if (dataTable2.Rows[0]["MaCnkh"].ToString() == "")
                                        {
                                            if (kt.checkThemKetHon(txt_kethon_hotenvo, txt_kethon_hotenchong, dtp_kethon_ngaysinhvo, dtp_kethon_ngaysinhchong,
                                            txt_kethon_dantocvo, txt_kethon_dantocchong, txt_kethon_quoctichvo, txt_kethon_quoctichchong, txt_kethon_noicutruvo, txt_kethon_noicutruchong, txt_kethon_gtttvo,
                                            txt_kethon_gtttchong, txt_kethon_noidkkethon, dtp_kethon_ngaydkkethon))
                                            {
                                                Cnkh cnkh = new Cnkh(txt_kethon_makh.Text, txt_kethon_hotenvo.Text, txt_kethon_hotenchong.Text, Convert.ToDateTime(dtp_kethon_ngaysinhvo.Text.Trim()), Convert.ToDateTime(dtp_kethon_ngaysinhchong.Text.Trim()), txt_kethon_dantocvo.Text, txt_kethon_dantocchong.Text, txt_kethon_quoctichvo.Text, txt_kethon_quoctichchong.Text, txt_kethon_noicutruvo.Text, txt_kethon_noicutruchong.Text, txt_kethon_gtttvo.Text, txt_kethon_gtttchong.Text, txt_kethon_noidkkethon.Text, Convert.ToDateTime(dtp_kethon_ngaydkkethon.Text.Trim()));
                                                khDao.ThemThongTinKetHon(cnkh);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Người nam đã kết hôn!");
                                        }
                                    else
                                    {
                                        MessageBox.Show("Người nam chưa đủ tuổi kết hôn!");
                                    }
                                else
                                {
                                    MessageBox.Show("Giới tính người nam không phù hợp!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Người nam không có trong hệ thống!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Người nữ đã kết hôn!");
                        }
                    else
                    {
                        MessageBox.Show("Người nữ chưa đủ tuổi kết hôn!");
                    }
                else
                {
                    MessageBox.Show("Giới tính người nữ không phù hợp!");
                }
            }
            else
            {
                MessageBox.Show("Người nữ không có trong hệ thống!");
            }
        }
    }
}
