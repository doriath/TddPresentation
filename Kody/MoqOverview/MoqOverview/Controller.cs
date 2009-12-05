using System;
using System.Collections.Generic;
using MoqOverview.Repo;

namespace MoqOverview
{
    public class Controller
    {
        private readonly IEmployeeRepository m_repository;


        public Controller (IEmployeeRepository repository)
        {
            this.m_repository = repository;
        }

        public IEnumerable<string> ShowUsers()
        {
            foreach (var employee in this.m_repository.GetEmployees ())
            {
                yield return String.Format ("{0}: {1:0.00}z³", employee.FirstName, employee.Salary);
            }
        }

        //2.
        public void RaiseSalaryOfAllUsers(double amount)
        {
            foreach (var employee in this.m_repository.GetEmployees ())
            {
                employee.RaiseSalaryLinear(amount);
            }
        }
    }
}