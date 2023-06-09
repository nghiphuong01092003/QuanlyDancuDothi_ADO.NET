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
    /// Interaction logic for Đơn.xaml
    /// </summary>
    public partial class Đơn : Window
    {
        CongDanDAO CDDao = new CongDanDAO();
        KhaiSinhDAO ksDao = new KhaiSinhDAO();
        ChungTuDAO ctDao = new ChungTuDAO();
        ThueDAO thDao = new ThueDAO();
        HoKhauDAO hkDao = new HoKhauDAO();
        TamTruDAO ttDao = new TamTruDAO();
        TamVangDAO tvDao = new TamVangDAO();
        KetHonDAO khDao = new KetHonDAO();
        LyHonDAO lhDao = new LyHonDAO();
        public Đơn()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click_1(object sender, RoutedEventArgs e)
        {
            ADMIN_QuanLyDon qld = new ADMIN_QuanLyDon();
            qld.Show();
            Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            DataTable dt2 = CDDao.KiemTraDuLieuCongDan(ADMIN_QuanLyDon.search);
            CongDan cd = new CongDan(dt2.Rows[0]["HoTen"].ToString(), dt2.Rows[0]["GioiTinh"].ToString(), dt2.Rows[0]["CCCD"].ToString(), Convert.ToDateTime(dt2.Rows[0]["NgaySinh"]),
                dt2.Rows[0]["NoiSinh"].ToString(), dt2.Rows[0]["QuocTich"].ToString(), dt2.Rows[0]["DanToc"].ToString(), dt2.Rows[0]["QueQuan"].ToString(),
                dt2.Rows[0]["DiaChi"].ToString(), dt2.Rows[0]["NcCccd"].ToString(), Convert.ToDateTime(dt2.Rows[0]["NgcCccd"]), dt2.Rows[0]["SDT"].ToString(), dt2.Rows[0]["Email"].ToString(), dt2.Rows[0]["MaKS"].ToString());
            txt_tt_hoten.Text = cd.Hoten.ToString().Trim();
            txt_tt_gioitinh.Text = cd.Gioitinh.ToString().Trim();
            txt_tt_cccd.Text = cd.Cccd.ToString().Trim();
            dtp_tt_ngaysinh.Text = cd.Ngaysinh.ToString().Trim();
            txt_tt_noisinh.Text = cd.Noisinh.ToString().Trim();
            txt_tt_quoctich.Text = cd.Quoctich.ToString().Trim();
            txt_tt_dantoc.Text = cd.Dantoc.ToString().Trim();
            txt_tt_quequan.Text = cd.Quequan.ToString().Trim();
            txt_tt_diachi.Text = cd.Noiohientai.ToString().Trim();
            txt_tt_sdt.Text = cd.Sdt.ToString().Trim();
            txt_tt_email.Text = cd.Email.ToString().Trim();


            DataTable dt3 = ttDao.HienThiThongTinTamTru(ADMIN_QuanLyDon.search);
            if (dt3.Rows.Count > 0)
            {
                TamTru tamtru = new TamTru(dt3.Rows[0]["MaTT"].ToString(), dt3.Rows[0]["Cccd"].ToString(), Convert.ToDateTime(dt3.Rows[0]["Ngaydk"]), dt3.Rows[0]["Noidk"].ToString(),
                    dt3.Rows[0]["HoTen"].ToString(), Convert.ToDateTime(dt3.Rows[0]["NgaySinh"]), dt3.Rows[0]["NcCccd"].ToString(), Convert.ToDateTime(dt3.Rows[0]["NgcCccd"]),
                    Convert.ToDateTime(dt3.Rows[0]["Ngayden"]), Convert.ToDateTime(dt3.Rows[0]["Ngaydi"]), dt3.Rows[0]["LyDo"].ToString());
                txt_tamtru_matt.Text = tamtru.Matt.ToString().Trim();
                txt_tamtru_hoten.Text = tamtru.Hoten.ToString().Trim();
                dtp_tamtru_ngaysinh.Text = tamtru.Ngaysinh.ToString().Trim();
                txt_tamtru_cccd.Text = tamtru.Cccd.ToString().Trim();
                txt_tamtru_noicapcccd.Text = tamtru.Noicapcccd.ToString().Trim();
                dtp_tamtru_ngaycapcccd.Text = tamtru.Ngaycapcccd.ToString().Trim();
                dtp_tamtru_ngayden.Text = tamtru.Ngayden.ToString().Trim();
                dtp_tamtru_ngaydi.Text = tamtru.Ngaydi.ToString().Trim();
                txt_tamtru_lydo.Text = tamtru.Lydo.ToString().Trim();
                txt_tamtru_noidk.Text = tamtru.Noidk.ToString().Trim();
                dtp_tamtru_ngaydk.Text = tamtru.Ngaydk.ToString().Trim();
            }
            else
            {
                tab_tamtru.IsEnabled = false;
            }

            DataTable dt4 = tvDao.HienThiThongTinTamVang(ADMIN_QuanLyDon.search);
            if (dt4.Rows.Count > 0)
            {
                TamVang tamvang = new TamVang(dt4.Rows[0]["MaTV"].ToString(), dt4.Rows[0]["CCCD"].ToString(), Convert.ToDateTime(dt4.Rows[0]["Ngaydk"]), dt4.Rows[0]["Ncdi"].ToString(),
                    dt4.Rows[0]["Ncden"].ToString(), dt4.Rows[0]["HoTen"].ToString(), Convert.ToDateTime(dt4.Rows[0]["NgaySinh"]), Convert.ToDateTime(dt4.Rows[0]["NgcCccd"]), dt4.Rows[0]["NcCccd"].ToString(), Convert.ToDateTime(dt4.Rows[0]["Ngaydi"]), Convert.ToDateTime(dt4.Rows[0]["Ngayve"]), dt4.Rows[0]["Lydo"].ToString());
                txt_tamvang_noichuyendi.Text = tamvang.Ncdi.ToString().Trim();
                txt_tamvang_noichuyenden.Text = tamvang.Ncden.ToString().Trim();
                txt_tamvang_matv.Text = tamvang.Matv.ToString().Trim();
                txt_tamvang_hoten.Text = tamvang.Hoten.ToString().Trim();
                dtp_tamvang_ngaysinh.Text = tamvang.Ngaysinh.ToString().Trim();
                txt_tamvang_cccd.Text = tamvang.Cccd.ToString().Trim();
                txt_tamvang_noicapcccd.Text = tamvang.Noicapcccd.ToString().Trim();
                dtp_tamvang_ngaycapcccd.Text = tamvang.Ngaycapcccd.ToString().Trim();
                dtp_tamvang_ngaydi.Text = tamvang.Ngaydi.ToString().Trim();
                dtp_tamvang_ngayve.Text = tamvang.Ngayve.ToString().Trim();
                txt_tamvang_lydo.Text = tamvang.Lydo.ToString().Trim();
            }
            else
            {
                tab_tamvang.IsEnabled = false;
            }

            DataTable dt5 = khDao.HienThiThongTinCnkh(ADMIN_QuanLyDon.search);
            if (dt5.Rows.Count > 0)
            {
                Cnkh cnkh = new Cnkh(dt5.Rows[0]["MaCnkh"].ToString(), dt5.Rows[0]["Hotenvo"].ToString(), dt5.Rows[0]["Hotenchong"].ToString(), Convert.ToDateTime(dt5.Rows[0]["Ngaysinhvo"]), Convert.ToDateTime(dt5.Rows[0]["Ngaysinhchong"]),
                    dt5.Rows[0]["Dantocvo"].ToString(), dt5.Rows[0]["Dantocchong"].ToString(), dt5.Rows[0]["Quoctichvo"].ToString(), dt5.Rows[0]["Quoctichchong"].ToString(), dt5.Rows[0]["Noicutruvo"].ToString(), dt5.Rows[0]["Noicutruchong"].ToString(), dt5.Rows[0]["Giaytotuythanvo"].ToString(), dt5.Rows[0]["Giaytotuythanchong"].ToString(), dt5.Rows[0]["Noidk"].ToString(), Convert.ToDateTime(dt5.Rows[0]["Ngaydk"]));
                txt_kethon_hotenvo.Text = cnkh.Hotenvo.ToString().Trim();
                dtb_kethon_ngaysinhvo.Text = cnkh.Ngaysinhvo.ToString().Trim();
                txt_kethon_dantocvo.Text = cnkh.Dantocvo.ToString().Trim();
                txt_kethon_quoctichvo.Text = cnkh.Quoctichvo.ToString().Trim();
                txt_kethon_noicutruvo.Text = cnkh.Noicutruvo.ToString().Trim();
                txt_kethon_gtttvo.Text = cnkh.Cccdvo.ToString().Trim();
                txt_kethon_hotenchong.Text = cnkh.Hotenchong.ToString().Trim();
                dtb_kethon_ngaysinhchong.Text = cnkh.Ngaysinhchong.ToString().Trim();
                txt_kethon_dantocchong.Text = cnkh.Dantocchong.ToString().Trim();
                txt_kethon_quoctichchong.Text = cnkh.Quoctichchong.ToString().Trim();
                txt_kethon_noicutruchong.Text = cnkh.Noicutruchong.ToString().Trim();
                txt_kethon_gtttchong.Text = cnkh.Cccdchong.ToString().Trim();
                txt_kethon_macnkh.Text = cnkh.Macnkh.ToString().Trim();
                txt_kethon_noidkkethon.Text = cnkh.Noidk.ToString().Trim();
                dtb_kethon_ngaydkkethon.Text = cnkh.Ngaydk.ToString().Trim();
            }
            else
            {
                grid_Cnkh.IsEnabled = false;
            }

            DataTable dt6 = ksDao.HienThiThongTinKhaiSinh(ADMIN_QuanLyDon.search);
            if (dt6.Rows.Count > 0)
            {
                KhaiSinh ks = new KhaiSinh(dt6.Rows[0]["MaKS"].ToString(), dt6.Rows[0]["Hoten"].ToString(), dt6.Rows[0]["GioiTinh"].ToString(), Convert.ToDateTime(dt6.Rows[0]["NgaySinh"]),
                    dt6.Rows[0]["NoiSinh"].ToString(), dt6.Rows[0]["DanToc"].ToString(), dt6.Rows[0]["QuocTich"].ToString(), dt6.Rows[0]["QueQuan"].ToString(),
                    dt6.Rows[0]["Cha"].ToString(), dt6.Rows[0]["Me"].ToString(), dt6.Rows[0]["NguoiKhaiSinh"].ToString(), dt6.Rows[0]["QuanHe"].ToString(), Convert.ToDateTime(dt6.Rows[0]["NgayDk"]), dt6.Rows[0]["NoiDk"].ToString());
                txt_ks_hoten.Text = ks.HotenKS.ToString().Trim();
                txt_ks_maks.Text = ks.Maks.ToString().Trim();
                dtp_ks_ngaysinh.Text = ks.Ngaysinh.ToString().Trim();
                txt_ks_noisinh.Text = ks.Noisinh.ToString().Trim();
                txt_ks_quoctich.Text = ks.Quoctich.ToString().Trim();
                txt_ks_dantoc.Text = ks.Dantoc.ToString().Trim();
                txt_ks_quequan.Text = ks.Quequan.ToString().Trim();
                txt_ks_cha.Text = ks.Cha.ToString().Trim();
                txt_ks_me.Text = ks.Me.ToString().Trim();
                dtp_ks_ngaydk.Text = ks.Ngaydk.ToString().Trim();
                txt_ks_nguoikhaisinh.Text = ks.Nguoikhaisinh.ToString().Trim();
                txt_ks_noidk.Text = ks.Noidk.ToString().Trim();
                txt_ks_quanhe.Text = ks.Quanhe.ToString().Trim();
            }
            else
            {
                tab_khaisinh.IsEnabled = false;
            }
            DataTable dt7 = lhDao.HienThiThongTinLyHon(ADMIN_QuanLyDon.search);
            if (dt7.Rows.Count > 0)
            {
                //Lyhon.MaLh as Malyhon, Lyhon.MaCnkh as Makethon, HotenVo, P.CccdVo as CCCDVo, HotenChong, Q.CccdChong as CCCDChong, Lyhon.Noidk as Noidangky, Lyhon.Ngaydk as Ngaydangky, Lydo, CccdNguoiNopDon, Hotennguoinopdon
                LyHon lh = new LyHon(dt7.Rows[0]["Malyhon"].ToString(), dt7.Rows[0]["Makethon"].ToString(), dt7.Rows[0]["CccdNguoiNopDon"].ToString(),
                dt7.Rows[0]["Hotennguoinopdon"].ToString(), dt7.Rows[0]["CCCDVo"].ToString(), dt7.Rows[0]["HotenVo"].ToString(), dt7.Rows[0]["CCCDChong"].ToString(),
                dt7.Rows[0]["HotenChong"].ToString(), dt7.Rows[0]["Noidangky"].ToString(), Convert.ToDateTime(dt7.Rows[0]["Ngaydangky"]), dt7.Rows[0]["Lydo"].ToString());
                txt_cnlh_malh.Text = lh.Malh.ToString().Trim();
                txt_cnlh_makh.Text = lh.Macnkh.ToString().Trim();
                txt_cnlh_hotenvo.Text = lh.Hotenvo.ToString().Trim();
                txt_cnlh_cccdvo.Text = lh.Cccdvo.ToString().Trim();
                dtp_cnlh_ngaydk.Text = lh.Ngaydk.ToString().Trim();
                txt_cnlh_hotenchong.Text = lh.Hotenchong.ToString().Trim();
                txt_cnlh_cccdchong.Text = lh.Cccdchong.ToString().Trim();
                txt_cnlh_noidk.Text = lh.Noidk.ToString().Trim();
                txt_cnlh_lydo.Text = lh.Lydo.ToString().Trim();
                txt_cnlh_hotennguoinopdon.Text = lh.Hotennguoinopdon.ToString().Trim();
                txt_cnlh_cccdnguoinopdon.Text = lh.Cccdnguoinopdon.ToString().Trim();
            }
            else
            {
                tab_lyhon.IsEnabled = false;
            }

            DataTable dt8 = ctDao.HienThiThongTinChungTu(ADMIN_QuanLyDon.search);
            if (dt8.Rows.Count > 0)
            {
                GiayChungTu ct = new GiayChungTu(dt8.Rows[0]["MaCT"].ToString(), dt8.Rows[0]["Hoten"].ToString(), dt8.Rows[0]["Cccd"].ToString(), Convert.ToDateTime(dt8.Rows[0]["NgaySinh"]),
                Convert.ToDateTime(dt8.Rows[0]["NgayMat"]), dt8.Rows[0]["NoiMat"].ToString(), dt8.Rows[0]["NguyenNhan"].ToString());
                txt_ct_mact.Text = ct.Mact.ToString().Trim();
                txt_ct_hoten.Text = ct.Hoten.ToString().Trim();
                txt_ct_cccd.Text = ct.Cccd.ToString().Trim();
                txt_ct_noimat.Text = ct.Noimat.ToString().Trim();
                dtp_ct_ngaymat.Text = ct.Ngaymat.ToString().Trim();
                dtp_ct_ngaysinh.Text = ct.Ngaysinh.ToString().Trim();
                txt_ct_lydo.Text = ct.Nguyennhan.ToString().Trim();
            }
            else
            {
                tab_chungtu.IsEnabled = false;
            }
        }
        private void dtg_Tamtru_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = (DataRowView)dtg_Tamtru.SelectedItem;
            if (rowView != null)
            {
                txt_tamtru_matt.Text = rowView["Matt"].ToString();
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
                txt_tamvang_matv.Text = rowView["MaTV"].ToString();
                //dtp.Text = rowView["Ngaydk"].ToString();
                txt_tamvang_noichuyendi.Text = rowView["NCdi"].ToString();
                txt_tamvang_noichuyenden.Text = rowView["NCden"].ToString();
                txt_tamvang_hoten.Text = rowView["HoTen"].ToString();
                dtp_tamvang_ngaysinh.Text = rowView["NgaySinh"].ToString();
                txt_tamvang_cccd.Text = rowView["CCCD"].ToString();
                txt_tamvang_noicapcccd.Text = rowView["NcCccd"].ToString();
                dtp_tamvang_ngaycapcccd.Text = rowView["NgcCccd"].ToString();
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
                txt_kethon_macnkh.Text = rowView["MaCnkh"].ToString();
                txt_kethon_hotenvo.Text = rowView["Hotenvo"].ToString();
                dtb_kethon_ngaysinhvo.Text = rowView["Ngaysinhvo"].ToString();
                txt_kethon_dantocvo.Text = rowView["Dantocvo"].ToString();
                txt_kethon_quoctichvo.Text = rowView["Quoctichvo"].ToString();
                txt_kethon_noicutruvo.Text = rowView["Noicutruvo"].ToString();
                txt_kethon_gtttvo.Text = rowView["Giaytotuythanvo"].ToString();
                txt_kethon_hotenchong.Text = rowView["Hotenchong"].ToString();
                dtb_kethon_ngaysinhchong.Text = rowView["Ngaysinhchong"].ToString();
                txt_kethon_dantocchong.Text = rowView["Dantocchong"].ToString();
                txt_kethon_quoctichchong.Text = rowView["Quoctichchong"].ToString();
                txt_kethon_noicutruchong.Text = rowView["Noicutruchong"].ToString();
                txt_kethon_gtttchong.Text = rowView["Giaytotuythanchong"].ToString();
                txt_kethon_noidkkethon.Text = rowView["Noidk"].ToString();
                dtb_kethon_ngaydkkethon.Text = rowView["Ngaydk"].ToString();
            }
        }
        private void dtg_LyHon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = (DataRowView)dtg_LyHon.SelectedItem;
            if (rowView != null)
            {
                txt_cnlh_noidk.Text = rowView["Malyhon"].ToString();
                txt_cnlh_makh.Text = rowView["Makethon"].ToString();
                txt_cnlh_hotennguoinopdon.Text = rowView["Hotennguoinopdon"].ToString();
                txt_cnlh_cccdnguoinopdon.Text = rowView["CccdNguoiNopDon"].ToString();
                txt_cnlh_hotenvo.Text = rowView["HotenVo"].ToString();
                txt_cnlh_cccdvo.Text = rowView["CCCDVo"].ToString();
                txt_cnlh_hotenchong.Text = rowView["HotenChong"].ToString();
                txt_cnlh_hotenchong.Text = rowView["CCCDChong"].ToString();
                txt_cnlh_noidk.Text = rowView["Noidangky"].ToString();
                dtp_cnlh_ngaydk.Text = rowView["Ngaydangky"].ToString();
                txt_cnlh_lydo.Text = rowView["Lydo"].ToString();
            }
        }
        private void dtg_Tamtru_Loaded(object sender, RoutedEventArgs e)
        {
            ttDao.LichSuThongTinTamTru(ADMIN_QuanLyDon.search, dtg_Tamtru);
        }

        private void dtg_Tamvang_Loaded(object sender, RoutedEventArgs e)
        {
            tvDao.LichSuThongTinTamVang(ADMIN_QuanLyDon.search, dtg_Tamvang);
        }

        private void dtg_Cnkh_Loaded(object sender, RoutedEventArgs e)
        {
            khDao.LichSuThongTinCNKH(ADMIN_QuanLyDon.search, dtg_Cnkh);
        }

        private void dtg_LyHon_Loaded(object sender, RoutedEventArgs e)
        {
            lhDao.LichSuThongTinLyHon(ADMIN_QuanLyDon.search, dtg_LyHon);
        }
    }
}

