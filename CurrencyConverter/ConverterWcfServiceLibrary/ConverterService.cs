namespace ConverterWcfServiceLibrary
{
    public class ConverterService : IConverterService
    {
        public string GetData(string currencyAmount)
        {
            CurrencyConvert converter = new CurrencyConvert(currencyAmount);

            return converter.Convert();
        }
    }
}
