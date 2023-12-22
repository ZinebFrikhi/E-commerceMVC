using AppMVC.Data.Base;
using AppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVC.Data.Services
{
    public interface ICategoriesService : IEntityBaseRepository<Category>
    {
    }

}
