using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Category> GetAllCategories()
        {
            return FindAll()
                .OrderBy(cat => cat.name)
                .ToList();
        }

        public Category GetCategoryById(int id)
        {
            return FindByCondition(cat => cat.id.Equals(id))
                    .FirstOrDefault();
        }

        public void CreateCategory(Category cat)
        {
            Create(cat);
        }

        public void UpdateCategory(Category cat)
        {
            Update(cat);
        }

        public void DeleteCategory(Category cat)
        {
            Delete(cat);
        }
    }
}
