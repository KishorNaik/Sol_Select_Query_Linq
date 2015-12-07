using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Select_Query_Linq
{
    public class EmployeeIEnumerable
    {

        // Using IEnumerable
        public IEnumerable<ORD.Employee> GetEmployeeDataIEnumerable()
        {
            ORD.EmployeeDCmlDataContext DC = new ORD.EmployeeDCmlDataContext();

            var Query = DC.Employees.AsEnumerable().Select(LE => new ORD.Employee()
            {
                EmployeeID=Convert.ToInt32(LE.EmployeeID),
                FirstName=LE.FirstName,
                LastName=LE.LastName
            });

            return Query;

        }

        // Using Task Ienumerable
        public Task<IEnumerable<ORD.Employee>> GetEmployeeDataTaskIEnumerable()
        {
            return Task.Run<IEnumerable<ORD.Employee>>(() =>
            {
                ORD.EmployeeDCmlDataContext DC = new ORD.EmployeeDCmlDataContext();

                var Query = DC.Employees.AsEnumerable().Select(LE => new ORD.Employee()
                {
                    EmployeeID = Convert.ToInt32(LE.EmployeeID),
                    FirstName = LE.FirstName,
                    LastName = LE.LastName
                });

                return Query;
            });

        }

        // Using IEnurable Dynamic // Selected Specific Column

        public IEnumerable<dynamic> GetDataDynamic()
        {
            ORD.EmployeeDCmlDataContext DC = new ORD.EmployeeDCmlDataContext();

            var Query = DC.Employees.AsEnumerable().Select(LE => new
            {
                EmployeeID=LE.EmployeeID,
                FirstName =LE.FirstName,
                LastName=LE.LastName
            }).ToList();

            return Query;
        }

        public Task<IEnumerable<dynamic>> GetDataDynamicTask()
        {
            return Task.Run<IEnumerable<dynamic>>(() =>
            {
                ORD.EmployeeDCmlDataContext DC = new ORD.EmployeeDCmlDataContext();

                var Query = DC.Employees.AsEnumerable().Select(LE => new
                {
                    EmployeeID = LE.EmployeeID,
                    FirstName = LE.FirstName,
                    LastName = LE.LastName
                }).ToList();

                return Query;
            });
        }

        public IEnumerable<EmployeeEntity> GetEmployeeEntity()
        {
            ORD.EmployeeDCmlDataContext DC = new ORD.EmployeeDCmlDataContext();

            return DC.Employees.Select(LE => new EmployeeEntity()
            {
                EmployeeID=Convert.ToInt32(LE.EmployeeID),
                FirstName=LE.FirstName,
                LastName=LE.LastName
            });
        }


    }
}
