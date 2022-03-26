namespace DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class GetNotesCombinationResponse
{
    public GetNotesCombinationResponse(IEnumerable<BankNoteResponse> notesCombination)
    {
        BankNotes = notesCombination;
    }

    public IEnumerable<BankNoteResponse> BankNotes { get; }
}