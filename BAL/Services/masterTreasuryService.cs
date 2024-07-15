using AutoMapper;
using master.BAL.IServices;
using master.DAL.Entity;
using master.DAL.IRepository;
using master.Dto;
using master.Models;
using System.Linq.Expressions;

namespace master.BAL.Services
{
    public class masterTreasuryService : ImasterTreasuryService
    {

        ImasterTreasuryRepository _masterTreasuryRepository;
        IMapper _mapper;
        public masterTreasuryService(IMapper mapper, ImasterTreasuryRepository masterTreasuryRepository)
        {
            _mapper = mapper;
            _masterTreasuryRepository = masterTreasuryRepository;
        }

        public async Task<IEnumerable<masterTresuryDTOs>> getmasterTreasury(DynamicListQueryParameters dynamicListQueryParameters)
        {
            try
            {
                string sortOrder = dynamicListQueryParameters.sortParameters?.Order.ToUpper() ?? "ASC";
                string sortField = dynamicListQueryParameters.sortParameters?.Field ?? "Id";
                IEnumerable<masterTresuryDTOs> StudentFormSajalResult = await _masterTreasuryRepository.GetSelectedColumnByConditionAsync(entity => new masterTresuryDTOs
                {
                    Id = entity.Id,
                    DistrictName = entity.DistrictName,
                    DistrictCode = entity.DistrictCode,
                    Code = entity.Code,
                    Name = entity.Name
                   
                },
                dynamicListQueryParameters.PageIndex,
                dynamicListQueryParameters.PageSize,
                dynamicListQueryParameters.filterParameters,
                sortField,
                sortOrder

                );
                return StudentFormSajalResult;
            }
            catch
            {
                throw;
            }
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
        public async Task<int> addStudent(masterTreasuryModel s)
        {
            try
            {
                Treasury? newTreasury = new Treasury();
                newTreasury = _mapper.Map<Treasury>(s);
                _masterTreasuryRepository.add(newTreasury);
                _masterTreasuryRepository.saveChangesManage();


                return newTreasury.Id;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> updateStudent(short id, masterTreasuryModel s)
        {
            var updatedstudent = await _masterTreasuryRepository.GetByIdAsync(id);

            //repository.Detach(updatedstudent);
            //updatedstudent.Id = id;
            //0updatedstudent = _mapper.Map<StudentFormSajal>(s);
            /*updatedstudent = _mapper.Map(s, updatedstudent);*/
            //updatedstudent.Id = id;
            /*updatedstudent.CreatedAt = DateTime.Now;*/

            updatedstudent.DistrictName = s.DistrictName;
            updatedstudent.DistrictCode = s.DistrictCode;
            updatedstudent.Code = s.Code;
            updatedstudent.Name = s.Name;


            _masterTreasuryRepository.update(updatedstudent);
            _masterTreasuryRepository.saveChangesManage();

            return true;
        }
        public async Task<bool> deleteStudent(short id)
        {
            var toDeleteStudent = await _masterTreasuryRepository.GetByIdAsync(id);
            if (toDeleteStudent != null)
            {
                _masterTreasuryRepository.delete(toDeleteStudent);
                await _masterTreasuryRepository.saveChangesAsync();
            }
            return true;
        }
        public async Task<Treasury> getStudentById(short id)
        {
            return (await _masterTreasuryRepository.GetByIdAsync(id));
        }
        /*public async Task<List<Ddo>> getStudentsByName(String name)
        {
            return (await _masterDDORepository.GetStudentByName(name));
        }*/

        /*public async int CountWithCondition(List<FilterParameter> dynamicFilters)
        {

        }*/

        public async Task<int> CountMasterTreasury(DynamicListQueryParameters dynamicListQueryParameters)
        {
            Expression<Func<Treasury, bool>> condition = d => true; // Default condition if no specific condition is required
            return _masterTreasuryRepository.CountWithCondition(condition, dynamicListQueryParameters.filterParameters);
        }
    }
}
