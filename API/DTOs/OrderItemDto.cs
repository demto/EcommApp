namespace API.DTOs
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ProdictName { get; set; }
        public string PictureUrl { get; set; }

    }
}