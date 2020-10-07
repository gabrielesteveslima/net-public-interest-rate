namespace Soft.InterestRate.API.Domain
{
    using System;
    using System.Globalization;

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
            };
        }

        public static string FormatToBrlCurrency(this decimal value)
        {
            NumberFormatInfo nfi = new CultureInfo("pt-BR", false).NumberFormat;
            return value.ToString("C", nfi);
        }

        public static string FormatToUsdCurrency(this decimal value)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            return value.ToString("C", nfi);
        }
    }
}