namespace CryptoQuotesApp.Models
{
    public class CryptoQuoteViewModel
    {
        public string CryptoCode { get; set; } = "";
        public decimal USD { get; set; }
        public decimal EUR { get; set; }
        public decimal BRL { get; set; }
        public decimal GBP { get; set; }
        public decimal AUD { get; set; }
    }
}
