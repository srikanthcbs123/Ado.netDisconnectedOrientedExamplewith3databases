namespace Ado.netDisconnectedOrientedExamplewith3databases.Utility
{
    public class StoredprocedureParameters
    {
        #region Department Parameters
        public static string DeptId = "@deptid";
        public static string DeptName = "@deptname";
        public static string DeptLocation = "@deptlocation";
        #endregion

        #region Order Parameters
        public static string OrderId = "@orderid";
        public static string OrderName = "@ordername";
        public static string OrderLocation = "@orderlocation";

        #endregion

        #region Employee Parameters
        public static string EmployeeID = "@empid";
        public static string EmployeeName = "@empname";
        public static string EmployeeSalary = "@empsalary";
        public static string Insertedvariable = "@insertvalue";
        #endregion



    }
}
