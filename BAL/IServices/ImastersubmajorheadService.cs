using master.DAL.Entity;
using master.Dto;
using master.Models;
using MasterManegmentSystem.Dto;
using MasterManegmentSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace master.BAL.IServices
{
    public interface ImastersubmajorheadService
    {
        Task<IEnumerable<mastersubmajorheadDTO>> GetMastersubmajorhead(bool isActive, DynamicListQueryParameters dynamicListQueryParameters);
        Task<int> AddMasterSubmajorHead(mastersubmajorheadModel model);
        Task<bool> UpdateMastersubMajorHead(int id, mastersubmajorheadModel model);
        Task<bool> DeleteMastersubMajorHead(int id);
        Task<SubMajorHead> GetMasterMastersubMajorHeadById(int id);
        Task<IEnumerable<MasterManegmentDTO>> GetMajorHeadcode();
        Task<int> CountMastersubmajorhead([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters);
    }
}
