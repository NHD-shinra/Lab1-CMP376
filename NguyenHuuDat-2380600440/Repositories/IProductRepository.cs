using NguyenHuuDat_2380600440.Models;
using System.Collections.Generic;
namespace NguyenHuuDat_2380600440.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
