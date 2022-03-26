namespace DesafioItau.Domain.Models;

public class Banknote
{
    public Banknote(int value)
    {
        Id = Guid.NewGuid();
        Value = value;
    }

    public Guid Id { get; private set; }
    public int Value { get; private set; }
}