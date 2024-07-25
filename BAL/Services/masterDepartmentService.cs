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
    public class masterDepartmentService : ImasterDepartmentService
    {
        ImasterDepartmentRepository _masterDepartmentRepository;
        IMapper _mapper;
        public masterDepartmentService(IMapper mapper, ImasterDepartmentRepository masterDepartmentRepository)
        {
            _mapper = mapper;
            _masterDepartmentRepository = masterDepartmentRepository;
        }
        public async Task<IEnumerable<masterDepartmentDto>> getmasterDepartment(bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            string sortOrder = dynamicListQueryParameters.sortParameters?.Order.ToUpper() ?? "DESC";
            string sortField = dynamicListQueryParameters.sortParameters?.Field ?? "Id";
            IEnumerable<masterDepartmentDto> masterdept = await _masterDepartmentRepository.GetSelectedColumnByConditionAsync(entity => entity.IsActive == isActive, entity => new masterDepartmentDto
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                DemandCode = entity.DemandCode,
                Address = entity.Address,
                PinCode = entity.PinCode,
                PhoneNumber = entity.PhoneNumber,
                MobileNumber = entity.MobileNumber,
                Email = entity.Email
            },
            dynamicListQueryParameters.PageIndex,
            dynamicListQueryParameters.PageSize,
            dynamicListQueryParameters.filterParameters,
            sortField,
            sortOrder

            );
            return masterdept;
            
        }
       
        public async Task<int> addDepartment(masterDepartmentModel s)
        {
            Department? newDepartment = new Department();
            newDepartment = _mapper.Map<Department>(s);
            _masterDepartmentRepository.add(newDepartment);
            _masterDepartmentRepository.saveChangesManage();
            return newDepartment.Id;
            
        }


        public async Task<bool> masterDepartmentExistsByDemandCode(string DemandCode)
        {
            return await _masterDepartmentRepository.AnyAsync(m => m.DemandCode == DemandCode);
        }

        public async Task<bool> masterDepartmentExistsById(short id)
        {
            return await _masterDepartmentRepository.AnyAsync(m => m.Id == id);
        }
        public async Task<bool> updateDepartment(short id, masterDepartmentModel s)
        {
            var updatedDepartment = await _masterDepartmentRepository.GetByIdAsync(id);

            //repository.Detach(updatedstudent);
            //updatedstudent.Id = id;
            //0updatedstudent = _mapper.Map<StudentFormSajal>(s);
            /*updatedstudent = _mapper.Map(s, updatedstudent);*/
            //updatedstudent.Id = id;
            /*updatedstudent.CreatedAt = DateTime.Now;*/

            updatedDepartment.Code = s.Code;
            updatedDepartment.Name = s.Name;
            updatedDepartment.DemandCode = s.DemandCode;
            updatedDepartment.Address = s.Address;
            updatedDepartment.PinCode = s.PinCode;
            updatedDepartment.PhoneNumber = s.PhoneNumber;
            updatedDepartment.MobileNumber = s.MobileNumber;
            updatedDepartment.Email = s.Email;


            _masterDepartmentRepository.update(updatedDepartment);
            _masterDepartmentRepository.saveChangesManage();

            return true;
        }
        public async Task<bool> deleteDepartment(short id)
        {
            var toDeleteDepartment = await _masterDepartmentRepository.GetByIdAsync(id);
            toDeleteDepartment.IsActive = false;
                _masterDepartmentRepository.update(toDeleteDepartment);
                await _masterDepartmentRepository.saveChangesAsync();
            return true;
        }
        public async Task<bool> restoreMasterDepartment(short id)
        {
            var toRestoreStudent = await _masterDepartmentRepository.GetByIdAsync(id);

            toRestoreStudent.IsActive = true;

            _masterDepartmentRepository.update(toRestoreStudent);
            _masterDepartmentRepository.saveChangesManage();
            return true;
        }
        public async Task<Department> getDepartmentById(short id)
        {
            return (await _masterDepartmentRepository.GetByIdAsync(id));
        }
        /*public async Task<List<Ddo>> getStudentsByName(String name)
        {
            return (await _masterDDORepository.GetStudentByName(name));
        }*/

        /*public async int CountWithCondition(List<FilterParameter> dynamicFilters)
        {

        }*/

        public async Task<int> CountMasterDepartment(bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            return _masterDepartmentRepository.CountWithCondition(entity => entity.IsActive == isActive, dynamicListQueryParameters.filterParameters);
        }
    }
}
