using DesafioItau.Domain.Models;

namespace DesafioItau.Infra.Data.MockData;

public static class MockBanknoteData
{
    private static IEnumerable<Banknote> _mockData = null;

    public static IEnumerable<Banknote> Banknotes
    { 
        get
        {
            if(_mockData == null)
            {
                _mockData = new List<Banknote>()
                {
                    new (100.00m, 9999999),
                    new (50.00m, 9999999),
                    new (20.00m, 9999999),
                    new (10.00m, 9999999),
                    new (5.00m, 9999999),
                    new (2.00m, 9999999),
                    new (1.00m, 9999999)
                };
            }

            return _mockData;
        } 
    }
}