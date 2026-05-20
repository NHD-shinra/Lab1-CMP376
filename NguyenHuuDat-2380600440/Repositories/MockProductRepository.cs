using NguyenHuuDat_2380600440.Models;
using System.Collections.Generic;
using System.Linq;

namespace NguyenHuuDat_2380600440.Repositories
{
    public class MockProductRepository : IProductRepository
    {
        private static List<Product> _products = new List<Product>
        {
            new Product 
            { 
                Id = 1, 
                Name = "MacBook Pro 16\" M3 Max", 
                Price = 79990000, 
                Description = "Apple M3 Max chip, 36GB Unified Memory, 1TB SSD, 16.2-inch Liquid Retina XDR Display. Trải nghiệm hiệu năng đỉnh cao.", 
                ImageUrl = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?w=600&auto=format&fit=crop&q=80", 
                CategoryId = 1 
            },
            new Product 
            { 
                Id = 2, 
                Name = "iPhone 15 Pro Max 512GB", 
                Price = 34990000, 
                Description = "Khung viền Titanium siêu bền nhẹ, Chip A17 Pro mạnh mẽ, Hệ thống camera zoom quang học 5x đẳng cấp chuyên nghiệp.", 
                ImageUrl = "https://images.unsplash.com/photo-1695048133142-1a20484d2569?w=600&auto=format&fit=crop&q=80", 
                CategoryId = 2 
            },
            new Product 
            { 
                Id = 3, 
                Name = "Bàn phím GravaStar Mercury V75 Pro Special Edition – Neon Graffiti", 
                Price = 4890000, 
                Description = "Bàn phím cơ Custom không dây hoàn toàn bằng nhôm, mạch xuôi, hỗ trợ QMK/VIA và núm xoay đa năng tiện lợi.", 
                ImageUrl = "https://owlgaming.vn/wp-content/uploads/2025/07/Ban-phim-GravaStar-Mercury-V75-Pro-Special-Edition-%E2%80%93-Neon-Graffiti.jpg", 
                CategoryId = 3 
            },
            new Product 
            { 
                Id = 4, 
                Name = "Apple Watch Ultra 2 GPS + Cellular", 
                Price = 21990000, 
                Description = "Vỏ Titanium 49mm siêu cứng cáp, màn hình sáng nhất lịch sử Apple, GPS tần số kép độ chính xác cực cao.", 
                ImageUrl = "https://images.unsplash.com/photo-1508685096489-7aacd43bd3b1?w=600&auto=format&fit=crop&q=80", 
                CategoryId = 2 
            },
            new Product 
            { 
                Id = 5, 
                Name = "Tai Nghe Chống Ồn Sony WH-1000XM5", 
                Price = 8490000, 
                Description = "Công nghệ chống ồn đỉnh cao, chất âm trung thực chi tiết, thời lượng pin ấn tượng lên tới 30 giờ sử dụng liên tục.", 
                ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=600&auto=format&fit=crop&q=80", 
                CategoryId = 3 
            },
            new Product 
            { 
                Id = 6, 
                Name = "Chuột Gaming Logitech G Pro X Superlight 2", 
                Price = 3890000, 
                Description = "Thiết kế siêu nhẹ chỉ 60g, cảm biến HERO 2 độ chính xác siêu việt, kết nối không dây LIGHTSPEED siêu tốc.", 
                ImageUrl = "https://images.unsplash.com/photo-1615663245857-ac93bb7c39e7?w=600&auto=format&fit=crop&q=80", 
                CategoryId = 3 
            }
        };

        public IEnumerable<Product> GetAll() => _products;

        public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = GetById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.CategoryId = product.CategoryId;
                if (!string.IsNullOrEmpty(product.ImageUrl))
                {
                    existingProduct.ImageUrl = product.ImageUrl;
                }
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null) _products.Remove(product);
        }
    }
}
