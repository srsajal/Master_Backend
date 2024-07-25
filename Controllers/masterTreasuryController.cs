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
    public class masterTreasuryController : ControllerBase
    {
        ImasterTreasuryService _imasterTreasuryService;

        public masterTreasuryController(ImasterTreasuryService imasterTreasuryService)
        {
            _imasterTreasuryService = imasterTreasuryService;
        }



        [HttpPost("GetMasterTreasury")]
        /* public async Task<ActionResult<ServiceResponse<DynamicListResult<IEnumerable<masterTresuryDTOs>>>>> GetStudent(DynamicListQueryParameters dynamicListQueryParameters)
         {
             ServiceResponse<DynamicListResult<IEnumerable<masterTresuryDTOs>>> response = new();
             try
             {
                 DynamicListResult<IEnumerable<masterTresuryDTOs>> result = new DynamicListResult<IEnumerable<masterTresuryDTOs>>
                 {
                     Headers = new List<ListHeader>
                 {
                     new ListHeader
                     {
                         Name="District Name",
                         DataType="text",
                         FieldName ="districtName",
                         FilterField ="DistrictName",
                         IsFilterable=true,
                         IsSortable=true,
                     },
                     new ListHeader
                     {
                         Name="District Code",
                         DataType="number",
                         FieldName ="districtCode",
                         FilterField ="DistrictCode",
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
                         Name="Name",
                         DataType="text",
                         FieldName ="name",
                         FilterField ="Name",
                         IsFilterable=true,
                         IsSortable=true,
                     }


                 },
                     Data = await _imasterTreasuryService.getmasterTreasury(dynamicListQueryParameters),
                     DataCount = await _imasterTreasuryService.CountMasterTreasury(dynamicListQueryParameters)
                 };
                 response.result = result;
             }
             catch (Exception ex)
             {
                 response.Message = ex.Message;
                 response.apiResponseStatus = APIResponseStatus.Error;
             }
             return Ok(response);
         }*/

        public async Task<ActionResult<ServiceResponse<DynamicListResult<IEnumerable<masterTresuryDTOs>>>>> GetStudent([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            ServiceResponse<DynamicListResult<IEnumerable<masterTresuryDTOs>>> response = new();
            try
            {
                DynamicListResult<IEnumerable<masterTresuryDTOs>> result = new DynamicListResult<IEnumerable<masterTresuryDTOs>>
                {
                    Headers = new List<ListHeader>
                {
                    new ListHeader
                     {
                         Name="District Name",
                         DataType="text",
                         FieldName ="districtName",
                         FilterField ="DistrictName",
                         IsFilterable=true,
                         IsSortable=true,
                     },
                     new ListHeader
                     {
                         Name="District Code",
                         DataType="number",
                         FieldName ="districtCode",
                         FilterField ="DistrictCode",
                         IsFilterable=true,
                         IsSortable=true,
                     },
                     new ListHeader
                     {
                         Name="Treasury Code",
                         DataType="text",
                         FieldName ="code",
                         FilterField ="Code",
                         IsFilterable=true,
                         IsSortable=true,
                     },
                     new ListHeader
                     {
                         Name="Treasury Name",
                         DataType="text",
                         FieldName ="name",
                         FilterField ="Name",
                         IsFilterable=true,
                         IsSortable=true,
                     }
                },
                    Data = await _imasterTreasuryService.getmasterTreasury(isActive, dynamicListQueryParameters),
                    DataCount = await _imasterTreasuryService.CountMasterTreasury(isActive, dynamicListQueryParameters)
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

        [HttpGet("GetMasterTreasuryById")]
        public async Task<IActionResult> GetStudentById(short id)
        {
            try
            {
                var student = await _imasterTreasuryService.getStudentById(id);
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
        [HttpPost("AddMasterTreasury")]
        public async Task<IActionResult> AddStudent(masterTreasuryModel s)
        {
            try
            {
                int id = await _imasterTreasuryService.addStudent(s);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateMasterTreasury")]
        public async Task<IActionResult> UpdateStudent(short id, masterTreasuryModel s)
        {
            try
            {
                await _imasterTreasuryService.updateStudent(id, s);
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

        [HttpDelete("DeleteMasterTreasury")]
        public async Task<IActionResult> DeleteStudent(short id)
        {
            try
            {
                await _imasterTreasuryService.deleteStudent(id);
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

        [HttpDelete("RestoreMasterTreasury")]
        public async Task<IActionResult> restoreMasterTreasury(short id)
        {
            try
            {
                await _imasterTreasuryService.restoreMasterTreasury(id);
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
        [HttpPost("CountMasterTreasury")]
        public async Task<IActionResult> CountMasterTreasury([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            try
            {
                var DataCount = await _imasterTreasuryService.CountMasterTreasury(isActive, dynamicListQueryParameters);
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
