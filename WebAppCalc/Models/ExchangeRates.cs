namespace WebAppCalc.Models
{
    public class ExchangeRates
    {
        public int Id { get; set; }
        public int DigitalCode { get; set; }
        public string LetterCode { get; set; }
        public int NumberOfUnits { get; set; }
        public string CurrencyName { get; set; }
        public double OfficialExchangeRates { get; set; }

        public ExchangeRates()
        {
            DigitalCode = 0;
            LetterCode = "";
            NumberOfUnits = 0;
            CurrencyName = "";
            OfficialExchangeRates = 0;
        }        
    }
}