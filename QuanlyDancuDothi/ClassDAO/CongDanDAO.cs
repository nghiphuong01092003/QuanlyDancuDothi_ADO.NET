using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using QuanlyDancuDothi.ClassObject;
using QuanlyDancuDothi.DBConnect;

namespace QuanlyDancuDothi.ClassDAO
{
    public class CongDanDAO
    {
        DBConnection dB = new DBConnection();
        public void LoadThongTinCongDan(DataGrid dataGrid)
        {
            string sqlStr = "select HoTen, GioiTinh, NgaySinh, NoiSinh, DanToc, QuocTich, QueQuan, CCCD, NcCccd, NgcCccd, DiaChi, SDT, Email, KhaiSinh.MaKS from KhaiSinh join CongDan on KhaiSinh.MaKS = CongDan.MaKS join QuanHe on KhaiSinh.MaKS = QuanHe.KhaiSinhNguoiThamGia join HoKhau on QuanHe.MaHK = HoKhau.MaHK where QuanHe.TrangThai = 1 and CongDan.TrangThai = 1";
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
        public void XoaThongTinCongDan(CongDan congDan)
        {
            string sqlStr1 = string.Format("update CongDan set TrangThai = 0 where cccd = '{0}'", congDan.Cccd);
            dB.Sql_Them_Xoa_Sua(sqlStr1);
        }
        public void SuaThongTinCongDan(CongDan cd)
        {
            string sqlStr = string.Format("update CongDan set Sdt = '{0}', Email = '{1}' where MaKS = '{2}'", cd.Sdt, cd.Email, cd.Maks);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public void ThemThongTinCongDan(CongDan congDan)
        {
            DataTable dataTable = new DataTable();
            string sqlStr1 = string.Format("Select * from CongDan where MaKS = '{0}'", congDan.Maks);
            string sqlStr2 = string.Format("update CongDan set TrangThai = 1 where CCCD = '{0}'", congDan.Maks);
            string sqlStr3 = string.Format("insert into CongDan(CCCD, HoTen, NcCccd, NgcCccd, MaKS, SDT, Email, TrangThai) values ('{0}',N'{1}', N'{2}', '{3}', '{4}', '{5}', '{6}', 1)", congDan.Cccd, congDan.Hoten, congDan.Nccccd, congDan.Ngccccd, congDan.Maks, congDan.Sdt, congDan.Email);
            dataTable = dB.Sql_Select(sqlStr1);
            if (dataTable.Rows.Count > 0)
            {
                if (Convert.ToInt32(dataTable.Rows[0]["TrangThai"]) == 1)
                {
                    MessageBox.Show("Người này đã được cấp CCCD!");
                }
                else
                {
                    dB.Sql_Them_Xoa_Sua(sqlStr2);
                }
            }
            else
            {
                dB.Sql_Them_Xoa_Sua(sqlStr3);
            }
        }
        public DataTable KiemTraDuLieuCongDan(string CCCD)
        {
            string sqlStr = string.Format("select *, datediff(year, NgaySinh, GETDATE()) as Tuoi from CongDan join KhaiSinh on CongDan.MaKS = KhaiSinh.MaKS join QuanHe on KhaiSinh.MaKS = QuanHe.KhaiSinhNguoiThamGia join HoKhau on QuanHe.MaHK = HoKhau.MaHK left join (select MaCnkh, TrangThai, CccdChong, CccdVo from Cnkh where TrangThai = 1)Q on(CongDan.CCCD = Q.CccdChong or CongDan.CCCD = Q.CccdVo) where Cccd = '{0}' and CongDan.TrangThai=1", CCCD);
            return dB.Sql_Select(sqlStr);
        }
        public DataTable XemThongTinCongDan(string CCCD)
        {
            string sqlStr = string.Format("select HoTen, GioiTinh, NgaySinh, NoiSinh, DanToc, QuocTich, QueQuan, CCCD, NcCccd, NgcCccd, DiaChi, SDT, Email, CongDan.MaKS from KhaiSinh join CongDan on KhaiSinh.MaKS = CongDan.MaKS join QuanHe on KhaiSinh.MaKS = QuanHe.KhaiSinhNguoiThamGia join HoKhau on QuanHe.MaHK = HoKhau.MaHK Where QuanHe.TrangThai = 1 and Cccd = '{0}'", CCCD);
            return dB.Sql_Select(sqlStr);
        }
        public void Searching(DataGrid dataGrid, string content)
        {
            string sqlStr = string.Format("select HoTen, GioiTinh, NgaySinh, NoiSinh, DanToc, QuocTich, QueQuan, CCCD, NcCccd, NgcCccd, DiaChi, SDT, Email from KhaiSinh join CongDan on KhaiSinh.MaKS = CongDan.MaKS join QuanHe on KhaiSinh.MaKS = QuanHe.KhaiSinhNguoiThamGia join HoKhau on QuanHe.MaHK = HoKhau.MaHK where CongDan.TrangThai = 1 and N'{0}' in" +
                "(HoTen, GioiTinh, NoiSinh, DanToc, QuocTich, QueQuan, CCCD, DiaChi, SDT, Email)", content);
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
    }
}
