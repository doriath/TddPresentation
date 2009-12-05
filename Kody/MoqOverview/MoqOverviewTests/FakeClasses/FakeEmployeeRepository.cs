using System;
using System.Collections.Generic;
using System.Linq;
using MoqOverview.Repo;

namespace MoqOverviewTests.FakeClasses
{
    public class FakeEmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees ()
        {
            yield return new Employee () {FirstName = "M�j", LastName = "Testowy", Salary = 2000};
        }
    }
}