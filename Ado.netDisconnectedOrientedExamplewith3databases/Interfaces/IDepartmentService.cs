using Ado.netDisconnectedOrientedExample.Dtos;

namespace Ado.netDisconnectedOrientedExample.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllDepartments();
        Task<DepartmentDto> GetDepartmentById(int DepartmentId);
        Task<bool> AddDepartment(DepartmentDto Dept);
        Task<bool> UpdateDepartment(DepartmentDto Dept);
        Task<bool> DeleteDepartment(int DepartmentId);
    }
}
