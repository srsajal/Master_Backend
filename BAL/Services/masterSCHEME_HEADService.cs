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
    public class masterSCHEME_HEADService : ImasterSCHEME_HEADService
    {

        ImasterSCHEME_HEADRepository _masterSCHEME_HEADRepository;
        IMapper _mapper;
        ImasterMinorHeadRepository _masterMinorHeadRepository;

        public masterSCHEME_HEADService(IMapper mapper, ImasterSCHEME_HEADRepository masterSCHEME_HEADRepository, ImasterMinorHeadRepository masterMinorHeadRepository)
        {
            _mapper = mapper;
            _masterSCHEME_HEADRepository = masterSCHEME_HEADRepository;
       _masterMinorHeadRepository = masterMinorHeadRepository;
        }

        public async Task<IEnumerable<masterSCHEME_HEADDto>> getmasterSCHEME_HEAD(bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
           
                string sortOrder = dynamicListQueryParameters.sortParameters?.Order.ToUpper() ?? "ASC";
                string sortField = dynamicListQueryParameters.sortParameters?.Field ?? "Id";
                IEnumerable<masterSCHEME_HEADDto> Result = await _masterSCHEME_HEADRepository.GetSelectedColumnByConditionAsync(entity => entity.IsActive == isActive, entity => new masterSCHEME_HEADDto
                {
                    Id = entity.Id,

                    Code = entity.Code,
                    DemandCode = entity.DemandCode,
                    Name = entity.Name,
                    MinorHeadId = entity.MinorHeadId,
                },
                dynamicListQueryParameters.PageIndex,
                dynamicListQueryParameters.PageSize,
                dynamicListQueryParameters.filterParameters,
                sortField,
                sortOrder

                );
                return Result;
          
        }
        public async Task<IEnumerable<SchemeMinorheadfromMINORHEADIdDTO>> getSchemeMinorheadfromMINORHEADId()
        {
            IEnumerable<SchemeMinorheadfromMINORHEADIdDTO> Result = await _masterMinorHeadRepository.GetSelectedColumnAsync(entity => new SchemeMinorheadfromMINORHEADIdDTO
            { 
                Id =entity.Id,
                Code = entity.Code,
                Name = entity.Name
            });
            return Result;
        }
        public async Task<int> addStudent(masterSCHEME_HEADModel s)
        {
            
                SchemeHead? newSchemeHead = new SchemeHead();
                newSchemeHead = _mapper.Map<SchemeHead>(s);
                _masterSCHEME_HEADRepository.add(newSchemeHead);
                _masterSCHEME_HEADRepository.saveChangesManage();


                return  newSchemeHead.Id;
          
        }
        public async Task<bool> updateStudent(int id, masterSCHEME_HEADModel s)
        {
            var updatedstudent = await _masterSCHEME_HEADRepository.GetByIdAsync(id);

            //repository.Detach(updatedstudent);
            //updatedstudent.Id = id;
            //0updatedstudent = _mapper.Map<StudentFormSajal>(s);
            /*updatedstudent = _mapper.Map(s, updatedstudent);*/
            //updatedstudent.Id = id;
            /*updatedstudent.CreatedAt = DateTime.Now;*/

            updatedstudent.DemandCode = s.DemandCode;
            updatedstudent.Code = s.Code;
            updatedstudent.Name = s.Name;
            updatedstudent.MinorHeadId = s.MinorHeadId;


            _masterSCHEME_HEADRepository.update(updatedstudent);
            _masterSCHEME_HEADRepository.saveChangesManage();

            return true;
        }
        public async Task<bool> deleteStudent(int id)
        {
            var toDeleteStudent = await _masterSCHEME_HEADRepository.GetByIdAsync(id);
            if (toDeleteStudent != null)
            {
                _masterSCHEME_HEADRepository.delete(toDeleteStudent);
                await _masterSCHEME_HEADRepository.saveChangesAsync();
            }
            return true;
        }
        public async Task<SchemeHead> getStudentById(int id)
        {
            return (await _masterSCHEME_HEADRepository.GetByIdAsync(id));
        }
        /*public async Task<List<Ddo>> getStudentsByName(String name)
        {
            return (await _masterDDORepository.GetStudentByName(name));
        }*/

        /*public async int CountWithCondition(List<FilterParameter> dynamicFilters)
        {

        }*/

        public async Task<int> CountMasterSCHEME_HEAD(DynamicListQueryParameters dynamicListQueryParameters)
        {
            Expression<Func<SchemeHead, bool>> condition = d => true; // Default condition if no specific condition is required
            return _masterSCHEME_HEADRepository.CountWithCondition(condition, dynamicListQueryParameters.filterParameters);
        }
    }
}

