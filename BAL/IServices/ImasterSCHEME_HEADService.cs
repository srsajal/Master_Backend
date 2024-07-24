using master.DAL.Entity;
using master.Dto;
using master.Models;

namespace master.BAL.IServices
{
    public interface ImasterSCHEME_HEADService
    {
        Task<int> addStudent(masterSCHEME_HEADModel s);
        Task<bool> updateStudent(int id, masterSCHEME_HEADModel s);
        Task<bool> deleteStudent(int id);
        Task<bool> restoreMasterSchemeHead(int studentId);
        Task<SchemeHead> getStudentById(int id);
        Task<IEnumerable<masterSCHEME_HEADDto>> getmasterSCHEME_HEAD(bool isActive, DynamicListQueryParameters dynamicListQueryParameters);

        Task<IEnumerable<SchemeMinorheadfromMINORHEADIdDTO>> getSchemeMinorheadfromMINORHEADId();
        //int CountWithCondition(List<FilterParameter> dynamicFilters);
        Task<int> CountMasterSCHEME_HEAD(bool isActive, DynamicListQueryParameters dynamicListQueryParameters);
    }
}
