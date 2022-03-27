using DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;
using DesafioItau.Domain.Interfaces;
using DesafioItau.Infra.Data.MockData;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using FluentAssertions;

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
    [TestCase(9)]
    [TestCase(150)]
    [TestCase(197)]
    [TestCase(3123)]
    [TestCase(1238746)]
    public void GetNotesCombination_Should_Return_Expetected_Combination(int amount)
    {
        GetNotesCombinationRequest request = new(amount);

        _banknoteRepository.Setup(x => x.Get()).Returns(MockBanknoteData.Banknotes);

        var response = _useCase.GetNotesCombination(request);

        response.Should().NotBeNull();
        response.Should().BeEquivalentTo(GetExpectedCombination(amount));
    }

    private static GetNotesCombinationResponse GetExpectedCombination(int amount) =>
    amount switch
    {
        9 => new GetNotesCombinationResponse(new List<BankNoteResponse>() {
            new BankNoteResponse(5, 1),
            new BankNoteResponse(2, 2)
        }),
        150 => new GetNotesCombinationResponse(new List<BankNoteResponse>() { 
            new BankNoteResponse(100, 1),
            new BankNoteResponse(50, 1)
        }),
        197 => new GetNotesCombinationResponse(new List<BankNoteResponse>() {
            new BankNoteResponse(100, 1),
            new BankNoteResponse(50, 1),
            new BankNoteResponse(20, 2),
            new BankNoteResponse(5, 1),
            new BankNoteResponse(2, 1)

        }),
        3123 => new GetNotesCombinationResponse(new List<BankNoteResponse>() {
            new BankNoteResponse(100, 31),
            new BankNoteResponse(20, 1),
            new BankNoteResponse(2, 1),
            new BankNoteResponse(1, 1)
        }),
        1238746 => new GetNotesCombinationResponse(new List<BankNoteResponse>() {
            new BankNoteResponse(100, 12387),
            new BankNoteResponse(20, 2),
            new BankNoteResponse(5, 1),
            new BankNoteResponse(1, 1)
        }),
        _ => throw new ArgumentOutOfRangeException(),
    };
}