namespace Core.Entities.OrderAggregate
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered()
        {
        }

        public ProductItemOrdered(int productItemID, string productName, string pictureUrl)
        {
            ProductItemID = productItemID;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }

        public int ProductItemID { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
    }
}