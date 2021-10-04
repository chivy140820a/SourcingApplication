namespace WebApplication6.Entity
{
    public class ManagerProduct
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int  Status { get; set; }
        public int Quantity { get; set; }
        public int ProductStatusId { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }
}
