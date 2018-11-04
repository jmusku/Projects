using EmployeePortal.Interfaces;
using EmployeePortal.Models;
using EmployeePortal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePortal.Repositories
{
    public class EmployeeRepository : IRepository<EmployeeViewModel>
    {

        DataAccessContext context = new DataAccessContext();
        public bool Add(EmployeeViewModel item)
        {
            EmployeeModel emp = new EmployeeModel();
            emp.FirstName = item.FirstName;
            emp.LastName = item.LastName;
            emp.Address = item.Address;
            emp.Salary = item.Salary;
            emp.DOB = Convert.ToDateTime(item.DOB.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            context.Employees.Add(emp);
            var result = context.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Delete(int id)
        {
            EmployeeModel emp = new EmployeeModel();
            emp = context.Employees.Find(id);
            if (emp != null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public EmployeeViewModel Get(int id)
        {
            var data = context.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
            if (data != null)
            {
                EmployeeViewModel employee = new EmployeeViewModel();
                employee.EmployeeID = data.EmployeeID;
                employee.FirstName = data.FirstName;
                employee.LastName = data.LastName;
                employee.Address = data.Address;
                employee.Salary = data.Salary;
                employee.DOB = data.DOB;
                return employee;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            var data = context.Employees.ToList().OrderBy(x => x.FirstName);
            var result = data.Select(x => new EmployeeViewModel()
            {
                EmployeeID = x.EmployeeID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                Salary = x.Salary,
                DOB = x.DOB
            });
            return result.ToList();
        }

        public bool Update(EmployeeViewModel item)
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmployeeID = item.EmployeeID;
            emp.FirstName = item.FirstName;
            emp.LastName = item.LastName;
            emp.Address = item.Address;
            emp.Salary = item.Salary;
            emp.DOB = Convert.ToDateTime(item.DOB.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            context.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            var result = context.SaveChanges();
            return result > 0 ? true : false;
        }
    }
}