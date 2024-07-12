using AutoMapper;
using master.BAL.IServices;
using master.DAL.Entity;
using master.DAL.IRepository;
using master.DAL.Repository;
using master.Dto;
using master.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.Linq.Expressions;

namespace master.BAL.Services
{
    public class masterDDOService : ImasterDDOService
    {
        ImasterDDORepository _masterDDORepository;
        ImasterTreasuryRepository _masterTreasuryRepository;
        IMapper _mapper;
        public masterDDOService(IMapper mapper, ImasterDDORepository masterDDORepository, ImasterTreasuryRepository masterTreasuryRepository)
        {
            _mapper = mapper;
            _masterDDORepository = masterDDORepository;
            _masterTreasuryRepository = masterTreasuryRepository;
        }

        public async Task<IEnumerable<masterDDODto>> getmasterDDO(DynamicListQueryParameters dynamicListQueryParameters)
        {
            string sortOrder = dynamicListQueryParameters.sortParameters?.Order.ToUpper() ?? "ASC";
            string sortField = dynamicListQueryParameters.sortParameters?.Field ?? "Id";
            IEnumerable<masterDDODto> StudentFormSajalResult = await _masterDDORepository.GetSelectedColumnByConditionAsync(entity => new masterDDODto
            {
                Id = entity.Id,
                TreasuryCode = entity.TreasuryCode,
                TreasuryMstld = entity.TreasuryMstId,
                Code = entity.Code,
                Designation = entity.Designation,
                DesignationMstld = entity.DesignationMstId,
                Address = entity.Address,
                Phone = entity.Phone
            },
            dynamicListQueryParameters.PageIndex,
            dynamicListQueryParameters.PageSize,
            dynamicListQueryParameters.filterParameters,
            sortField,
            sortOrder

            );
            return StudentFormSajalResult;
        }
        public async Task<IEnumerable<DdoCodeTresuryDTO>> getTreasuryCode()
        {
            IEnumerable<DdoCodeTresuryDTO> StudentFormSajalResult = await _masterTreasuryRepository.GetSelectedColumnAsync(entity => new DdoCodeTresuryDTO
            {
                Code = entity.Code
            });
            return StudentFormSajalResult;
        }
        /*public async Task<List<Ddo>> getstudents()
        {
            try
            {
                return (await _masterDDORepository.get()).ToList();
            }
            catch
            {
                throw;
            }
        }*/

        //public async Task<List<DdoCodeTresuryDTO> getTreasuryCodes()
        //{

        //}

        public async Task<int> addStudent(masterDDOModel s)
        {
            Ddo? newDdo = new Ddo();
            newDdo = _mapper.Map<Ddo>(s);
            _masterDDORepository.add(newDdo);
            _masterDDORepository.saveChangesManage();


            return newDdo.Id;
           

        }
        public async Task<bool> updateStudent(int id, masterDDOModel s)
        {
            var updatedstudent = await _masterDDORepository.GetByIdAsync(id);

            //repository.Detach(updatedstudent);
            //updatedstudent.Id = id;
            //0updatedstudent = _mapper.Map<StudentFormSajal>(s);
            /*updatedstudent = _mapper.Map(s, updatedstudent);*/
            //updatedstudent.Id = id;
            /*updatedstudent.CreatedAt = DateTime.Now;*/

            updatedstudent.TreasuryCode = s.TreasuryCode;
            updatedstudent.TreasuryMstId = s.TreasuryMstld;
            updatedstudent.Code = s.Code;
            updatedstudent.Designation = s.Designation;
            updatedstudent.DesignationMstId = s.DesignationMstld;
            updatedstudent.Address = s.Address;
            updatedstudent.Phone = s.Phone;


            _masterDDORepository.update(updatedstudent);
            _masterDDORepository.saveChangesManage();

            return true;
        }
        public async Task<bool> deleteStudent(int id)
        {
            var toDeleteStudent = await _masterDDORepository.GetByIdAsync(id);
            if (toDeleteStudent != null)
            {
                _masterDDORepository.delete(toDeleteStudent);
                await _masterDDORepository.saveChangesAsync();
            }
            return true;
        }
        public async Task<Ddo> getStudentById(int id)
        {
            return (await _masterDDORepository.GetByIdAsync(id));
        }
        /*public async Task<List<Ddo>> getStudentsByName(String name)
        {
            return (await _masterDDORepository.GetStudentByName(name));
        }*/

        /*public async int CountWithCondition(List<FilterParameter> dynamicFilters)
        {

        }*/

        public async Task<int> CountMasterDDO(DynamicListQueryParameters dynamicListQueryParameters)
        {
            Expression<Func<Ddo, bool>> condition = d => true; // Default condition if no specific condition is required
            return _masterDDORepository.CountWithCondition(condition, dynamicListQueryParameters.filterParameters);
        }
    }
}
