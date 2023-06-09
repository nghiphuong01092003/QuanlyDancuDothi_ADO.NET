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
    public class LyHonDAO
    {
        DBConnection dB = new DBConnection();
        public void LoadThongTinLyHon(DataGrid dataGrid)
        {
            string sqlStr = "select Lyhon.MaLh as Malyhon, Lyhon.MaCnkh as Makethon, HotenVo, P.CccdVo as CCCDVo, HotenChong, Q.CccdChong as CCCDChong, Lyhon.Noidk as Noidangky, Lyhon.Ngaydk as Ngaydangky, Lydo, CccdNguoiNopDon, Hotennguoinopdon from LyHon join Cnkh on Lyhon.MaCnkh = Cnkh.MaCnkh join (select HoTen as HotenChong, CccdChong from Cnkh join CongDan on Cnkh.CccdChong = CongDan.CCCD)Q on Cnkh.CccdChong = Q.CccdChong join (select HoTen as HotenVo, CccdVo from Cnkh join CongDan on Cnkh.CccdVo = CongDan.CCCD)P on Cnkh.CccdVo = P.CccdVo join (select Malh, Hoten as Hotennguoinopdon from CongDan join Lyhon on CongDan.CCCD = Lyhon.CccdNguoiNopDon) T on T.MaLh = Lyhon.MaLh where Lyhon.TrangThai = 1";
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
        public void XoaThongTinLyHon(LyHon lyHon)
        {
            string sqlStr = string.Format("update Lyhon set TrangThai = 0 where MaLh = '{0}'", lyHon.Malh);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public void SuaThongTinLyHon(LyHon lh)
        {
            string sqlStr = string.Format("update Lyhon set Noidk = N'{0}', Ngaydk = '{1}', Lydo = N'{2}' where Malh = '{3}'",
                lh.Noidk, lh.Ngaydk, lh.Lydo, lh.Malh);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public DataTable HienThiThongTinDonLyHon(string CCCD)
        {
            string sqlStr = string.Format("SELECT Cnkh.*, Q.HoTenNguoiNopDon, Q.CCCDNguoiNopDon, P.HoTen as HoTenVo, T.HoTen as HoTenChong FROM Cnkh JOIN (SELECT HoTen as HoTenNguoiNopDon, CCCD as CCCDNguoiNopDon FROM CongDan WHERE CCCD = '{0}') as Q ON Cnkh.CccdVo = Q.CCCDNguoiNopDon OR Cnkh.CccdChong = Q.CCCDNguoiNopDon JOIN CongDan as P ON Cnkh.CccdVo = P.Cccd JOIN CongDan as T ON Cnkh.CccdChong = T.Cccd WHERE (Cnkh.CccdVo = '{0}' OR Cnkh.CccdChong = '{0}') AND Cnkh.TrangThai = 1;", CCCD);
            return dB.Sql_Select(sqlStr);
        }
        public void ThemThongTinLyHon(LyHon lyHon)
        {
            string sqlStr = string.Format("insert into Lyhon (MaCnkh, CccdNguoiNopDon, Noidk, Ngaydk, Lydo, TrangThai) values ('{0}', '{1}', N'{2}', '{3}', N'{4}', 1)" + "update Cnkh set TrangThai = 0 where MaCnkh = '{0}'", lyHon.Macnkh, lyHon.Cccdnguoinopdon, lyHon.Noidk, lyHon.Ngaydk, lyHon.Lydo);          
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public void LichSuThongTinLyHon(string search, DataGrid dataGrid)
        {
            string sqlStr = string.Format("select Lyhon.MaLh as Malyhon, Lyhon.MaCnkh as Makethon, HotenVo, P.CccdVo as CCCDVo, HotenChong, Q.CccdChong as CCCDChong, Lyhon.Noidk as Noidangky, Lyhon.Ngaydk as Ngaydangky, Lydo, CccdNguoiNopDon, Hotennguoinopdon, Lyhon.TrangThai from LyHon join Cnkh on Lyhon.MaCnkh = Cnkh.MaCnkh join (select HoTen as HotenChong, CccdChong from Cnkh join CongDan on Cnkh.CccdChong = CongDan.CCCD)Q on Cnkh.CccdChong = Q.CccdChong join (select HoTen as HotenVo, CccdVo from Cnkh join CongDan on Cnkh.CccdVo = CongDan.CCCD)P on Cnkh.CccdVo = P.CccdVo join (select Malh, Hoten as Hotennguoinopdon from CongDan join Lyhon on CongDan.CCCD = Lyhon.CccdNguoiNopDon) T on T.MaLh = Lyhon.MaLh where CccdNguoiNopDon ='{0}'", search);
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
        public DataTable HienThiThongTinLyHon(string username)
        {
            string sqlStr = string.Format("select Lyhon.MaLh as Malyhon, Lyhon.MaCnkh as Makethon, HotenVo, P.CccdVo as CCCDVo, HotenChong, Q.CccdChong as CCCDChong, Lyhon.Noidk as Noidangky, Lyhon.Ngaydk as Ngaydangky, Lydo, CccdNguoiNopDon, Hotennguoinopdon, Lyhon.TrangThai from LyHon join Cnkh on Lyhon.MaCnkh = Cnkh.MaCnkh join (select HoTen as HotenChong, CccdChong from Cnkh join CongDan on Cnkh.CccdChong = CongDan.CCCD)Q on Cnkh.CccdChong = Q.CccdChong join (select HoTen as HotenVo, CccdVo from Cnkh join CongDan on Cnkh.CccdVo = CongDan.CCCD)P on Cnkh.CccdVo = P.CccdVo join (select Malh, Hoten as Hotennguoinopdon from CongDan join Lyhon on CongDan.CCCD = Lyhon.CccdNguoiNopDon) T on T.MaLh = Lyhon.MaLh where LyHon.TrangThai = 1 and (P.CccdVo ='{0}' or Q.CccdChong = '{1}')", username, username);
            return dB.Sql_Select(sqlStr);
        }
    }
}
