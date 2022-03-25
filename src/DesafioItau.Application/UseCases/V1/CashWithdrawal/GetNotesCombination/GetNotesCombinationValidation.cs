namespace DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class GetNotesCombinationValidation : IGetNotesCombinationUseCase
{
    public readonly IGetNotesCombinationUseCase _useCase;

    public GetNotesCombinationValidation(IGetNotesCombinationUseCase useCase)
    {
        _useCase = useCase;
    }

    public IEnumerable<GetNotesCombinationResponse> GetNotesCombination(GetNotesCombinationRequest request)
    {
        ArgumentNullException.ThrowIfNull(nameof(request));
        ArgumentNullException.ThrowIfNull(nameof(request.Amount));

        return _useCase.GetNotesCombination(request);
    }
}