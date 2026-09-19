using ConsoleEMS.Models;

namespace ConsoleEMS.Services.Inter;

public interface IEmployeeService
{
    Task<ICollection<Employee>> GetAll(string? search, bool print);
}