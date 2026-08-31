namespace SoliDevs.OOProgramming.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents a monetary value object with an amount and currency.
/// </summary>
public readonly record struct Money

{
    /// <summary>
    /// The underlying amount.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public decimal Amount
    {
        get;
        init
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            field = value;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <exception cref="ArgumentException"></exception>

    public Currency Currency
    {
        get;
        init
        {
            if (value == default)
                throw new ArgumentException("Currency is required.", nameof(value));
            field = value;
        }
    }
    /// <summary>
    /// Prevents parameterless construction of <see cref="Money"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thr</exception>

    public Money() =>
        throw new InvalidOperationException("Money must be initialized with a valid amount and currency.");
    /// <summary>
    /// Initializes a new isntance of the <see cref="Money"/> value object.
    /// </summary>
    /// <param name="amount">The monetary amount</param>
    /// <param name="currency">The currency</param>

    public Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }
    
    /// <summary>
    /// initializes a new instance of the <see cref="Money"/> value object.
    /// </summary>
    /// <param name="amount">The monetary amount</param>
    /// <param name="currencyCode">The ISO 4217 alphabetical code of the currency</param>

    public Money(decimal amount, string currencyCode) : this(amount, new Currency(currencyCode))
    {
    }

    public override string ToString() => $"{Amount} {Currency}";

    public Money Add(Money other)
    {
        if (Currency == default || other.Currency == default)
            throw new InvalidOperationException("Cannot add Money with uninitialized currency.");
        
        if(Currency != other.Currency)
            throw new InvalidOperationException($"Cannot add Money with different currencies: {Currency} and {other.Currency}.");
        return new Money(Amount + other.Amount, Currency);
    }
    /// <summary>
    /// Adds two <see cref="Money"/> objects together.
    /// </summary>
    /// <param name="factor">The factor by which to multiply the money</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the currencies of the two <see cref="Money"/> objects are different</exception>
    public Money Multiply(decimal factor)
    {
        if(Currency == default)
            throw new InvalidOperationException("Cannot multiply Money with uninitialized currency.");
        ArgumentOutOfRangeException.ThrowIfNegative(factor);
        
        return new Money(Amount * factor, Currency);
    }
    
    public Money Multiply (int factor) => Multiply((decimal)factor);
    
    public static Money operator +(Money left, Money right) => left.Add(right);
    
    public static Money operator *(Money money, decimal factor) => money.Multiply(factor);
    
    public static Money operator *(decimal factor, Money money) => money.Multiply(factor);
    
    public static Money operator *(Money money, int factor) => money.Multiply(factor);
    
    public static Money operator *(int factor, Money money) => money.Multiply(factor);


}