using master.BAL.IServices;
using master.Dto;
using master.Models;
using masterDDO.Enums;
using masterDDO.Helpers;
using MasterManegmentSystem.BAL.IServices;
using MasterManegmentSystem.Dto;
using MasterManegmentSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace master.Controllers
{
    public class mastersubmajorheadController : Controller
    {
        ImastersubmajorheadService _mastersubmajorheadService;
        public mastersubmajorheadController(ImastersubmajorheadService es)
        {
            _mastersubmajorheadService = es;
        }
        [HttpPost("GetMastersubmajorhead")]
        public async Task<ActionResult<ServiceResponse<DynamicListResult<IEnumerable<mastersubmajorheadDTO>>>>> GetStudent(DynamicListQueryParameters dynamicListQueryParameters)
        {
            ServiceResponse<DynamicListResult<IEnumerable<mastersubmajorheadDTO>>> response = new();
            try
            {
                DynamicListResult<IEnumerable<mastersubmajorheadDTO>> result = new DynamicListResult<IEnumerable<mastersubmajorheadDTO>>
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
                        Name="MajorHeadId",
                        DataType="text",
                        FieldName ="majorHeadId",
                        FilterField ="MajorHeadId",
                        IsFilterable=true,
                        IsSortable=true,
                    },

                },
                    Data = await _mastersubmajorheadService.GetMastersubmajorhead(dynamicListQueryParameters),
                    DataCount = await _mastersubmajorheadService.CountMastersubmajorhead(dynamicListQueryParameters)
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

        [HttpGet("GetMasterMastersubMajorHeadById")]
        public async Task<IActionResult> GetMasterMastersubMajorHeadById(int id)
        {
            try
            {
                var student = await _mastersubmajorheadService.GetMasterMastersubMajorHeadById(id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpPost("AddMasterSubmajorHead")]
        public async Task<IActionResult> AddMasterSubmajorHead(mastersubmajorheadModel s)
        {
            try
            {
                int id = await _mastersubmajorheadService.AddMasterSubmajorHead(s);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateMastersubMajorHead")]
        public async Task<IActionResult> UpdateMastersubMajorHead(int id, mastersubmajorheadModel s)
        {
            try
            {
                await _mastersubmajorheadService.UpdateMastersubMajorHead(id, s);
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

        [HttpDelete("DeleteMastersubMajorHead")]
        public async Task<IActionResult> DeleteMastersubMajorHead(int id)
        {
            try
            {
                await _mastersubmajorheadService.DeleteMastersubMajorHead(id);
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
