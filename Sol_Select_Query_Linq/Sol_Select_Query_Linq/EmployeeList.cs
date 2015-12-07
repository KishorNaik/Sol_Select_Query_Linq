using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Select_Query_Linq
{
    public class EmployeeList
    {
        public List<ORD.Employee> GetEmployeeeList()
        {
            ORD.EmployeeDCmlDataContext DC = new ORD.EmployeeDCmlDataContext();

            var Query = DC.Employees.AsEnumerable().Select(LE => new ORD.Employee() { EmployeeID=LE.EmployeeID,FirstName=LE.FirstName,LastName=LE.LastName}).ToList();

            return Query;
        }

        public Task<List<ORD.Employee>> GetEMployeeTaskList()
        {
            return Task.Run<List<ORD.Employee>>(() =>
            {
                ORD.EmployeeDCmlDataContext DC = new ORD.EmployeeDCmlDataContext();

                return DC.Employees.AsEnumerable().Select(LE => new ORD.Employee()
                {
                    EmployeeID=Convert.ToInt64(LE.EmployeeID),
                    FirstName=LE.FirstName,
                    LastName=LE.LastName
                }).ToList();
            });
        }

        public List<dynamic> GetEmployeeDynamicList()
        {
            ORD.EmployeeDCmlDataContext DC = new ORD.EmployeeDCmlDataContext();

            var Query = DC.Employees.AsEnumerable().Select(LE => new
            {
                EmployeeID = LE.EmployeeID,
                FirstName = LE.FirstName,
                LastName = LE.LastName
            });

            return Query.Select(LE => (dynamic) LE).ToList();
        }

        public Task<List<dynamic>> GetEmployeeTaskDynamicList()
        {
            return Task.Run<List<dynamic>>(() =>
            {
                ORD.EmployeeDCmlDataContext DC = new ORD.EmployeeDCmlDataContext();

                var Query = DC.Employees.AsEnumerable().Select(LE => new
                {
                    EmployeeID = LE.EmployeeID,
                    FirstName = LE.FirstName,
                    LastName = LE.LastName
                });

                return Query.Select(LE => (dynamic) LE).ToList();
            });
        }

    }
}
