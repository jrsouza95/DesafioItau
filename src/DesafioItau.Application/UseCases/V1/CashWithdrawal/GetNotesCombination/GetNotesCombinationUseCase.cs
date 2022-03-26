using DesafioItau.Domain.Interfaces;
using DesafioItau.Domain.Models;

namespace DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class GetNotesCombinationUseCase : IGetNotesCombinationUseCase
{
    private readonly IBanknoteRepository _banknoteRepository;

    public GetNotesCombinationUseCase(IBanknoteRepository banknotesRepository)
    {
        _banknoteRepository = banknotesRepository;
    }

    public GetNotesCombinationResponse GetNotesCombination(GetNotesCombinationRequest request)
    {
        IEnumerable<Banknote> avaliableNotes = _banknoteRepository.Get().OrderByDescending(x => x.Value);
        List<BankNoteResponse> notesCombination = new();

        int amount = request.Amount.Value;
        
        foreach(var note in avaliableNotes)
        {
            if(amount >= note.Value)
            {
                int noteAmount = amount / note.Value;
                
                BankNoteResponse bankNote = new(note.Value, noteAmount);

                amount %= note.Value;

                notesCombination.Add(bankNote);
            }
        }
        return new GetNotesCombinationResponse(notesCombination);
    }
}