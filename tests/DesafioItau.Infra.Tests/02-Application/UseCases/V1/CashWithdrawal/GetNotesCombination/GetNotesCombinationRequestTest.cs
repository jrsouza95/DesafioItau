using DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;
using NUnit.Framework;
using FluentAssertions;

namespace DesafioItau.Infra.Tests._02_Application.UseCases.V1.CashWithdrawal.GetNotesCombination;

public class GetNotesCombinationRequestTest
{
    [Test]
    public void GetNotesCombinationRequest_Constructor_Should_Assign_Correctly_Values()
    {
        int amount = 12375;
        GetNotesCombinationRequest request = new(amount);

        request.Amount.Should().Be(amount);
    }
}