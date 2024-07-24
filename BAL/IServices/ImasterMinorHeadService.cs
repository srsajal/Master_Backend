
using master.DAL.Entity;
using master.Dto;
using master.Models;
using Microsoft.AspNetCore.Mvc;

namespace master.BAL.IServices
{
    public interface ImasterMinorHeadService
    {
        Task<int> addMinorHead(masterMinorHeadModel s);
        Task<bool> updateMinorHead(int id,masterMinorHeadModel s);
        Task<bool> deleteMinorHead(int MinorHeadId);
        Task<MinorHead> getMinorHeadById(int id);
        Task<IEnumerable<masterMinorHeadDto>> getmasterMinorHead(DynamicListQueryParameters dynamicListQueryParameters);
        // int CountWithCondition(List<FilterParameter> dynamicFilters);
        Task<IEnumerable<SubMajorHeadToMinorHeadDTO>> getSubMajorHeadCode();
        Task<int> CountMasterMinorHead([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters);
    }
}
