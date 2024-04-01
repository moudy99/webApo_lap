using Lap.Models;

namespace Lap.Repository
{
    public interface IproductRepository
    {
        Product getByID(int id);

        List<Product> GetAll();

        void updateProduct(int id, Product product);

        Product getByIdAndName(int id, string name);

        void Add(Product product);

        void deleteProduct(int id);



        void Save();
    }
}
