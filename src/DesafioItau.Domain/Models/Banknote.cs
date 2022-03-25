namespace DesafioItau.Domain.Models;

public class Banknote
{
    public Banknote(decimal value,
                    int amount)
    {
        Id = Guid.NewGuid();
        Value = value;
        Amount = amount;
    }

    public Guid Id { get; private set; }
    public decimal Value { get; private set; }
    public int Amount { get; private set; }
}
