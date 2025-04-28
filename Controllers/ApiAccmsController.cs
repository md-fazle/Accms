using ACCMS_AGH.Models.Accms;
using ACCMS_AGH.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ACCMS_AGH.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiAccmsController : ControllerBase // Changed from Controller to ControllerBase for API
    {
        private readonly AccmsRepositories _repository;

        public ApiAccmsController(IConfiguration configuration)
        {
            _repository = new AccmsRepositories(configuration);
        }

        // Optional landing/test endpoint
        [HttpGet("index")]
        public IActionResult Index()
        {
            return Ok("API is up and running.");
        }

        // GET: api/ApiAccms/ledgerlist?groupCode=1234
        [HttpGet("ledgerlist")]
        public IActionResult LedgerList([FromQuery] string groupCode)
        {
            if (string.IsNullOrEmpty(groupCode))
            {
                return BadRequest(new { success = false, message = "Group Code is required." });
            }

            var ledgers = _repository.GetLedgerInformationGridByGroupCode(groupCode);
            return Ok(new { success = true, data = ledgers });
        }

        // GET: api/ApiAccms/chequelist?groupCode=1234
        [HttpGet("chequelist")]
        public IActionResult ChequeList([FromQuery] string groupCode)
        {
            if (string.IsNullOrEmpty(groupCode))
            {
                return BadRequest(new { success = false, message = "Group Code is required." });
            }

            try
            {
                var cheques = _repository.GetCheqInformationGrid(groupCode);
                return Ok(new { success = true, data = cheques });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }

        // POST: api/ApiAccms/savechequeallotment
        [HttpPost("savechequeallotment")]
        public IActionResult SaveChequeAllotment([FromBody] ChequeAllotmentRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.LCode) || string.IsNullOrEmpty(request.ChqNo))
            {
                return BadRequest(new { success = false, message = "LCode and ChqNo are required." });
            }

            try
            {
                var result = _repository.SaveChequeAllotment(
                    request.LCode,
                    request.Lname,
                    request.ChqNo,
                    request.Amount,
                    request.Chqdate,
                    request.ValidDate,
                    request.PaymentType,
                    request.Remarks,
                    request.EntryBy,
                    request.CompanyID,
                    request.LocationID,
                    request.MachineID
                );

                return Ok(new { success = true, message = "Cheque allotment saved successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error saving cheque allotment: {ex.Message}" });
            }
        }

        // GET: api/ApiAccms/chequeregister?where=1&cp_ChequeNo=ABC123
        [HttpGet("chequeregister")]
        public ActionResult<List<ChequePrintDetails>> GetChequeRegisterPrintReport([FromQuery] int where, [FromQuery] string cp_ChequeNo)
        {
            try
            {
                var result = _repository.GetChequeRegisterPrintReport(where, cp_ChequeNo);

                if (result == null || result.Count == 0)
                {
                    return NotFound("No data found for the given Cheque Number.");
                }

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", detail = ex.Message });
            }
        }
        // GET: api/ApiAccms/listtable
        [HttpGet("listtable")]
        public IActionResult GetListTable([FromQuery] string pPrint)
        {
            try
            {
                // Validate input parameter
                if (string.IsNullOrEmpty(pPrint))
                {
                    return BadRequest(new { success = false, message = "Group Code (pPrint) is required." });
                }

           
                var result = _repository.GetList(pPrint);

                if (result == null || result.Count == 0)
                {
                    return Ok(new { success = true, message = "No data found.", data = new List<ChequeRegisterDetailsModel>() });
                }

      
                return Ok(new { success = true, data = result });
            }
            catch (ArgumentException ex)
            {
         
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { success = false, message = "Internal server error", detail = ex.Message });
            }
        }

    }
}
