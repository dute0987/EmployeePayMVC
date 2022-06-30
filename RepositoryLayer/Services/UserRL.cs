using CommonLayer.User;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL:IUserRL
    {
        private readonly IConfiguration configuration;
        public UserRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string AddEmployee(UserPostModel employee)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@profileImage", employee.profileImage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@startDate", employee.startDate);
                cmd.Parameters.AddWithValue("@notes", employee.notes);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();
                if (result != 0)
                {
                    return "Employee Added Successfully";
                }
                else
                {
                    return "Added Unsuccessfull";
                }
            }
        }

        public string DeleteEmployee(int? id)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", id);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();
                if (result != 0)
                {
                    return " Employee Deleted Successfully";
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<UserPostModel> GetAllEmployees()
        {
            List<UserPostModel> lstemployee = new List<UserPostModel>();
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UserPostModel employee = new UserPostModel();

                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = Convert.ToString(rdr["Name"]);
                    employee.profileImage = Convert.ToString(rdr["profileImage"]);
                    employee.Gender = Convert.ToString(rdr["Gender"]);
                    employee.Department = Convert.ToString(rdr["Department"]);
                    employee.salary = Convert.ToInt64(rdr["salary"]);
                    employee.startDate = Convert.ToDateTime(rdr["startDate"]);
                    employee.notes = Convert.ToString(rdr["notes"]);

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }

        public UserPostModel GetEmployeeData(int? id)
        {
            UserPostModel employee = new UserPostModel();
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmployeePayrollMVC"]))
            {
                string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = Convert.ToString(rdr["Name"]);
                    employee.profileImage = Convert.ToString(rdr["profileImage"]);
                    employee.Gender = Convert.ToString(rdr["Gender"]);
                    employee.Department = Convert.ToString(rdr["Department"]);
                    employee.salary = Convert.ToInt64(rdr["salary"]);
                    employee.startDate = Convert.ToDateTime(rdr["startDate"]);
                    employee.notes = Convert.ToString(rdr["notes"]);
                }

            }
            return employee;
        }

        public string UpdateEmployee(UserPostModel employee)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmployeePayrollMVC"]))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@profileImage", employee.profileImage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@startDate", employee.startDate);
                cmd.Parameters.AddWithValue("@notes", employee.notes);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();

                if (result != 0)
                {
                    return "Employee Updated Successfully";
                }
                else
                {
                    return "Update Unsuccessfull";
                }
            }
        }
    }
}
