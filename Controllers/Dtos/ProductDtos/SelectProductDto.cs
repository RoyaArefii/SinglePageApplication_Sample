namespace SinglePageApplication.Controllers.Dtos.ProductDtos
{
    public class SelectProductDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public double Price { get { return (UnitPrice * Quantity); } }
    }
}
