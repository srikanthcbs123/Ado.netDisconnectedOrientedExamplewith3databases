using Ado.netDisconnectedOrientedExample.Dtos;
using Ado.netDisconnectedOrientedExample.Interfaces;
using Ado.netDisconnectedOrientedExample.Models;

namespace Ado.netDisconnectedOrientedExample.Services
{
    public class DepartmentServices : IDepartmentService
    {
        public readonly IDepartmentRepository _Deptrepository;

        public DepartmentServices(IDepartmentRepository deptrepository)
        {
            _Deptrepository = deptrepository;
        }


        public async Task<bool> AddDepartment(DepartmentDto Dept)
        {
            Department department = new Department();
            department.DepartmentName = Dept.DepartmentName;
            department.DepartmentLocation = Dept.DepartmentLocation;
            department.DepartmentId = Dept.DepartmentId;
            var res = await _Deptrepository.AddDepartment(department);
            return res;
        }

        public async Task<bool> DeleteDepartment(int DepartmentId)
        {
            await _Deptrepository.DeleteDepartment(DepartmentId);
            return true;
        }

        public async Task<List<DepartmentDto>> GetAllDepartments()
        {
            List<DepartmentDto> deptlist = new List<DepartmentDto>();
            var getdept = await _Deptrepository.GetAllDepartments();
            foreach (Department dept in getdept)
            {
                DepartmentDto deptobj = new DepartmentDto();
                deptobj.DepartmentId = dept.DepartmentId;
                deptobj.DepartmentName = dept.DepartmentName;
                deptobj.DepartmentLocation = dept.DepartmentLocation;
                deptlist.Add(deptobj);
            }
            return deptlist;
        }
        public async Task<DepartmentDto> GetDepartmentById(int DepartmentId)
        {
            var res = await _Deptrepository.GetDepartmentById(DepartmentId);
            DepartmentDto dept = new DepartmentDto();
            dept.DepartmentId = res.DepartmentId;
            dept.DepartmentName = res.DepartmentName;
            dept.DepartmentLocation = res.DepartmentLocation;
            return dept;
        }

        public async Task<bool> UpdateDepartment(DepartmentDto Dept)
        {
            Department department = new Department();
            department.DepartmentName = Dept.DepartmentName;
            department.DepartmentLocation = Dept.DepartmentLocation;
            department.DepartmentId = Dept.DepartmentId;
            await _Deptrepository.UpdateDepartment(department);
            return true;
        }
    }
}
