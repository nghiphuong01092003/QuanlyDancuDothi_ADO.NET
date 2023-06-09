using MaterialDesignThemes.Wpf;
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
using QuanlyDancuDothi.ClassDAO;

namespace QuanlyDancuDothi
{
    /// <summary>
    /// Interaction logic for ADMIN_CongDan.xaml
    /// </summary>
    public partial class ADMIN_CongDan : Window
    {
        ComboBoxData comboBoxData = new ComboBoxData();
        KiemTraDuLieu kt = new KiemTraDuLieu();
        CongDanDAO cdDao = new CongDanDAO();
        KhaiSinhDAO ksDao = new KhaiSinhDAO();
        ChungTuDAO ctDao = new ChungTuDAO();
        ThueDAO thDao = new ThueDAO();
        HoKhauDAO hkDao = new HoKhauDAO();
        TamTruDAO ttDao = new TamTruDAO();
        TamVangDAO tvDao = new TamVangDAO();
        KetHonDAO khDao = new KetHonDAO();
        LyHonDAO lhDao = new LyHonDAO();
        public ADMIN_CongDan()
        {
            InitializeComponent();
            btn_CongDan.Background = Brushes.MistyRose;
            cmb_khaisinh_gioitinh.ItemsSource = comboBoxData.GioiTinh();
            cmb_khaisinh_dantoc.ItemsSource = comboBoxData.DanToc();
            cmb_khaisinh_noisinh.ItemsSource = cmb_khaisinh_quequan.ItemsSource = cmb_khaisinh_noidk.ItemsSource = comboBoxData.TinhThanh();
            cmb_khaisinh_quanhe.ItemsSource = comboBoxData.QuanHeKS();
            cmb_khaisinh_quoctich.ItemsSource = comboBoxData.QuocTich();
        }

        private void btn_TrangChu_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_TrangChu trangChu = new ADMIN_TrangChu();
            trangChu.Show();
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

        private void btn_LogOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void dtg_ThongTin_Loaded(object sender, RoutedEventArgs e)
        {
            cdDao.LoadThongTinCongDan(dtg_ThongTin);
        }
        private void dtg_Thue_Loaded(object sender, RoutedEventArgs e)
        {
            thDao.LoadThongTinThue(dtg_Thue);
        }

        private void dtg_Tamtru_Loaded(object sender, RoutedEventArgs e)
        {
            ttDao.LoadThongTinTamTru(dtg_Tamtru);
        }

        private void dtg_Tamvang_Loaded(object sender, RoutedEventArgs e)
        {
            tvDao.LoadThongTinTamVang(dtg_Tamvang);
        }

        private void dtg_KhaiSinh_Loaded(object sender, RoutedEventArgs e)
        {
            ksDao.LoadThongTinKhaiSinh(dtg_KhaiSinh);
        }

        private void dtg_ChungTu_Loaded(object sender, RoutedEventArgs e)
        {
            ctDao.LoadThongTinChungTu(dtg_ChungTu);
        }

