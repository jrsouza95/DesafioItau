using DesafioItau.Domain.Interfaces;
using DesafioItau.Domain.Models;
using DesafioItau.Infra.Data.MockData;

namespace DesafioItau.Infra.Data.Repositories;

public class BanknoteRepository : IBanknoteRepository
{
    public BanknoteRepository() { }

    public IEnumerable<Banknote> Get(decimal value)
        => MockBanknoteData.Banknotes.Where(x => x.Value == value);
}