﻿
using master.BAL.IServices;
using master.DAL.Entity;
using master.Dto;
using master.Models;
using masterDDO.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using masterDDO;
using masterDDO.Enums;


namespace master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class masterDDOController : ControllerBase
    {
        ImasterDDOService _imasterDDOService;

        public masterDDOController(ImasterDDOService imasterDDOService)
        {
            _imasterDDOService = imasterDDOService;
        }


       /* [HttpGet("GetMasterDdo")]
        public async Task<IActionResult> GetStudent()
        {
            try
            {
                var students = await _imasterDDOService.getstudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }*/

        [HttpPost("GetMasterDdo")]
        public async Task<ActionResult<ServiceResponse<DynamicListResult<IEnumerable<masterDDODto>>>>> GetStudent(DynamicListQueryParameters dynamicListQueryParameters)
        {
            ServiceResponse<DynamicListResult<IEnumerable<masterDDODto>>> response = new();
            try
            {
                DynamicListResult<IEnumerable<masterDDODto>> result = new DynamicListResult<IEnumerable<masterDDODto>>
                {
                    Headers = new List<ListHeader>
                {
                    new ListHeader
                    {
                        Name="Treasury Code",
                        DataType="text",
                        FieldName ="treasuryCode",
                        FilterField ="TreasuryCode",
                        IsFilterable=true,
                        IsSortable=true,
                    },
                    new ListHeader
                    {
                        Name="Code",
                        DataType="text",
                        FieldName ="code",
                        FilterField ="Code",
                        IsFilterable=true,
                        IsSortable=true,
                    },
                    new ListHeader
                    {
                        Name="Designation",
                        DataType="text",
                        FieldName ="designation",
                        FilterField ="Designation",
                        IsFilterable=true,
                        IsSortable=true,
                    },
                    new ListHeader
                    {
                        Name="Address",
                        DataType="text",
                        FieldName ="address",
                        FilterField ="Address",
                        IsFilterable=true,
                        IsSortable=true,
                    },
                    new ListHeader
                    {
                        Name="Phone NO.",
                        DataType="number",
                        FieldName ="phone",
                        FilterField ="Phone",
                        IsFilterable=true,
                        IsSortable=true,
                    }
                },
                    Data = await _imasterDDOService.getmasterDDO(dynamicListQueryParameters),
                    DataCount = await _imasterDDOService.CountMasterDDO(dynamicListQueryParameters)
                };
                response.result = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.apiResponseStatus = APIResponseStatus.Error;
            }
            return Ok(response);
        }

        [HttpGet("GetMasterDdoById")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var student = await _imasterDDOService.getStudentById(id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        /*[HttpGet("GetStudentByName")]
        public async Task<IActionResult> GetStudentByName(string name)
        {
            try
            {
                List<Ddo> students = await _imasterDDOService.getStudentsByName(name);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }*/
        [HttpPost("AddMasterDdo")]
        public async Task<IActionResult> AddStudent(masterDDOModel s)
        {
            try
            {
                int id = await _imasterDDOService.addStudent(s);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateMasterDdo")]
        public async Task<IActionResult> UpdateStudent(int id, masterDDOModel s)
        {
            try
            {
                await _imasterDDOService.updateStudent(id, s);
                return StatusCode(200);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteMasterDdo")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                await _imasterDDOService.deleteStudent(id);
                return StatusCode(200);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}