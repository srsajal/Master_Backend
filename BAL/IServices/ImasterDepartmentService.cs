using master.DAL.Entity;
using master.Dto;
using master.Models;
using System.Linq.Expressions;

namespace master.BAL.IServices
{
    public interface ImasterDepartmentService
    {
        Task<int> addDepartment(masterDepartmentModel s);
        Task<bool> updateDepartment(short id, masterDepartmentModel s);
        Task<bool> deleteDepartment(short DepartmentId);
        Task<Department> getDepartmentById(short id);
        Task<IEnumerable<masterDepartmentDto>> getmasterDepartment(bool isActiv,DynamicListQueryParameters dynamicListQueryParameters);
        //int CountWithCondition(List<FilterParameter> dynamicFilters);
        Task<int> CountMasterDepartment(DynamicListQueryParameters dynamicListQueryParameters);
       // Task<IEnumerable<masterDepartmentDto>> getmasterDepartment(bool isActive, DynamicListQueryParameters dynamicListQueryParameters);
    }
}
