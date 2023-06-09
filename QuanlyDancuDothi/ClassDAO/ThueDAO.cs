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
    public class ThueDAO
    {
        DBConnection dB = new DBConnection();
        public void LoadThongTinThue(DataGrid dataGrid)
        {
            string sqlStr = "Select *from Thue join CongDan on Thue.SoCMT_CCCD = CongDan.CCCD join KhaiSinh on CongDan.MaKS = KhaiSinh.MaKS Where Thue.TrangThai = 1";
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
        public void ThemThongTinThue(Thue thue)
        {
            string sqlStr = string.Format("update Thue set TrangThai = 0 where SoCMT_CCCD = '{0}'" + "insert into Thue (Coquanthue, SoCMT_CCCD, Ngaythaydoithongtingannhat, TrangThai) values (N'{1}', '{2}', '{3}', 1)", thue.Socmt_cccd, thue.Coquanthue, thue.Socmt_cccd, thue.Ngaythaydoithongtingannhat);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public void XoaThongTinThue(Thue thue)
        {
            string sqlStr = string.Format("update Thue set TrangThai = 0 where Masothue = '{0}'", thue.Masothue);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public void SuaThongTinThue(Thue thue)
        {
            string sqlStr = string.Format("update Thue set Coquanthue = N'{0}', Ngaythaydoithongtingannhat = '{1}' Where Masothue = '{2}'", thue.Coquanthue, thue.Ngaythaydoithongtingannhat, thue.Masothue);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public DataTable HienThiThongTinThue(string username)
        {
            string sqlStr = string.Format("Select *from Thue join CongDan on Thue.SoCMT_CCCD = CongDan.CCCD Where Thue.TrangThai = 1 and SoCMT_CCCD = '{0}'", username);
            return dB.Sql_Select(sqlStr);
        }
    }
}
