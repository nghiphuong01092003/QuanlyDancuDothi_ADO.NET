using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using QuanlyDancuDothi.ClassObject;
using QuanlyDancuDothi.DBConnect;

namespace QuanlyDancuDothi.ClassDAO
{
    public class KhaiSinhDAO
    {
        DBConnection dB = new DBConnection();
        public void LoadThongTinKhaiSinh(DataGrid dataGrid)
        {
            string sqlStr = "select *from KhaiSinh where KhaiSinh.TrangThai = 1";
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
        public void ThemThongTinKhaiSinh(KhaiSinh khaiSinh)
        {                
            string sqlStr = string.Format("insert into KhaiSinh(HoTenKS, GioiTinh, NgaySinh, NoiSinh, DanToc, QuocTich, QueQuan, Cha, Me, NguoiKhaiSinh, QuanHe, NgayDk, NoiDk, TrangThai) values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}', 1)", khaiSinh.HotenKS, khaiSinh.Gioitinh, khaiSinh.Ngaysinh, khaiSinh.Noisinh, khaiSinh.Dantoc, khaiSinh.Quoctich, khaiSinh.Quequan, khaiSinh.Cha, khaiSinh.Me, khaiSinh.Nguoikhaisinh, khaiSinh.Quanhe, khaiSinh.Ngaydk, khaiSinh.Noidk);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public void XoaThongTinKhaiSinh(KhaiSinh khaiSinh)
        {
            string sqlStr = string.Format("update KhaiSinh set TrangThai = 0 where MaKS = '{0}'" + "update CongDan set TrangThai = 0 where MaKS = '{0}'", khaiSinh.Maks);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public void SuaThongTinKhaiSinh(KhaiSinh ks)
        {
            string sqlStr = string.Format("update CongDan set Hoten = N'{0}' Where MaKS = '{7}'" + "update KhaiSinh set HoTenKS = N'{0}', Gioitinh = N'{1}', Ngaysinh = '{2}', Noisinh = N'{3}', Dantoc = N'{4}', Quoctich = N'{5}', Quequan = N'{6}', Cha = N'{8}', Me = N'{9}', Nguoikhaisinh = N'{10}', Quanhe = N'{11}', Ngaydk = '{12}', Noidk = N'{13}' Where MaKS = '{7}'",
                ks.HotenKS, ks.Gioitinh, ks.Ngaysinh, ks.Noisinh, ks.Dantoc, ks.Quoctich, ks.Quequan, ks.Maks, ks.Cha, ks.Me, ks.Nguoikhaisinh, ks.Quanhe, ks.Ngaydk, ks.Noidk);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public DataTable KiemTraThongTinKhaiSinh(string MaKS)
        {
            string sqlStr = string.Format("select *, datediff(year, NgaySinh, GETDATE()) as Tuoi, CCCD from KhaiSinh left join CongDan on KhaiSinh.MaKS = CongDan.MaKS where KhaiSinh.TrangThai = 1 and KhaiSinh.MaKS = '{0}'", MaKS);
            return dB.Sql_Select(sqlStr);
        }
        public DataTable HienThiThongTinKhaiSinh(string MaKS)
        {
            string sqlStr = string.Format("select * from KhaiSinh join CongDan on KhaiSinh.MaKS = CongDan.MaKS Where CongDan.CCCD = '{0}'", MaKS);
            return dB.Sql_Select(sqlStr);
        }
    }
}
