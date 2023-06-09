using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanlyDancuDothi.DBConnect;

namespace QuanlyDancuDothi.ClassDAO
{
    public class TrangChuDAO
    {
        DBConnection dB = new DBConnection();

        public int DemSoCongDanNam()
        {
            int count;
            string sqlStr = "select GioiTinh, count(KhaiSinh.MaKS) as SoLuong from KhaiSinh join CongDan on KhaiSinh.MaKS = CongDan.MaKS where CongDan.TrangThai = 1 and GioiTinh = N'Nam' group by GioiTinh";
            DataTable dataTable = dB.Sql_Select(sqlStr);
            return count = Convert.ToInt32(dataTable.Rows[0]["SoLuong"]);
        }
        public int DemSoCongDanNu()
        {
            int count;
            string sqlStr = "select GioiTinh, count(KhaiSinh.MaKS) as SoLuong from KhaiSinh join CongDan on KhaiSinh.MaKS = CongDan.MaKS where CongDan.TrangThai = 1 and GioiTinh = N'Nữ' group by GioiTinh";
            DataTable dataTable = dB.Sql_Select(sqlStr);
            return count = Convert.ToInt32(dataTable.Rows[0]["SoLuong"]);
        }
        public int DemSoCongDan()
        {
            int count;
            string sqlStr = "select count(KhaiSinh.MaKS) as SoLuong from KhaiSinh join CongDan on KhaiSinh.MaKS = CongDan.MaKS where CongDan.TrangThai = 1";
            DataTable dataTable = dB.Sql_Select(sqlStr);
            return count = Convert.ToInt32(dataTable.Rows[0]["SoLuong"]);
        }
        public int DemSoCongDanDaKetHon()
        {
            int count;
            string sqlStr = "select 2*COUNT(MaCnkh) as SoLuong from Cnkh";
            DataTable dataTable = dB.Sql_Select(sqlStr);
            return count = Convert.ToInt32(dataTable.Rows[0]["SoLuong"]);
        }
        public int DemSoCongDanDaLyHon()
        {
            int count;
            string sqlStr = "select 2*COUNT(MaLh) as SoLuong from Lyhon where TrangThai = '1'";
            DataTable dataTable = dB.Sql_Select(sqlStr);
            return count = Convert.ToInt32(dataTable.Rows[0]["SoLuong"]);
        }
        public int TinhTuoi()
        {
            int tuoi;
            string sqlStr = "select datediff(year, NgaySinh, GETDATE()) as Tuoi from CongDan join KhaiSinh on CongDan.MaKS = KhaiSinh.MaKS";
            DataTable dataTable = dB.Sql_Select(sqlStr);
            return tuoi = Convert.ToInt32(dataTable.Rows[0]["Tuoi"]);
        }
        public double DoTuoiTrungBinh()
        {
            double avg;
            string sqlStr = "select AVG(Tuoi) as TuoiTB from (select datediff(year, NgaySinh, GETDATE()) as Tuoi from CongDan join KhaiSinh on CongDan.MaKS = KhaiSinh.MaKS where CongDan.TrangThai = 1) Q";
            DataTable dataTable = dB.Sql_Select(sqlStr);
            return avg = Convert.ToInt32(dataTable.Rows[0]["TuoiTB"]);
        }
        public int SoNguoiTrongDoTuoiLaoDong()
        {
            int count;
            string sqlStr = "select sum(SoLuong) as Tong from (select count(MaKS) as SoLuong, GioiTinh from (select datediff(year, NgaySinh, GETDATE()) as Tuoi, KhaiSinh.MaKS, GioiTinh from CongDan join KhaiSinh on CongDan.MaKS = KhaiSinh.MaKS where CongDan.TrangThai = 1)Q where (GioiTinh = N'Nữ' and Tuoi between 18 and 56) or (GioiTinh = N'Nam' and Tuoi between 18 and 61) group by GioiTinh)P";
            DataTable dataTable = dB.Sql_Select(sqlStr);
            return count = Convert.ToInt32(dataTable.Rows[0]["Tong"]);
        }
        public DataTable ThongTinNguoiDung(string username)
        {
            string sqlStr = string.Format("select HoTen, GioiTinh, NgaySinh, NoiSinh, DanToc, QuocTich, QueQuan, CCCD, NcCccd, NgcCccd, DiaChi, SDT, Email, KhaiSinh.MaKS from KhaiSinh join CongDan on KhaiSinh.MaKS = CongDan.MaKS join QuanHe on KhaiSinh.MaKS = QuanHe.KhaiSinhNguoiThamGia join HoKhau on QuanHe.MaHK = HoKhau.MaHK where QuanHe.TrangThai = 1 and CCCD = '{0}'", username);
            return dB.Sql_Select(sqlStr);
        }
    }
}
