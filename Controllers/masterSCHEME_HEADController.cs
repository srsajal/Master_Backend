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
    public class masterSCHEME_HEADController : ControllerBase
    {
        ImasterSCHEME_HEADService _imasterSCHEMEHEADService;
        ImasterMinorHeadService _imasterMinorHeadService;

        public masterSCHEME_HEADController(ImasterSCHEME_HEADService imasterSCHEMEHEADService, ImasterMinorHeadService imasterMinorHeadService)
        {
            _imasterSCHEMEHEADService = imasterSCHEMEHEADService;
            _imasterMinorHeadService = imasterMinorHeadService;
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

        [HttpPost("GetMasterSCHEME_HEAD")]
        public async Task<ActionResult<ServiceResponse<DynamicListResult<IEnumerable<masterSCHEME_HEADDto>>>>> GetStudent([FromQuery] bool isActive ,DynamicListQueryParameters dynamicListQueryParameters)
        {
            ServiceResponse<DynamicListResult<IEnumerable<masterSCHEME_HEADDto>>> response = new();
            try
            {
                DynamicListResult<IEnumerable<masterSCHEME_HEADDto>> result = new DynamicListResult<IEnumerable<masterSCHEME_HEADDto>>
                {
                    Headers = new List<ListHeader>
                {
                    new ListHeader
                    {
                        Name="DemandCode ",
                        DataType="text",
                        FieldName ="demandCode",
                        FilterField ="DemandCode",
                        IsFilterable=true,
                        IsSortable=true,
                    },
                    new ListHeader
                    {
                        Name="Scheme Head Code",
                        DataType="text",
                        FieldName ="code",
                        FilterField ="Code",
                        IsFilterable=true,
                        IsSortable=true,
                    },
                    new ListHeader
                    {
                        Name=" Scheme Head Name",
                        DataType="text",
                        FieldName ="name",
                        FilterField ="Name",
                        IsFilterable=true,
                        IsSortable=true,
                    },
                    new ListHeader
                    {
                        Name="MinorHeadId",
                        DataType="number",
                        FieldName ="minorHeadId",
                        FilterField ="MinorHeadId",
                        IsFilterable=true,
                        IsSortable=true,
                    },

                },
                    Data = await _imasterSCHEMEHEADService.getmasterSCHEME_HEAD( isActive,dynamicListQueryParameters),
                    DataCount = await _imasterSCHEMEHEADService.CountMasterSCHEME_HEAD(isActive, dynamicListQueryParameters)
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

        [HttpGet("GetMasterSCHEME_HEADfromMINORHEADId")]
        public async Task<IActionResult> getgetSchemeMinorheadfromMINORHEADId()
        {
            try
            {
                var codes = await _imasterSCHEMEHEADService.getSchemeMinorheadfromMINORHEADId();
                return Ok(codes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpGet("GetMasterSCHEME_HEADById")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var student = await _imasterSCHEMEHEADService.getStudentById(id);
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
        [HttpPost("AddmasterSCHEME-HEAD")]
        public async Task<IActionResult>AddStudent(masterSCHEME_HEADModel s)
        {
            try
            {
                int id = await _imasterSCHEMEHEADService.addStudent(s);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateMasterSCHEME_HEAD")]
        public async Task<IActionResult> UpdateStudent(int id, masterSCHEME_HEADModel s)
        {
            try
            {
                await _imasterSCHEMEHEADService.updateStudent(id, s);
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

        [HttpDelete("DeleteMasterSchemeHead")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                await _imasterSCHEMEHEADService.deleteStudent(id);
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
        [HttpDelete("RestoreMasterSchemeHead")]
        public async Task<IActionResult> RestoreMasterDdo(int id)
        {
            try
            {
                await _imasterSCHEMEHEADService.restoreMasterSchemeHead(id);
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
        [HttpPost("CountMasterDdo")]
        public async Task<IActionResult> CountMasterSchemeHead([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            try
            {
                var DataCount = await _imasterSCHEMEHEADService.CountMasterSCHEME_HEAD(isActive, dynamicListQueryParameters);
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

