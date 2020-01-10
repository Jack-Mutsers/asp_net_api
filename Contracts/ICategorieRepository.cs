using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ICategorieRepository
    {
        IEnumerable<Categorie> GetAllCategories();
        Categorie GetCategorieById(int id);
        void CreateCategorie(Categorie cat);
    }
}
