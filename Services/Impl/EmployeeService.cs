using ConsoleEMS.Dal;
using ConsoleEMS.Models;
using ConsoleEMS.Services.Inter;
using ConsoleEMS.Utils;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEMS.Services.Impl;

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext _context;

    public EmployeeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Employee>> GetAll(string? search, bool print = false)
    {
        IQueryable<Employee> employeesQuery = _context.Employees;

        if (search != null)
        {
            var pattern = $"%{search}%";

            employeesQuery = employeesQuery.Where(e =>
                e.EmployeeNumber.Contains(search) ||
                e.FirstName.Contains(search) ||
                e.LastName.Contains(search) ||
                e.Email.Contains(search) ||
                EF.Functions.Like(Convert.ToString(e.HoursWorked), pattern) ||
                EF.Functions.Like(Convert.ToString(e.Wage), pattern) ||
                EF.Functions.Like(Convert.ToString(e.HourlyRate), pattern)
            );
        }
            
        var employees = await employeesQuery
            .AsNoTracking()
            .ToListAsync();

        if (print)
        {
            Table<Employee>.Build()
                .AddColumn("Id", 3)
                .AddColumn("Employee No.")
                .AddColumn("First Name", 14)
                .AddColumn("Last Name", 14)
                .AddColumn("Birthdate", 12)
                .AddColumn("Age")
                .AddColumn("Hours Worked")
                .AddColumn("Wage", 9)
                .AddColumn("Hourly Rate")
                .AddColumn("Email", 37)
                .SetRows(employees, employee => [
                    employee.Id.ToString(),
                    employee.EmployeeNumber,
                    employee.FirstName,
                    employee.LastName,
                    employee.BirthDate.ToString("MM-dd-yyyy"),
                    employee.Age.ToString(),
                    employee.HoursWorked.ToString(),
                    employee.Wage.ToString("C2"),
                    employee.HourlyRate.ToString("C2"),
                    employee.Email
                ])
                .Display();
        }
        
        return employees;
    }

    public async Task<Employee?> Get(int id, bool print = false)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == id);
        
        if (print && employee != null)
        {
            Table<Employee>.Build()
                .AddColumn("Id", 3)
                .AddColumn("Employee No.")
                .AddColumn("First Name", 14)
                .AddColumn("Last Name", 14)
                .AddColumn("Birthdate", 12)
                .AddColumn("Age")
                .AddColumn("Hours Worked")
                .AddColumn("Wage", 9)
                .AddColumn("Hourly Rate")
                .AddColumn("Email", 37)
                .AddRow([
                    employee.Id.ToString(),
                    employee.EmployeeNumber,
                    employee.FirstName,
                    employee.LastName,
                    employee.BirthDate.ToString("MM-dd-yyyy"),
                    employee.Age.ToString(),
                    employee.HoursWorked.ToString(),
                    employee.Wage.ToString("C2"),
                    employee.HourlyRate.ToString("C2"),
                    employee.Email
                ])
                .Display();
        }

        return employee;
    }
}