        private void dtg_Hokhau_Loaded(object sender, RoutedEventArgs e)
        {
            hkDao.LoadThongTinHoKhau(dtg_Hokhau);
        }
        private void dtg_Cnkh_Loaded(object sender, RoutedEventArgs e)
        {
            khDao.LoadThongTinCNKH(dtg_Cnkh);
        }
        private void dtg_LyHon_Loaded(object sender, RoutedEventArgs e)
        {
            lhDao.LoadThongTinLyHon(dtg_LyHon);
        }
        private void dtg_ThongTin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = (DataRowView)dtg_ThongTin.SelectedItem;
            if (rowView != null)
            {
                txt_tt_cccd.Text = rowView["CCcd"].ToString();
                txt_tt_dantoc.Text = rowView["DanToc"].ToString();
                txt_tt_diachi.Text = rowView["DiaChi"].ToString();
                txt_tt_email.Text = rowView["Email"].ToString();
                txt_tt_gioitinh.Text = rowView["GioiTinh"].ToString();
                txt_tt_hoten.Text = rowView["HoTen"].ToString();
                txt_tt_noisinh.Text = rowView["NoiSinh"].ToString();
                txt_tt_quequan.Text = rowView["QueQuan"].ToString();
                txt_tt_quoctich.Text = rowView["QuocTich"].ToString();
                txt_tt_sdt.Text = rowView["Sdt"].ToString();
                dtp_tt_ngaysinh.Text = rowView["NgaySinh"].ToString();
                txt_tt_ncCccd.Text = rowView["NcCccd"].ToString();
                dtp_tt_ngcCccd.Text = rowView["NgcCccd"].ToString();
                txt_tt_maks.Text = rowView["Maks"].ToString();
            }
        }
        private void dtg_Thue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = (DataRowView)dtg_Thue.SelectedItem;
            if (rowView != null)
            {
                txt_thue_masothue.Text = rowView["Masothue"].ToString();
                txt_thue_nguoinopthue.Text = rowView["HoTen"].ToString();
                txt_thue_coquanthue.Text = rowView["Coquanthue"].ToString();
                txt_thue_cccd.Text = rowView["SoCMT_CCcd"].ToString();
                dtp_thue_ngaythaydoi.Text = rowView["Ngaythaydoithongtingannhat"].ToString();
            }
        }
        private void dtg_KhaiSinh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = (DataRowView)dtg_KhaiSinh.SelectedItem;

            if (rowView != null)
            {
                txt_khaisinh_maks.Text = rowView["MaKS"].ToString();
                txt_khaisinh_hoten.Text = rowView["HoTenKS"].ToString();
                cmb_khaisinh_gioitinh.Text = rowView["GioiTinh"].ToString();
                dtp_khaisinh_ngaysinh.Text = rowView["NgaySinh"].ToString();
                cmb_khaisinh_noisinh.Text = rowView["NoiSinh"].ToString();
                cmb_khaisinh_dantoc.Text = rowView["DanToc"].ToString();
                cmb_khaisinh_quoctich.Text = rowView["QuocTich"].ToString();
                cmb_khaisinh_quequan.Text = rowView["QueQuan"].ToString();
                txt_khaisinh_cha.Text = rowView["Cha"].ToString();
                txt_khaisinh_me.Text = rowView["Me"].ToString();
                txt_khaisinh_ngkhaisinh.Text = rowView["NguoiKhaiSinh"].ToString();
                cmb_khaisinh_quanhe.Text = rowView["QuanHe"].ToString();
                dtp_khaisinh_ngaydk.Text = rowView["NgayDK"].ToString();
                cmb_khaisinh_noidk.Text = rowView["NoiDK"].ToString();

            }
        }
        private void dtg_ChungTu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                     DataRowView rowView = (DataRowView)dtg_ChungTu.SelectedItem;

            if (rowView != null)
            {
                txt_chungtu_maso.Text = rowView["MaCT"].ToString();
                txt_chungtu_hoten.Text = rowView["HoTen"].ToString();
                txt_chungtu_cccd.Text = rowView["CCcd"].ToString();
                dtp_chungtu_ngaysinh.Text = rowView["NgaySinh"].ToString();
                dtp_chungtu_ngaymat.Text = rowView["NgayMat"].ToString();
                txt_chungtu_noimat.Text = rowView["NoiMat"].ToString();
                txt_chungtu_nguyennhan.Text = rowView["NguyenNhan"].ToString();

            }
        }
        private void dtg_Hokhau_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = (DataRowView)dtg_Hokhau.SelectedItem;

            if (rowView != null)
            {
                txt_hokhau_mahokhau.Text = rowView["MaHK"].ToString();
                txt_hokhau_makschuho.Text = rowView["KhaiSinhChuHo"].ToString();
                txt_hokhau_diachi.Text = rowView["DiaChi"].ToString();
                txt_hokhau_hotenchuho.Text = rowView["HoTenKS"].ToString();

            }
        }
        private void dtg_Tamtru_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = (DataRowView)dtg_Tamtru.SelectedItem;

            if (rowView != null)
            {
                txt_tamtru_MaTamTru.Text = rowView["Matt"].ToString();
                txt_tamtru_hoten.Text = rowView["HoTen"].ToString();
                txt_tamtru_noidk.Text = rowView["Noidk"].ToString();
                dtp_tamtru_ngaydk.Text = rowView["NgayDK"].ToString();
                dtp_tamtru_ngaysinh.Text = rowView["NgaySinh"].ToString();
                txt_tamtru_cccd.Text = rowView["Cccd"].ToString();
                txt_tamtru_noicapcccd.Text = rowView["Nccccd"].ToString();
                dtp_tamtru_ngaycapcccd.Text = rowView["NgcCccd"].ToString();
                dtp_tamtru_ngayden.Text = rowView["Ngayden"].ToString();
                dtp_tamtru_ngaydi.Text = rowView["Ngaydi"].ToString();
                txt_tamtru_lydo.Text = rowView["Lydo"].ToString();
            }
        }
        private void dtg_Tamvang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = (DataRowView)dtg_Tamvang.SelectedItem;

            if (rowView != null)
            {
                txt_tamvang_matamvang.Text = rowView["MaTV"].ToString();
                dtp_tamvang_ngaydk.Text = rowView["Ngaydk"].ToString();
                txt_tamvang_noichuyendi.Text = rowView["Ncdi"].ToString();
                txt_tamvang_noichuyenden.Text = rowView["Ncden"].ToString();
                txt_tamvang_hoten.Text = rowView["HoTen"].ToString();
                dtp_tamvang_ngaysinh.Text = rowView["NgaySinh"].ToString();
                txt_tamvang_cmnd.Text = rowView["CCcd"].ToString();
                txt_tamvang_noicapcmnd.Text = rowView["NcCccd"].ToString();
                dtp_tamvang_ngaycapcmnd.Text = rowView["NgcCccd"].ToString();
                dtp_tamvang_ngaydi.Text = rowView["Ngaydi"].ToString();
                dtp_tamvang_ngayve.Text = rowView["Ngayve"].ToString();
                txt_tamvang_lydo.Text = rowView["Lydo"].ToString();
            }
        }
        private void dtg_Cnkh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = (DataRowView)dtg_Cnkh.SelectedItem;

            if (rowView != null)
            {
                txt_kethon_makh.Text = rowView["MaCnkh"].ToString();
                txt_kethon_hotenvo.Text = rowView["Hotenvo"].ToString();
                dtp_kethon_ngaysinhvo.Text = rowView["Ngaysinhvo"].ToString();
                txt_kethon_dantocvo.Text = rowView["Dantocvo"].ToString();
                txt_kethon_quoctichvo.Text = rowView["Quoctichvo"].ToString();
                txt_kethon_noicutruvo.Text = rowView["Noicutruvo"].ToString();
                txt_kethon_gtttvo.Text = rowView["Giaytotuythanvo"].ToString();
                txt_kethon_hotenchong.Text = rowView["Hotenchong"].ToString();
                dtp_kethon_ngaysinhchong.Text = rowView["Ngaysinhchong"].ToString();
                txt_kethon_dantocchong.Text = rowView["Dantocchong"].ToString();
                txt_kethon_quoctichchong.Text = rowView["Quoctichchong"].ToString();
                txt_kethon_noicutruchong.Text = rowView["Noicutruchong"].ToString();
                txt_kethon_gtttchong.Text = rowView["Giaytotuythanchong"].ToString();
                txt_kethon_noidkkethon.Text = rowView["Noidk"].ToString();
                dtp_kethon_ngaydkkethon.Text = rowView["Ngaydk"].ToString();
            }
        }
        private void dtg_LyHon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = (DataRowView)dtg_LyHon.SelectedItem;

            if (rowView != null)
            {
                txt_lyhon_malyhon.Text = rowView["Malyhon"].ToString();
                txt_lyhon_macnkh.Text = rowView["Makethon"].ToString();
                txt_lyhon_hotennguoinopdon.Text = rowView["Hotennguoinopdon"].ToString();
                txt_lyhon_cccdnguoinopdon.Text = rowView["CccdNguoiNopDon"].ToString();
                txt_lyhon_hotenvo.Text = rowView["HotenVo"].ToString();
                txt_lyhon_cccdvo.Text = rowView["CCcdVo"].ToString();
                txt_lyhon_hotenchong.Text = rowView["HotenChong"].ToString();
                txt_lyhon_cccdchong.Text = rowView["CCcdChong"].ToString();
                txt_lyhon_noidk.Text = rowView["Noidangky"].ToString();
                dtp_lyhon_ngaydk.Text = rowView["Ngaydangky"].ToString();
                txt_lyhon_lydo.Text = rowView["Lydo"].ToString();
            }
        }
        private void Searching()
        {
            string content = txt_tt_keyword.Text;
            if (content == "")
            {
                cdDao.LoadThongTinCongDan(dtg_ThongTin);
                return;
            }
            cdDao.Searching(dtg_ThongTin, content);
        }
        private void btn_TraCuu_ThongTin_Click(object sender, RoutedEventArgs e)
        {
            Searching();
        }
        private void txt_tt_keyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Searching();
            }
        }
        private void btn_DienTT_Khaisinh_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = ksDao.KiemTraThongTinKhaiSinh(txt_tt_maks.Text);
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0]["CCcd"].ToString().Trim() == "")
                {
                    if (Convert.ToInt32(dataTable.Rows[0]["Tuoi"]) >= 14)
                    {
                        txt_tt_hoten.Text = dataTable.Rows[0]["HoTenKS"].ToString().Trim();
                        txt_tt_dantoc.Text = dataTable.Rows[0]["DanToc"].ToString().Trim();
                        txt_tt_gioitinh.Text = dataTable.Rows[0]["GioiTinh"].ToString().Trim();
                        txt_tt_noisinh.Text = dataTable.Rows[0]["NoiSinh"].ToString().Trim();
                        txt_tt_quequan.Text = dataTable.Rows[0]["QueQuan"].ToString().Trim();
                        txt_tt_quoctich.Text = dataTable.Rows[0]["QuocTich"].ToString().Trim();
                        dtp_tt_ngaysinh.Text = dataTable.Rows[0]["NgaySinh"].ToString().Trim();
                    }
                    else
                    {
                        MessageBox.Show("Người này chưa đủ tuổi cấp CCcd!");
                    }
                }
                else
                {
                    MessageBox.Show("Người này đã được cấp CCcd");
                }
            }
            else
            {
                MessageBox.Show("Mã khai sinh không hợp lệ!");
            }
        }
        private void btn_Them_ThongTin_Click(object sender, RoutedEventArgs e)
        {
            if (kt.checkThemCongDan(txt_tt_hoten, txt_tt_gioitinh, txt_tt_cccd, dtp_tt_ngaysinh, txt_tt_noisinh, txt_tt_quoctich, txt_tt_dantoc,
                txt_tt_quequan, txt_tt_diachi, txt_tt_ncCccd, dtp_tt_ngcCccd, txt_tt_sdt, txt_tt_email, txt_tt_maks))
            {
                CongDan congDan = new CongDan(txt_tt_hoten.Text, txt_tt_gioitinh.Text, txt_tt_cccd.Text, Convert.ToDateTime(dtp_tt_ngaysinh.Text.Trim()), txt_tt_noisinh.Text, txt_tt_quoctich.Text, txt_tt_dantoc.Text, txt_tt_quequan.Text, txt_tt_diachi.Text, txt_tt_ncCccd.Text, Convert.ToDateTime(dtp_tt_ngcCccd.Text.Trim()), txt_tt_sdt.Text, txt_tt_email.Text, txt_tt_maks.Text);
                cdDao.ThemThongTinCongDan(congDan);
                dtg_ThongTin_Loaded(sender, e);
            }
        }
        private void btn_Xoa_ThongTin_Click(object sender, RoutedEventArgs e)
        {
            CongDan congDan = new CongDan(txt_tt_hoten.Text, txt_tt_gioitinh.Text, txt_tt_cccd.Text, Convert.ToDateTime(dtp_tt_ngaysinh.Text.Trim()), txt_tt_noisinh.Text, txt_tt_quoctich.Text, txt_tt_dantoc.Text, txt_tt_quequan.Text, txt_tt_diachi.Text, txt_tt_ncCccd.Text, Convert.ToDateTime(dtp_tt_ngcCccd.Text.Trim()), txt_tt_sdt.Text, txt_tt_email.Text, txt_tt_maks.Text);
            cdDao.XoaThongTinCongDan(congDan);
            dtg_ThongTin_Loaded(sender, e);
        }
        private void btn_Sua_ThongTin1_Click(object sender, RoutedEventArgs e)
        {
            if (kt.checkThemCongDan(txt_tt_hoten, txt_tt_gioitinh, txt_tt_cccd, dtp_tt_ngaysinh, txt_tt_noisinh, txt_tt_quoctich, txt_tt_dantoc,
                txt_tt_quequan, txt_tt_diachi, txt_tt_ncCccd, dtp_tt_ngcCccd, txt_tt_sdt, txt_tt_email, txt_tt_maks))
            {
                MessageBox.Show("Bạn chỉ có quyền thay đổi SĐT và Email", "Ghi chú", MessageBoxButton.OK, MessageBoxImage.Information);
                CongDan cd = new CongDan(txt_tt_hoten.Text, txt_tt_gioitinh.Text, txt_tt_cccd.Text, Convert.ToDateTime(dtp_tt_ngaysinh.Text.Trim()), txt_tt_noisinh.Text, txt_tt_quoctich.Text, txt_tt_dantoc.Text,
                txt_tt_quequan.Text, txt_tt_diachi.Text, txt_tt_ncCccd.Text, Convert.ToDateTime(dtp_tt_ngcCccd.Text.Trim()), txt_tt_sdt.Text, txt_tt_email.Text, txt_tt_maks.Text);
                cdDao.SuaThongTinCongDan(cd);
                dtg_ThongTin_Loaded(sender, e);
            }
        }
        private void txt_khaisinh_cha_LostFocus(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_khaisinh_cha.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                txt_khaisinh_cha.Text = dataTable.Rows[0]["HoTen"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }

        private void txt_khaisinh_me_LostFocus(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_khaisinh_me.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                txt_khaisinh_me.Text = dataTable.Rows[0]["HoTen"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }

        private void txt_khaisinh_ngkhaisinh_LostFocus(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_khaisinh_ngkhaisinh.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                txt_khaisinh_ngkhaisinh.Text = dataTable.Rows[0]["HoTen"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_Them_KhaiSinh_Click(object sender, RoutedEventArgs e)
        {
            if (kt.checkThemKS(txt_khaisinh_hoten, cmb_khaisinh_gioitinh, dtp_khaisinh_ngaysinh, cmb_khaisinh_noisinh, cmb_khaisinh_dantoc, cmb_khaisinh_quoctich, cmb_khaisinh_quequan, txt_khaisinh_cha, txt_khaisinh_me, txt_khaisinh_ngkhaisinh, cmb_khaisinh_quanhe, dtp_khaisinh_ngaydk, cmb_khaisinh_noidk))
            {
                KhaiSinh khaiSinh = new KhaiSinh(txt_khaisinh_maks.Text, txt_khaisinh_hoten.Text, cmb_khaisinh_gioitinh.Text, Convert.ToDateTime(dtp_khaisinh_ngaysinh.Text.Trim()), cmb_khaisinh_noisinh.Text, cmb_khaisinh_dantoc.Text, cmb_khaisinh_quoctich.Text, cmb_khaisinh_quequan.Text, txt_khaisinh_cha.Text, txt_khaisinh_me.Text, txt_khaisinh_ngkhaisinh.Text, cmb_khaisinh_quanhe.Text, Convert.ToDateTime(dtp_khaisinh_ngaydk.Text.Trim()), cmb_khaisinh_noidk.Text);
                ksDao.ThemThongTinKhaiSinh(khaiSinh);
                dtg_KhaiSinh_Loaded(sender, e);
            }
        }
        private void btn_Xoa_KhaiSinh_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_khaisinh_dantoc.SelectedIndex >= 0 && cmb_khaisinh_gioitinh.SelectedIndex >= 0 && cmb_khaisinh_noidk.SelectedIndex >= 0 && cmb_khaisinh_noisinh.SelectedIndex >= 0 && cmb_khaisinh_quanhe.SelectedIndex >= 0 && cmb_khaisinh_quequan.SelectedIndex >= 0 && cmb_khaisinh_quoctich.SelectedIndex >= 0)
            {
                KhaiSinh khaiSinh = new KhaiSinh(txt_khaisinh_maks.Text, txt_khaisinh_hoten.Text, cmb_khaisinh_gioitinh.Text, Convert.ToDateTime(dtp_khaisinh_ngaysinh.Text.Trim()), cmb_khaisinh_noisinh.Text, cmb_khaisinh_dantoc.Text, cmb_khaisinh_quoctich.Text, cmb_khaisinh_quequan.Text, txt_khaisinh_cha.Text, txt_khaisinh_me.Text, txt_khaisinh_ngkhaisinh.Text, cmb_khaisinh_quanhe.Text, Convert.ToDateTime(dtp_khaisinh_ngaydk.Text.Trim()), cmb_khaisinh_noidk.Text);
                ksDao.XoaThongTinKhaiSinh(khaiSinh);
                dtg_KhaiSinh_Loaded(sender, e);
            }    
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
        }
        private void btn_Sua_KhaiSinh_Click(object sender, RoutedEventArgs e)
        {
            if (kt.checkThemKS(txt_khaisinh_hoten, cmb_khaisinh_gioitinh, dtp_khaisinh_ngaysinh, cmb_khaisinh_noisinh, cmb_khaisinh_dantoc, cmb_khaisinh_quoctich, cmb_khaisinh_quequan, txt_khaisinh_cha, txt_khaisinh_me, txt_khaisinh_ngkhaisinh, cmb_khaisinh_quanhe, dtp_khaisinh_ngaydk, cmb_khaisinh_noidk))
            {
                KhaiSinh ks = new KhaiSinh(txt_khaisinh_maks.Text, txt_khaisinh_hoten.Text, cmb_khaisinh_gioitinh.Text, Convert.ToDateTime(dtp_khaisinh_ngaysinh.Text.Trim()), cmb_khaisinh_noisinh.Text, cmb_khaisinh_dantoc.Text, cmb_khaisinh_quoctich.Text, cmb_khaisinh_quequan.Text, txt_khaisinh_cha.Text, txt_khaisinh_me.Text, txt_khaisinh_ngkhaisinh.Text, cmb_khaisinh_quanhe.Text, Convert.ToDateTime(dtp_khaisinh_ngaydk.Text.Trim()), cmb_khaisinh_noidk.Text);
                ksDao.SuaThongTinKhaiSinh(ks);
                dtg_KhaiSinh_Loaded(sender, e);
            }
        }
        private void btn_DienTT_ChungTu_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_chungtu_cccd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                txt_chungtu_hoten.Text = dataTable.Rows[0]["HoTen"].ToString().Trim();
                dtp_chungtu_ngaysinh.Text = dataTable.Rows[0]["NgaySinh"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_Them_ChungTu_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_chungtu_cccd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                if (kt.checkThemChungTu(txt_chungtu_hoten, txt_chungtu_cccd, dtp_chungtu_ngaysinh, dtp_chungtu_ngaymat, txt_chungtu_noimat, txt_chungtu_nguyennhan))
                {
                    GiayChungTu giayChungTu = new GiayChungTu(txt_chungtu_maso.Text, txt_chungtu_hoten.Text, txt_chungtu_cccd.Text, Convert.ToDateTime(dtp_chungtu_ngaysinh.Text.Trim()), Convert.ToDateTime(dtp_chungtu_ngaymat.Text.Trim()), txt_chungtu_noimat.Text, txt_chungtu_nguyennhan.Text);
                    ctDao.ThemThongTinChungTu(giayChungTu);
                    dtg_ChungTu_Loaded(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_Xoa_ChungTu_Click(object sender, RoutedEventArgs e)
        {
            GiayChungTu giayChungTu = new GiayChungTu(txt_chungtu_maso.Text, txt_chungtu_hoten.Text, txt_chungtu_cccd.Text, Convert.ToDateTime(dtp_chungtu_ngaysinh.Text.Trim()), Convert.ToDateTime(dtp_chungtu_ngaymat.Text.Trim()), txt_chungtu_noimat.Text, txt_chungtu_nguyennhan.Text);
            ctDao.XoaThongTinChungTu(giayChungTu);
            dtg_ChungTu_Loaded(sender, e);
        }
        private void btn_Sua_ChungTu_Click(object sender, RoutedEventArgs e)
        {
            if (kt.checkThemChungTu(txt_chungtu_hoten, txt_chungtu_cccd, dtp_chungtu_ngaysinh, dtp_chungtu_ngaymat, txt_chungtu_noimat, txt_chungtu_nguyennhan))
            {
                MessageBox.Show("Bạn không thể thay đổi các thông tin liên quan đến CCCD", "Ghi chú", MessageBoxButton.OK, MessageBoxImage.Information);
                GiayChungTu ct = new GiayChungTu(txt_chungtu_maso.Text, txt_chungtu_hoten.Text, txt_chungtu_cccd.Text, Convert.ToDateTime(dtp_chungtu_ngaysinh.Text.Trim()), Convert.ToDateTime(dtp_chungtu_ngaymat.Text.Trim()), txt_chungtu_noimat.Text, txt_chungtu_nguyennhan.Text);
                ctDao.SuaThongTinChungTu(ct);
                dtg_ChungTu_Loaded(sender, e);
            }
        }
        private void btn_DienTT_Thue_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_thue_cccd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                txt_thue_nguoinopthue.Text = dataTable.Rows[0]["HoTen"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_Them_Thue_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_thue_cccd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                if (kt.checkThemThue(txt_thue_coquanthue, txt_thue_nguoinopthue, txt_thue_cccd, dtp_thue_ngaythaydoi))
                {
                    Thue thue = new Thue(txt_thue_masothue.Text, txt_thue_coquanthue.Text, txt_thue_nguoinopthue.Text, txt_thue_cccd.Text, Convert.ToDateTime(dtp_thue_ngaythaydoi.Text.Trim()));
                    thDao.ThemThongTinThue(thue);
                    dtg_Thue_Loaded(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_Xoa_Thue_Click(object sender, RoutedEventArgs e)
        {
            Thue thue = new Thue(txt_thue_masothue.Text, txt_thue_coquanthue.Text, txt_thue_nguoinopthue.Text, txt_thue_cccd.Text, Convert.ToDateTime(dtp_thue_ngaythaydoi.Text.Trim()));
            thDao.XoaThongTinThue(thue);
            dtg_Thue_Loaded(sender, e);
        }
        private void btn_Sua_Thue_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_thue_cccd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                if (kt.checkThemThue(txt_thue_coquanthue, txt_thue_nguoinopthue, txt_thue_cccd, dtp_thue_ngaythaydoi))
                {
                    MessageBox.Show("Bạn sẽ không thể thay đổi CCCD", "Ghi chú", MessageBoxButton.OK, MessageBoxImage.Information);
                    Thue thue = new Thue(txt_thue_masothue.Text, txt_thue_coquanthue.Text, txt_thue_nguoinopthue.Text, txt_thue_cccd.Text, Convert.ToDateTime(dtp_thue_ngaythaydoi.Text.Trim()));
                    thDao.SuaThongTinThue(thue);
                    dtg_Thue_Loaded(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_Xem_Hokhau_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_HoKhau hoKhau = new ADMIN_HoKhau();
            hoKhau.txt_hokhau_mahokhau.Text = txt_hokhau_mahokhau.Text;
            hoKhau.txt_hokhau_makschuho.Text = txt_hokhau_makschuho.Text;
            hoKhau.txt_hokhau_hotenchuho.Text = txt_hokhau_hotenchuho.Text;
            hoKhau.txt_hokhau_diachi.Text = txt_hokhau_diachi.Text;
            hoKhau.Show();
        }
        private void btn_DienTT_HoKhau_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = ksDao.KiemTraThongTinKhaiSinh(txt_hokhau_makschuho.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                if (Convert.ToInt32(dataTable.Rows[0]["Tuoi"]) >= 18)
                {
                    txt_hokhau_hotenchuho.Text = dataTable.Rows[0]["HoTenKS"].ToString().Trim();
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
        private void btn_Them_Hokhau_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = ksDao.KiemTraThongTinKhaiSinh(txt_hokhau_makschuho.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                if(Convert.ToInt32(dataTable.Rows[0]["Tuoi"]) >= 18)
                {
                    if (kt.checkThemHK(txt_hokhau_makschuho, txt_hokhau_hotenchuho, txt_hokhau_diachi))
                    {
                        HoKhau hk = new HoKhau(txt_hokhau_mahokhau.Text, txt_hokhau_makschuho.Text, txt_hokhau_hotenchuho.Text, txt_hokhau_diachi.Text);
                        hkDao.ThemThongTinHoKhau(hk);
                        dtg_Hokhau_Loaded(sender, e);
                    }
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
        private void btn_Xoa_Hokhau_Click(object sender, RoutedEventArgs e)
        {
            HoKhau hoKhau = new HoKhau(txt_hokhau_mahokhau.Text, txt_hokhau_makschuho.Text, txt_hokhau_hotenchuho.Text, txt_hokhau_diachi.Text);
            hkDao.XoaThongTinHoKhau(hoKhau);
            dtg_Hokhau_Loaded(sender, e);
        }
        private void btn_Sua_Hokhau_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_hokhau_makschuho.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                if (kt.checkThemHK(txt_hokhau_makschuho, txt_hokhau_hotenchuho, txt_hokhau_diachi))
                {
                    MessageBox.Show("Bạn chỉ có quyền thay đổi địa chỉ Hộ khẩu, nếu muốn đổi thông tin chủ hộ và quan hệ trong hộ khẩu vui lòng hủy hộ khẩu này và đăng ký mới", "Ghi chú", MessageBoxButton.OK, MessageBoxImage.Information);
                    HoKhau hk = new HoKhau(txt_hokhau_mahokhau.Text, txt_hokhau_makschuho.Text, txt_hokhau_hotenchuho.Text, txt_hokhau_diachi.Text);
                    hkDao.SuaThongTinHoKhau(hk);
                    dtg_Hokhau_Loaded(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_DienTT_TamTru_Click(object sender, RoutedEventArgs e)
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
        private void btn_Them_Tamtru_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_tamtru_cccd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                if (kt.checkThemTamTru(txt_tamtru_cccd, dtp_tamtru_ngaydk, txt_tamtru_noidk, txt_tamtru_hoten, dtp_tamtru_ngaysinh, txt_tamtru_noicapcccd, dtp_tamtru_ngaycapcccd, dtp_tamtru_ngayden, dtp_tamtru_ngaydi, txt_tamtru_lydo))
                {
                    TamTru tamTru = new TamTru(txt_tamtru_MaTamTru.Text, txt_tamtru_cccd.Text, Convert.ToDateTime(dtp_tamtru_ngaydk.Text.Trim()), txt_tamtru_noidk.Text, txt_tamtru_hoten.Text, Convert.ToDateTime(dtp_tamtru_ngaysinh.Text.Trim()), txt_tamtru_noicapcccd.Text, Convert.ToDateTime(dtp_tamtru_ngaycapcccd.Text.Trim()), Convert.ToDateTime(dtp_tamtru_ngayden.Text.Trim()), Convert.ToDateTime(dtp_tamtru_ngaydi.Text.Trim()), txt_tamtru_lydo.Text);
                    ttDao.ThemThongTinTamTru(tamTru);
                    dtg_Tamtru_Loaded(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_Xoa_Tamtru_Click(object sender, RoutedEventArgs e)
        {
            TamTru tamTru = new TamTru(txt_tamtru_MaTamTru.Text, txt_tamtru_cccd.Text, Convert.ToDateTime(dtp_tamtru_ngaydk.Text.Trim()), txt_tamtru_noidk.Text, txt_tamtru_hoten.Text, Convert.ToDateTime(dtp_tamtru_ngaysinh.Text.Trim()), txt_tamtru_noicapcccd.Text, Convert.ToDateTime(dtp_tamtru_ngaycapcccd.Text.Trim()), Convert.ToDateTime(dtp_tamtru_ngayden.Text.Trim()), Convert.ToDateTime(dtp_tamtru_ngaydi.Text.Trim()), txt_tamtru_lydo.Text);
            ttDao.XoaThongTinTamTru(tamTru);
            dtg_Tamtru_Loaded(sender, e);
        }
        private void btn_Sua_Tamtru_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_tamtru_cccd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                if (kt.checkThemTamTru(txt_tamtru_cccd, dtp_tamtru_ngaydk, txt_tamtru_noidk, txt_tamtru_hoten, dtp_tamtru_ngaysinh, txt_tamtru_noicapcccd, dtp_tamtru_ngaycapcccd, dtp_tamtru_ngayden, dtp_tamtru_ngaydi, txt_tamtru_lydo))
                {
                    MessageBox.Show("Bạn không thể thay đổi các thông tin liên quan đến CCCD", "Ghi chú", MessageBoxButton.OK, MessageBoxImage.Information);
                    TamTru tt = new TamTru(txt_tamtru_MaTamTru.Text, txt_tamtru_cccd.Text, Convert.ToDateTime(dtp_tamtru_ngaydk.Text.Trim()), txt_tamtru_noidk.Text, txt_tamtru_hoten.Text, Convert.ToDateTime(dtp_tamtru_ngaysinh.Text.Trim()), txt_tamtru_noicapcccd.Text, Convert.ToDateTime(dtp_tamtru_ngaycapcccd.Text.Trim()), Convert.ToDateTime(dtp_tamtru_ngayden.Text.Trim()), Convert.ToDateTime(dtp_tamtru_ngaydi.Text.Trim()), txt_tamtru_lydo.Text);
                    ttDao.SuaThongTinTamTru(tt);
                    dtg_Tamtru_Loaded(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_DienTT_TamVang_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_tamvang_cmnd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                txt_tamvang_hoten.Text = dataTable.Rows[0]["HoTen"].ToString().Trim();
                dtp_tamvang_ngaycapcmnd.Text = dataTable.Rows[0]["NgcCccd"].ToString().Trim();
                dtp_tamvang_ngaysinh.Text = dataTable.Rows[0]["NgaySinh"].ToString().Trim();
                txt_tamvang_noicapcmnd.Text = dataTable.Rows[0]["NcCccd"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_Them_Tamvang_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_tamvang_cmnd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                if (kt.checkThemTamVang(txt_tamvang_cmnd, dtp_tamvang_ngaydk, txt_tamvang_noichuyendi, txt_tamvang_noichuyenden, txt_tamvang_hoten, dtp_tamvang_ngaysinh, dtp_tamvang_ngaycapcmnd,
                txt_tamvang_noicapcmnd, dtp_tamvang_ngaydi, dtp_tamvang_ngayve, txt_tamvang_lydo))
                {
                    TamVang tamVang = new TamVang(txt_tamvang_matamvang.Text, txt_tamvang_cmnd.Text, Convert.ToDateTime(dtp_tamvang_ngaydk.Text.Trim()), txt_tamvang_noichuyendi.Text, txt_tamvang_noichuyenden.Text, txt_tamvang_hoten.Text, Convert.ToDateTime(dtp_tamvang_ngaysinh.Text.Trim()), Convert.ToDateTime(dtp_tamvang_ngaycapcmnd.Text.Trim()), txt_tamvang_noicapcmnd.Text, Convert.ToDateTime(dtp_tamvang_ngaydi.Text.Trim()), Convert.ToDateTime(dtp_tamvang_ngayve.Text.Trim()), txt_tamvang_lydo.Text);
                    tvDao.ThemThongTinTamVang(tamVang);
                    dtg_Tamvang_Loaded(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
        }
        private void btn_Xoa_Tamvang_Click(object sender, RoutedEventArgs e)
        {
            TamVang tamVang = new TamVang(txt_tamvang_matamvang.Text, txt_tamvang_cmnd.Text, Convert.ToDateTime(dtp_tamvang_ngaydk.Text.Trim()), txt_tamvang_noichuyendi.Text, txt_tamvang_noichuyenden.Text, txt_tamvang_hoten.Text, Convert.ToDateTime(dtp_tamvang_ngaysinh.Text.Trim()), Convert.ToDateTime(dtp_tamvang_ngaycapcmnd.Text.Trim()), txt_tamvang_noicapcmnd.Text, Convert.ToDateTime(dtp_tamvang_ngaydi.Text.Trim()), Convert.ToDateTime(dtp_tamvang_ngayve.Text.Trim()), txt_tamvang_lydo.Text);
            tvDao.XoaThongTinTamVang(tamVang);
            dtg_Tamvang_Loaded(sender, e);
        }
        private void btn_Sua_Tamvang_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_tamvang_cmnd.Text.Trim());
            if (dataTable.Rows.Count > 0)
            {
                if (kt.checkThemTamVang(txt_tamvang_cmnd, dtp_tamvang_ngaydk, txt_tamvang_noichuyendi, txt_tamvang_noichuyenden, txt_tamvang_hoten, dtp_tamvang_ngaysinh, dtp_tamvang_ngaycapcmnd,
                txt_tamvang_noicapcmnd, dtp_tamvang_ngaydi, dtp_tamvang_ngayve, txt_tamvang_lydo))
                {
                    MessageBox.Show("Bạn không thể thay đổi các thông tin liên quan đến CCCD", "Ghi chú", MessageBoxButton.OK, MessageBoxImage.Information);
                    TamVang tv = new TamVang(txt_tamvang_matamvang.Text, txt_tamvang_cmnd.Text, Convert.ToDateTime(dtp_tamvang_ngaydk.Text.Trim()), txt_tamvang_noichuyendi.Text, txt_tamvang_noichuyenden.Text, txt_tamvang_hoten.Text, Convert.ToDateTime(dtp_tamvang_ngaysinh.Text.Trim()), Convert.ToDateTime(dtp_tamvang_ngaycapcmnd.Text.Trim()), txt_tamvang_noicapcmnd.Text, Convert.ToDateTime(dtp_tamvang_ngaydi.Text.Trim()), Convert.ToDateTime(dtp_tamvang_ngayve.Text.Trim()), txt_tamvang_lydo.Text);
                    tvDao.SuaThongTinTamVang(tv);
                    dtg_Tamvang_Loaded(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Người này không tồn tại trong hệ thống!");
            }
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
        private void btn_Them_Cnkh_Click(object sender, RoutedEventArgs e)
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
                                                dtg_Cnkh_Loaded(sender, e);
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
        private void btn_Xoa_Cnkh_Click(object sender, RoutedEventArgs e)
        {
            Cnkh cnkh = new Cnkh (txt_kethon_makh.Text, txt_kethon_hotenvo.Text, txt_kethon_hotenchong.Text, Convert.ToDateTime(dtp_kethon_ngaysinhvo.Text.Trim()), Convert.ToDateTime(dtp_kethon_ngaysinhchong.Text.Trim()), txt_kethon_dantocvo.Text, txt_kethon_dantocchong.Text, txt_kethon_quoctichvo.Text, txt_kethon_quoctichchong.Text, txt_kethon_noicutruvo.Text, txt_kethon_noicutruchong.Text, txt_kethon_gtttvo.Text, txt_kethon_gtttchong.Text, txt_kethon_noidkkethon.Text, Convert.ToDateTime(dtp_kethon_ngaydkkethon.Text.Trim()));
            khDao.XoaThongTinCNKH(cnkh);
            dtg_Cnkh_Loaded(sender, e);
        }
        private void btn_Sua_Cnkh1_Click(object sender, RoutedEventArgs e)
        {
            if (kt.checkThemKetHon(txt_kethon_hotenvo, txt_kethon_hotenchong, dtp_kethon_ngaysinhvo, dtp_kethon_ngaysinhchong,
            txt_kethon_dantocvo, txt_kethon_dantocchong, txt_kethon_quoctichvo, txt_kethon_quoctichchong, txt_kethon_noicutruvo, txt_kethon_noicutruchong, txt_kethon_gtttvo,
            txt_kethon_gtttchong, txt_kethon_noidkkethon, dtp_kethon_ngaydkkethon))
            {
                MessageBox.Show("Bạn không thể thay đổi các thông tin liên quan đến CCCD của Vợ hoặc Chồng", "Ghi chú", MessageBoxButton.OK, MessageBoxImage.Information);
                Cnkh kh = new Cnkh(txt_kethon_makh.Text, txt_kethon_hotenvo.Text, txt_kethon_hotenchong.Text, Convert.ToDateTime(dtp_kethon_ngaysinhvo.Text.Trim()), Convert.ToDateTime(dtp_kethon_ngaysinhchong.Text.Trim()), txt_kethon_dantocvo.Text, txt_kethon_dantocchong.Text, txt_kethon_quoctichvo.Text, txt_kethon_quoctichchong.Text, txt_kethon_noicutruvo.Text, txt_kethon_noicutruchong.Text, txt_kethon_gtttvo.Text, txt_kethon_gtttchong.Text, txt_kethon_noidkkethon.Text, Convert.ToDateTime(dtp_kethon_ngaydkkethon.Text.Trim()));
                khDao.SuaThongTinCnkh(kh);
                dtg_Cnkh_Loaded(sender, e);
            }
        }
        private void btn_DienTT_NguoiDK_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = lhDao.HienThiThongTinDonLyHon(txt_lyhon_cccdnguoinopdon.Text);
            if (dataTable.Rows.Count > 0)
            {
                txt_lyhon_hotennguoinopdon.Text = dataTable.Rows[0]["HoTenNguoiNopDon"].ToString().Trim();
                txt_lyhon_cccdvo.Text = dataTable.Rows[0]["CccdVo"].ToString().Trim();
                txt_lyhon_cccdchong.Text = dataTable.Rows[0]["CccdChong"].ToString().Trim();
                txt_lyhon_hotenchong.Text = dataTable.Rows[0]["HoTenChong"].ToString().Trim();
                txt_lyhon_hotenvo.Text = dataTable.Rows[0]["HoTenVo"].ToString().Trim();
                txt_lyhon_macnkh.Text = dataTable.Rows[0]["MaCnkh"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Không có thông tin về người này!");
            }
        }

        private void btn_Them_Lyhon_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_lyhon_cccdnguoinopdon.Text);
            if (dataTable.Rows.Count > 0)
            {
                if (kt.checkThemLyHon(txt_lyhon_cccdnguoinopdon, txt_lyhon_hotennguoinopdon, txt_lyhon_cccdvo, txt_lyhon_hotenvo, txt_lyhon_cccdchong, txt_lyhon_hotenchong, txt_lyhon_noidk, dtp_lyhon_ngaydk, txt_lyhon_lydo))
                {
                    LyHon lyHon = new LyHon(txt_lyhon_malyhon.Text, txt_lyhon_macnkh.Text, txt_lyhon_cccdnguoinopdon.Text, txt_lyhon_hotennguoinopdon.Text, txt_lyhon_cccdvo.Text, txt_lyhon_hotenvo.Text, txt_lyhon_cccdchong.Text, txt_lyhon_hotenchong.Text, txt_lyhon_noidk.Text, Convert.ToDateTime(dtp_lyhon_ngaydk.Text.Trim()), txt_lyhon_lydo.Text);
                    lhDao.ThemThongTinLyHon(lyHon);
                    dtg_LyHon_Loaded(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Không có thông tin về người này!");
            }
        }
        private void btn_Xoa_Lyhon_Click(object sender, RoutedEventArgs e)
        {
            LyHon lyHon = new LyHon (txt_lyhon_malyhon.Text, txt_lyhon_macnkh.Text, txt_lyhon_cccdnguoinopdon.Text, txt_lyhon_hotennguoinopdon.Text, txt_lyhon_cccdvo.Text, txt_lyhon_hotenvo.Text, txt_lyhon_cccdchong.Text, txt_lyhon_hotenchong.Text, txt_lyhon_noidk.Text, Convert.ToDateTime(dtp_lyhon_ngaydk.Text.Trim()), txt_lyhon_lydo.Text);
            lhDao.XoaThongTinLyHon(lyHon);
            dtg_LyHon_Loaded(sender, e);
        }
        private void btn_Sua_Lyhon_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = cdDao.KiemTraDuLieuCongDan(txt_lyhon_cccdnguoinopdon.Text);
            if (dataTable.Rows.Count > 0)
            {
                if (kt.checkThemLyHon(txt_lyhon_cccdnguoinopdon, txt_lyhon_hotennguoinopdon, txt_lyhon_cccdvo, txt_lyhon_hotenvo, txt_lyhon_cccdchong, txt_lyhon_hotenchong, txt_lyhon_noidk, dtp_lyhon_ngaydk, txt_lyhon_lydo))
                {
                    MessageBox.Show("Bạn không thể thay đổi các thông tin liên quan đến CCCD", "Ghi chú", MessageBoxButton.OK, MessageBoxImage.Information);
                    LyHon lh = new LyHon(txt_lyhon_malyhon.Text, txt_lyhon_macnkh.Text, txt_lyhon_cccdnguoinopdon.Text, txt_lyhon_hotennguoinopdon.Text, txt_lyhon_cccdvo.Text, txt_lyhon_hotenvo.Text, txt_lyhon_cccdchong.Text, txt_lyhon_hotenchong.Text, txt_lyhon_noidk.Text, Convert.ToDateTime(dtp_lyhon_ngaydk.Text.Trim()), txt_lyhon_lydo.Text);
                    lhDao.SuaThongTinLyHon(lh);
                    dtg_LyHon_Loaded(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Không có thông tin về người này!");
            }
        }

        private void btn_clear_tt_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_CongDan load = new ADMIN_CongDan();
            load.Show();
            load.tab_tt.IsSelected = true;
            Close();
        }

        private void btn_clear_ks_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_CongDan load = new ADMIN_CongDan();
            load.Show();
            load.tab_khaisinh.IsSelected = true;
            Close();
        }

        private void btn_clear_ct_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_CongDan load = new ADMIN_CongDan();
            load.Show();
            load.tab_khaitu.IsSelected = true;
            Close();
        }

        private void btn_clear_thue_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_CongDan load = new ADMIN_CongDan();
            load.Show();
            load.tab_thue.IsSelected = true;
            Close();
        }

        private void btn_clear_hk_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_CongDan load = new ADMIN_CongDan();
            load.Show();
            load.tab_hokhau.IsSelected = true;
            Close();
        }

        private void btn_clear_tamtru_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_CongDan load = new ADMIN_CongDan();
            load.Show();
            load.tab_tamtru.IsSelected = true;
            Close();
        }

        private void btn_clear_tamvang_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_CongDan load = new ADMIN_CongDan();
            load.Show();
            load.tab_tamvang.IsSelected = true;
            Close();
        }

        private void btn_clear_lyhon_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_CongDan load = new ADMIN_CongDan();
            load.Show();
            load.tab_lyhon.IsSelected = true;
            Close();
        }

        private void btn_clear_cnkh_Click(object sender, RoutedEventArgs e)
        {
            ADMIN_CongDan load = new ADMIN_CongDan();
            load.Show();
            load.tab_cnkh.IsSelected = true;
            Close();
        }
    }
}
