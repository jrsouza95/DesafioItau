using DesafioItau.Domain.Interfaces;

namespace DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class GetNotesCombinationUseCase : IGetNotesCombinationUseCase
{
    private readonly IBanknoteRepository _repository;

    public GetNotesCombinationUseCase(IBanknoteRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<GetNotesCombinationResponse> GetNotesCombination(GetNotesCombinationRequest request)
    {
        // obter todas as notas disponíveis
        var avaliableNotes = _repository.Get();

        return new List<GetNotesCombinationResponse>();
    }
}