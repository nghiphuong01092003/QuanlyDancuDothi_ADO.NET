using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QuanlyDancuDothi.DBConnect
{
    public class DBConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public string KetQuaDangNhap(string sqlStr)
        {
            string state = "";
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    state = Convert.ToString(dataReader["Quyen"]).Trim();
                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Kết nối không thành công.");
            }
            return state;
        }
        public DataTable Sql_Select(string sqlStr)
        {
            DataTable dataTable = new DataTable();
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                dataTable.Load(dataReader);
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi!");
            }
            return dataTable;
        }
        public void Sql_Them_Xoa_Sua(string sqlStr)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại" + ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
