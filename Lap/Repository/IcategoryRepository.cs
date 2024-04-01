using Lap.Models;

namespace Lap.Repository
{
    public interface IcategoryRepository
    {
        List<Category> getAllWithProduct();


        Category getById(int id);
    }
}
