using master.Dto;
using masterDDO.Enums;
using masterDDO.Helpers;
using MasterManegmentSystem.BAL.IServices;
using MasterManegmentSystem.Dto;
using MasterManegmentSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class masterMajorHeadController : ControllerBase
    {
        IMasterManegmentService _imasterDDOService;
        public masterMajorHeadController(IMasterManegmentService es)
        {
            _imasterDDOService = es;    
            
        }
        [HttpPost("GetMasterMAJORHEAD")]
        public async Task<ActionResult<ServiceResponse<DynamicListResult<IEnumerable<MasterManegmentDTO>>>>> GetStudent(DynamicListQueryParameters dynamicListQueryParameters)
        {
            ServiceResponse<DynamicListResult<IEnumerable<MasterManegmentDTO>>> response = new();
            try
            {
                DynamicListResult<IEnumerable<MasterManegmentDTO>> result = new DynamicListResult<IEnumerable<MasterManegmentDTO>>
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

                },
                    Data = await _imasterDDOService.GetMastermajorhead(dynamicListQueryParameters),
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

        [HttpGet("GetMasterMAJORHEADById")]
        public async Task<IActionResult> GetMasterMAJORHEADById(short id)
        {
            try
            {
                var student = await _imasterDDOService.GetMastermajorheadById(id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpPost("AddMasterMAJORHEAD")]
        public async Task<IActionResult> AddMasterMAJORHEAD(MasterManegmentModel s)
        {
            try
            {
                int id = await _imasterDDOService.AddMasterMAJORHEAD(s);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateMasterMAJORHEAD")]
        public async Task<IActionResult> UpdateMasterMAJORHEAD(short id, MasterManegmentModel s)
        {
            try
            {
                await _imasterDDOService.UpdateMastermajorhead(id, s);
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

        [HttpDelete("DeleteMasterMAJORHEAD")]
        public async Task<IActionResult> DeleteMasterMAJORHEAD(short id)
        {
            try
            {
                await _imasterDDOService.DeleteMastermajorhead(id);
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
