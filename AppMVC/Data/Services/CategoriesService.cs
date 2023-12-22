using AppMVC.Data.Base;
using AppMVC.Models;

namespace AppMVC.Data.Services
{
    public class CategoriesService : EntityBaseRepository<Category>, ICategoriesService
    {
        public CategoriesService(AppDbContext context) : base(context)
        {
        }
    }
}
