using DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using FluentAssertions;

namespace DesafioItau.Infra.Tests._02_Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class GetNotesCombinationValidationTest
{
    private Mock<IGetNotesCombinationUseCase> _getNotesCombinationUseCase;
    private IGetNotesCombinationUseCase _GetNotesCombinationValidation;

    [SetUp]
    public void SetUp()
    {
        _getNotesCombinationUseCase = new Mock<IGetNotesCombinationUseCase>();
        _GetNotesCombinationValidation = new GetNotesCombinationValidation(_getNotesCombinationUseCase.Object);
    }

    [Test]
    [TestCase(150)]
    [TestCase(320)]
    [TestCase(3123123)]
    [TestCase(1)]
    public void GetNotesCombinationValidation_Valid_Request_Should_Call_UseCase(int amount)
    {
        List<BankNoteResponse> banknotesResponse = new()
        {
            new(100, 1),
            new(50, 1)
        };
        GetNotesCombinationResponse response = new(banknotesResponse);
        GetNotesCombinationRequest request = new(amount);

        _getNotesCombinationUseCase.Setup(x => x.GetNotesCombination(request)).Returns(response);

        _ = _GetNotesCombinationValidation.GetNotesCombination(request);

        _getNotesCombinationUseCase.Verify(x => x.GetNotesCombination(It.IsAny<GetNotesCombinationRequest>()), Times.Once);
    }

    [Test]
    [TestCase(-150)]
    [TestCase(0)]
    [TestCase(-3123123)]
    [TestCase(-1)]
    public void GetNotesCombinationValidation_Invalid_Request_Should_Throws_ArgumentOutOfRangeException(int amount)
    {
        GetNotesCombinationRequest request = new(amount);

        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _GetNotesCombinationValidation.GetNotesCombination(request));

        ex.Message.Should().Be("Must be greater than 0 (Parameter 'Amount')");
    }
}
