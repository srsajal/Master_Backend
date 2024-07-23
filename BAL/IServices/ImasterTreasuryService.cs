using master.DAL.Entity;
using master.Dto;
using master.Models;
using Microsoft.AspNetCore.Mvc;

namespace master.BAL.IServices
{
    public interface ImasterTreasuryService
    {
        Task<int> addStudent(masterTreasuryModel s);
        Task<bool> updateStudent(short id, masterTreasuryModel s);
        Task<bool> deleteStudent(short TreasuryId);
        Task<bool> restoreMasterTreasury(short TreasuryId);
        Task<Treasury> getStudentById(short id);

      
        Task<IEnumerable<masterTresuryDTOs>> getmasterTreasury(bool isActive, DynamicListQueryParameters dynamicListQueryParameters);
        //int CountWithCondition(List<FilterParameter> dynamicFilters);

        Task<int> CountMasterTreasury([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters);
       
    }
}
