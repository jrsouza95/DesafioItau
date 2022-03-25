namespace DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class GetNotesCombinationResponse
{
    public IEnumerable<NotesResponse> Notes { get; set; }
}

public class NotesResponse
{
    public decimal NoteValue { get; set; }
    public int Amount { get; set; }
}