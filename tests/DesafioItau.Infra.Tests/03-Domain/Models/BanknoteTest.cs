using DesafioItau.Domain.Models;
using NUnit.Framework;
using System;
using FluentAssertions;

namespace DesafioItau.Infra.Tests._03_Domain.Models
{
    public class BanknoteTest
    {
        [Test]
        public void Banknote_Constructor_Should_Assign_Correctly_Values()
        {
            int value = 75;

            Banknote banknote = new(value);
            
            banknote.Id.Should().NotBeEmpty();
            banknote.Value.Should().Be(value);
        }
    }
}
