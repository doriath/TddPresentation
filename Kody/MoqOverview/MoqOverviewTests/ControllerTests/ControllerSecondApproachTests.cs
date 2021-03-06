using System.Collections.Generic;
using System.Linq;
using Moq;
using MoqOverview;
using MoqOverview.Repo;
using NUnit.Framework;

namespace MoqOverviewTests.ControllerTests
{
    [TestFixture]
    public class ControllerSecondApproachTests
    {
        #region Setup/Teardown


        [SetUp]
        public void SetUp ()
        {
            //create result set
            this.m_employeesList = new List<Employee> ();
            this.m_employeesList.Add (new Employee ()
                {
                        FirstName = "M�j",
                        Salary = 2000
                });
            //approach 2. create moq...
            var repository = new Mock<IEmployeeRepository> ();
            repository.Setup (x => x.GetEmployees ()).Returns (this.m_employeesList);
            this.m_controller = new Controller (repository.Object);
        }


        #endregion


        private Controller m_controller;
        private List<Employee> m_employeesList;


        //something cool now..
        [Test]
        public void WhetherEveryUserHasRiseSalaryCalledTest ()
        {
            var employee = new Mock<Employee> ();
            employee.Setup (x => x.RaiseSalaryLinear (It.IsAny<double> ())).Verifiable ();
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
            employee.Verify (x => x.RaiseSalaryLinear (It.IsAny<double> ()), Times.Exactly (2));

            //a nawet, czy z konkretnymi argumentami
            employee.Verify (x => x.RaiseSalaryLinear (It.Is<double> (y => y == 150.0)), Times.Exactly (2));
        }


        [Test]
        public void WritingUsersTest ()
        {
            string[] result = this.m_controller.ShowUsers ().ToArray ();

            Assert.AreEqual ("M�j: 2000,00z�", result[0]);
            Assert.AreEqual (1, result.Length);
        }
    }
}