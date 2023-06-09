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
    public class DanhGiaDAO
    {
        DBConnection dB = new DBConnection();
        public void GuiDanhGia(DanhGiaDichVu danhgia, string cccd)
        {
            string sqlStr = string.Format("insert into DanhGia(CCCD, DanhGia, Tongquan, Thuantien, Dedang, Chinhxac, Trucquan) values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}')", cccd, danhgia.Danhgia, danhgia.Tongquan, danhgia.Thuantien, danhgia.Dedang, danhgia.Chinhxac, danhgia.Trucquan);
            dB.Sql_Them_Xoa_Sua(sqlStr);
        }
        public double TongQuan()
        {
            double avg;
            string sqlStr1 = "select * from DanhGia";
            string sqlStr2 = "select AVG(Tongquan) as TrungBinh from DanhGia";
            DataTable dataTable = dB.Sql_Select(sqlStr1);
            if (dataTable.Rows.Count > 0)
            {
                return avg = Convert.ToDouble(dB.Sql_Select(sqlStr2).Rows[0]["TrungBinh"]);
            }
            else
            {
                return avg = 0;

            }
        }
        public double ThuanTien()
        {
            double avg;
            string sqlStr1 = "select * from DanhGia";
            string sqlStr2 = "select AVG(Thuantien) as TrungBinh from DanhGia";
            DataTable dataTable = dB.Sql_Select(sqlStr1);
            if (dataTable.Rows.Count > 0)
            {
                return avg = Convert.ToDouble(dB.Sql_Select(sqlStr2).Rows[0]["TrungBinh"]);
            }
            else
            {
                return avg = 0;

            }
        }
        public double DeDang()
        {
            double avg;
            string sqlStr1 = "select * from DanhGia";
            string sqlStr2 = "select AVG(Dedang) as TrungBinh from DanhGia";
            DataTable dataTable = dB.Sql_Select(sqlStr1);
            if (dataTable.Rows.Count > 0)
            {
                return avg = Convert.ToDouble(dB.Sql_Select(sqlStr2).Rows[0]["TrungBinh"]);
            }
            else
            {
                return avg = 0;

            }
        }
        public double ChinhXac()
        {
            double avg;
            string sqlStr1 = "select * from DanhGia";
            string sqlStr2 = "select AVG(Chinhxac) as TrungBinh from DanhGia";
            DataTable dataTable = dB.Sql_Select(sqlStr1);
            if (dataTable.Rows.Count > 0)
            {
                return avg = Convert.ToDouble(dB.Sql_Select(sqlStr2).Rows[0]["TrungBinh"]);
            }
            else
            {
                return avg = 0;

            }
        }
        public double TrucQuan()
        {
            double avg;
            string sqlStr1 = "select * from DanhGia";
            string sqlStr2 = "select AVG(Trucquan) as TrungBinh from DanhGia";
            DataTable dataTable = dB.Sql_Select(sqlStr1);
            if (dataTable.Rows.Count > 0)
            {
                return avg = Convert.ToDouble(dB.Sql_Select(sqlStr2).Rows[0]["TrungBinh"]);
            }
            else
            {
                return avg = 0;

            }
        }
        public void HienThiDanhGia(DataGrid dataGrid)
        {
            string sqlStr = "select * from DanhGia join (select CCCD as CCCDNguoiDanhGia, HoTen from CongDan)Q on DanhGia.CCCD = Q.CCCDNguoiDanhGia";
            dataGrid.ItemsSource = dB.Sql_Select(sqlStr).DefaultView;
        }
    }
}
