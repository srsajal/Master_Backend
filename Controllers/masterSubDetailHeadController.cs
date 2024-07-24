using master.BAL.IServices;
using master.BAL.Services;
using master.Dto;
using master.Models;
using masterDDO.Enums;
using masterDDO.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class masterSubDetailHeadController : ControllerBase
    {
        ImasterSubDetailHeadService _masterSubDetailHeadService;
        public masterSubDetailHeadController(ImasterSubDetailHeadService masterSubDetailHeadService)
        {
            _masterSubDetailHeadService = masterSubDetailHeadService;
        }
        [HttpPost("GetMasterSubDetailHead")]
        public async Task<ActionResult<ServiceResponse<DynamicListResult<IEnumerable<masterSubDetailHeadDto>>>>> GetStudent([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            ServiceResponse<DynamicListResult<IEnumerable<masterSubDetailHeadDto>>> response = new();
            try
            {
                DynamicListResult<IEnumerable<masterSubDetailHeadDto>> result = new DynamicListResult<IEnumerable<masterSubDetailHeadDto>>
                {
                    Headers = new List<ListHeader>
                {
                    new ListHeader
                    {
                        Name="Sub Detail Head Code",
                        DataType="text",
                        FieldName ="code",
                        FilterField ="Code",
                        IsFilterable=true,
                        IsSortable=true,
                    },
                    new ListHeader
                    {
                        Name="Sub Detail Head Name",
                        DataType="text",
                        FieldName ="name",
                        FilterField ="Name",
                        IsFilterable=true,
                        IsSortable=true,
                    },
                    new ListHeader
                    {
                        Name="Detail Head Id",
                        DataType="number",
                        FieldName ="detailHeadId",
                        FilterField ="DetailHeadId",
                        IsFilterable=true,
                        IsSortable=true,
                    }
                },
                    Data = await _masterSubDetailHeadService.getSubDetailHead(isActive, dynamicListQueryParameters),
                    DataCount = await _masterSubDetailHeadService.CountSubDetailHead(isActive, dynamicListQueryParameters)
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

        [HttpGet("GetMasterSubDetailHeadById")]
        public async Task<IActionResult> GetStudentById(short id)
        {
            try
            {
                var student = await _masterSubDetailHeadService.getSubDetailHeadById(id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpGet("GetDetailCode")]
        public async Task<IActionResult> GetDetailHeadCodes()
        {
            try
            {
                var codes = await _masterSubDetailHeadService.getDetailCode();
                return Ok(codes);
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
        [HttpPost("AddMasterSubDetailHead")]
        public async Task<IActionResult> AddStudent(masterSubDetailHeadModel s)
        {
            try
            {
                int id = await _masterSubDetailHeadService.addSubDetailHead(s);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateMasterSubDetailHead")]
        public async Task<IActionResult> UpdateStudent(short id, masterSubDetailHeadModel s)
        {
            try
            {
                await _masterSubDetailHeadService.updateSubDetailHead(id, s);
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

        [HttpDelete("DeleteMasterSubDetailHead")]
        public async Task<IActionResult> DeleteStudent(short id)
        {
            try
            {
                await _masterSubDetailHeadService.deleteSubDetailHead(id);
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
        [HttpDelete("RestoreMasterSubDetailHead")]
        public async Task<IActionResult> RestoreMasterSubDetailHead(int id)
        {
            try
            {
                await _masterSubDetailHeadService.restoreMasterSubDetailHead(id);
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
        [HttpPost("CountMasterSubDetailHead")]
        public async Task<IActionResult> CountMasterSubDetailHead([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            try
            {
                var DataCount = await _masterSubDetailHeadService.CountSubDetailHead(isActive, dynamicListQueryParameters);
                return Ok(DataCount);
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
