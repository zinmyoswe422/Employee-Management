using EmployeePortal.Data;
using EmployeePortal.Models;
using EmployeePortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;

        public EmployeeController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public  IActionResult GetAllEmployees()
        {


            return Ok(dbContext.Employees.ToList());

        }

        

        [HttpPost]
        public  IActionResult AddEmployee(AddEmployeeDetail addEmployeeDetail)
        {

            var employeeEntity = new Employee()
            {
                Name = addEmployeeDetail.Name,
                Email = addEmployeeDetail.Email,
                Position = addEmployeeDetail.Position,
                Department = addEmployeeDetail.Department,
                Phone = addEmployeeDetail.Phone,
                Salary = addEmployeeDetail.Salary,

            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
            
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {

            var employee = dbContext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDetail updateEmployeeDetail)
        {

            var employee = dbContext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }

            employee.Name = updateEmployeeDetail.Name;
            employee.Email = updateEmployeeDetail.Email;
            employee.Position = updateEmployeeDetail.Position;
            employee.Department = updateEmployeeDetail.Department;
            employee.Phone = updateEmployeeDetail.Phone;
            employee.Salary = updateEmployeeDetail.Salary;

            dbContext.SaveChanges();

            return Ok(employee);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
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
