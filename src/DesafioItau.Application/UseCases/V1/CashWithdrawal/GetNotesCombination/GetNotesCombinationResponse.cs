namespace DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class GetNotesCombinationResponse
{
    public IEnumerable<BankNoteResponse> Notes { get; set; }
}

public class BankNoteResponse
{
    public int NoteValue { get; set; }
    public int Amount { get; set; }
}