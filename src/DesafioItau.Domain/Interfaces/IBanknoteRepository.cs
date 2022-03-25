using DesafioItau.Domain.Models;

namespace DesafioItau.Domain.Interfaces;

/// <summary>
/// Access the Banknotes data repository
/// </summary>
public interface IBanknoteRepository
{
    /// <summary>
    /// Gets a collection of Banknotes filtered by the value passed
    /// </summary>
    /// <param name="value">Banknote value</param>
    /// <returns>Collection of Banknotes filtered by value</returns>
    IEnumerable<Banknote> Get(decimal value);

    /// <summary>
    /// Gets a collection of all Banknotes data
    /// </summary>
    /// <returns>Collection of all Banknotes</returns>
    IEnumerable<Banknote> Get();
}