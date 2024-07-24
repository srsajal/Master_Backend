using AutoMapper;
using master.BAL.IServices;
using master.DAL.Entity;
using master.DAL.IRepository;
using master.DAL.Repository;
using master.Dto;
using master.Models;
using System.Linq.Expressions;

namespace master.BAL.Services
{
    public class masterMinorHeadService : ImasterMinorHeadService
    {
        ImastersubmajorheadRepository _mastersubmajorheadRepository;
        ImasterMinorHeadRepository _masterMinorHeadRepository;
        IMapper _mapper;
        public masterMinorHeadService(IMapper mapper, ImasterMinorHeadRepository masterMinorHeadRepository,ImastersubmajorheadRepository mastersubmajorheadRepository)
        {
            _mapper = mapper;
            _masterMinorHeadRepository = masterMinorHeadRepository;
            _mastersubmajorheadRepository = mastersubmajorheadRepository;
        }   
        public async Task<IEnumerable<masterMinorHeadDto>> getmasterMinorHead(bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            string sortOrder = dynamicListQueryParameters.sortParameters?.Order.ToUpper() ?? "DESC";
            string sortField = dynamicListQueryParameters.sortParameters?.Field ?? "Id";
            IEnumerable<masterMinorHeadDto> masterminor = await _masterMinorHeadRepository.GetSelectedColumnByConditionAsync(entity => entity.IsActive == isActive, entity => new masterMinorHeadDto
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                SubMajorId = entity.SubMajorId,
            },
            dynamicListQueryParameters.PageIndex,
            dynamicListQueryParameters.PageSize,
            dynamicListQueryParameters.filterParameters,
            sortField,
            sortOrder

            );
            return masterminor;

        }

       public async Task<IEnumerable<SubMajorHeadToMinorHeadDTO>> getSubMajorHeadCode()
        {
            IEnumerable<SubMajorHeadToMinorHeadDTO> StudentFormSajalResult = await _mastersubmajorheadRepository.GetSelectedColumnAsync(entity => new SubMajorHeadToMinorHeadDTO
            {
                Code = entity.Code,
                Name = entity.Name
            });
            return StudentFormSajalResult;
        }
        public async Task<int> addMinorHead(masterMinorHeadModel s)
        {
            MinorHead? newMinorHead = new MinorHead();
            newMinorHead = _mapper.Map<MinorHead>(s);
            _masterMinorHeadRepository.add(newMinorHead);
            _masterMinorHeadRepository.saveChangesManage();
            return newMinorHead.Id;

        }
        public async Task<bool> updateMinorHead(int id, masterMinorHeadModel s)
        {
            var updatedMinorHead = await _masterMinorHeadRepository.GetByIdAsync(id);

            //repository.Detach(updatedstudent);
            //updatedstudent.Id = id;
            //0updatedstudent = _mapper.Map<StudentFormSajal>(s);
            /*updatedstudent = _mapper.Map(s, updatedstudent);*/
            //updatedstudent.Id = id;
            /*updatedstudent.CreatedAt = DateTime.Now;*/

            updatedMinorHead.Code = s.Code;
            updatedMinorHead.Name = s.Name;
            updatedMinorHead.SubMajorId = s.SubMajorId;


            _masterMinorHeadRepository.update(updatedMinorHead);
            _masterMinorHeadRepository.saveChangesManage();

            return true;
        }
        public async Task<bool> deleteMinorHead(int id)
        {
            var toDeleteMinorHead = await _masterMinorHeadRepository.GetByIdAsync(id);
            if (toDeleteMinorHead != null)
            {
                _masterMinorHeadRepository.delete(toDeleteMinorHead);
                await _masterMinorHeadRepository.saveChangesAsync();
            }
            return true;
        }
        public async Task<MinorHead> getMinorHeadById(int id)
        {
            return (await _masterMinorHeadRepository.GetByIdAsync(id));
        }
        /*public async Task<List<Ddo>> getStudentsByName(String name)
        {
            return (await _masterDDORepository.GetStudentByName(name));
        }*/

        /*public async int CountWithCondition(List<FilterParameter> dynamicFilters)
        {

        }*/

  
        public async Task<int> CountMasterMinorHead(bool IsActive,DynamicListQueryParameters dynamicListQueryParameters)
        {
            return _masterMinorHeadRepository.CountWithCondition(entity=> entity.IsActive == IsActive, dynamicListQueryParameters.filterParameters);
        }

       
    }
}
