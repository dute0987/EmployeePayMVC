using BussinessLayer.Interfaces;
using CommonLayer.User;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class UserBL:IUserBL
    {
        private readonly IUserRL UserRL;
        public UserBL(IUserRL UserRL)
        {
            this.UserRL = UserRL;
        }

        public string AddEmployee(UserPostModel employee)
        {
            try
            {
                return UserRL.AddEmployee(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteEmployee(int? id)
        {
            try
            {
                return UserRL.DeleteEmployee(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<UserPostModel> GetAllEmployees()
        {
            try
            {
                return UserRL.GetAllEmployees();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserPostModel GetEmployeeData(int? id)
        {
            try
            {
                return UserRL.GetEmployeeData(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string UpdateEmployee(UserPostModel employee)
        {
            try
            {
                return UserRL.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
