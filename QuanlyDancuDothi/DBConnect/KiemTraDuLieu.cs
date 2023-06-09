using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using QuanlyDancuDothi.ClassDAO;

namespace QuanlyDancuDothi.DBConnect
{
    public class KiemTraDuLieu
    {
        KhaiSinhDAO ksDao = new KhaiSinhDAO();
        LyHonDAO lhDao = new LyHonDAO();
        public bool IsNotName(string name)
        {
            Regex isValidInput = new Regex(@"[0-9+\-\/\*\(\)]");
            return isValidInput.IsMatch(name);
        }
        public bool IsCmndNumber(string cmndNumber)
        {
            Regex isValidInput = new Regex(@"^\d{9}(\d{3})?$");
            return isValidInput.IsMatch(cmndNumber);
        }
        public bool IsPhoneNumber(string phoneNumber)
        {
            Regex isValidInput = new Regex(@"\b0[0-9]{9}\b");
            return isValidInput.IsMatch(phoneNumber);
        }
        public bool IsEmail(string email)
        {
            Regex isValidInput = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return isValidInput.IsMatch(email);
        }
        public bool checkThemKS(TextBox txt_khaisinh_hoten, ComboBox cmb_khaisinh_gioitinh, DatePicker dtp_khaisinh_ngaysinh, ComboBox cmb_khaisinh_noisinh,
            ComboBox cmb_khaisinh_dantoc, ComboBox cmb_khaisinh_quoctich, ComboBox cmb_khaisinh_quequan, TextBox txt_khaisinh_cha, TextBox txt_khaisinh_me, TextBox txt_khaisinh_ngkhaisinh,
            ComboBox cmb_khaisinh_quanhe, DatePicker dtp_khaisinh_ngaydk, ComboBox cmb_khaisinh_noidk)
        {
            if (string.IsNullOrEmpty(txt_khaisinh_hoten.Text))
            {
                MessageBox.Show(messageBoxText: "Họ tên không được để trống");
                txt_khaisinh_hoten.Focus();
                return false;
            }
            if (IsNotName(txt_khaisinh_hoten.Text))
            {
                MessageBox.Show(messageBoxText: "Họ tên không hợp lệ");
                txt_khaisinh_hoten.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cmb_khaisinh_gioitinh.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn giới tính");
                cmb_khaisinh_gioitinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_khaisinh_ngaysinh.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn ngày sinh");
                dtp_khaisinh_ngaysinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cmb_khaisinh_noisinh.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn nơi sinh");
                cmb_khaisinh_noisinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cmb_khaisinh_dantoc.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn dân tộc");
                cmb_khaisinh_dantoc.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cmb_khaisinh_quoctich.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn quốc tịch");
                cmb_khaisinh_quoctich.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cmb_khaisinh_quequan.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn quê quán");
                cmb_khaisinh_quequan.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cmb_khaisinh_quoctich.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn quốc tịch");
                cmb_khaisinh_quoctich.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_khaisinh_cha.Text))
            {
                MessageBox.Show(messageBoxText: "CCCD cha không được để trống");
                txt_khaisinh_cha.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_khaisinh_me.Text))
            {
                MessageBox.Show(messageBoxText: "CCCD mẹ không được để trống");
                txt_khaisinh_me.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_khaisinh_ngkhaisinh.Text))
            {
                MessageBox.Show(messageBoxText: "CCCD người khai sinh không được để trống");
                txt_khaisinh_ngkhaisinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cmb_khaisinh_quanhe.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn quan hệ");
                cmb_khaisinh_quanhe.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cmb_khaisinh_quanhe.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn quan hệ");
                cmb_khaisinh_quanhe.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_khaisinh_ngaydk.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn ngày đăng kí");
                dtp_khaisinh_ngaydk.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cmb_khaisinh_noidk.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lònng chọn nơi đăng kí");
                cmb_khaisinh_noidk.Focus();
                return false;
            }
            return true;
        }
        public bool checkThemCongDan(TextBox txt_tt_hoten, TextBox txt_tt_gioitinh, TextBox txt_tt_cccd, DatePicker dtp_tt_ngaysinh, TextBox txt_tt_noisinh, TextBox txt_tt_quoctich,
            TextBox txt_tt_dantoc, TextBox txt_tt_quequan, TextBox txt_tt_diachi, TextBox txt_tt_ncCccd, DatePicker dtp_tt_ngcCccd, TextBox txt_tt_sdt, TextBox txt_tt_email, TextBox txt_tt_maks)
        {
            if (string.IsNullOrEmpty(txt_tt_hoten.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập MaKS để tải thông tin");
                txt_tt_hoten.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tt_gioitinh.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập MaKS để tải thông tin");
                txt_tt_gioitinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tt_cccd.Text))
            {
                MessageBox.Show(messageBoxText: "CCCD không được để trống");
                txt_tt_cccd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_tt_ngaysinh.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập MaKS để tải thông tin");
                dtp_tt_ngaysinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tt_noisinh.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập MaKS để tải thông tin");
                txt_tt_noisinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tt_quoctich.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập MaKS để tải thông tin");
                txt_tt_quoctich.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tt_dantoc.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập MaKS để tải thông tin");
                txt_tt_dantoc.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tt_quequan.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập MaKS để tải thông tin");
                txt_tt_quequan.Focus();
                return false;
            }
            if (IsCmndNumber(txt_tt_cccd.Text) == false)
            {
                MessageBox.Show(messageBoxText: "CCCD không hợp lệ");
                txt_tt_cccd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tt_ncCccd.Text))
            {
                MessageBox.Show(messageBoxText: "Nơi cấp CCCD không được để trống");
                txt_tt_ncCccd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_tt_ngcCccd.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn ngày cấp CCCD");
                dtp_tt_ngcCccd.Focus();
                return false;
            }
            if (IsPhoneNumber(txt_tt_sdt.Text) == false)
            {
                MessageBox.Show(messageBoxText: "Số điện thoại không hợp lệ");
                txt_tt_sdt.Focus();
                return false;
            }
            if (IsEmail(txt_tt_email.Text) == false)
            {
                MessageBox.Show(messageBoxText: "Email không hợp lệ");
                txt_tt_email.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tt_maks.Text))
            {
                MessageBox.Show(messageBoxText: "Mã khai sinh không được để trống");
                txt_tt_maks.Focus();
                return false;
            }
            DataTable dataTable = ksDao.KiemTraThongTinKhaiSinh(txt_tt_maks.Text);
            if (dataTable.Rows.Count > 0)
            {
                if (Convert.ToInt32(dataTable.Rows[0]["Tuoi"]) >= 14)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Người này chưa đủ tuổi cấp CCCD!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Mã khai sinh không hợp lệ!");
                return false;
            }
        }
        public bool checkThemChungTu(TextBox txt_chungtu_hoten, TextBox txt_chungtu_cccd, DatePicker dtp_chungtu_ngaysinh, DatePicker dtp_chungtu_ngaymat, TextBox txt_chungtu_noimat, TextBox txt_chungtu_nguyennhan)
        {
            if (string.IsNullOrEmpty(txt_chungtu_hoten.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD để tải thông tin");
                txt_chungtu_hoten.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_chungtu_cccd.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD để tải thông tin");
                txt_chungtu_cccd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_chungtu_ngaysinh.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD để tải thông tin");
                dtp_chungtu_ngaysinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_chungtu_ngaymat.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn ngày mất");
                dtp_chungtu_ngaymat.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_chungtu_noimat.Text))
            {
                MessageBox.Show(messageBoxText: "Nơi mất không được để trống");
                txt_chungtu_noimat.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_chungtu_nguyennhan.Text))
            {
                MessageBox.Show(messageBoxText: "Nguyên nhân không được để trống");
                txt_chungtu_nguyennhan.Focus();
                return false;
            }
            return true;
        }
        public bool checkThemThue(TextBox txt_thue_coquanthue, TextBox txt_thue_nguoinopthue, TextBox txt_thue_cccd, DatePicker dtp_thue_ngaythaydoi)
        {
            if (string.IsNullOrEmpty(txt_thue_nguoinopthue.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD để tải thông tin");
                txt_thue_nguoinopthue.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_thue_cccd.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD để tải thông tin");
                txt_thue_cccd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_thue_coquanthue.Text))
            {
                MessageBox.Show(messageBoxText: "Cơ quan thuế không được để trống");
                txt_thue_coquanthue.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_thue_ngaythaydoi.Text))
            {
                MessageBox.Show(messageBoxText: "Ngày thay đổi không được để trống");
                dtp_thue_ngaythaydoi.Focus();
                return false;
            }
            return true;
        }
        public bool checkThemHK(TextBox txt_hokhau_cccdchuho, TextBox txt_hokhau_hotenchuho, TextBox txt_hokhau_diachi)
        {
            if (string.IsNullOrEmpty(txt_hokhau_cccdchuho.Text))
            {
                MessageBox.Show(messageBoxText: "CCCD chủ hộ không được để trống");
                txt_hokhau_cccdchuho.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_hokhau_hotenchuho.Text))
            {
                MessageBox.Show(messageBoxText: "Họ tên chủ hộ không được để trống");
                txt_hokhau_hotenchuho.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_hokhau_diachi.Text))
            {
                MessageBox.Show(messageBoxText: "Địa chỉ không được để trống");
                txt_hokhau_diachi.Focus();
                return false;
            }
            return true;
        }
        public bool checkThemTamTru(TextBox txt_tamtru_cccd, DatePicker dtp_tamtru_ngaydk, TextBox txt_tamtru_noidk, TextBox txt_tamtru_hoten, DatePicker dtp_tamtru_ngaysinh, TextBox txt_tamtru_noicapcccd, DatePicker dtp_tamtru_ngaycapcccd, DatePicker dtp_tamtru_ngayden, DatePicker dtp_tamtru_ngaydi, TextBox txt_tamtru_lydo)
        {
            if (string.IsNullOrEmpty(txt_tamtru_cccd.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD để tải thông tin");
                txt_tamtru_cccd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_tamtru_ngaydk.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn ngày đăng kí");
                dtp_tamtru_ngaydk.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tamtru_noidk.Text))
            {
                MessageBox.Show(messageBoxText: "Nơi đăng kí không được để trống");
                txt_tamtru_noidk.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tamtru_hoten.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD để tải thông tin");
                txt_tamtru_hoten.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_tamtru_ngaysinh.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD để tải thông tin");
                dtp_tamtru_ngaysinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tamtru_noicapcccd.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD để tải thông tin");
                txt_tamtru_noicapcccd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_tamtru_ngaycapcccd.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD để tải thông tin");
                dtp_tamtru_ngaycapcccd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_tamtru_ngayden.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn ngày đến");
                dtp_tamtru_ngayden.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_tamtru_ngaydi.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn ngày đi");
                dtp_tamtru_ngaydi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tamtru_lydo.Text))
            {
                MessageBox.Show(messageBoxText: "Lý do không được để trống");
                txt_tamtru_lydo.Focus();
                return false;
            }
            return true;
        }
        public bool checkThemTamVang(TextBox txt_tamvang_cmnd, DatePicker dtp_tamvang_ngaydk, TextBox txt_tamvang_noichuyendi, TextBox txt_tamvang_noichuyenden, TextBox txt_tamvang_hoten, DatePicker dtp_tamvang_ngaysinh, DatePicker dtp_tamvang_ngaycapcmnd,
            TextBox txt_tamvang_noicapcmnd, DatePicker dtp_tamvang_ngaydi, DatePicker dtp_tamvang_ngayve, TextBox txt_tamvang_lydo)
        {
            if (string.IsNullOrEmpty(txt_tamvang_cmnd.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD để tải thông tin");
                txt_tamvang_cmnd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_tamvang_ngaydk.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn ngày đăng kí");
                dtp_tamvang_ngaydk.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tamvang_noichuyendi.Text))
            {
                MessageBox.Show(messageBoxText: "Nơi chuyển đi không được để trống");
                txt_tamvang_noichuyendi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tamvang_noichuyenden.Text))
            {
                MessageBox.Show(messageBoxText: "Nơi chuyển đến không được để trống");
                txt_tamvang_noichuyenden.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tamvang_hoten.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD để tải thông tin");
                txt_tamvang_hoten.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_tamvang_ngaysinh.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD để tải thông tin");
                dtp_tamvang_ngaysinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_tamvang_ngaycapcmnd.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD để tải thông tin");
                dtp_tamvang_ngaycapcmnd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tamvang_noicapcmnd.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD để tải thông tin");
                txt_tamvang_noicapcmnd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_tamvang_ngaydi.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn ngày đi");
                dtp_tamvang_ngaydi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_tamvang_ngayve.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn ngày về");
                dtp_tamvang_ngayve.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tamvang_lydo.Text))
            {
                MessageBox.Show(messageBoxText: "Lý do không được để trống");
                txt_tamvang_lydo.Focus();
                return false;
            }
            return true;
        }
        public bool checkThemKetHon(TextBox txt_kethon_hotenvo, TextBox txt_kethon_hotenchong, DatePicker dtp_kethon_ngaysinhvo, DatePicker dtp_kethon_ngaysinhchong,
           TextBox txt_kethon_dantocvo, TextBox txt_kethon_dantocchong, TextBox txt_kethon_quoctichvo, TextBox txt_kethon_quoctichchong, TextBox txt_kethon_noicutruvo, TextBox txt_kethon_noicutruchong, TextBox txt_kethon_gtttvo,
          TextBox txt_kethon_gtttchong, TextBox txt_kethon_noidkkethon, DatePicker dtp_kethon_ngaydkkethon)
        {
            if (string.IsNullOrEmpty(txt_kethon_hotenvo.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD Vợ để tải thông tin");
                txt_kethon_hotenvo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_kethon_hotenchong.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD Chồng để tải thông tin");
                txt_kethon_hotenchong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_kethon_ngaysinhvo.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD Vợ để tải thông tin");
                dtp_kethon_ngaysinhvo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_kethon_ngaysinhchong.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD Chồng để tải thông tin");
                dtp_kethon_ngaysinhchong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_kethon_dantocvo.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD Vợ để tải thông tin");
                txt_kethon_dantocvo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_kethon_dantocchong.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD Chồng để tải thông tin");
                txt_kethon_dantocchong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_kethon_quoctichvo.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD Vợ để tải thông tin");
                txt_kethon_quoctichvo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_kethon_quoctichchong.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD Chồng để tải thông tin");
                txt_kethon_quoctichchong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_kethon_noicutruvo.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD Vợ để tải thông tin");
                txt_kethon_noicutruvo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_kethon_noicutruchong.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD Chồng để tải thông tin");
                txt_kethon_noicutruchong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_kethon_gtttvo.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD Vợ để tải thông tin");
                txt_kethon_gtttvo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_kethon_gtttchong.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng nhập CCCD Chồng để tải thông tin");
                txt_kethon_gtttchong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_kethon_noidkkethon.Text))
            {
                MessageBox.Show(messageBoxText: "Nơi đk không được để trống");
                txt_kethon_noidkkethon.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_kethon_ngaydkkethon.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn ngày đk");
                dtp_kethon_ngaydkkethon.Focus();
                return false;
            }
            return true;
        }
        public bool checkThemLyHon(TextBox txt_lyhon_cccdnguoinopdon, TextBox txt_lyhon_hotennguoinopdon, TextBox txt_lyhon_cccdvo, TextBox txt_lyhon_hotenvo,
            TextBox txt_lyhon_cccdchong, TextBox txt_lyhon_hotenchong, TextBox txt_lyhon_noidk, DatePicker dtp_lyhon_ngaydk, TextBox txt_lyhon_lydo)
        {
            if (string.IsNullOrEmpty(txt_lyhon_cccdnguoinopdon.Text))
            {
                MessageBox.Show(messageBoxText: "CCCD người nộp đơn không được để trống");
                txt_lyhon_cccdnguoinopdon.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_lyhon_hotennguoinopdon.Text))
            {
                MessageBox.Show(messageBoxText: "Họ tên người nộp đơn không được để trống");
                txt_lyhon_hotennguoinopdon.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_lyhon_cccdvo.Text))
            {
                MessageBox.Show(messageBoxText: "CCCD vợ không được để trống");
                txt_lyhon_cccdvo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_lyhon_hotenvo.Text))
            {
                MessageBox.Show(messageBoxText: "Họ tên vợ không được để trống");
                txt_lyhon_hotenvo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_lyhon_cccdchong.Text))
            {
                MessageBox.Show(messageBoxText: "CCCD chồng không được để trống");
                txt_lyhon_cccdchong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_lyhon_hotenchong.Text))
            {
                MessageBox.Show(messageBoxText: "Họ tên chồng không được để trống");
                txt_lyhon_hotenchong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_lyhon_noidk.Text))
            {
                MessageBox.Show(messageBoxText: "Nơi đăng kí không được để trống");
                txt_lyhon_noidk.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_lyhon_ngaydk.Text))
            {
                MessageBox.Show(messageBoxText: "Vui lòng chọn ngày đăng kí");
                dtp_lyhon_ngaydk.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_lyhon_lydo.Text))
            {
                MessageBox.Show(messageBoxText: "Lý do không được để trống");
                txt_lyhon_lydo.Focus();
                return false;
            }
            DataTable dataTable = lhDao.HienThiThongTinDonLyHon(txt_lyhon_cccdnguoinopdon.Text);
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Không có thông tin về người này!");
                return false;
            }
        }
    }
}
