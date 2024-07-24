using AutoMapper;
using master.DAL.Entity;
using master.Dto;
using MasterManegmentSystem.BAL.IServices;
using MasterManegmentSystem.DAL.IRepository;
using MasterManegmentSystem.Dto;
using MasterManegmentSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MasterManegmentSystem.BAL.Services
{
    public class MasterManegmentService : IMasterManegmentService
    {
        private readonly IMasterManegmentRepository _masterManegmentRepository;
        private readonly IMapper _mapper;

        public MasterManegmentService(IMapper mapper, IMasterManegmentRepository masterManegmentRepository)
        {
            _mapper = mapper;
            _masterManegmentRepository = masterManegmentRepository;
        }

        public async Task<IEnumerable<MasterManegmentDTO>> GetMastermajorhead(bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
                string sortOrder = dynamicListQueryParameters.sortParameters?.Order.ToUpper() ?? "ASC";
                string sortField = dynamicListQueryParameters.sortParameters?.Field ?? "Id";
                IEnumerable<MasterManegmentDTO> result = await _masterManegmentRepository.GetSelectedColumnByConditionAsync(entity => entity.IsActive == isActive,
                    entity => new MasterManegmentDTO
                    {
                        Id = entity.Id,
                        Code = entity.Code,
                        Name = entity.Name,
                    },
                    dynamicListQueryParameters.PageIndex,
                    dynamicListQueryParameters.PageSize,
                    dynamicListQueryParameters.filterParameters,
                    sortField,
                    sortOrder);
            
                return result;
        }

        public async Task<int> AddMasterMAJORHEAD(MasterManegmentModel model)
        {
            MajorHead newMajorHead = _mapper.Map<MajorHead>(model);
            newMajorHead.Id = Convert.ToInt32(newMajorHead.Code);
            _masterManegmentRepository.Add(newMajorHead);
            await _masterManegmentRepository.SaveChangesAsync();

            return newMajorHead.Id;
        }

        public async Task<bool> MasterMAJORHEADExistsByCode(string code)
        {
            return await _masterManegmentRepository.AnyAsync(m => m.Code == code);
        }

        public async Task<bool> MasterMAJORHEADExistsById(int id)
        {
            return await _masterManegmentRepository.AnyAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<MasterManegmentModel>> GetAllMasterMAJORHEADs()
        {
            var majorHeads = await _masterManegmentRepository.GetAllAsync<MajorHead>();
            return _mapper.Map<IEnumerable<MasterManegmentModel>>(majorHeads);
        }
        public async Task<bool> UpdateMastermajorhead(int id, MasterManegmentModel model)
        {
                MajorHead updatedStudent = await _masterManegmentRepository.GetByIdAsync(id);

                if (updatedStudent == null) return false;
            updatedStudent.Code = model.Code;
            updatedStudent.Name = model.Name;   


                _masterManegmentRepository.update(updatedStudent);
                await _masterManegmentRepository.saveChangesAsync();

                return true;
        }

        public async Task<bool> DeleteMastermajorhead(int  id)
        {
                MajorHead toDeleteStudent = await _masterManegmentRepository.GetByIdAsync(id);
                toDeleteStudent.IsActive = false;

                _masterManegmentRepository.update(toDeleteStudent);
                await _masterManegmentRepository.saveChangesAsync();

                return true;
        }
        public async Task<bool> restoreMasterMajorHead(int id)
        {
            var toRestoreStudent = await _masterManegmentRepository.GetByIdAsync(id);

            toRestoreStudent.IsActive = true;

            _masterManegmentRepository.update(toRestoreStudent);
            _masterManegmentRepository.saveChangesManage();
            return true;
        }



        public async Task<int> CountMasterMajorHead(bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            return _masterManegmentRepository.CountWithCondition(entity => entity.IsActive == isActive, dynamicListQueryParameters.filterParameters);
        }

        public Task<MajorHead> GetMastermajorheadById(int id)
        {
            return  _masterManegmentRepository.GetByIdAsync(id);
        }
       


    }
}
