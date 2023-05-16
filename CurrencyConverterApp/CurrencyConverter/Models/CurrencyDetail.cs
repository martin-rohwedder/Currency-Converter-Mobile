namespace CurrencyConverter.Models
{
    public class CurrencyDetail
    {
        public string Country { get; set; }
        public string Currency { get; set; }
        public string IsoA3Code { get; set; }
        public string IsoA2Code { get; set; }
        public float Value { get; set; }
        public string Comment { get; set; }

        public string DisplayName { get; set; }

        public void CreateDisplayName()
        {
            DisplayName = $"{Currency} ({IsoA3Code})";
        }
    }

}
