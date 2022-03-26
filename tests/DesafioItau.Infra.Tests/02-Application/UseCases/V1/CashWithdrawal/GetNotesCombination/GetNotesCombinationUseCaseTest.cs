using DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;
using DesafioItau.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace DesafioItau.Infra.Tests._02_Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class GetNotesCombinationUseCaseTest
{
    private Mock<IBanknoteRepository> _banknoteRepository;
    private IGetNotesCombinationUseCase _useCase;

    [SetUp]
    public void SetUp()
    {
        _banknoteRepository = new Mock<IBanknoteRepository>();
        _useCase = new GetNotesCombinationUseCase(_banknoteRepository.Object);
    }

    [Test]
    public void GetNotesCombination_Should_Return_expetected_values()
    {

    }
}
