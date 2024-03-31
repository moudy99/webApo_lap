using Lap.Models;

namespace Lap.Repository
{
    public class ProductRepository : IproductRepository
    {
        private readonly Context context;

        public ProductRepository(Context context)
        {
            this.context = context;
        }

        public void Add(Product product)
        {
            context.Add(product);
        }

        public void deleteProduct(int id)
        {
            Product product = getByID(id);
            context.Products.Remove(product);
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product getByID(int id)
        {
            return context.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void updateProduct(int id, Product productmodel)
        {
            Product product = getByID(id);
            product.Name = productmodel.Name;
            product.Description = productmodel.Description;
            product.price = productmodel.price;
            context.Update(product);

        }
    }
}
