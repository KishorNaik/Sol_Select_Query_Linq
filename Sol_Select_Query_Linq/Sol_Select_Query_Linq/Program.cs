using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Select_Query_Linq
{
    class Program
    {
        static void Main(string[] args)
        {

            #region IEnumerable

            // IEnumerable<ORD.Employee> List1 = new EmployeeIEnumerable().GetEmployeeDataIEnumerable();

            // Task.Run(async () =>
            //{
            //    IEnumerable<ORD.Employee> List2 = await new EmployeeIEnumerable().GetEmployeeDataTaskIEnumerable();
            //}).Wait();

            // #region Read Dynamic Data

            //IEnumerable<dynamic> List3 = new EmployeeIEnumerable().GetDataDynamic();

            //var Query1 = List3.Select(LE => new ORD.Employee() { EmployeeID = LE.EmployeeID, FirstName = LE.FirstName, LastName = LE.LastName });

            //Task.Run(async () =>
            //{
            //    IEnumerable<dynamic> List8 = await new EmployeeIEnumerable().GetDataDynamicTask();

            //    var Query4=List8.Select(LE => new ORD.Employee() { EmployeeID = LE.EmployeeID, FirstName = LE.FirstName, LastName = LE.LastName });
            //}).Wait();

            // #endregion

            // IEnumerable<EmployeeEntity> List4 = new EmployeeIEnumerable().GetEmployeeEntity();



            #endregion

            #region List

            List<ORD.Employee> List5 = new EmployeeList().GetEmployeeeList();

            List<dynamic> List6 = new EmployeeList().GetEmployeeDynamicList();

            var Query2 =
                List6.Select(
                    LE =>
                        new ORD.Employee()
                        {
                            FirstName = LE.FirstName,
                            LastName = LE.LastName,
                            EmployeeID = LE.EmployeeID
                        }).ToList();

            Task.Run(async () =>
            {
                List<ORD.Employee> List7 = await new EmployeeList().GetEMployeeTaskList();
            }).Wait();

            Task.Run(async () =>
            {
                List<dynamic> List7 = await new EmployeeList().GetEmployeeTaskDynamicList();

                var Query3 =
               List6.Select(
                   LE =>
                       new ORD.Employee()
                       {
                           FirstName = LE.FirstName,
                           LastName = LE.LastName,
                           EmployeeID = LE.EmployeeID
                       }).ToList();
            }).Wait();

            #endregion

        }
    }
}
