using master.BAL.IServices;
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
    public class MasterDepartmentController : ControllerBase
    {
        ImasterDepartmentService _imasterDepartmentService;
        private object isActive;

        public MasterDepartmentController(ImasterDepartmentService imasterDepartmentService)
        {
            _imasterDepartmentService = imasterDepartmentService;
        }
        [HttpPost("GetMasterDepartment")]
        public async Task<ActionResult<ServiceResponse<DynamicListResult<IEnumerable<masterDepartmentDto>>>>> GetDepartment([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            ServiceResponse<DynamicListResult<IEnumerable<masterDepartmentDto>>> response = new();
            try
            {
                DynamicListResult<IEnumerable<masterDepartmentDto>> result = new DynamicListResult<IEnumerable<masterDepartmentDto>>
                {
                    Headers = new List<ListHeader>
                {
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
                    },
                    new ListHeader
                    {
                        Name="DemandCode",
                        DataType="text",
                        FieldName ="demandCode",
                        FilterField ="DemandCode",
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
                        Name="Pin Code",
                        DataType="text",
                        FieldName ="pinCode",
                        FilterField ="PinCode",
                        IsFilterable=true,
                        IsSortable=true,
                    },
                    new ListHeader
                    {
                        Name="Phone NO",
                        DataType="text",
                        FieldName ="phoneNumber",
                        FilterField ="PhoneNumber",
                        IsFilterable=true,
                        IsSortable=true,
                    },
                    new ListHeader
                    {
                        Name="Mobile NO.",
                        DataType="number",
                        FieldName ="mobileNumber",
                        FilterField ="MobileNumber",
                        IsFilterable=true,
                        IsSortable=true,
                    },
                    new ListHeader
                    {
                        Name="Email",
                        DataType="text",
                        FieldName ="email",
                        FilterField ="Email",
                        IsFilterable=true,
                        IsSortable=true,
                    }
                },
                    Data = await _imasterDepartmentService.getmasterDepartment(isActive,dynamicListQueryParameters),
                    DataCount = await _imasterDepartmentService.CountMasterDepartment(dynamicListQueryParameters)
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

        [HttpGet("GetMasterDepartmentById")]
        public async Task<IActionResult> GetDepartmentById(short id)
        {
            try
            {
                var Department = await _imasterDepartmentService.getDepartmentById(id);
                return Ok(Department);
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
        [HttpPost("AddMasterDepartment")]
        public async Task<IActionResult> AddDepartment(masterDepartmentModel s)
        {
            try
            {
                int id = await _imasterDepartmentService.addDepartment(s);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateMasterDepartment")]
        public async Task<IActionResult> UpdateDepartment(short id, masterDepartmentModel s)
        {
            try
            {
                await _imasterDepartmentService.updateDepartment(id, s);
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

        [HttpDelete("DeleteMasterDepartment")]
        public async Task<IActionResult> DeleteDepartment(short id)
        {
            try
            {
                await _imasterDepartmentService.deleteDepartment(id);
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
