using DesafioItau.Domain.Exceptions;
using DesafioItau.Domain.Interfaces;
using DesafioItau.Domain.Models;
using DesafioItau.Infra.Data.MockData;

namespace DesafioItau.Infra.Data.Repositories;

public class BanknoteRepository : IBanknoteRepository
{
    private readonly string _exceptionMessage = "Ops! It was not possible to complete this operation for now";

    public BanknoteRepository() { }

    public IEnumerable<Banknote> Get(decimal value)
    {
        try
        {
            return MockBanknoteData.Banknotes.Where(x => x.Value == value);
        }
        catch (Exception ex)
        {
            throw new InternalServerException(_exceptionMessage, ex);
        }
    }

    public IEnumerable<Banknote> Get()
    {
        try
        {
            return MockBanknoteData.Banknotes;
        }
        catch (Exception ex)
        {
            throw new InternalServerException(_exceptionMessage, ex);
        }
    }
}