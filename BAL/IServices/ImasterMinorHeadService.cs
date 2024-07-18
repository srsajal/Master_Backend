
using master.DAL.Entity;
using master.Dto;
using master.Models;

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
        Task<int> CountMasterMinorHead(DynamicListQueryParameters dynamicListQueryParameters);
    }
}
