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
    public class ComponentRepository : RepositoryBase<Component>, IComponentRepository
    {
        public ComponentRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Component> GetAllComponents()
        {
            return FindAll()
                .OrderBy(comp => comp.name)
                .ToList();
        }
        public Component GetComponentById(int id)
        {
            return FindByCondition(comp => comp.id.Equals(id))
                    .FirstOrDefault();
        }

        public Component GetComponentsWithCategorie(int cat)
        {
            return FindByCondition(comp => comp.cat_id.Equals(cat))
                .FirstOrDefault();
        }

        public void CreateComponent(Component comp)
        {
            Create(comp);
        }


    }
}
