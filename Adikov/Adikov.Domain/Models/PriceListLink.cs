namespace Adikov.Domain.Models
{
    public class PriceListLink : BaseEntity
    {
        public string Text { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public int OrderNumber { get; set; }
    }
}