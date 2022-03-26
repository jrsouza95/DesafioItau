namespace DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class BankNoteResponse
{
    public BankNoteResponse(int noteValue,
                            int amount)
    {
        NoteValue = noteValue.ToString("C2");
        Amount = amount;
    }

    public string NoteValue { get; }
    public int Amount { get; }
}