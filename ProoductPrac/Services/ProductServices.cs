using ProoductPrac.Model;
using System.Security.Cryptography.X509Certificates;
namespace ProoductPrac.Services
{
    public class ProductServices
    {
        private static List<Product> _products = new List<Product>
        {
            new Product {Id=1,Name="laptop",Price=50000},
            new Product {Id=2,Name="mobile",Price=10000},
        };

        public List<Product> GetAll() => _products;

        public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }

        public bool Update(int Id, Product product)
        {
            var existing = GetById(Id);
            if (existing == null) return false;
            existing.Name = product.Name;
            existing.Price = product.Price;
            return true;

        }

        public bool Delete(int Id)
        {
            var product = GetById(Id);
            if (product == null) return false;
            _products.Remove(product);
            return true;


        }
    }
}
