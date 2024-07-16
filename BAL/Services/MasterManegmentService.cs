using AutoMapper;
using master.DAL.Entity;
using master.Dto;
using MasterManegmentSystem.BAL.IServices;
using MasterManegmentSystem.DAL.IRepository;
using MasterManegmentSystem.Dto;
using MasterManegmentSystem.Models;
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

        public async Task<IEnumerable<MasterManegmentDTO>> GetMasterSubmajorhead(DynamicListQueryParameters dynamicListQueryParameters)
        {
            try
            {
                string sortOrder = dynamicListQueryParameters.sortParameters?.Order.ToUpper() ?? "ASC";
                string sortField = dynamicListQueryParameters.sortParameters?.Field ?? "Id";
                IEnumerable<MasterManegmentDTO> result = await _masterManegmentRepository.GetSelectedColumnByConditionAsync(
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
            catch (Exception ex)
            {
                // Log the exception
                throw;
            }
        }

       public async Task<int> AddMasterSubmajorhead(MasterManegmentModel model)
        {
            try
            {
                MajorHead newMajorHead = _mapper.Map<MajorHead>(model);
               /* await _masterManegmentRepository.add(newMajorHead);*/
                await _masterManegmentRepository.saveChangesAsync();

                return newMajorHead.Id;
            }
            catch (Exception ex)
            {
                // Log the exception
                throw;
            }
        }

        public async Task<bool> UpdateMasterSubmajorhead(short id, MasterManegmentModel model)
        {
            try
            {
                MajorHead updatedStudent = await _masterManegmentRepository.GetByIdAsync(id);

                if (updatedStudent == null) return false;

                _mapper.Map(model, updatedStudent);

                _masterManegmentRepository.update(updatedStudent);
                await _masterManegmentRepository.saveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                throw;
            }
        }

        public async Task<bool> DeleteMasterSubmajorhead(short id)
        {
            try
            {
                MajorHead student = await _masterManegmentRepository.GetByIdAsync(id);
                if (student == null) return false;

                _masterManegmentRepository.delete(student);
                await _masterManegmentRepository.saveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                throw;
            }
        }

       

        public async Task<int> CountMasterDDO(DynamicListQueryParameters dynamicListQueryParameters)
        {
            Expression<Func<MajorHead, bool>> condition = d => true; // Default condition if no specific condition is required
            return _masterManegmentRepository.CountWithCondition(condition, dynamicListQueryParameters.filterParameters);
        }

        public Task<MajorHead> GetMasterSubmajorheadById(short id)
        {
            return  _masterManegmentRepository.GetByIdAsync(id);
        }

        
    }
}
