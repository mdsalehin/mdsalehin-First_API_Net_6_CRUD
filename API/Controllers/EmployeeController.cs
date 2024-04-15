using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetEmployees()
        {
            try
            {
                var employees = _employeeRepository.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            try
            {
                var employee = _employeeRepository.GetEmployeeById(id);
                if (employee == null)
                    return NotFound();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            try
            {
                var addedEmployee = _employeeRepository.AddEmployee(employee);
                return Ok(addedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }







        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            try
            {
                var existingEmployee = _employeeRepository.GetEmployeeById(id);
                if (existingEmployee == null)
                    return NotFound();

                existingEmployee.EmployeeName = employee.EmployeeName;
                existingEmployee.City = employee.City;
                existingEmployee.DateofJoining = employee.DateofJoining;
                existingEmployee.Salary = employee.Salary;

                var updatedEmployee = _employeeRepository.UpdateEmployee(existingEmployee);
                return Ok(updatedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                // Delete employee
                bool deletionResult = _employeeRepository.DeleteEmployee(id);

                // Additional code to execute after deletion (example)
                // This could be any logic you want to execute after the employee is deleted

                // Return 200 OK response
                return Ok($"Employee with ID {id} deleted successfully");
            }



            /*  try
              {
                  _employeeRepository.DeleteEmployee(id);
                  return NoContent(); // Return 204 No Content on successful deletion
              }*/
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message); // Return 404 Not Found if employee not found
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting employee: {ex.Message}");
            }
        }













    }
}
