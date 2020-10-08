namespace Soft.InterestRate.API.Domain
{
    using System;
    using System.Globalization;
    using Infrastructure.Processing;

    public static class CurrencyExtensions
    {
        public static decimal TruncateInTwoPlaces(this decimal value)
        {
            return Math.Truncate(value * 100) / 100;
        }

        public static string FormatToCurrency(this decimal value, CurrencyDisplay currencyDisplay)
        {
            return currencyDisplay switch
            {
                CurrencyDisplay.EnUs => FormatToUsdCurrency(value),
                CurrencyDisplay.PtBr => FormatToBrlCurrency(value),
                _ => throw new InvalidCommandException("currency display no t found")
            };
        }

        private static string FormatToBrlCurrency(this decimal value)
        {
            NumberFormatInfo nfi = new CultureInfo("pt-BR", false).NumberFormat;
            return value.ToString("C", nfi);
        }

        private static string FormatToUsdCurrency(this decimal value)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            return value.ToString("C", nfi);
        }
    }
}