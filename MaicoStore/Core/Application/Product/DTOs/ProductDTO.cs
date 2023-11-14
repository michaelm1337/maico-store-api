namespace Application.Product.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

    }
}
