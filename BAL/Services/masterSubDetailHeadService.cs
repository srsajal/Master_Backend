﻿using AutoMapper;
using master.BAL.IServices;
using master.DAL.Entity;
using master.DAL.IRepository;
using master.DAL.Repository;
using master.Dto;
using master.Models;
using System.Linq.Expressions;

namespace master.BAL.Services
{
    public class masterSubDetailHeadService : ImasterSubDetailHeadService
    {
        ImasterSubDetailHeadRepository _masterSubDetailHeadRepository;
        ImasterDetailHeadRepository _masterDetailHeadRepository;
        IMapper _mapper;
        public masterSubDetailHeadService(ImasterSubDetailHeadRepository masterSubDetailHeadRepository, IMapper mapper, ImasterDetailHeadRepository masterDetailHeadRepository)
        {
            _masterSubDetailHeadRepository = masterSubDetailHeadRepository;
            _mapper = mapper;
            _masterDetailHeadRepository = masterDetailHeadRepository;
        }
        public async Task<IEnumerable<masterSubDetailHeadDto>> getSubDetailHead(bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            string sortOrder = dynamicListQueryParameters.sortParameters?.Order.ToUpper() ?? "ASC";
            string sortField = dynamicListQueryParameters.sortParameters?.Field ?? "Id";
            IEnumerable<masterSubDetailHeadDto> StudentFormSajalResult = await _masterSubDetailHeadRepository.GetSelectedColumnByConditionAsync(entity => entity.IsActive == isActive, entity => new masterSubDetailHeadDto
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                DetailHeadId = entity.DetailHeadId,
            },
            dynamicListQueryParameters.PageIndex,
            dynamicListQueryParameters.PageSize,
            dynamicListQueryParameters.filterParameters,
            sortField,
            sortOrder

            );
            return StudentFormSajalResult;
        }
        public async Task<IEnumerable<DetailToSubDetailCodeDTO>> getDetailCode()
        {
            IEnumerable<DetailToSubDetailCodeDTO> StudentFormSajalResult = await _masterDetailHeadRepository.GetSelectedColumnAsync(entity => new DetailToSubDetailCodeDTO
            {
                Id = entity.Id,
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

        public async Task<int> addSubDetailHead(masterSubDetailHeadModel s)
        {
            SubDetailHead? newSubDetailHead = new SubDetailHead();
            newSubDetailHead = _mapper.Map<SubDetailHead>(s);
            _masterSubDetailHeadRepository.add(newSubDetailHead);
            _masterSubDetailHeadRepository.saveChangesManage();
            return newSubDetailHead.Id;


        }
        public async Task<bool> updateSubDetailHead(short id, masterSubDetailHeadModel s)
        {
            var updatedDetailHead = await _masterSubDetailHeadRepository.GetByIdAsync(id);

            updatedDetailHead.Name = s.Name;
            updatedDetailHead.Code = s.Code;
            updatedDetailHead.DetailHeadId = s.DetailHeadId;

            _masterSubDetailHeadRepository.update(updatedDetailHead);
            _masterSubDetailHeadRepository.saveChangesManage();

            return true;
        }
        public async Task<bool> deleteSubDetailHead(short id)
        {
            var toDeleteStudent = await _masterSubDetailHeadRepository.GetByIdAsync(id);

            toDeleteStudent.IsActive = false;
            _masterSubDetailHeadRepository.update(toDeleteStudent);
            await _masterSubDetailHeadRepository.saveChangesAsync();
            return true;
        }
        public async Task<bool> restoreMasterSubDetailHead(short id)
        {
            var toRestoreStudent = await _masterSubDetailHeadRepository.GetByIdAsync(id);

            toRestoreStudent.IsActive = true;

            _masterSubDetailHeadRepository.update(toRestoreStudent);
            _masterSubDetailHeadRepository.saveChangesManage();
            return true;
        }
        public async Task<masterSubDetailHeadDto> getSubDetailHeadById(short id)
        {
            //return (await _masterDDORepository.GetByIdAsync(id));
            masterSubDetailHeadDto StudentFormSajalResult = await _masterSubDetailHeadRepository.GetSelectedIdColumnAsync(id, entity => new masterSubDetailHeadDto
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                DetailHeadId = entity.DetailHeadId,
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

        public async Task<int> CountSubDetailHead(bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            return _masterSubDetailHeadRepository.CountWithCondition(entity => entity.IsActive == isActive,  dynamicListQueryParameters.filterParameters);
        }
    }
}
