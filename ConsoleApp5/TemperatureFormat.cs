namespace ConsoleApp5;

public class Temperature : IFormattable
{
    private decimal temp;

    public Temperature(decimal temperature)
    {
        if (temperature < -273.15m)
            throw new ArgumentOutOfRangeException(String.Format("{0} is less than absolute zero.",
                                                  temperature));
        this.temp = temperature;
    }

    public decimal Celsius
    {
        get { return temp; }
    }

    public decimal Fahrenheit
    {
        get { return temp * 9 / 5 + 32; }
    }

    public decimal Kelvin
    {
        get { return temp + 273.15m; }
    }

    public override string ToString()
    {
        return this.ToString("G", CultureInfo.CurrentCulture);
    }

    public string ToString(string format)
    {
        return this.ToString(format, CultureInfo.CurrentCulture);
    }

    public string ToString(string format, IFormatProvider provider)
    {
        if (String.IsNullOrEmpty(format)) format = "G";
        if (provider == null) provider = CultureInfo.CurrentCulture;

        switch (format.ToUpperInvariant())
        {
            case "G":
            case "C":
                return temp.ToString("F2", provider) + " Celsius";
            case "F":
                return Fahrenheit.ToString("F2", provider) + " Fahrenheit";
            case "K":
                return Kelvin.ToString("F2", provider) + " Kelvin";
            default:
                throw new FormatException(String.Format("The {0} format string is not supported.", format));
        }
    }
}
