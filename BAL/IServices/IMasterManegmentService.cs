using master.DAL.Entity;
using master.Dto;
using MasterManegmentSystem.Dto;
using MasterManegmentSystem.Models;
using System.Linq.Expressions;

namespace MasterManegmentSystem.BAL.IServices
{
    public interface IMasterManegmentService
    {
        Task<IEnumerable<MasterManegmentDTO>> GetMastermajorhead(DynamicListQueryParameters dynamicListQueryParameters);
          Task<int> AddMasterMAJORHEAD(MasterManegmentModel model);
           Task<bool> UpdateMastermajorhead(short id, MasterManegmentModel model);
           Task<bool> DeleteMastermajorhead(short id);
        Task<MajorHead> GetMastermajorheadById(int id);
        Task<int> CountMasterDDO(DynamicListQueryParameters dynamicListQueryParameters);
    }
}
