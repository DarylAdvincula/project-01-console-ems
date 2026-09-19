namespace ConsoleEMS.Models;

public class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public int Age => DateTime.Today.Year - BirthDate.Year;

    public int HoursWorked { get; set; }
    public double Wage { get; set; }
    public double HourlyRate { get; set; }

    public string EmployeeNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}