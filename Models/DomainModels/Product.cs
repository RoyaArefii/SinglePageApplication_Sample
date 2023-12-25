namespace SinglePageApplication.Models.DomainModels
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }

    }
}
