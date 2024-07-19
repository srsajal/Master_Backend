using master.Dto;
using master.Models;

namespace master.BAL.IServices
{
    public interface ImasterSubDetailHeadService
    {
        Task<int> addSubDetailHead(masterSubDetailHeadModel s);
        Task<bool> updateSubDetailHead(short id, masterSubDetailHeadModel s);
        Task<bool> deleteSubDetailHead(short studentId);
        Task<masterSubDetailHeadDto> getSubDetailHeadById(short id);
        Task<IEnumerable<masterSubDetailHeadDto>> getSubDetailHead(DynamicListQueryParameters dynamicListQueryParameters);
        Task<IEnumerable<DetailToSubDetailCodeDTO>> getDetailCode();
        //int CountWithCondition(List<FilterParameter> dynamicFilters);
        Task<int> CountSubDetailHead(DynamicListQueryParameters dynamicListQueryParameters);
    }
}
