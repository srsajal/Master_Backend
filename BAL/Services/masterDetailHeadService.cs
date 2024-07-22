using AutoMapper;
using master.BAL.IServices;
using master.DAL.Entity;
using master.DAL.IRepository;
using master.DAL.Repository;
using master.Dto;
using master.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace master.BAL.Services
{
    public class masterDetailHeadService : ImasterDetailHeadService
    {
        ImasterDetailHeadRepository _masterDetailHeadRepository;
        IMapper _mapper;
        public masterDetailHeadService(ImasterDetailHeadRepository masterDetailHeadRepository, IMapper mapper)
        {
            _masterDetailHeadRepository = masterDetailHeadRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<masterDetailHeadDto>> getDetailHead(bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            string sortOrder = dynamicListQueryParameters.sortParameters?.Order.ToUpper() ?? "ASC";
            string sortField = dynamicListQueryParameters.sortParameters?.Field ?? "Id";
            IEnumerable<masterDetailHeadDto> StudentFormSajalResult = await _masterDetailHeadRepository.GetSelectedColumnByConditionAsync(entity => entity.IsActive == isActive, entity => new masterDetailHeadDto
            {
                Id = entity.Id,
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
       /* public async Task<IEnumerable<DdoCodeTresuryDTO>> getTreasuryCode()
        {
            IEnumerable<DdoCodeTresuryDTO> StudentFormSajalResult = await _masterTreasuryRepository.GetSelectedColumnAsync(entity => new DdoCodeTresuryDTO
            {
                Code = entity.Code,
                Name = entity.Name
            });
            return StudentFormSajalResult;
        }*/
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

        public async Task<int> addDetailHead(masterDetailHeadModel s)
        {
            DetailHead? newDetailHead = new DetailHead();
            newDetailHead = _mapper.Map<DetailHead>(s);
            _masterDetailHeadRepository.add(newDetailHead);
            _masterDetailHeadRepository.saveChangesManage();
            return newDetailHead.Id;


        }
        public async Task<bool> updateDetailHead(short id, masterDetailHeadModel s)
        {
            var updatedDetailHead = await _masterDetailHeadRepository.GetByIdAsync(id);

            updatedDetailHead.Name = s.Name;
            updatedDetailHead.Code = s.Code;

            _masterDetailHeadRepository.update(updatedDetailHead);
            _masterDetailHeadRepository.saveChangesManage();

            return true;
        }
        public async Task<bool> deleteDetailHead(short id)
        {

            var toDeleteStudent = await _masterDetailHeadRepository.GetByIdAsync(id);

            toDeleteStudent.IsActive = false;
            _masterDetailHeadRepository.update(toDeleteStudent);
            await _masterDetailHeadRepository.saveChangesAsync();
            return true;
        }
        public async Task<masterDetailHeadDto> getDetailHeadById(short id)
        {
            //return (await _masterDDORepository.GetByIdAsync(id));
            masterDetailHeadDto StudentFormSajalResult = await _masterDetailHeadRepository.GetSelectedIdColumnAsync(id, entity => new masterDetailHeadDto
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name
                //Designation = entity.Designation,
                //DesignationMstld = entity.DesignationMstId,
                //Address = entity.Address,
                //Phone = entity.Phone
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

        public async Task<int> CountDetailHead([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            return _masterDetailHeadRepository.CountWithCondition(entity => entity.IsActive == isActive, dynamicListQueryParameters.filterParameters);
        }
    }
}
