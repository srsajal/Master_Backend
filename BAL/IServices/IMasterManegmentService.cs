using master.DAL.Entity;
using master.Dto;
using MasterManegmentSystem.Dto;
using MasterManegmentSystem.Models;
using System.Linq.Expressions;

namespace MasterManegmentSystem.BAL.IServices
{
    public interface IMasterManegmentService
    {
        Task<IEnumerable<MasterManegmentDTO>> GetMastermajorhead(bool isActive, DynamicListQueryParameters dynamicListQueryParameters);
        Task<int> AddMasterMAJORHEAD(MasterManegmentModel model);
        Task<bool> MasterMAJORHEADExistsByCode(string code);
        Task<bool> MasterMAJORHEADExistsById(int id);
        Task<IEnumerable<MasterManegmentModel>> GetAllMasterMAJORHEADs();
        Task<bool> UpdateMastermajorhead(int id, MasterManegmentModel model);
        Task<bool> DeleteMastermajorhead(int id);
        Task<MajorHead> GetMastermajorheadById(int id);
        Task<int> CountMasterDDO(DynamicListQueryParameters dynamicListQueryParameters);
       
    }
}
