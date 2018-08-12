using DevReadyAcademy.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevReadyAcademy.Models.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        //public IEnumerable<Category> GetActiveCategories()
        //{
        //    return AppContext.Categories.Where(c => c.Name == "").ToList();
        //}

        public ApplicationDbContext AppContext
        {
            get { return base.Context as ApplicationDbContext; }
        }
    }
}