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
        IMasterManegmentService _imasterManagementService;
        public masterMajorHeadController(IMasterManegmentService es)
        {
            _imasterManagementService = es;

        }
        [HttpPost("GetMasterMAJORHEAD")]
        public async Task<ActionResult<ServiceResponse<DynamicListResult<IEnumerable<MasterManegmentDTO>>>>> GetStudent([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
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
                    Data = await _imasterManagementService.GetMastermajorhead(isActive, dynamicListQueryParameters),
                    DataCount = await _imasterManagementService.CountMasterMajorHead(isActive, dynamicListQueryParameters)
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
        public async Task<IActionResult> GetMasterMAJORHEADById(int id)
        {
            try
            {
                var student = await _imasterManagementService.GetMastermajorheadById(id);
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
                // Check if the Code already exists
                bool exists = await _imasterManagementService.MasterMAJORHEADExistsByCode(s.Code);

                if (exists)
                {
                    return BadRequest("Error: The provided code already exists in the database.");
                }

                // Add the new MasterMAJORHEAD
                int id = await _imasterManagementService.AddMasterMAJORHEAD(s);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("CheckMasterMAJORHEADCode/{code}")]
        public async Task<bool> CheckMasterMAJORHEADCode(string code)
        {
            try
            {
                // Check if the Code exists
                bool codeExists = await _imasterManagementService.MasterMAJORHEADExistsByCode(code);

                if (codeExists)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetAllMasterMAJORHEADs")]
        public async Task<IActionResult> GetAllMasterMAJORHEADs()
        {
            try
            {
                var masterMajorHeads = await _imasterManagementService.GetAllMasterMAJORHEADs();
                return Ok(masterMajorHeads);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    




        [HttpPut("UpdateMasterMAJORHEAD")]
        public async Task<IActionResult> UpdateMasterMAJORHEAD(int id, MasterManegmentModel s)
        {
            try
            {
                await _imasterManagementService.UpdateMastermajorhead(id, s);
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
        public async Task<IActionResult> DeleteMasterMAJORHEAD(int id)
        {
            try
            {
                await _imasterManagementService.DeleteMastermajorhead(id);
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
        [HttpPost("CountMasterMajorHead")]
        public async Task<IActionResult> CountMasterDdo([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            try
            {
                var DataCount = await _imasterManagementService.CountMasterMajorHead(isActive, dynamicListQueryParameters);
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
