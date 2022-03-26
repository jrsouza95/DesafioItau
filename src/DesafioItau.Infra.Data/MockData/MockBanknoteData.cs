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
                    new (100),
                    new (50),
                    new (20),
                    new (10),
                    new (5),
                    new (2),
                    new (1)
                };
            }

            return _mockData;
        } 
    }
}