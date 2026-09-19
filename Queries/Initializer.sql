use ConsoleEMS;
go

insert into Employees
    (FirstName,  LastName,    BirthDate,   HoursWorked, Wage,    HourlyRate, EmployeeNumber, Email)
VALUES 
    (N'John',    N'Doe',      '1990-05-15', 160,        4080.00, 25.50,      N'EMP-001',     N'john.doe@company.com'),
    (N'Jane',    N'Smith',    '1985-11-22', 175,        5600.00, 32.00,      N'EMP-002',     N'jane.smith@company.com'),
    (N'Alex',    N'Johnson',  '1998-03-10', 150,        3000.00, 20.00,      N'EMP-003',     N'alex.johnson@company.com'),
    (N'Sarah',   N'Williams', '1992-08-04', 160,        4800.00, 30.00,      N'EMP-004',     N'sarah.williams@company.com'),
    (N'Michael', N'Brown',    '1988-01-30', 140,        3920.00, 28.00,      N'EMP-005',     N'michael.brown@company.com'),
    (N'Emily',   N'Davis',    '1995-12-18', 165,        4125.00, 25.00,      N'EMP-006',     N'emily.davis@company.com'),
    (N'David',   N'Miller',   '1982-06-25', 180,        7200.00, 40.00,      N'EMP-007',     N'david.miller@company.com'),
    (N'Jessica', N'Wilson',   '1993-09-09', 155,        3487.50, 22.50,      N'EMP-008',     N'jessica.wilson@company.com'),
    (N'James',   N'Taylor',   '1991-04-03', 170,        5950.00, 35.00,      N'EMP-009',     N'james.taylor@company.com'),
    (N'Amanda',  N'Anderson', '1996-07-21', 160,        4480.00, 28.00,      N'EMP-010',     N'amanda.anderson@company.com');
go

select *
from Employees;

