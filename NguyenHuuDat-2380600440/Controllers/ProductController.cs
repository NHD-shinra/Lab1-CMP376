using Microsoft.AspNetCore.Mvc;
using NguyenHuuDat_2380600440.Models;
using NguyenHuuDat_2380600440.Repositories;

namespace NguyenHuuDat_2380600440.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _webHostEnvironment; // Khai báo môi trường web

        // Inject cả Repository và WebHostEnvironment vào Constructor
        public ProductController(IProductRepository productRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(_productRepository.GetAll());
        }

        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(Product product, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                // Xử lý Upload File hình ảnh nếu có
                if (imageFile != null && imageFile.Length > 0)
                {
                    product.ImageUrl = await SaveImage(imageFile);
                }

                _productRepository.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Update(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Product product, IFormFile imageFile)
        {
            if (id != product.Id) return NotFound();

            if (ModelState.IsValid)
            {
                // Nếu người dùng chọn ảnh mới thì ghi đè, nếu không thì giữ nguyên ảnh cũ
                if (imageFile != null && imageFile.Length > 0)
                {
                    product.ImageUrl = await SaveImage(imageFile);
                }

                _productRepository.Update(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // Hàm helper phục vụ việc lưu trữ file hình ảnh riêng biệt
        private async Task<string> SaveImage(IFormFile imageFile)
        {
            // Trỏ đến thư mục wwwroot/images
            string savePath = Path.Combine(_webHostEnvironment.WebRootPath, "images");

            // Tạo tên file duy nhất bằng chuỗi GUID để tránh trùng lặp tệp trùng tên
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            string filePath = Path.Combine(savePath, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            // Trả về đường dẫn tương đối để lưu vào Database/MockData
            return "/images/" + uniqueFileName;
        }
    }
}