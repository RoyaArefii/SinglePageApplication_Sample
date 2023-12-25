namespace SinglePageApplication.ApplicationService.Dtos.ProductDtos
{
    public class SelectProductAppDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
    }
}
