using AutoMapper;
using master.BAL.IServices;
using master.DAL.Entity;
using master.DAL.IRepository;
using master.DAL.Repository;
using master.Dto;
using master.Models;
using MasterManegmentSystem.DAL.IRepository;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.Linq.Expressions;

namespace master.BAL.Services
{
    public class masterDDOService : ImasterDDOService
    {
        ImasterDDORepository _masterDDORepository;
        ImasterDetailHeadRepository _masterDetailHeadRepository;
        ImasterSubDetailHeadRepository _masterSubDetailHeadRepository;
        ImasterDepartmentRepository _masterDepartmentRepository;
        IMasterManegmentRepository _masterManegmentRepository;
        ImasterSCHEME_HEADRepository _masterSchemeHeadRepository;
        ImasterTreasuryRepository _masterTreasuryRepository;
        IMapper _mapper;
        public masterDDOService(IMapper mapper, ImasterDDORepository masterDDORepository,
            ImasterDetailHeadRepository masterDetailHeadRepository,
            ImasterSubDetailHeadRepository masterSubDetailHeadRepository,
            ImasterDepartmentRepository masterDepartmentRepository,
            IMasterManegmentRepository masterManegmentRepository,
            ImasterSCHEME_HEADRepository masterSchemeHeadRepository,
            ImasterTreasuryRepository masterTreasuryRepository
            )
        {
            _mapper = mapper;
            _masterDDORepository = masterDDORepository;
            _masterDetailHeadRepository = masterDetailHeadRepository;
            _masterSubDetailHeadRepository = masterSubDetailHeadRepository;
            _masterDepartmentRepository = masterDepartmentRepository;
            _masterManegmentRepository = masterManegmentRepository;
            _masterSchemeHeadRepository = masterSchemeHeadRepository;
            _masterTreasuryRepository = masterTreasuryRepository;

        }

        public async Task<IEnumerable<masterDDODto>> getmasterDDO(bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            string sortOrder = dynamicListQueryParameters.sortParameters?.Order.ToUpper() ?? "ASC";
            string sortField = dynamicListQueryParameters.sortParameters?.Field ?? "Id";
            IEnumerable<masterDDODto> StudentFormSajalResult = await _masterDDORepository.GetSelectedColumnByConditionAsync(entity=>entity.IsActive==isActive, entity => new masterDDODto
            {
                Id = entity.Id,
                TreasuryCode = entity.TreasuryCode,
                //TreasuryMstld = entity.TreasuryMstId,
                Code = entity.Code,
                Designation = entity.Designation,
                //DesignationMstld = entity.DesignationMstId,
                Address = entity.Address,
                Phone = entity.Phone,
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
                Code = entity.Code,
                Name = entity.Name
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

            toDeleteStudent.IsActive = false;
            
            _masterDDORepository.update(toDeleteStudent);
            _masterDDORepository.saveChangesManage();

            /*var toDeleteStudent = await _masterDDORepository.GetByIdAsync(id);
            if (toDeleteStudent != null)
            {
                _masterDDORepository.delete(toDeleteStudent);
                await _masterDDORepository.saveChangesAsync();
            }*/
            return true;
        }
        public async Task<bool> restoreMasterDdo(int id)
        {
            var toRestoreStudent = await _masterDDORepository.GetByIdAsync(id);

            toRestoreStudent.IsActive = true;

            _masterDDORepository.update(toRestoreStudent);
            _masterDDORepository.saveChangesManage();

            /*var toDeleteStudent = await _masterDDORepository.GetByIdAsync(id);
            if (toDeleteStudent != null)
            {
                _masterDDORepository.delete(toDeleteStudent);
                await _masterDDORepository.saveChangesAsync();
            }*/
            return true;
        }
        public async Task<masterDDODto> getStudentById(int id)
        {
            //return (await _masterDDORepository.GetByIdAsync(id));
            masterDDODto StudentFormSajalResult = await _masterDDORepository.GetSelectedIdColumnAsync(id, entity => new masterDDODto
            {
                Id = entity.Id,
                TreasuryCode = entity.TreasuryCode,
                //TreasuryMstld = entity.TreasuryMstId,
                Code = entity.Code,
                Designation = entity.Designation,
                //DesignationMstld = entity.DesignationMstId,
                Address = entity.Address,
                Phone = entity.Phone
            });
            return StudentFormSajalResult;
        }
        /*public async Task<List<Ddo>> getStudentsByName(String name)
        {
            return (await _masterDDORepository.GetStudentByName(name));
        }*/

        /*public async int CountWithCondition(List<FilterParameter> dynamicFilters)
        {

        }*/

        public async Task<int> CountMasterDDO(bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            //Expression<Func<Ddo, bool>> condition = d => true; // Default condition if no specific condition is required
            return _masterDDORepository.CountWithCondition(entity => entity.IsActive == isActive, dynamicListQueryParameters.filterParameters);
        }
        public async Task<AllMasterDTO> CountAllMaster()
        {
            AllMasterDTO allMasterCount = new AllMasterDTO
            {
                TotalActiveDdo = _masterDDORepository.CountWithCondition(entity => entity.IsActive == true),
                TotalInactiveDdo = _masterDDORepository.CountWithCondition(entity => entity.IsActive == false),

                TotalActiveDetailHead = _masterDetailHeadRepository.CountWithCondition(entity => entity.IsActive == true),
                TotalInactiveDetailHead = _masterDetailHeadRepository.CountWithCondition(entity => entity.IsActive == false),

                TotalActiveSubDetailHead = _masterSubDetailHeadRepository.CountWithCondition(entity => entity.IsActive == true),
                TotalInactiveSubDetailHead = _masterSubDetailHeadRepository.CountWithCondition(entity => entity.IsActive == false),

                TotalActiveDepartment = _masterDepartmentRepository.CountWithCondition(entity => entity.IsActive == true),
                TotalInactiveDepartment = _masterDepartmentRepository.CountWithCondition(entity => entity.IsActive == false),

                TotalActiveMajorHead = _masterManegmentRepository.CountWithCondition(entity => entity.IsActive == true),
                TotalInactiveMajorHead = _masterManegmentRepository.CountWithCondition(entity => entity.IsActive == false),

                TotalActiveSchemeHead = _masterSchemeHeadRepository.CountWithCondition(entity => entity.IsActive == true),
                TotalInactiveSchemeHead = _masterSchemeHeadRepository.CountWithCondition(entity => entity.IsActive == false),

                TotalActiveTreasury = _masterTreasuryRepository.CountWithCondition(entity => entity.IsActive == true),
                TotalInactiveTreasury = _masterTreasuryRepository.CountWithCondition(entity => entity.IsActive == false),
            };

            return allMasterCount;
        }
    }
}
