using Newform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Newform.DAL
{
    public class MyprojectDAL
    {
        string constr = ConfigurationManager.ConnectionStrings["Dbcon"].ConnectionString;
        DataTable DT = new DataTable();
        public IList<Employeeinfo> GetEmployeeinfos()
        {
            IList<Employeeinfo> lst = new List<Employeeinfo>();
            DT = new DataTable();
            using (SqlConnection sqlcon=new SqlConnection(constr))
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("Getemployeeinfo", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DT);
                lst=(from DataRow r in DT.Rows
                     select new Employeeinfo()
                     {
                         FirstName = Convert.ToString(r["FirstName"]),
                         EmployeeId = Convert.ToInt32(r["EmployeeId"]),
                         LastName = Convert.ToString(r["LastName"]),
                         Email = Convert.ToString(r["Email"]),
                         DepartmentName = Convert.ToString(r["DepartmentName"]),
                         IsActive = Convert.ToBoolean(r["IsActive"]),
                         DateOfBirth = Convert.ToDateTime(r["DateOfBirth"]),
                        
                         
                     }
                     ).ToList();
            }
            return lst;
        }
        public IList<Departmentmst> GetDepartmentcombo()
        {
            DT = new DataTable();
            IList<Departmentmst> lst = new List<Departmentmst>();
            using (SqlConnection con=new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select Departmentid,DepartmentName from departments",con);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DT);
                lst = (from DataRow r in DT.Rows
                       select new Departmentmst()
                       {
                           DepID=Convert.ToInt32(r["Departmentid"]),
                           Depname=Convert.ToString(r["DepartmentName"])

                       }
                       ).ToList();
            }
            return lst;

        }
        public void Insertemployee(Employeeinfo model)
        {
            using(SqlConnection con=new SqlConnection(constr))
            {
                con.Open();
                
                SqlCommand cmd = new SqlCommand("InsertEmployee", con);
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", model.EmployeeId>0?(object)model.EmployeeId:DBNull.Value);
                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Phone", model.Phone);
                cmd.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth);
                cmd.Parameters.AddWithValue("@DepartmentId", model.DepartmentId);
                cmd.Parameters.AddWithValue("@IsActive", model.IsActive);
                cmd.Parameters.AddWithValue("@ResumePath", model.ResumePath ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }
        public Employeeinfo editemp(int id)
        {
            Employeeinfo obj = new Employeeinfo();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from employees where EmployeeId=@employeeid", con);
                cmd.Parameters.AddWithValue("@employeeid", id);
                using(SqlDataReader reader=cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        obj.EmployeeId = id;
                        obj.FirstName = reader["FirstName"].ToString();
                        obj.LastName = reader["LastName"].ToString();
                        obj.Email = reader["Email"].ToString();
                        //obj.Phone = reader["Phone"].ToString();
                        obj.Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString():string.Empty;
                        obj.DateOfBirth = (DateTime)reader["DateOfBirth"];
                        obj.DepartmentId = (int)reader["DepartmentId"];
                        obj.IsActive = (bool)reader["IsActive"];
                        obj.ResumePath = reader["ResumePath"] != DBNull.Value ? reader["ResumePath"].ToString():null;
                    }
                }
            }
            return obj;
        }
        public void DeleteEmp(int id)
        {
            using(SqlConnection con=new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from employees where employeeid=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}