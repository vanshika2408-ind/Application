using Application.Data;
using Application.Models;
using Application.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = dbContext.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if(employee is  null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDTO AddEmployeeDTO)
        {
            var employeeEmtity = new Employee()
            {
                Name = AddEmployeeDTO.Name,
                Email = AddEmployeeDTO.Email,
                Phone = AddEmployeeDTO.Phone,
                Salary = AddEmployeeDTO.Salary
            };


            dbContext.Employees.Add(employeeEmtity);
            dbContext.SaveChanges();

            return Ok(employeeEmtity);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult updateEmployee(Guid id,UpdateEmployeeDTO updateEmployeeDTO )
        {
            var employee = dbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }

            employee.Name = updateEmployeeDTO.Name;
            employee.Salary = updateEmployeeDTO.Salary;
            employee.Phone = updateEmployeeDTO.Phone;
            employee.Email = updateEmployeeDTO.Email;

            dbContext.SaveChanges();
            return Ok(employee);

        }


        [HttpDelete]
        [Route("id")]
        public IActionResult deleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            return Ok();

        }
    }
}
