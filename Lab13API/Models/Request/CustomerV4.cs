namespace Lab13API.Models.Request
{
    public class CustomerV4
    {
        public int CustomerId { get; set; }

        public List<Invoice> Invoices { get; set; }
    }
}
