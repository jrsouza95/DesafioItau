using DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;
using DesafioItau.Presentation.API.UseCases.V1.CashWithdrawal.GetNotesCombination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

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
        GetNotesCombinationResponse seed = new GetNotesCombinationResponse()
        {
            Notes = new List<BankNoteResponse>()
            {
                new BankNoteResponse(){ Amount = It.IsAny<int>(), NoteValue = It.IsAny<int>()},
                new BankNoteResponse(){ Amount = It.IsAny<int>(), NoteValue = It.IsAny<int>()},
                new BankNoteResponse(){ Amount = It.IsAny<int>(), NoteValue = It.IsAny<int>()}
            }
        };

        _mockUseCase.Setup(_ => _.GetNotesCombination(It.IsAny<GetNotesCombinationRequest>())).Returns(seed);

        int request = 35400;
        var result = _controller.Get(request);

        Assert.IsNotNull(result);
        Assert.IsInstanceOf<OkObjectResult>(result);
        Assert.AreEqual(StatusCodes.Status200OK, ((OkObjectResult)result).StatusCode);
        Assert.AreEqual(seed, ((OkObjectResult)result).Value);
    }

    [Test]
    public void Get_ShouldReturn_NotFound()
    {
        GetNotesCombinationResponse seed = null;

        _mockUseCase.Setup(_ => _.GetNotesCombination(It.IsAny<GetNotesCombinationRequest>())).Returns(seed);

        int request = 253123;
        var result = _controller.Get(request);

        Assert.IsNotNull(result);
        Assert.IsInstanceOf<NotFoundResult>(result);
        Assert.AreEqual(StatusCodes.Status404NotFound, ((NotFoundResult)result).StatusCode);
    }
}
