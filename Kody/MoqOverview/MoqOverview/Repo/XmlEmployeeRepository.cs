using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MoqOverview.Repo
{
    public class XmlEmployeeRepository : IEmployeeRepository
    {
        private XDocument m_xDoc;


        public XmlEmployeeRepository ()
        {
            m_xDoc = XDocument.Load ("Employees.xml");
        }


        public IEnumerable<Employee> GetEmployees ()
        {
            /*IEnumerable<Employee> q = from c in m_xDoc.Descendants("employees")
                                      where c!=null && (int)c.Attribute("employeeId") > 0
                                      select new Employee()
                                      {
                                          FirstName = (string)c.Element("firstName"),
                                          LastName = (string)c.Element("lastName"),
                                          Salary = (double)c.Element("salary")
                                      };*/

            yield return new Employee () {FirstName = "Jan", LastName = "Wêglarz", Salary = 2000};
            yield return new Employee() { FirstName = "Tadeusz", LastName = "Morzy", Salary = 1000 };
            //return q;
        }
    }
}