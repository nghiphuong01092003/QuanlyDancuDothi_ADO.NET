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
    public class TamTruDAO
    {
        DBConnection dB = new DBConnection();
        public void LoadThongTinTamTru(DataGrid dataGrid)
        {
            string sqlStr = "select * from Tamtru join CongDan on Tamtru.Cccd = CongDan.CCCD join KhaiSinh on CongDan.MaKS = KhaiSinh.MaKS join (select datediff(day, Tamtru.Ngaydk, GETDATE()) as Han, MaTT as Ma from Tamtru)Q on Tamtru.MaTT = Q.Ma Where TamTru.TrangThai = 1 and Han <= 730\r\n";
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
        public void ThemThongTinTamTru(TamTru tamTru)
        {
            string sqlStr = string.Format("update TamTru set TrangThai = 0 where CCCD = '{0}'" + "insert into Tamtru (CCCD, Ngaydk, Noidk, Ngayden, Ngaydi, Lydo, TrangThai) values ('{0}', '{1}', N'{2}', '{3}','{4}', N'{5}', 1)", tamTru.Cccd, tamTru.Ngaydk, tamTru.Noidk, tamTru.Ngayden, tamTru.Ngaydi, tamTru.Lydo);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public void XoaThongTinTamTru(TamTru tamTru)
        {
            string sqlStr = string.Format("update Tamtru set TrangThai = 0 where MaTT = '{0}'", tamTru.Matt);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public void SuaThongTinTamTru(TamTru tt)
        {
            string sqlStr = string.Format("update TamTru set Ngaydk = '{0}', Noidk = N'{1}', Ngayden = '{2}', Ngaydi = '{3}', Lydo = N'{4}' where MaTT = '{5}'",
               tt.Ngaydk, tt.Noidk, tt.Ngayden, tt.Ngaydi, tt.Lydo, tt.Matt);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public DataTable HienThiThongTinTamTru(string search)
        {
            string sqlStr = string.Format("select * from Tamtru join CongDan on Tamtru.Cccd = CongDan.CCCD join KhaiSinh on CongDan.MaKS = KhaiSinh.MaKS Where TamTru.TrangThai = 1 and Tamtru.Cccd = '{0}'", search);
            return dB.Sql_Select(sqlStr);
        }
        public void LichSuThongTinTamTru(string search, DataGrid dataGrid)
        {
            string sqlStr1 = "update Tamtru set TrangThai = 0 where datediff(day, NgayDk, GETDATE()) > 730";
            dB.Sql_Them_Xoa_Sua(sqlStr1);
            string sqlStr = string.Format("select * from Tamtru join CongDan on Tamtru.Cccd = CongDan.CCCD join KhaiSinh on CongDan.MaKS = KhaiSinh.MaKS Where Tamtru.Cccd = '{0}'", search);
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
    }
}
