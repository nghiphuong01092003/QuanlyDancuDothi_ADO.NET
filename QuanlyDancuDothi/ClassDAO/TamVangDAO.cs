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
    public class TamVangDAO
    {
        DBConnection dB = new DBConnection();
        public void LoadThongTinTamVang(DataGrid dataGrid)
        {
            string sqlStr = "select MaTV, TamVang.CCCD, TamVang.Ngaydk, Ncdi, Ncden, Ngaydi, Ngayve, Lydo, NcCccd, NgcCccd, HoTen, NgaySinh, Han from Tamvang join CongDan on Tamvang.Cccd = CongDan.CCCD join KhaiSinh on CongDan.MaKS = KhaiSinh.MaKS join (select datediff(day, Tamvang.Ngaydk, GETDATE()) as Han, MaTV as Ma from Tamvang)Q on Tamvang.MaTV = Q.Ma Where TamVang.TrangThai = 1 and Han <= 730\r\n";
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
        public void ThemThongTinTamVang(TamVang tamVang)
        {
            string sqlStr = string.Format("update TamVang set TrangThai = 0 where CCCD = '{0}'" + "insert into Tamvang (CCCD, Ngaydk, Ncdi, Ncden, Ngaydi, Ngayve, Lydo, TrangThai) values ('{0}', '{1}', N'{2}', N'{3}', '{4}','{5}', N'{6}', 1)", tamVang.Cccd, tamVang.Ngaydk, tamVang.Ncdi, tamVang.Ncden, tamVang.Ngaydi, tamVang.Ngayve, tamVang.Lydo);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public void XoaThongTinTamVang(TamVang tamVang)
        {
            string sqlStr = string.Format("update Tamvang set TrangThai = 0 where MaTV = '{0}'", tamVang.Matv);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public void SuaThongTinTamVang(TamVang tv)
        {
            string sqlStr = string.Format("update TamVang set Ngaydk = '{0}', Ncdi = N'{1}', Ncden = N'{2}', Ngaydi = '{3}', Ngayve = '{4}', Lydo = N'{5}' where Matv = '{6}'",
                tv.Ngaydk, tv.Ncden, tv.Ncdi, tv.Ngaydi, tv.Ngayve, tv.Lydo, tv.Matv);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public DataTable HienThiThongTinTamVang(string search)
        {
            string sqlStr = string.Format("select * from Tamvang join CongDan on Tamvang.CCCD = CongDan.CCCD join KhaiSinh on CongDan.MaKS = KhaiSinh.MaKS Where TamVang.TrangThai = 1 and Tamvang.CCCD = '{0}'", search);
            return dB.Sql_Select(sqlStr);
        }
        public void LichSuThongTinTamVang(string search, DataGrid dataGrid)
        {
            string sqlStr1 = "update Tamvang set TrangThai = 0 where datediff(day, NgayDk, GETDATE()) > 730";
            dB.Sql_Them_Xoa_Sua(sqlStr1);
            string sqlStr = string.Format("select * from Tamvang join CongDan on Tamvang.CCCD = CongDan.CCCD join KhaiSinh on CongDan.MaKS = KhaiSinh.MaKS Where Tamvang.CCCD = '{0}'", search);
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
    }
}
