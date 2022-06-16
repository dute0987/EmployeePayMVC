using CommonLayer.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        public string AddEmployee(UserPostModel employee);
        public IEnumerable<UserPostModel> GetAllEmployees();
        public UserPostModel GetEmployeeData(int? id);
        public string UpdateEmployee(UserPostModel employee);
        public string DeleteEmployee(int? id);
    }
}
