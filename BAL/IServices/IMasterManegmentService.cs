using master.DAL.Entity;
using master.Dto;
using MasterManegmentSystem.Dto;
using MasterManegmentSystem.Models;
using System.Linq.Expressions;

namespace MasterManegmentSystem.BAL.IServices
{
    public interface IMasterManegmentService
    {
        Task<IEnumerable<MasterManegmentDTO>> GetMasterMAJORHEAD(DynamicListQueryParameters dynamicListQueryParameters);
          Task<int> AddMasterMAJORHEAD(MasterManegmentModel model);
           Task<bool> UpdateMasterMAJORHEAD(short id, MasterManegmentModel model);
           Task<bool> DeleteMasterMAJORHEAD(short id);
        /* Task<List<MajorHead>> GetMasterMAJORHEADName(string name);*/
        Task<MajorHead> GetMasterMAJORHEADById(short id);
        Task<int> CountMasterDDO(DynamicListQueryParameters dynamicListQueryParameters);
       
    }
}
