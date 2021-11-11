using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MatrixAgent.Models;
using MatrixAgent.Services;


namespace MatrixAgent.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MatrixAgentController : ControllerBase
    {
        private readonly IMatrixAgentService _matrixAgentService;

        public MatrixAgentController(IMatrixAgentService matrixAgentService)
        {
            _matrixAgentService = matrixAgentService;
        }

        public async Task<ActionResult<RowColMultiplicationDto>> CalculateScalar(
            RowColMultiplicationDto rowColMultiplicationDto)
        {
            Console.WriteLine("Otrzymałem zadanie od brokera");
            var rowCol = await _matrixAgentService.CalculateScalar(rowColMultiplicationDto);
            Console.WriteLine("Zwracam otrzymany wynik do brokera");
            return Ok(rowCol);
        }
    }
}
