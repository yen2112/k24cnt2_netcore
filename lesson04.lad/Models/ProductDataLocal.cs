using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson04.lad.Models
{
    public class ProductDataLocal
    {
        public static List<Category> _categories = new List<Category>()
        {
            new Category() { Id = 1, Name = "Laptop & Máy tính" },
            new Category() { Id = 2, Name = "Điện thoại & Máy tính bảng" },
            new Category() { Id = 3, Name = "Phụ kiện công nghệ" }
        };

        public static List<Product> _products = new List<Product>()
        {
            new Product() { Id = 1, Name = "Laptop Dell XPS 13", Price = 35000000, SalePrice = 32000000, Status = true, CreatedDate = Convert.ToDateTime("2024/01/15"), Image = "images/products/product1.jpg", CategoryId = 1, Description = "Laptop cao cấp mỏng nhẹ, hiệu năng mạnh mẽ" },
            new Product() { Id = 2, Name = "iPhone 15 Pro Max", Price = 30000000, SalePrice = 28900000, Status = true, CreatedDate = Convert.ToDateTime("2024/02/10"), Image = "images/products/product2.jpg", CategoryId = 2, Description = "Điện thoại Flagship hàng đầu với khung titan" },
            new Product() { Id = 3, Name = "iPad Pro M2 11 inch", Price = 22000000, SalePrice = 20500000, Status = true, CreatedDate = Convert.ToDateTime("2024/03/01"), Image = "images/products/product3.jpg", CategoryId = 2, Description = "Máy tính bảng hiệu năng chip M2 vượt trội" }
        };

        public static List<Category> GetCategories()
        {
            return _categories;
        }

        public static List<Product> GetProducts()
        {
            return _products;
        }

        public static Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public static void AddProduct(Product product)
        {
            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
        }

        public static void UpdateProduct(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index != -1)
            {
                _products[index] = product;
            }
        }

        public static void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
