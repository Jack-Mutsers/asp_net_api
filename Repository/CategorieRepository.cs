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
    public class CategorieRepository : RepositoryBase<Categorie>, ICategorieRepository
    {
        public CategorieRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Categorie> GetAllCategories()
        {
            return FindAll()
                .OrderBy(cat => cat.cat_name)
                .ToList();
        }

        public Categorie GetCategorieById(int id)
        {
            return FindByCondition(cat => cat.cat_id.Equals(id))
                    .FirstOrDefault();
        }

        public void CreateCategorie(Categorie cat)
        {
            Create(cat);
        }
    }
}
