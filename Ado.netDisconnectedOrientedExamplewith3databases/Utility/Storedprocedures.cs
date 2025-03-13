namespace Ado.netDisconnectedOrientedExamplewith3databases.Utility
{
    public static class Storedprocedures
    {
        #region DepartmentDetails
        public static readonly string AddDepartment = "Usp_AddDepartment_WithoutReturn";
        public static readonly string UpdateDepartment = "Usp_UpdateDepartment";
        public static readonly string DeleteDepartment = "Usp_DeleteDepartment";
        public static readonly string GetDepartment = "Usp_GetDepartment";
        public static readonly string GetDepartmentByDeptId = "Usp_GetDepartmentById";
        #endregion

        #region OrderDetails
        public static readonly string AddOrder = "Usp_AddOrder_Without_Return";
        public static readonly string UpdateOrder = "Usp_UpdateOrder";
        public static readonly string DeleteOrder = "Usp_DeleteOrder";
        public static readonly string GetOrder = "Usp_GetOrder";
        public static readonly string GetOrderByOrderId = "Usp_GetOrderById";

        #endregion

        #region Employee
        public static readonly string AddEmployee = "Usp_AddEmployee";
        public static readonly string UpdateEmployee = "Usp_UpdateEmployee";
        public static readonly string DeleteEmployee = "Usp_DeleteEmployee";
        public static readonly string GetEmployee = "Usp_GetEmployee";
        public static readonly string GetEmployeeByEmpid = "Usp_GetEmployeeId";
        #endregion
    }
}
