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
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IEnumerable<mastersubmajorheadDTO>> GetMastersubmajorhead(bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            string sortOrder = dynamicListQueryParameters.sortParameters?.Order.ToUpper() ?? "ASC";
            string sortField = dynamicListQueryParameters.sortParameters?.Field ?? "Id";
            IEnumerable<mastersubmajorheadDTO> result = await _mastersubmajorheadRepository.GetSelectedColumnByConditionAsync(entity => entity.IsActive == isActive,
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
        public async Task<IEnumerable<MasterManegmentDTO>> GetMajorHeadcode()
        {
            IEnumerable<MasterManegmentDTO> StudentFormSajalResult = await _masterManegmentRepository.GetSelectedColumnAsync(entity => new MasterManegmentDTO
            { 
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name
            });
            return StudentFormSajalResult;
        }   

        public async Task<int> AddMasterSubmajorHead(mastersubmajorheadModel model)
        {
            SubMajorHead newSubMajorHead = _mapper.Map<SubMajorHead>(model);
            newSubMajorHead.Id = int.Parse(model.MajorHeadId.ToString() + model.Code);
            int numberOfRow = await _masterManegmentRepository.CountWithConditionAsync(x => x.Id == newSubMajorHead.Id);
            if (numberOfRow > 0)
            {
                return 0;
            }
            _mastersubmajorheadRepository.add(newSubMajorHead);
            _mastersubmajorheadRepository.saveChangesAsync();

            return newSubMajorHead.Id;
        }

        public async Task<bool> UpdateMastersubMajorHead(int id, mastersubmajorheadModel model)
        {
            SubMajorHead updatedStudent = await _mastersubmajorheadRepository.GetByIdAsync(id);

            if (updatedStudent == null) return false;
            updatedStudent.Code = model.Code;
            updatedStudent.Name = model.Name;   
            updatedStudent.MajorHeadId = model.MajorHeadId;



            _mastersubmajorheadRepository.update(updatedStudent);
            await _mastersubmajorheadRepository.saveChangesAsync();

            return true;
        }

     

        public async Task<bool> DeleteMastersubMajorHead(int id)
        {
            var toDeleteStudent = await _mastersubmajorheadRepository.GetByIdAsync(id);

            toDeleteStudent.IsActive = false;

            _mastersubmajorheadRepository.update(toDeleteStudent);
            _mastersubmajorheadRepository.saveChangesManage();

        
            return true;

        }

        public async Task<bool> restoreMastersubMajorHead(int id)
        {
            var toRestoreStudent = await _mastersubmajorheadRepository.GetByIdAsync(id);

            toRestoreStudent.IsActive = true;

            _mastersubmajorheadRepository.update(toRestoreStudent);
            _mastersubmajorheadRepository.saveChangesManage();

      
            return true;
        }

        public async Task<int> CountMastersubmajorhead([FromQuery] bool IsActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            return _mastersubmajorheadRepository.CountWithCondition(entity => entity.IsActive == IsActive, dynamicListQueryParameters.filterParameters);
        }

        public Task<SubMajorHead> GetMasterMastersubMajorHeadById(int id)
        {
            return _mastersubmajorheadRepository.GetByIdAsync(id);
        }

        
    
    }
}
