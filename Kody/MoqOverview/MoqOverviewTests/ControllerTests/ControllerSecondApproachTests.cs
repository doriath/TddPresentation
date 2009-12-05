using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using MoqOverview;
using MoqOverview.Repo;
using MoqOverviewTests.FakeClasses;
using NUnit.Framework;

namespace MoqOverviewTests.ControllerTests
{
    [TestFixture]
    public class ControllerSecondApproachTests
    {
        private Controller m_controller;
        private List<Employee> m_employeesList;


        [SetUp]
        public void SetUp()
        {
            //create result set
            m_employeesList = new List<Employee> ();
            m_employeesList.Add(new Employee ()
                                {
                                        FirstName = "Mój",
                                        Salary = 2000
                                });
            //approach 2. create moq...
            var repository = new Mock<IEmployeeRepository> ();
            repository.Setup (x => x.GetEmployees ()).Returns ( m_employeesList );
            m_controller = new Controller (repository.Object);
        }

        [Test]
        public void WritingUsersTest()
        {
            string[] result = this.m_controller.ShowUsers().ToArray();

            Assert.AreEqual("Mój: 2000,00z³", result[0]);
            Assert.AreEqual(1, result.Length);
        }

        //something cool now..
        [Test]
        public void WhetherEveryUserHasRiseSalaryCalledTest()
        {
            var employee = new Mock<Employee>();
            employee.Setup (x => x.RaiseSalaryLinear (It.IsAny<double> ())).Verifiable();
            var employeesList = new List<Employee>
                {
                        employee.Object,
                        employee.Object
                };
            var employeeRepo = new Mock<IEmployeeRepository> ();
            employeeRepo.Setup (x => x.GetEmployees ()).Returns (employeesList);

            var controller = new Controller (employeeRepo.Object);
            controller.RaiseSalaryOfAllUsers (150.00);

            //mozemy sprawdzic, czy byla wywolana tyle razy
            employee.Verify(x => x.RaiseSalaryLinear (It.IsAny<double> ()), Times.Exactly (2));
            
            //a nawet, czy z konkretnymi argumentami
            employee.Verify(x => x.RaiseSalaryLinear(It.Is<double>(y => y == 150.0)), Times.Exactly(2));
        }
    }
}