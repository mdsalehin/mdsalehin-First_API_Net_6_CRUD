using DatabaseProject.Interfaces;
using DatabaseProject.DatabaseContext;
using DatabaseProject.Models;
using System.Collections.Generic;
using System.Linq;
using System;
namespace DatabaseProject.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        public EmployeeRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public List<Employee> GetEmployees()
        {
            var lstEmployee = _sqlServerContext.Employee.ToList();
            return lstEmployee;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _sqlServerContext.Employee.FirstOrDefault(x => x.EmployeeId == id);
            return employee;
        }

        public Employee AddEmployee(Employee employee)
        {
            _sqlServerContext.Employee.Add(employee);
            _sqlServerContext.SaveChanges();
            return employee;
        }






        public Employee UpdateEmployee(Employee employee)
        {
            _sqlServerContext.Employee.Update(employee);
            _sqlServerContext.SaveChanges();
            return employee;
        }




        /*  public void DeleteEmployee(int id)
          {
              var employeeToDelete = _sqlServerContext.Employee.Find(id);
              if (employeeToDelete != null)
              {
                  _sqlServerContext.Employee.Remove(employeeToDelete);
                  _sqlServerContext.SaveChanges();
              }
              else
              {
                  throw new ArgumentException($"Employee with ID {id} not found");
              }
          }

  */


        public bool DeleteEmployee(int id)
        {
            var employeeToDelete = _sqlServerContext.Employee.Find(id);
            if (employeeToDelete != null)
            {
                _sqlServerContext.Employee.Remove(employeeToDelete);
                _sqlServerContext.SaveChanges();
                return true; // Deletion succeeded
            }
            else
            {
                return false; // Employee not found or deletion failed
            }
        }


    }
}
