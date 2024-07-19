using AutoMapper;
using master.BAL.IServices;
using master.DAL.Entity;
using master.DAL.IRepository;
using master.DAL.Repository;
using master.Dto;
using master.Models;
using MasterManegmentSystem.BAL.IServices;
using MasterManegmentSystem.DAL.IRepository;
using MasterManegmentSystem.Dto;
using MasterManegmentSystem.Models;
using System.Linq.Expressions;

namespace master.BAL.Services
{
    public class mastersubmajorheadService : ImastersubmajorheadService
    {
        private readonly IMasterManegmentRepository _masterManegmentRepository;
        private readonly ImastersubmajorheadRepository _mastersubmajorheadRepository;
        private readonly IMapper _mapper;

        public mastersubmajorheadService(IMapper mapper,  ImastersubmajorheadRepository imastersubmajorheadRepository, IMasterManegmentRepository masterManegmentRepository)
        {
            _mapper = mapper;
            _mastersubmajorheadRepository = imastersubmajorheadRepository;
            _masterManegmentRepository = masterManegmentRepository;
        }

        public async Task<IEnumerable<mastersubmajorheadDTO>> GetMastersubmajorhead(DynamicListQueryParameters dynamicListQueryParameters)
        {
            string sortOrder = dynamicListQueryParameters.sortParameters?.Order.ToUpper() ?? "ASC";
            string sortField = dynamicListQueryParameters.sortParameters?.Field ?? "Id";
            IEnumerable<mastersubmajorheadDTO> result = await _mastersubmajorheadRepository.GetSelectedColumnByConditionAsync(
                entity => new mastersubmajorheadDTO
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Name = entity.Name,
                    MajorHeadId = entity.MajorHeadId,

                },
                dynamicListQueryParameters.PageIndex,
                dynamicListQueryParameters.PageSize,
                dynamicListQueryParameters.filterParameters,
                sortField,
                sortOrder);

            return result;
        }
        public async Task<IEnumerable<mastersubmajorheadDTO>> GetMajorHeadcode()
        {
            IEnumerable<mastersubmajorheadDTO> StudentFormSajalResult = await _masterManegmentRepository.GetSelectedColumnAsync(entity => new mastersubmajorheadDTO { 
                Code = entity.Code,
                Name = entity.Name
            });
            return StudentFormSajalResult;
        }   

        public async Task<int> AddMasterSubmajorHead(mastersubmajorheadModel model)
        {
            SubMajorHead newSubMajorHead = _mapper.Map<SubMajorHead>(model);
            _mastersubmajorheadRepository.add(newSubMajorHead);
            _mastersubmajorheadRepository.saveChangesAsync();

            return newSubMajorHead.Id;
        }

        public async Task<bool> UpdateMastersubMajorHead(int id, mastersubmajorheadModel model)
        {
            SubMajorHead updatedStudent = await _mastersubmajorheadRepository.GetByIdAsync(id);

            if (updatedStudent == null) return false;

            _mapper.Map(model, updatedStudent);

            _mastersubmajorheadRepository.update(updatedStudent);
            await _mastersubmajorheadRepository.saveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteMastersubMajorHead(int id)
        {
            SubMajorHead student = await _mastersubmajorheadRepository.GetByIdAsync(id);
            if (student == null) return false;

            _mastersubmajorheadRepository.delete(student);
            await _mastersubmajorheadRepository.saveChangesAsync();

            return true;
        }



        public async Task<int> CountMastersubmajorhead(DynamicListQueryParameters dynamicListQueryParameters)
        {
            Expression<Func<SubMajorHead, bool>> condition = d => true; // Default condition if no specific condition is required
            return _mastersubmajorheadRepository.CountWithCondition(condition, dynamicListQueryParameters.filterParameters);
        }

        public Task<SubMajorHead> GetMasterMastersubMajorHeadById(int id)
        {
            return _mastersubmajorheadRepository.GetByIdAsync(id);
        }

        
    
    }
}
