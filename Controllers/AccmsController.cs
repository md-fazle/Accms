using ACCMS_AGH.Models.Accms;
using ACCMS_AGH.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ACCMS_AGH.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccmsController : Controller
    {

        private readonly AccmsRepositories _repository;

        public AccmsController(IConfiguration configuration)
        {
            _repository = new AccmsRepositories(configuration);
        }

        [HttpGet("cheque-allotment")]
        public IActionResult ChequeAllotment([FromQuery] string? pPrint = "")
        {
            try
            {
                // Validate input parameter
                if (string.IsNullOrWhiteSpace(pPrint))
                {
                    ViewBag.ErrorMessage = "Group Code (pPrint) is required.";
                    return View(new List<ChequeRegisterDetailsModel>());
                }

                var result = _repository.GetList(pPrint);

                if (result == null || result.Count == 0)
                {
                    ViewBag.Message = "No data found.";
                    return View(new List<ChequeRegisterDetailsModel>());
                }

                return View(result);
            }
            catch (ArgumentException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(new List<ChequeRegisterDetailsModel>());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Internal server error: " + ex.Message;
                return View(new List<ChequeRegisterDetailsModel>());
            }
        }

    }
}
