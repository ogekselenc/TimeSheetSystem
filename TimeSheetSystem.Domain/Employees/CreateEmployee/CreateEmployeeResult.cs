namespace TimeSheetSystem.Domain.Employees.CreateEmployee
{

    public record CreateEmployeeResult(Guid Id, string FirstName, string LastName, string Email);
}