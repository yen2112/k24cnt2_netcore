using Microsoft.EntityFrameworkCore;

namespace Nvylesson14.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            // Đảm bảo Database đã được tạo
            context.Database.EnsureCreated();

            if (!context.Categories.Any())
            {
                var cat1 = new Category
                {
                    Name = "Điện thoại & Tablet",
                    Status = 1,
                    CreatedDate = DateTime.Now.AddDays(-30),
                    Image = "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?w=300",
                    Description = "Các dòng điện thoại thông minh, máy tính bảng chính hãng cao cấp"
                };
                var cat2 = new Category
                {
                    Name = "Laptop & Máy tính",
                    Status = 1,
                    CreatedDate = DateTime.Now.AddDays(-25),
                    Image = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=300",
                    Description = "Laptop gaming, văn phòng, đồ họa cấu hình mạnh mẽ"
                };
                var cat3 = new Category
                {
                    Name = "Phụ kiện công nghệ",
                    Status = 1,
                    CreatedDate = DateTime.Now.AddDays(-20),
                    Image = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=300",
                    Description = "Tai nghe không dây, chuột, bàn phím cơ, sạc dự phòng"
                };
                var cat4 = new Category
                {
                    Name = "Đồng hồ thông minh",
                    Status = 1,
                    CreatedDate = DateTime.Now.AddDays(-15),
                    Image = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=300",
                    Description = "Smartwatch theo dõi sức khỏe và thể thao tiện lợi"
                };

                context.Categories.AddRange(cat1, cat2, cat3, cat4);
                context.SaveChanges();

                // Seed Products
                context.Products.AddRange(
                    new Product
                    {
                        Name = "iPhone 15 Pro Max 256GB",
                        Price = 29990000,
                        SalePrice = 27990000,
                        Status = 1,
                        CategoryId = cat1.Id,
                        CreatedDate = DateTime.Now.AddDays(-10),
                        Image = "https://images.unsplash.com/photo-1592750475338-74b7b21085ab?w=400",
                        Description = "Khung viền Titan siêu bền nhẹ, Chip Apple A17 Pro đỉnh cao hiệu năng đồ họa."
                    },
                    new Product
                    {
                        Name = "Samsung Galaxy S24 Ultra",
                        Price = 28500000,
                        SalePrice = 26500000,
                        Status = 1,
                        CategoryId = cat1.Id,
                        CreatedDate = DateTime.Now.AddDays(-9),
                        Image = "https://images.unsplash.com/photo-1610945265064-0e34e5519bbf?w=400",
                        Description = "Màn hình Dynamic AMOLED 2X 120Hz, tích hợp bút S-Pen và Galaxy AI thông minh."
                    },
                    new Product
                    {
                        Name = "MacBook Pro 14 M3 Pro",
                        Price = 45000000,
                        SalePrice = 42500000,
                        Status = 1,
                        CategoryId = cat2.Id,
                        CreatedDate = DateTime.Now.AddDays(-8),
                        Image = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?w=400",
                        Description = "Chip Apple M3 Pro 18GB RAM 512GB SSD, màn hình Liquid Retina XDR tuyệt đỉnh."
                    },
                    new Product
                    {
                        Name = "Dell XPS 13 Plus 9320",
                        Price = 38000000,
                        SalePrice = 35900000,
                        Status = 1,
                        CategoryId = cat2.Id,
                        CreatedDate = DateTime.Now.AddDays(-7),
                        Image = "https://images.unsplash.com/photo-1593642632823-8f785ba67e45?w=400",
                        Description = "Thiết kế sang trọng không viền, Intel Core i7 Gen 13th mượt mà mọi tác vụ."
                    },
                    new Product
                    {
                        Name = "Tai nghe Sony WH-1000XM5",
                        Price = 8490000,
                        SalePrice = 7490000,
                        Status = 1,
                        CategoryId = cat3.Id,
                        CreatedDate = DateTime.Now.AddDays(-6),
                        Image = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=400",
                        Description = "Chống ồn đỉnh cao hàng đầu thế giới, âm thanh Hi-Res Audio chi tiết trung thực."
                    },
                    new Product
                    {
                        Name = "Apple Watch Series 9 GPS",
                        Price = 10490000,
                        SalePrice = 9890000,
                        Status = 1,
                        CategoryId = cat4.Id,
                        CreatedDate = DateTime.Now.AddDays(-5),
                        Image = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=400",
                        Description = "Thao tác chạm hai lần Double Tap mới mẻ, màn hình sáng gấp đôi, đo nồng độ oxy."
                    }
                );
                context.SaveChanges();
            }

            if (!context.Banners.Any())
            {
                context.Banners.AddRange(
                    new Banner
                    {
                        Name = "Siêu Sale Công Nghệ 2026",
                        Status = 1,
                        Prioty = 1,
                        Image = "https://images.unsplash.com/photo-1468495244123-6c6c332eeece?w=1200",
                        Description = "Giảm giá lên đến 50% tất cả các mặt hàng điện tử chính hãng trong tháng."
                    },
                    new Banner
                    {
                        Name = "Ra Mắt Dòng Sản Phẩm Mới",
                        Status = 1,
                        Prioty = 2,
                        Image = "https://images.unsplash.com/photo-1550745165-9bc0b252726f?w=1200",
                        Description = "Trải nghiệm sức mạnh công nghệ AI thế hệ mới nhất cùng hệ sinh thái cao cấp."
                    },
                    new Banner
                    {
                        Name = "Ưu Đãi Phụ Kiện Chính Hãng",
                        Status = 1,
                        Prioty = 3,
                        Image = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=1200",
                        Description = "Tặng kèm quà tặng hấp dẫn trị giá 1 triệu đồng khi mua đơn hàng từ 5 triệu."
                    }
                );
                context.SaveChanges();
            }

            if (!context.Blogs.Any())
            {
                context.Blogs.AddRange(
                    new Blog
                    {
                        Name = "Đánh giá chi tiết công nghệ AI trên Smartphone 2026",
                        Status = 1,
                        CreatedDate = DateTime.Now.AddDays(-12),
                        Image = "https://images.unsplash.com/photo-1485827404703-89b55fcc595e?w=500",
                        Description = "Trí tuệ nhân tạo đang thay đổi cách chúng ta chụp ảnh, dịch thuật và làm việc hàng ngày như thế nào."
                    },
                    new Blog
                    {
                        Name = "Top 5 Laptop mỏng nhẹ pin trâu cho sinh viên & dân văn phòng",
                        Status = 1,
                        CreatedDate = DateTime.Now.AddDays(-8),
                        Image = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=500",
                        Description = "Tổng hợp danh sách những chiếc laptop đáp ứng hoàn hảo tiêu chí: mỏng nhẹ, pin trên 10 tiếng và hiệu năng cao."
                    },
                    new Blog
                    {
                        Name = "Hướng dẫn xây dựng layout hiện đại trong ASP.NET Core MVC",
                        Status = 1,
                        CreatedDate = DateTime.Now.AddDays(-3),
                        Image = "https://images.unsplash.com/photo-1517694712202-14dd9538aa97?w=500",
                        Description = "Tìm hiểu cách sử dụng _Layout, _ViewStart, _ViewImports, Area và ViewComponent trong ứng dụng Net Core."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
