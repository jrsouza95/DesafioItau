using DesafioItau.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class GetNotesCombinationUseCase : IGetNotesCombinationUseCase
{
    private readonly IBanknoteRepository _repository;
    private readonly ILogger<GetNotesCombinationUseCase> _logger;

    public GetNotesCombinationUseCase(IBanknoteRepository repository,
                                      ILogger<GetNotesCombinationUseCase> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public IEnumerable<GetNotesCombinationResponse> GetNotesCombination(GetNotesCombinationRequest request)
    {
        _logger.LogInformation("Init banknotes combination");

        _logger.LogInformation("Getting avaliables banknotes");
        var avaliableNotes = _repository.Get();



        return new List<GetNotesCombinationResponse>();
    }
}