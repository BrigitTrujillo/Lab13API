namespace Lab13API.Models.Request
{
    public class InvoiceV1
    {
        public int InvoiceID { get; set; }

        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal Total { get; set; }
    }
}
