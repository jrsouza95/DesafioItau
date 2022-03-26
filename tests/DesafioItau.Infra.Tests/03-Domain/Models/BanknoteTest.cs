using DesafioItau.Domain.Models;
using NUnit.Framework;
using System;

namespace DesafioItau.Infra.Tests._03_Domain.Models
{
    public class BanknoteTest
    {
        [Test]
        public void Banknote_Constructor_Should_Assign_Correctly_Values()
        {
            int value = 75;

            Banknote banknote = new(value);

            Assert.True(Guid.Empty != banknote.Id);
            Assert.AreEqual(value, banknote.Value);
        }
    }
}
