using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using QuanlyDancuDothi.ClassObject;
using QuanlyDancuDothi.DBConnect;

namespace QuanlyDancuDothi.ClassDAO
{
    public class ChungTuDAO
    {
        DBConnection dB = new DBConnection();
        public void LoadThongTinChungTu(DataGrid dataGrid)
        {
            string sqlStr = "select MaCT, CongDan.CCCD, HoTen, NgaySinh, NgayMat, NoiMat, NguyenNhan from GiayChungTu join CongDan on GiayChungTu.CCCD = CongDan.CCCD join KhaiSinh on CongDan.MaKS = KhaiSinh.MaKS Where GiayChungTu.TrangThai = 1";
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
        public void ThemThongTinChungTu(GiayChungTu giayChungTu)
        {
            string sqlStr = string.Format("update CongDan set TrangThai = 0 where CCCD = '{0}'" + "update DangNhap set TrangThai = 0 where TenDangNhap='{0}'" + "insert into GiayChungTu(CCCD, NgayMat, NoiMat, NguyenNhan, TrangThai) values ('{0}', '{1}', '{2}', '{3}', 1)", giayChungTu.Cccd, giayChungTu.Ngaymat, giayChungTu.Noimat, giayChungTu.Nguyennhan);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public void XoaThongTinChungTu(GiayChungTu giayChungTu)
        {
            string sqlStr = string.Format("update GiayChungTu set TrangThai = 0 where MaCT = '{1}'" + "update CongDan set TrangThai = 1 where CCCD = '{0}'" + "update DangNhap set TrangThai = 1 where TenDangNhap='{2}'" + "update QuanHe set TrangThai = 1", giayChungTu.Cccd, giayChungTu.Mact, giayChungTu.Cccd);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public void SuaThongTinChungTu(GiayChungTu ct)
        {
            string sqlStr = string.Format("update GiayChungTu set NgayMat = '{0}', NoiMat = N'{1}', NguyenNhan = N'{2}' where MaCT = '{3}'",
                ct.Ngaymat, ct.Noimat, ct.Nguyennhan, ct.Mact);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public DataTable HienThiThongTinChungTu(string CCCD)
        {
            string sqlStr = string.Format("select MaCT, GiayChungTu.CCCD, HoTen,NgaySinh, NgayMat, NoiMat, NguyenNhan from GiayChungTu join (select CCCD, NgaySinh, HoTen from KhaiSinh join CongDan on KhaiSinh.MaKS = CongDan.MaKS) Q on GiayChungTu.CCCD = Q.CCCD Where GiayChungTu.CCCD = '{0}'", CCCD);
            return dB.Sql_Select(sqlStr);
        }
    }
}
