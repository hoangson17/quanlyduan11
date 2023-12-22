using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsAppQuanly
{
    internal class Modify
    {
       SqlDataAdapter dataAdapter; //truy xuất dữ liệu vào bảng
        //Dataset trả về nhiều bảng
        //Datatable trả về một bảng
       public Modify() { }
       SqlCommand sqlCommand;//dùng để truy vấn câu lệnh insert, update,delete,...
       private SqlDataReader dataReader;
       SqlDataReader sqlDataReader;//dùng để đọc dữ liệu trong bảng
       public List<NHANVIEN> TaiKhoans(string query)//check tai khoan
        {
            List<NHANVIEN> TaiKhoans = new List<NHANVIEN>();
            using(SqlConnection sqlConnection = Connection.GetSqlConnection()) {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query,sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    TaiKhoans.Add(new NHANVIEN(dataReader.GetString(7), dataReader.GetString(8)));
                }


                sqlConnection.Close();
            }
            return TaiKhoans;
        }
        public void Command(string query)//dang ky tai khoan
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection()) {
                sqlConnection.Open();
                sqlCommand = new SqlCommand (query,sqlConnection);
                sqlCommand.ExecuteNonQuery();//thuc thi cau truy van
                sqlConnection.Close();
            }
        }
        //nhanvien
        public DataTable getAllNhanvien()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from NHANVIEN";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection()) {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query,sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }


                return dataTable;
        }

        

        public bool insert(nhanvien1 nhanVien)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "insert into NHANVIEN values (@MaNV,@TenNV,@Ngaysinh,@DiachiNV,@SDTNV,@Chucvu,@Email,@Taikhoan,@MatKhau)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nhanVien.MaNV1;
                sqlCommand.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nhanVien.Hoten1;
                sqlCommand.Parameters.Add("@Ngaysinh", SqlDbType.DateTime).Value = nhanVien.Ngaysinh1;
                sqlCommand.Parameters.Add("@DiachiNV", SqlDbType.NVarChar).Value = nhanVien.Diachi1;
                sqlCommand.Parameters.Add("@SDTNV", SqlDbType.NVarChar).Value = nhanVien.Sdt1;
                sqlCommand.Parameters.Add("@Chucvu", SqlDbType.NVarChar).Value = nhanVien.Chucvu1;
                sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = nhanVien.Email1;
                sqlCommand.Parameters.Add("@Taikhoan", SqlDbType.NVarChar).Value = nhanVien.Taikhoan1;
                sqlCommand.Parameters.Add("@Matkhau", SqlDbType.NVarChar).Value = nhanVien.Matkhau1;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool update(nhanvien1 nhanVien)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "update NHANVIEN set TenNV = @TenNV,Ngaysinh = @Ngaysinh,DiachiNV = @DiachiNV,SDTNV = @SDTNV,Chucvu = @Chucvu,Email = @Email,Taikhoan = @Taikhoan,Matkhau = @MatKhau where MaNV=@MaNV";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nhanVien.MaNV1;
                sqlCommand.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nhanVien.Hoten1;
                sqlCommand.Parameters.Add("@Ngaysinh", SqlDbType.DateTime).Value = nhanVien.Ngaysinh1;
                sqlCommand.Parameters.Add("@DiachiNV", SqlDbType.NVarChar).Value = nhanVien.Diachi1;
                sqlCommand.Parameters.Add("@SDTNV", SqlDbType.NVarChar).Value = nhanVien.Sdt1;
                sqlCommand.Parameters.Add("@Chucvu", SqlDbType.NVarChar).Value = nhanVien.Chucvu1;
                sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = nhanVien.Email1;
                sqlCommand.Parameters.Add("@Taikhoan", SqlDbType.NVarChar).Value = nhanVien.Taikhoan1;
                sqlCommand.Parameters.Add("@Matkhau", SqlDbType.NVarChar).Value = nhanVien.Matkhau1;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }


        public bool delete(string id)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "DELETE FROM NHANVIEN WHERE MaNV = @MaNV";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = id;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        //end nhanvien

        //hoadon
        public DataTable getAllHoadon() { 
            DataTable dataTable = new DataTable();
            string query = "select * from HOADON";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }


            return dataTable;
        }

        public bool insertHoadon(hoadon1 hoaDon)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "insert into HOADON values (@SoHD,@Ngayban,@HTTT,@MaNV,@MaKH)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@SoHD", SqlDbType.VarChar).Value = hoaDon.Sohd;
                sqlCommand.Parameters.Add("@Ngayban", SqlDbType.DateTime).Value = hoaDon.Ngayban;
                sqlCommand.Parameters.Add("@HTTT", SqlDbType.NVarChar).Value = hoaDon.Httt;
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.VarChar).Value = hoaDon.Manv;
                sqlCommand.Parameters.Add("@MaKH", SqlDbType.VarChar).Value = hoaDon.Makh;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool updateHoadon(hoadon1 hoaDon)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "update HOADON set Ngayban=@Ngayban,HTTT=@HTTT,MaNV=@MaNV,MaKH=@MaKH where SoHD=@SoHD";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@SoHD", SqlDbType.VarChar).Value = hoaDon.Sohd;
                sqlCommand.Parameters.Add("@Ngayban", SqlDbType.DateTime).Value = hoaDon.Ngayban;
                sqlCommand.Parameters.Add("@HTTT", SqlDbType.NVarChar).Value = hoaDon.Httt;
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.VarChar).Value = hoaDon.Manv;
                sqlCommand.Parameters.Add("@MaKH", SqlDbType.VarChar).Value = hoaDon.Makh;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool deleteHoadon(string id)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "DELETE FROM HOADON WHERE SoHD = @SoHD";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@SoHD", SqlDbType.NVarChar).Value = id;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        //end hoadon
    }
}
