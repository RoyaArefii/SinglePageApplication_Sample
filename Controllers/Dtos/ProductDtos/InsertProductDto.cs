namespace SinglePageApplication.Controllers.Dtos.ProductDtos
{
    public class InsertProductDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
    }
}
