using Ado.netDisconnectedOrientedExamplewith3databases.Interfaces;
using Ado.netDisconnectedOrientedExamplewith3databases.Models;
using Microsoft.AspNetCore.Connections;
using System.Data;
using Microsoft.Data.SqlClient;
using Ado.netDisconnectedOrientedExamplewith3databases.Utility;
namespace Ado.netDisconnectedOrientedExamplewith3databases.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //  string connectionstring="yorconnection string";(do't use the connection string like this.
        //alway read the connectionstring from "appsettings.json";
        private readonly IDatabaseConnectionFactory _connectionFactory;
        public EmployeeRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            this._connectionFactory = databaseConnectionFactory;
        }

        public async Task<int> AddEmployes(Employee empdetail)
        {
            using (SqlConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.AddEmployee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.EmployeeName, empdetail.empname);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.EmployeeSalary, empdetail.empsalary);

                SqlParameter outputParam = new SqlParameter(StoredprocedureParameters.Insertedvariable, SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParam);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();//create the dataset object
                da.Fill(ds, DataSetNames.EmployeeDataSetName);
                var lastInsertedValue = (int)cmd.Parameters[StoredprocedureParameters.Insertedvariable].Value;
                return lastInsertedValue;
            }
        }

        public async Task<bool> DeleteEmployesById(int empid)
        {
            using (SqlConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.DeleteEmployee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.EmployeeID, empid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            return true;
        }

        public async Task<Employee> GetEmployeeById(int empid)
        {
            Employee emp = new Employee();
            using (SqlConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetEmployeeByEmpid, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.EmployeeID, empid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, DataSetNames.EmployeeDataSetName);
                foreach (DataRow row in ds.Tables["Employee"].Rows)
                {
                    emp.empid = Convert.ToInt16(row["empid"]);
                    emp.empname = Convert.ToString(row["empname"]);
                    emp.empsalary = Convert.ToInt32(row["empsalary"]);
                }
            }
            return emp;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            using (SqlConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                List<Employee> lstemp = new List<Employee>();
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetEmployee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();//To store the data at ado.net side in table format we use dataset.
                dataAdapter.Fill(ds, DataSetNames.EmployeeDataSetName);//sqldataAdapter will assign the data to dataset like this way.
                foreach (DataRow row in ds.Tables["Employee"].Rows)
                {
                    Employee Emp = new Employee();
                    Emp.empid = Convert.ToInt16(row["empid"]);
                    Emp.empname = Convert.ToString(row["empname"]);
                    Emp.empsalary = Convert.ToInt32(row["empsalary"]);
                    lstemp.Add(Emp);
                }
                return lstemp;
            }
        }

        public async Task<bool> UpdateEmploye(Employee empdetail)
        {
            using (SqlConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.UpdateEmployee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.EmployeeID, empdetail.empid);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.EmployeeName, empdetail.empname);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.EmployeeSalary, empdetail.empsalary);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, DataSetNames.EmployeeDataSetName);

                return true;
            }
        }
    }
}
