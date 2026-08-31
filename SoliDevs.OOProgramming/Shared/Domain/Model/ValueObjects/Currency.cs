namespace SoliDevs.OOProgramming.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents a currency value object.
/// </summary>
public readonly record struct Currency
{
    /// <summary>
    /// ISO 4217 alphabetic code.
    /// </summary>
    /// <exception cref="ArgumentException">Throw when the code is not a 3-letter ISO 4217 alphabetic code.</exception>
    public string Code
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length != 3 || !value.All(char.IsAsciiLetter))
            
                throw new ArgumentException("Currency must be a 3-letter ISO 4217 alphabetic code.", nameof(value)); 
            field = value;
            
        }
        
    }
    
    /// <summary>
    /// Prevents parameterless construction of <see cref="Currency"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the currency is initialized with a parameterless constructor.</exception>
    public Currency() => throw new InvalidOperationException("Currency must be initialized with a valid ISO 4217 alphabetic code.");
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Currency"/> value object.
    /// </summary>
    /// <param name="code"></param>
    public Currency(string code) => Code = code;
    
    /// <summary>
    /// Returns a string representation of the currency value object.
    /// </summary>
    /// <returns> a string representation of the currency code.</returns>
    public override string ToString() => Code;
   
}