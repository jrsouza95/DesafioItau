namespace DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

/// <summary>
/// Implements rules of the Get Notes Combination Use Case
/// </summary>
public interface IGetNotesCombinationUseCase
{
    /// <summary>
    /// Gets the combination with the least amount of banknotes available for withdrawal
    /// </summary>
    /// <param name="request">The value of Withdrawal requested</param>
    /// <returns>Collection that contains the combination with the least amount of banknotes for the submitted request</returns>
    IEnumerable<GetNotesCombinationResponse> GetNotesCombination(GetNotesCombinationRequest request);
}
