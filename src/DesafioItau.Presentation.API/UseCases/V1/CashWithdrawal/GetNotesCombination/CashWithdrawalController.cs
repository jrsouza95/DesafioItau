using DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;
using DesafioItau.Presentation.API.ExceptionHandler.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DesafioItau.Presentation.API.UseCases.V1.CashWithdrawal.GetNotesCombination;

/// <summary>
/// Cash Withdrawal API controller
/// </summary>
[Route("api/v{version:apiVersion}/withdrawal")]
[ApiVersion("1.0")]
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
    /// <response code="404">Not Found</response>
    /// <response code="400">Bussiness Exception</response>
    /// <response code="500">Due to server problems, it is not possible to get your data now</response>
    [ProducesResponseType(typeof(GetNotesCombinationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseBadRequest), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseInternalServerError), StatusCodes.Status500InternalServerError)]
    [HttpGet("notes-combination/{amount}")]
    public IActionResult Get([FromRoute] int? amount)
    {
        GetNotesCombinationRequest request = new(amount);
        var response = _useCase.GetNotesCombination(request);

        return !response.BankNotes.Any()? NotFound() : Ok(response);
    }
}