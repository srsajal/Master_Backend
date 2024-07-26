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
        Task<bool> UpdateMastermajorhead(int id, MasterManegmentModel model);
        Task<bool> DeleteMastermajorhead(int id);
        Task<bool> restoreMasterMajorHead(int studentId);
        Task<MajorHead> GetMastermajorheadById(int id);
        Task<int> CountMasterMajorHead(bool isActive, DynamicListQueryParameters dynamicListQueryParameters);
       
    }
}
