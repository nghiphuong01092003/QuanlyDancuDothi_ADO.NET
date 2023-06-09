using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls.Primitives;
using QuanlyDancuDothi.ClassObject;
using QuanlyDancuDothi.DBConnect;

namespace QuanlyDancuDothi.ClassDAO
{
    public class HoKhauDAO
    {
        DBConnection dB = new DBConnection();
        public void LoadThongTinHoKhau(DataGrid dataGrid)
        {
            string sqlStr = "select * from HoKhau join KhaiSinh on HoKhau.KhaiSinhChuHo = KhaiSinh.MaKS where HoKhau.TrangThai = 1";
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
        public void XoaThongTinHoKhau(HoKhau hoKhau)
        {
            string sqlStr = string.Format("update HoKhau set TrangThai = 0 where MaHK = '{0}'", hoKhau.Mahk);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public void SuaThongTinHoKhau(HoKhau hk)
        {
            string sqlStr = string.Format("update HoKhau set DiaChi = N'{0}' where MaHK = '{1}'", hk.Diachi, hk.Mahk);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public void ThemThongTinHoKhau(HoKhau hk)
        {
            int count = 0;
            DataTable dataTable1 = new DataTable();
            DataTable dataTable2 = new DataTable();
            string sqlStr1 = string.Format("select * from QuanHe where KhaiSinhNguoiThamGia = '{0}'", hk.MaKSchuho);
            string sqlStr2 = string.Format("insert into HoKhau (DiaChi, KhaiSinhChuHo, TrangThai) values (N'{0}', '{1}', 1)", hk.Diachi, hk.MaKSchuho);
            dataTable1 = dB.Sql_Select(sqlStr1);
            if (dataTable1.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable1.Rows.Count; i++)
                {
                    if (dataTable1.Rows[i]["TrangThai"].ToString() == "1")
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    MessageBox.Show("Người này đang tồn tại trong hộ khẩu " + dataTable1.Rows[dataTable1.Rows.Count - 1]["MaHK"].ToString() + "! Vui lòng cắt khẩu!");
                }
                else
                {
                    dB.Sql_Them_Xoa_Sua(sqlStr2); 
                    string sqlStr3 = string.Format("select MaHK, KhaiSinhChuHo from HoKhau where TrangThai = 1 and KhaiSinhChuHo = '{0}'", hk.MaKSchuho);
                    dataTable2 = dB.Sql_Select(sqlStr3);
                    string sqlStr4 = string.Format("insert into QuanHe (MaHK, KhaiSinhNguoiThamGia, QuanHeVoiChuHo, TrangThai) values ('{0}', '{1}', N'Chủ hộ', 1)", dataTable2.Rows[0]["MaHK"].ToString(), dataTable2.Rows[0]["KhaiSinhChuHo"].ToString());
                    dB.Sql_Them_Xoa_Sua(sqlStr4);
                }
            }
            else
            {
                dB.Sql_Them_Xoa_Sua(sqlStr2); 
                string sqlStr3 = string.Format("select MaHK, KhaiSinhChuHo from HoKhau where TrangThai = 1 and KhaiSinhChuHo = '{0}'", hk.MaKSchuho);
                dataTable2 = dB.Sql_Select(sqlStr3);
                string sqlStr4 = string.Format("insert into QuanHe (MaHK, KhaiSinhNguoiThamGia, QuanHeVoiChuHo, TrangThai) values ('{0}', '{1}', N'Chủ hộ', 1)", dataTable2.Rows[0]["MaHK"].ToString(), dataTable2.Rows[0]["KhaiSinhChuHo"].ToString());
                dB.Sql_Them_Xoa_Sua(sqlStr4);
            }
        }
        public void HienThiChiTietHoKhau(DataGrid dataGrid, string mahk)
        {
            string sqlStr = string.Format("select KhaiSinhNguoiThamGia, QuanHeVoiChuHo, HoTenKS from HoKhau join QuanHe on HoKhau.MaHK = QuanHe.MaHK join KhaiSinh on QuanHe.KhaiSinhNguoiThamGia = KhaiSinh.MaKS where QuanHe.TrangThai = 1 and HoKhau.MaHK = '{0}'", mahk);
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
        public void CatKhau(QuanHe quanHe)
        {
            string sqlStr = string.Format("update QuanHe set TrangThai = 0 where KhaiSinhNguoiThamGia = '{0}' and MaHK = '{1}'", quanHe.MaKSnguoithan, quanHe.MaHK);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public int KiemTraQuanHe(DataTable dataTable, QuanHe quanHe)
        {
            for (int r = 0; r < dataTable.Rows.Count; r++)
            {
                DataRow row2 = dataTable.Rows[r];
                if (row2["MaHK"].ToString().Trim() == quanHe.MaHK.Trim())
                {
                    return r;
                }
            }
            return -1;
        }
        public void ThemNguoiThamGia(QuanHe quanHe)
        {
            int count = 0;
            DataTable dataTable = new DataTable();
            string sqlStr1 = string.Format("select * from QuanHe where KhaiSinhNguoiThamGia = '{0}'", quanHe.MaKSnguoithan);
            string sqlStr2 = string.Format("insert into QuanHe (MaHK, KhaiSinhNguoiThamGia, QuanHeVoiChuHo, TrangThai) values ('{0}', '{1}', N'{2}', 1)", quanHe.MaHK, quanHe.MaKSnguoithan, quanHe.Quanhe);
            string sqlStr3 = string.Format("update QuanHe set TrangThai = 1 where KhaiSinhNguoiThamGia = '{0}' and MaHK = '{1}'", quanHe.MaKSnguoithan, quanHe.MaHK);
            dataTable = dB.Sql_Select(sqlStr1);
            if (dataTable.Rows.Count > 0)
            {

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    if (Convert.ToInt32(row["TrangThai"].ToString()) == 1)
                    {
                        MessageBox.Show("Người này đang tồn tại trong hộ khẩu " + dataTable.Rows[i]["MaHK"].ToString() + "! Vui lòng cắt khẩu!");
                        break;
                    }
                    else
                    {
                        if (KiemTraQuanHe(dataTable, quanHe) >= 0)
                        {
                            dB.Sql_Them_Xoa_Sua(sqlStr3);
                            break;
                        }
                        else
                        {
                            dB.Sql_Them_Xoa_Sua(sqlStr2);
                            break;
                        }
                    }
                }
            }
            else
            {
                dB.Sql_Them_Xoa_Sua(sqlStr2);
            }
        }
        public DataTable HienThiThongTinHoKhau(string CCCD)
        {
            string sqlStr = string.Format("select MaHK, DiaChi, KhaiSinhChuHo, HoTenKS as HotenChuHo, KhaiSinhNguoiThamGia, Hotennguoithan, QuanHeVoiChuHo, Q.CCCD from (select HoKhau.MaHK, DiaChi, KhaiSinhChuHo, KhaiSinhNguoiThamGia, HoTenKS as Hotennguoithan, QuanHeVoiChuHo from HoKhau join QuanHe on HoKhau.MaHK = QuanHe.MaHK join KhaiSinh on QuanHe.KhaiSinhNguoiThamGia = KhaiSinh.MaKS where QuanHe.TrangThai = 1) T join KhaiSinh on T.KhaiSinhChuHo = KhaiSinh.MaKS join (select CCCD, MaKS from CongDan join QuanHe on QuanHe.KhaiSinhNguoiThamGia = CongDan.MaKS)Q on KhaiSinhNguoiThamGia = Q.MaKS where CCCD = '{0}'", CCCD);
            return dB.Sql_Select(sqlStr);
        }
        public DataTable HienThiThongTinHoKhau1(string MaKS)
        {
            string sqlStr = string.Format("select * from HoKhau HoKhau.TrangThai = 1 and KhaiSinhChuHo = '{0}'", MaKS);
            return dB.Sql_Select(sqlStr);
        }
        public void HienThiThongTinHoKhau2(string CCCD, DataGrid dataGrid)
        {
           string sqlStr = string.Format("select MaHK, KhaiSinhChuHo, HoTenKS as HotenChuHo, KhaiSinhNguoiThamGia, Hotennguoithan, QuanHeVoiChuHo, DiaChi, CCCD from (select HoKhau.MaHK, DiaChi, KhaiSinhChuHo, KhaiSinhNguoiThamGia, HoTenKS as Hotennguoithan, QuanHeVoiChuHo from HoKhau join QuanHe on HoKhau.MaHK = QuanHe.MaHK join KhaiSinh on QuanHe.KhaiSinhNguoiThamGia = KhaiSinh.MaKS where QuanHe.TrangThai = 1) T join KhaiSinh on T.KhaiSinhChuHo = KhaiSinh.MaKS join CongDan on KhaiSinh.MaKS = CongDan.MaKS WHERE MaHK IN (SELECT MaHK FROM QuanHe join CongDan on QuanHe.KhaiSinhNguoiThamGia = CongDan.MaKS WHERE QuanHe.TrangThai = 1 and CCCD = '{0}')", CCCD);
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
        public DataTable HienThiThongTinHoKhau3(string Mahk)
        {
            string sqlStr = string.Format("select * from HoKhau join KhaiSinh on HoKhau.KhaiSinhChuHo = KhaiSinh.MaKS where HoKhau.TrangThai = 1 and MaHK = '{0}'", Mahk);
            return dB.Sql_Select(sqlStr);
        }
        public void HienThiThongTinNguoiThamGia(DataGrid dataGrid, string Mahk)
        {
            string sqlStr = string.Format("select * from QuanHe join KhaiSinh on QuanHe.KhaiSinhNguoiThamGia = KhaiSinh.MaKS where QuanHe.TrangThai = 1 and MaHK = '{0}'", Mahk);
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
    }
}
