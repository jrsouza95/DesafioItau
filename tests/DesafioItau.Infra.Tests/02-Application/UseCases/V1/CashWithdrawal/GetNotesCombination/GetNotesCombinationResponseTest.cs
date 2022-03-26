using DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;
using NUnit.Framework;
using System.Collections.Generic;

namespace DesafioItau.Infra.Tests._02_Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class GetNotesCombinationResponseTest
{
    [Test]
    public void GetNotesCombinationRequest_Constructor_Should_Assign_Correctly_Values()
    {
        List<BankNoteResponse> bankNotes = new()
        {
            new(20, 5),
            new(10, 4),
            new(20, 3),
            new(100, 20)
        };

        GetNotesCombinationResponse request = new(bankNotes);

        Assert.AreEqual(bankNotes, request.BankNotes);
    }
}
