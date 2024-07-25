using master.BAL.IServices;
using master.BAL.Services;
using master.DAL.Entity;
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
    public class masterMinorHeadController : ControllerBase
    {
        ImasterMinorHeadService _imasterMinorHeadService;
        public masterMinorHeadController(ImasterMinorHeadService imasterMinorHeadService)
        {
            _imasterMinorHeadService = imasterMinorHeadService;
        }
        [HttpPost("GetmasterMinorHead")]
        public async Task<ActionResult<ServiceResponse<DynamicListResult<IEnumerable<masterMinorHeadDto>>>>> GetStudent([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            ServiceResponse<DynamicListResult<IEnumerable<masterMinorHeadDto>>> response = new();
            try
            {
                DynamicListResult<IEnumerable<masterMinorHeadDto>> result = new DynamicListResult<IEnumerable<masterMinorHeadDto>>
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
                        Name="SubMajorId",
                        DataType="text",
                        FieldName ="subMajorId",
                        FilterField ="SubMajorId",
                        IsFilterable=true,
                        IsSortable=true,
                    },
                },
                    Data = await _imasterMinorHeadService.getmasterMinorHead(isActive ,dynamicListQueryParameters),
                    DataCount = await _imasterMinorHeadService.CountMasterMinorHead(isActive ,dynamicListQueryParameters)
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

        [HttpGet("GetmasterMinorHeadById")]
        public async Task<IActionResult> GetMinorHeadById(int id)
        {
            try
            {
                var MinorHead = await _imasterMinorHeadService.getMinorHeadById(id);
                return Ok(MinorHead);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpGet("GetSubMajorHeadCode")]
        public async Task<IActionResult> GetSubMajorHeadCodes()
        {
            try
            {
                var codes = await _imasterMinorHeadService.getSubMajorHeadCode();
                return Ok(codes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpPost("AddmasterMinorHead")]
        public async Task<IActionResult> AddMinorHead(masterMinorHeadModel s)
        {
            try
            {
                int id = await _imasterMinorHeadService.addMinorHead(s);
                return Ok(id);
            }
            catch (Exception ex)
             {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdatemasterMinorHead")]
        public async Task<IActionResult> UpdateMinorHead(int id, masterMinorHeadModel s)
        {
            try
            {
                await _imasterMinorHeadService.updateMinorHead(id, s);
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

        [HttpDelete("DeletemasterMinorHead")]
        public async Task<IActionResult> DeleteMinorHead(int id)
        {
            try
            {
                await _imasterMinorHeadService.deleteMinorHead(id);
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

        [HttpPost("CountMasterMinorHead")]
        public async Task<IActionResult> CountMasterMinorHead([FromQuery] bool isActive, DynamicListQueryParameters dynamicListQueryParameters)
        {
            try
            {
                var DataCount = await _imasterMinorHeadService.CountMasterMinorHead(isActive, dynamicListQueryParameters);
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

        [HttpDelete("RestoreMasterMinorHead")]
        public async Task<IActionResult> restoreMasterMinorHead(int id)
        {
            try
            {
                await _imasterMinorHeadService.restoreMasterMinorHead(id);
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
