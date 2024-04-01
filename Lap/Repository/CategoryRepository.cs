using Lap.Models;
using Microsoft.EntityFrameworkCore;

namespace Lap.Repository
{
    public class CategoryRepository : IcategoryRepository
    {
        private readonly Context context;

        public CategoryRepository(Context context)
        {
            this.context = context;
        }

        public List<Category> getAllWithProduct()
        {
            return context.Categories.Include(c => c.Products).ToList();
        }

        public Category getById(int id)
        {
            return context.Categories.Include(c => c.Products).FirstOrDefault(c => c.Id == id);
        }
    }
}
