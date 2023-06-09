using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using QuanlyDancuDothi.ClassObject;
using QuanlyDancuDothi.DBConnect;

namespace QuanlyDancuDothi.ClassDAO
{
    public class DangNhapDAO
    {
        DBConnection dbc = new DBConnection();
        public void Dangnhap(DangNhap user)
        {
            string sqlStr = string.Format("SELECT *FROM DangNhap WHERE TenDangNhap = '{0}' AND (MatKhau = '{1}' AND TrangThai = 1)", user.Tendangnhap, user.Matkhau);
            if (dbc.KetQuaDangNhap(sqlStr) == "")
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin!");
                return;
            }
            if (dbc.KetQuaDangNhap(sqlStr) == "admin")
            {
                ADMIN_TrangChu mainWindow = new ADMIN_TrangChu();
                mainWindow.Show();

            }
            else
            {
                USER_TrangChu utc = new USER_TrangChu();
                utc.Show();
            }
        }
    }
}
