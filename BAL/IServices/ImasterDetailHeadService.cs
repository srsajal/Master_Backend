using master.Dto;
using master.Models;

namespace master.BAL.IServices
{
    public interface ImasterDetailHeadService
    {
        Task<int> addDetailHead(masterDetailHeadModel s);
        Task<bool> updateDetailHead(short id, masterDetailHeadModel s);
        Task<bool> deleteDetailHead(short studentId);
        Task<masterDetailHeadDto> getDetailHeadById(short id);
        Task<IEnumerable<masterDetailHeadDto>> getDetailHead(bool isActive, DynamicListQueryParameters dynamicListQueryParameters);
        //Task<IEnumerable<DdoCodeTresuryDTO>> getTreasuryCode();
        //int CountWithCondition(List<FilterParameter> dynamicFilters);
        Task<int> CountDetailHead(bool isActive, DynamicListQueryParameters dynamicListQueryParameters);
    }
}
