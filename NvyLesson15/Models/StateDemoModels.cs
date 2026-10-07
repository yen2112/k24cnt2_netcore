namespace NvyLesson15.Models
{
    public class UserLogin
    {
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "Member";
        public DateTime LoginTime { get; set; } = DateTime.Now;
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }

    public class CartItem
    {
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
        public decimal TotalPrice => Product.Price * Quantity;
    }
}
