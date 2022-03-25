using DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioItau.Presentation.API.UseCases.V1.CashWithdrawal.GetNotesCombination;

/// <summary>
/// Cash Withdrawal API controller
/// </summary>
[Route("api/v{version:apiVersion}/withdrawal")]
[ApiVersion("1.0")]
[Authorize]
[ValidateAntiForgeryToken]
[ApiController]
public class CashWithdrawalController : ControllerBase
{
    private readonly IGetNotesCombinationUseCase _useCase;

    /// <summary>
    /// Class constructor
    /// </summary>
    /// <param name="useCase">Get Cash Notes Withdrawal use case</param>
    public CashWithdrawalController(IGetNotesCombinationUseCase useCase)
        => _useCase = useCase;

    /// <summary>
    /// This Api is responsible Combine the smallest amount of banknotes possible by the request sent
    /// </summary>
    /// <param name="amount">Amount of money requested</param>
    /// <returns>Collection that contains the combination with the least amount of banknotes for the submitted Amount</returns>
    /// <response code="200">Success</response>
    /// <response code="400">Bussiness Exception</response>
    /// <response code="500">Due to server problems, it is not possible to get your data now</response>
    [ProducesResponseType(typeof(GetNotesCombinationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseBadRequest), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseInternalServerError), StatusCodes.Status500InternalServerError)]
    [HttpGet("notes-combination/{value}")]
    public async Task<IActionResult> GetAsync([FromRoute] decimal? amount)
    {
        GetNotesCombinationRequest request = new() { Amount = amount };
        return Ok(await _useCase.GetNotesCombination(request));
    }
}