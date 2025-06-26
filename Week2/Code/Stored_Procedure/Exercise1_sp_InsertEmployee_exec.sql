USE COGNIZANT
GO
EXEC sp_InsertEmployee 
    @EmployeeID = 101,
    @FirstName = 'Rahul',
    @LastName = 'Saha',
    @DepartmentID = 1,
    @Salary = 70000.00,
    @JoinDate = '2023-06-01';



