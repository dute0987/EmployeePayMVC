using BussinessLayer.Interfaces;
using CommonLayer.User;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUserBL UserBL;
        public EmployeeController(IUserBL UserBL)
        {
            this.UserBL = UserBL;
        }
        public IActionResult Index()
        {
            List<UserPostModel> allEmployees = new List<UserPostModel>();
            allEmployees = UserBL.GetAllEmployees().ToList();
            return View(allEmployees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind] UserPostModel employee)
        {
            if (ModelState.IsValid)
            {
                UserBL.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserPostModel employee = UserBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind] UserPostModel employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                UserBL.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserPostModel employee = UserBL.GetEmployeeData(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            UserBL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
