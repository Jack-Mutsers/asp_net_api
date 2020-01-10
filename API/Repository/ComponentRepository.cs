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

        public Component GetComponentsWithCategory(int cat)
        {
            return FindByCondition(comp => comp.Categoryid.Equals(cat))
                .FirstOrDefault();
        }

        public void CreateComponent(Component comp)
        {
            Create(comp);
        }

        public void UpdateComponent(Component comp)
        {
            Update(comp);
        }

        public void DeleteComponent(Component comp)
        {
            Delete(comp);
        }

        public IEnumerable<Component> componentsByCategory(int catId)
        {
            return FindByCondition(a => a.Categoryid.Equals(catId)).ToList();
        }
    }
}
