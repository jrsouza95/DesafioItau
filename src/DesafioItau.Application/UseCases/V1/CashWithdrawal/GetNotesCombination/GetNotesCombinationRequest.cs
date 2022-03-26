namespace DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class GetNotesCombinationRequest
{
    public GetNotesCombinationRequest(int? amount)
    {
        Amount = amount;
    }

    public int? Amount { get; }
}