using DatabaseProject.Models;
using System.Collections.Generic;
using System;
namespace DatabaseProject.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        Employee AddEmployee(Employee employee);




        Employee UpdateEmployee(Employee employee);


        bool DeleteEmployee(int id);

        /*  void DeleteEmployee(int id);*/
    }
}
