using System;

// Strategy Interface
public interface IVatStrategy
{
    decimal CalculateVat(decimal amount);
}

// Concrete Strategies
public class Country1VatStrategy : IVatStrategy
{
    public decimal CalculateVat(decimal amount) => amount * 0.10m;
}

public class Country2VatStrategy : IVatStrategy
{
    public decimal CalculateVat(decimal amount) => amount * 0.15m;
}

public class Country3VatStrategy : IVatStrategy
{
    public decimal CalculateVat(decimal amount) => amount * 0.20m;
}

// Context
public class VatCalculator
{
    private IVatStrategy _vatStrategy;

    public VatCalculator(IVatStrategy vatStrategy)
    {
        _vatStrategy = vatStrategy;
    }

    public void SetStrategy(IVatStrategy vatStrategy)
    {
        _vatStrategy = vatStrategy;
    }

    public decimal Calculate(decimal amount)
    {
        return _vatStrategy.CalculateVat(amount);
    }
}

class Program
{
    static void Main()
    {
        decimal amount = 1000;

        VatCalculator calculator = new VatCalculator(new Country1VatStrategy());
        Console.WriteLine($"Country 1 VAT: {calculator.Calculate(amount)}");

        calculator.SetStrategy(new Country2VatStrategy());
        Console.WriteLine($"Country 2 VAT: {calculator.Calculate(amount)}");

        calculator.SetStrategy(new Country3VatStrategy());
        Console.WriteLine($"Country 3 VAT: {calculator.Calculate(amount)}");
    }
}
