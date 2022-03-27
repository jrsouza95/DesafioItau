using DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;
using DesafioItau.Presentation.API.UseCases.V1.CashWithdrawal.GetNotesCombination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using FluentAssertions;

namespace DesafioItau.Infra.Tests._01_API.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class CashWithdrawalControllerTest
{

    Mock<IGetNotesCombinationUseCase> _mockUseCase;
    CashWithdrawalController _controller;

    [SetUp]
    public void Setup()
    {
        _mockUseCase = new Mock<IGetNotesCombinationUseCase>();
        _controller = new CashWithdrawalController(_mockUseCase.Object);
    }

    [Test]
    public void Get_ShouldReturn_Ok()
    {
        List<BankNoteResponse> bankNotes = new()
        {
            new BankNoteResponse(It.IsAny<int>(), It.IsAny<int>()),
            new BankNoteResponse(It.IsAny<int>(), It.IsAny<int>()),
            new BankNoteResponse(It.IsAny<int>(), It.IsAny<int>())
        };

        GetNotesCombinationResponse seed = new(bankNotes);

        _mockUseCase.Setup(_ => _.GetNotesCombination(It.IsAny<GetNotesCombinationRequest>())).Returns(seed);

        int request = 35400;
        var result = _controller.Get(request);


        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
        ((OkObjectResult)result).StatusCode.Should().Be(StatusCodes.Status200OK);
        ((OkObjectResult)result).Value.Should().Be(seed);
    }

    [Test]
    public void Get_ShouldReturn_NotFound()
    {
        GetNotesCombinationResponse seed = new(new List<BankNoteResponse>());

        _mockUseCase.Setup(_ => _.GetNotesCombination(It.IsAny<GetNotesCombinationRequest>())).Returns(seed);

        int request = 253123;
        var result = _controller.Get(request);

        result.Should().NotBeNull();
        result.Should().BeOfType<NotFoundResult>();
        ((NotFoundResult)result).StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
}