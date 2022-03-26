using DesafioItau.Domain.Interfaces;
using DesafioItau.Domain.Models;
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

    public GetNotesCombinationResponse GetNotesCombination(GetNotesCombinationRequest request)
    {
        var avaliableNotes = _repository.Get().OrderByDescending(x => x.Value);
        
        List<BankNoteResponse> notesCombination = new();

        int amount = request.Amount.Value;
        
        foreach(var note in avaliableNotes)
        {
            if(amount >= note.Value)
            {
                BankNoteResponse bankNote = new()
                {
                    NoteValue = note.Value,
                    Amount = amount / note.Value,
                };

                amount %= note.Value;

                notesCombination.Add(bankNote);
            }
            else break;
        }

        return new GetNotesCombinationResponse() { Notes = notesCombination };
    }
}