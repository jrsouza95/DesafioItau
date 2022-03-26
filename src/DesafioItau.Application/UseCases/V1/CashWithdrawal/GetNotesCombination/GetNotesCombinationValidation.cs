namespace DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class GetNotesCombinationValidation : IGetNotesCombinationUseCase
{
    public readonly IGetNotesCombinationUseCase _useCase;

    public GetNotesCombinationValidation(IGetNotesCombinationUseCase useCase)
    {
        _useCase = useCase;
    }

    public GetNotesCombinationResponse GetNotesCombination(GetNotesCombinationRequest request)
    {
        if(request.Amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(request.Amount), "Must be greater than 0");

        return _useCase.GetNotesCombination(request);
    }
}