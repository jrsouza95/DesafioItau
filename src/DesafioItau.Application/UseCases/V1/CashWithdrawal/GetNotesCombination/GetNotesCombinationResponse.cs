namespace DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class GetNotesCombinationResponse
{
    public GetNotesCombinationResponse(List<BankNoteResponse> notesCombination)
    {
        BankNotes = notesCombination;
    }

    public IEnumerable<BankNoteResponse> BankNotes { get; set; }
}

public class BankNoteResponse
{
    public BankNoteResponse(int noteValue,
                            int amount)
    {
        NoteValue = noteValue.ToString("C2");
        Amount = amount;    
    }

    public string NoteValue { get; set; }
    public int Amount { get; set; }
}