using System.Collections.Generic;

namespace MoqOverview.Repo
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees ();
    }
}