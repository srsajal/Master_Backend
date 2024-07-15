using master.DAL.Entity;
using master.Dto;
using master.Models;
using System.Linq.Expressions;

namespace master.BAL.IServices
{
    public interface ImasterDDOService
    {

        // Task<List<Ddo>> getstudents();
        
        Task<int> addStudent(masterDDOModel s);
        Task<bool> updateStudent(int id, masterDDOModel s);
        Task<bool> deleteStudent(int studentId);
        Task<masterDDODto> getStudentById(int id);
        Task<IEnumerable<masterDDODto>> getmasterDDO(DynamicListQueryParameters dynamicListQueryParameters);
        Task<IEnumerable<DdoCodeTresuryDTO>> getTreasuryCode();
        //int CountWithCondition(List<FilterParameter> dynamicFilters);
        Task<int> CountMasterDDO(DynamicListQueryParameters dynamicListQueryParameters);
    }
}
