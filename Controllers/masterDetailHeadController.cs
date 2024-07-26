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
    public class masterDetailHeadController : ControllerBase
    {
        ImasterDetailHeadService _masterDetailHeadService;
        public masterDetailHeadController(ImasterDetailHeadService masterDetailHeadService)
        {
            _masterDetailHeadService = masterDetailHeadService;
        }
        [HttpPost("GetMasterDetailHead")]
        public async Task<ActionResult<ServiceResponse<DynamicListResult<IEnumerable<masterDetailHeadDto>>>>> GetStudent([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            ServiceResponse<DynamicListResult<IEnumerable<masterDetailHeadDto>>> response = new();
            try
            {
                DynamicListResult<IEnumerable<masterDetailHeadDto>> result = new DynamicListResult<IEnumerable<masterDetailHeadDto>>
                {
                    Headers = new List<ListHeader>
                {
                    new ListHeader
                    {
                        Name="Detail Head Code",
                        DataType="text",
                        FieldName ="code",
                        FilterField ="Code",
                        IsFilterable=true,
                        IsSortable=true,
                    },
                    new ListHeader
                    {
                        Name="Detail Head Name",
                        DataType="text",
                        FieldName ="name",
                        FilterField ="Name",
                        IsFilterable=true,
                        IsSortable=true,
                    }
                },
                    Data = await _masterDetailHeadService.getDetailHead(isActive, dynamicListQueryParameters),
                    DataCount = await _masterDetailHeadService.CountDetailHead(isActive, dynamicListQueryParameters)
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

        [HttpGet("GetMasterDetailHeadById")]
        public async Task<IActionResult> GetStudentById(short id)
        {
            try
            {
                var student = await _masterDetailHeadService.getDetailHeadById(id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        /*[HttpGet("GetTreasuryCode")]
        public async Task<IActionResult> GetTreasuryCodes()
        {
            try
            {
                var codes = await _masterDetailHeadService.getTreasuryCode();
                return Ok(codes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }*/
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
        [HttpPost("AddMasterDetailHead")]
        public async Task<IActionResult> AddStudent(masterDetailHeadModel s)
        {
            try
            {
                int id = await _masterDetailHeadService.addDetailHead(s);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateMasterDetailHead")]
        public async Task<IActionResult> UpdateStudent(short id, masterDetailHeadModel s)
        {
            try
            {
                await _masterDetailHeadService.updateDetailHead(id, s);
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

        [HttpDelete("DeleteMasterDetailHead")]
        public async Task<IActionResult> DeleteStudent(short id)
        {
            try
            {
                await _masterDetailHeadService.deleteDetailHead(id);
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

        [HttpDelete("RestoreMasterDetailHead")]
        public async Task<IActionResult> RestoreMasterDdo(short id)
        {
            try
            {
                await _masterDetailHeadService.restoreMasterDetailHead(id);
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

        [HttpPost("CountMasterDetailHead")]
        public async Task<IActionResult> CountMasterDdo([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            try
            {
                var DataCount = await _masterDetailHeadService.CountDetailHead(isActive, dynamicListQueryParameters);
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
