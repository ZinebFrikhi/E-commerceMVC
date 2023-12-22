using AppMVC.Data.Base;
using AppMVC.Models;

namespace AppMVC.Data.Services
{
    public class SuppliersService : EntityBaseRepository<Supplier>, ISuppliersService
    {
        public SuppliersService(AppDbContext context) : base(context)
        {
        }
    }
}
