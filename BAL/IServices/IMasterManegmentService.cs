using master.DAL.Entity;
using master.Dto;
using MasterManegmentSystem.Dto;
using MasterManegmentSystem.Models;
using System.Linq.Expressions;

namespace MasterManegmentSystem.BAL.IServices
{
    public interface IMasterManegmentService
    {
        Task<IEnumerable<MasterManegmentDTO>> GetMasterSubmajorhead(DynamicListQueryParameters dynamicListQueryParameters);
          Task<int> AddMasterMAJORHEAD(MasterManegmentModel model);
           Task<bool> UpdateMasterSubmajorhead(short id, MasterManegmentModel model);
           Task<bool> DeleteMasterSubmajorhead(short id);
        /* Task<List<MajorHead>> GetMasterMAJORHEADName(string name);*/
        Task<MajorHead> GetMasterSubmajorheadById(short id);
        Task<int> CountMasterDDO(DynamicListQueryParameters dynamicListQueryParameters);
    }
}
