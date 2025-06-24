using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using EmployeeForm.DbContext;
using EmployeeForm.Models;

namespace EmployeeForm.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext _context;

        public EmployeeController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var employees = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                employees = employees.Where(e => e.EmployeeName.Contains(search));
            }

          
            var employeeList = employees.ToList();

            var viewModelList = employeeList.Select(emp =>
            {
                float basic = emp.BasicSalary ?? 0f;
                float da = basic * 0.4f;
                float ca = Math.Min(da * 0.1f, 250);
                float hra = Math.Max(basic * 0.25f, 1500);
                float gross = basic + da + ca + hra;
                float pt = (gross <= 3000) ? 100 : (gross <= 6000 ? 150 : 200);
                float total = gross - pt;

                return new EmployeeViewModel
                {
                    EmployeeCode = emp.EmployeeCode,
                    EmployeeName = emp.EmployeeName,
                    DateOfBirth = emp.DateOfBirth ?? DateTime.Now,  
                    Gender = emp.Gender ?? true,                   
                    Department = emp.Department,
                    Designation = emp.Designation,
                    BasicSalary = basic,
                    DearnessAllowance = da,
                    ConveyanceAllowance = ca,
                    HouseRentAllowance = hra,
                    PT = pt,
                    TotalSalary = total
                };
            }).ToList();


            return View(viewModelList);
        }

     
        public IActionResult Create()
        {
            return View(new Employee()); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            bool codeExists = _context.Employees.Any(e => e.EmployeeCode == emp.EmployeeCode);
            if (codeExists)
            {
                ModelState.AddModelError("EmployeeCode", "Employee Code already exists.");
            }

            if (ModelState.IsValid)
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emp);
        }



        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Invalid Employee Code");

            var emp = _context.Employees.Find(id);
            if (emp == null)
                return NotFound("Employee not found");

            return View("Create", emp); 
        }



        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(emp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", emp);
        }

        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Invalid Employee Code");

            var emp = _context.Employees.Find(id);
            if (emp == null)
                return NotFound("Employee not found");

            _context.Employees.Remove(emp);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
