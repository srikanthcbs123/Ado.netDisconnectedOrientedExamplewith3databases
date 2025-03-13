using Ado.netDisconnectedOrientedExample.Models;

namespace Ado.netDisconnectedOrientedExample.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int DepartmentId);
        Task<bool> AddDepartment(Department Dept);
        Task<bool> UpdateDepartment(Department Dept);
        Task<bool> DeleteDepartment(int DepartmentId);
    }
}
