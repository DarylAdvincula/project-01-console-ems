using ConsoleEMS.Services.Impl;
using ConsoleEMS.Utils;

namespace ConsoleEMS;

public class App
{
    private readonly EmployeeService _employeeService;
    
    public App(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    private static bool IsChoiceValid(string? choice, int choiceCount)
    {
        if (choice == null)
            return false;

        List<string> choices = Enumerable
            .Range(1, choiceCount)
            .Select(c => c.ToString())
            .ToList();
        
        return choices.Contains(choice.Trim());
    }

    public async Task Run()
    {
        var running = true;

        while (running)
        {
            Table.Build()
                .SetColumns([new Column("Employee Management System: Week 1 Task - Retrieval", 154)])
                .SetRows([
                    new Row(["1. View Employees"]),
                    new Row(["2. Search Employees"]),
                    new Row(["3. Create Employee"]),
                    new Row(["4. Edit Employee"]),
                    new Row(["5. Delete Employee"]),
                    new Row(["6. Exit"]),
                ])
                .Display();
            Console.Write("Choice: ");

            var choice = Console.ReadLine();

            if (IsChoiceValid(choice, 6))
            {
                switch (choice)
                {
                    case "1":
                        await _employeeService.GetAll(null, print: true);
                        break;
                    case "2":
                        Console.Write("Search Employee: ");
                    
                        var search = Console.ReadLine();

                        await _employeeService.GetAll(search, true);
                        break;
                    case "3":
                    case "4":
                    case "5":
                        Console.Write("Not yet implemented. (press enter)");
                        Console.ReadLine();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice number");
                        break;
                }
            }
        }
    }
}