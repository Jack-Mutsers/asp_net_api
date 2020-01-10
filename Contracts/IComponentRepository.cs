using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IComponentRepository
    {
        IEnumerable<Component> GetAllComponents();
        Component GetComponentById(int id);
        Component GetComponentsWithCategorie(int cat);
        void CreateComponent (Component comp);
    }
}
